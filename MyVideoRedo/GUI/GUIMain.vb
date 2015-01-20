Imports System
Imports System.Windows.Forms
Imports MediaPortal.GUI.Library
Imports MediaPortal.Dialogs
Imports MediaPortal.Player
Imports MediaPortal.Profile
Imports MediaPortal.Configuration
Imports System.Collections
Imports System.Collections.Generic
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging


Namespace MyVideoRedo
    Public Class GUIMain
        Inherits GUIWindow

#Region "SkinControls"
        <SkinControlAttribute(44)> Protected VideoWindow As GUIVideoControl = Nothing
        <SkinControlAttribute(45)> Protected lblAudioResync As GUILabelControl = Nothing
        <SkinControlAttribute(46)> Protected sliderAudioSync As GUISliderControl = Nothing
        <SkinControlAttribute(23)> Protected btnCutNow As GUIButtonControl = Nothing
        <SkinControlAttribute(24)> Protected btnHelp As GUIButtonControl = Nothing
        <SkinControlAttribute(4)> Protected btnCut As GUIButtonControl = Nothing
        <SkinControlAttribute(51)> Protected CutList As GUIListControl = Nothing
        <SkinControlAttribute(71)> Protected CutBarImage As GUIImage = Nothing
        <SkinControlAttribute(13)> Protected AnimWaiting As GUIAnimation = Nothing
        <SkinControlAttribute(25)> Protected HelpBackgroundImage As GUIImage = Nothing
        <SkinControlAttribute(26)> Protected btnExitHelp As GUIButtonControl = Nothing
        <SkinControlAttribute(29)> Protected ctlStillImage As GUIImage = Nothing
#End Region

#Region "Variablen"
        Private TempStartValue As Single
        Private TempEndValue As Single
        Private PlayerPosition As Long
        Private PlayerDuration As Long
        Private PlayerFramerate As Integer
        Private ThumbCount As Integer
        Friend tmrDelayRefreshOnSkip As New Timer
        Friend tmrCheckplayback As New Timer
        Friend tmrAdScan As New Timer
        Friend tmrRefresh As New Timer
        Private IsLoadingHDContent As Boolean = False
        Dim Props As PropertyCollection
        Dim NoImage As System.Drawing.Image
#End Region

#Region "MP EventSubs"

        Public Overloads Overrides Property GetID() As Integer
            Get
                Return enumWindows.GUIMain
            End Get
            Set(ByVal value As Integer)
            End Set
        End Property

        Protected Overridable ReadOnly Property SerializeName() As String
            Get
                Return "MyVideoRedo"
            End Get
        End Property

        Public Overloads Overrides Function Init() As Boolean
            'Beim initialisieren des Plugin den Screen laden

            Return Load(GUIGraphicsContext.Skin + "\MyVideoRedo.xml")
        End Function

        Public Overrides Function GetModuleName() As String
            Return HelpConfig.GetConfigString(ConfigKey.ModuleName) & " - " & Translation.ModuleMain
        End Function

        Protected Overrides Sub OnPageLoad()
            MyBase.OnPageLoad()
            If GUIWindowManager.ActiveWindow = GetID Then
                If VRD.OutputInProgress = True Then
                    GUIWindowManager.ActivateWindow(enumWindows.GUIstart, True)
                    Exit Sub
                End If
                If VRD.AdScanInProgress = True Then
                    LoadCuts()
                End If
                MyLog.DebugM("Set Playerhandler PlayBackStarted, PlayBackChanged, PlayBackEnded and PlayBackStopped")
                tmrDelayRefreshOnSkip.Interval = 1000
                tmrDelayRefreshOnSkip.Enabled = False
                tmrCheckplayback.Interval = 250
                tmrCheckplayback.Enabled = False
                tmrRefresh.Interval = HelpConfig.GetConfigString(ConfigKey.AlwaysRefreshMoviestripThumbsDelay) * 1000
                tmrRefresh.Enabled = False
				NoImage = System.Drawing.Image.FromFile(GUIGraphicsContext.Skin & "\Media\RedoEmptyThumb.png")
                Props = GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml")
                ThumbCount = Props("ThumbnailsCount")
                AddHandler g_Player.PlayBackStarted, AddressOf VideoStarted
                AddHandler g_Player.PlayBackChanged, AddressOf VideoChange
                AddHandler g_Player.PlayBackEnded, AddressOf VideoEnded
                AddHandler g_Player.PlayBackStopped, AddressOf VideoStopped
                AddHandler tmrDelayRefreshOnSkip.Tick, AddressOf RefreshTimerTick
                AddHandler tmrCheckplayback.Tick, AddressOf CheckPlaybackTick
                AddHandler tmrRefresh.Tick, AddressOf RefreshTimerTick
                MyLog.DebugM("Handler set")
                LoadRecordVideoToScreen()
                MyLog.DebugM("Ermittle aktuelle Videoformat...")
                Dim CurrFormat As MediaPortal.Player.VideoStreamFormat = g_Player.GetVideoFormat
                MyLog.DebugM("Aktuelles Videoformat des g_players ist {0} mit einer Auflösung von {1} * {2} und einer Bitrate von {3} .", _
                             CurrFormat.streamType.ToString, CurrFormat.width, CurrFormat.height, CurrFormat.bitrate)
                If CurrFormat.streamType = VideoStreamType.H264 Then
                    If Left(VRD.ReDoVersion, 1) < 4 Then
                        UnloadCutBar()
                        UnloadMoviestripBar()
                        ShowErrorDialog(GetID, Translation.VideoRedoCanNotHD)
                        LoadMoviestripBar(GetCutBarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
                        LoadCutbar(GetCutBarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
                        g_Player.Stop()
                        GUIWindowManager.ActivateWindow(GetGUIWindow(enumWindows.GUIstart), True)
                        Exit Sub
                    Else
                        IsLoadingHDContent = True
                        VRD.AktSavingProfile = HelpConfig.GetConfigString(ConfigKey.TVsuiteProfileH264)
                    End If
                Else
                    VRD.AktSavingProfile = HelpConfig.GetConfigString(ConfigKey.TVsuiteProfile)
                End If
                GetProfileDetail(HelpConfig.GetConfigString(ConfigKey.TVsuiteProfile))
                'Workaround um das Fenster von MP wieder in den Fordergrund zu bringen
                SetMPtoForeground(HelpConfig.GetConfigString(ConfigKey.ModuleName) & " - " & Translation.ModuleMain)
                tmrCheckplayback.Enabled = True
                If (HelpConfig.GetConfigString(ConfigKey.AlwaysRefreshMoviestripThumbs) = True) Then
                    tmrRefresh.Enabled = True
                End If
            End If
        End Sub

        Protected Overrides Sub OnPageDestroy(ByVal new_windowId As Integer)
            If VRD IsNot Nothing Then
                If VRD.OutputInProgress Then Exit Sub
                If GUIWindowManager.ActiveWindow = enumWindows.GUIMain Then ' My Window
                    UnloadCutbar()
                    UnloadMoviestripBar()
                    If VRD.AdScanInProgress Then
                        MyLog.DebugM("Showing YES/NO Dialog for Aborting the AdDetective Scan...")
                        If ShowYesNoDialog(GetID, Translation.ContinueScan, Translation.ContinueScan1) = True Then
                            MyLog.DebugM("Dialog was confirmed. Continuing with AdScanning in background!")
                            'zum Ausgangschirm vor dem Aufruf von MyVideoRedo zürckkehren
                            'ToDo
                        Else
                            MyLog.DebugM("Scan should be aborted.")
                            VRD.AbortScan()
                            Do While VRD.AdScanInProgress
                            Loop
                            MyLog.DebugM("Scan was aborted!")
                        End If
                    End If
                    tmrCheckplayback.Enabled = False
                    tmrRefresh.Enabled = False
                    g_Player.Stop()
                    If new_windowId < GetID Then
                        If VRD.AdScanInProgress = False And VRD.CutMarkerList.Count > 0 Then
                            If HelpConfig.GetConfigString(ConfigKey.AlwaysKeepCuts) = False Then
                                If ShowYesNoDialog(GetID, Translation.ClearCutsAtClose, Translation.ClearCutsAtClose1) = True Then
                                    MyCutbar.StartCutValues.Clear()
                                    MyCutbar.EndCutValues.Clear()
                                    VRD.CutMarkerList.Clear()
                                    VRD.ClearAllSelections()
                                Else
                                    MyLog.DebugM("Cutmarkes should not be deleted and are kept.")
                                End If
                            End If
                        End If
                    End If
                    If VRD IsNot Nothing Then
                        'Do While VRD.VRDobj.IsOutputInProgress
                        '    Threading.Thread.CurrentThread.Sleep(100)
                        'Loop
                        'VRD.Close()
                        'VRD.Dispose()
                    End If
                    RemoveHandler g_Player.PlayBackStarted, AddressOf VideoStarted
                    RemoveHandler g_Player.PlayBackChanged, AddressOf VideoChange
                    RemoveHandler g_Player.PlayBackEnded, AddressOf VideoEnded
                    RemoveHandler g_Player.PlayBackStopped, AddressOf VideoStopped
                    RemoveHandler tmrDelayRefreshOnSkip.Tick, AddressOf RefreshTimerTick
                    RemoveHandler tmrCheckplayback.Tick, AddressOf CheckplaybackTick
                    RemoveHandler tmrRefresh.Tick, AddressOf RefreshTimerTick
                    'GUIWindowManager.Clear()
                End If
            End If
            'GUIWindowManager.Clear()
            'GUIWindow.Clear()
            'GUIWindowManager.CloseCurrentWindow()
            MyBase.OnPageDestroy(new_windowId)
            'GUIWindowManager.ActivateWindow(enumWindows.GUIStart, True)
        End Sub

        Public Overrides Sub OnAction(ByVal action As MediaPortal.GUI.Library.Action)
            Dim AktWinId As Integer = GUIWindowManager.ActiveWindow
            Dim skipOnPlay As Integer
            Dim skipOnPause As Long
            If AktWinId = GetID Then
                Try
                    MyLog.DebugM("Keypress on VideoReDo Screen. KeyChar={0} ; KeyCode={1} ; Actiontype={2}", action.m_key.KeyChar, action.m_key.KeyCode, action.wID.ToString)
                Catch
                    MyLog.DebugM("Action on VideoReDo Screen. Action={0}", action.wID.ToString)
                End Try
                If action.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_KEY_PRESSED Then

                    If action.m_key IsNot Nothing Then
                        'Button 1
                        If action.m_key.KeyChar = 49 Then
                            skipOnPause = -1 * GetConfigString(ConfigKey.SeekStepOnPause1)
                            skipOnPlay = -1 * GetConfigString(ConfigKey.SeekStepOnPlay1)
                            SkipTo(skipOnPause, skipOnPlay)
                        End If
                        'Button 2
                        If action.m_key.KeyChar = 50 Then
                            If VRD.AdScanInProgress Then
                                VRD.AbortScan()
                                VRD.SeekToTime(0)
                                g_Player.SeekAbsolute(0)
                                If IsPlayerPaused = False Then
                                    g_Player.Pause()
                                End If
                            End If
                        End If
                        'Button 3
                        If action.m_key.KeyChar = 51 Then
                            skipOnPause = GetConfigString(ConfigKey.SeekStepOnPause3)
                            skipOnPlay = GetConfigString(ConfigKey.SeekStepOnPlay3)
                            SkipTo(skipOnPause, skipOnPlay)
                        End If
                        'Button 4
                        If action.m_key.KeyChar = 52 Then
                            skipOnPause = -1 * GetConfigString(ConfigKey.SeekStepOnPause4)
                            skipOnPlay = -1 * GetConfigString(ConfigKey.SeekStepOnPlay4)
                            SkipTo(skipOnPause, skipOnPlay)
                        End If
                        'Button 5
                        If action.m_key.KeyChar = 53 Then
                            MakeCut()
                        End If
                        'Button 6
                        If action.m_key.KeyChar = 54 Then
                            skipOnPause = GetConfigString(ConfigKey.SeekStepOnPause6)
                            skipOnPlay = GetConfigString(ConfigKey.SeekStepOnPlay6)
                            SkipTo(skipOnPause, skipOnPlay)
                        End If
                        'Button 7
                        If action.m_key.KeyChar = 55 Then
                            skipOnPause = -1 * GetConfigString(ConfigKey.SeekStepOnPause7)
                            skipOnPlay = -1 * GetConfigString(ConfigKey.SeekStepOnPlay7)
                            SkipTo(skipOnPause, skipOnPlay)
                        End If
                        'Button 8
                        If action.m_key.KeyChar = 56 Then
                            If CutList.Count > 0 Then
                                DeleteSelCutFromList(JumpToMarker(-1, True))
                            End If
                        End If
                        'Button 9
                        If action.m_key.KeyChar = 57 Then
                            skipOnPause = GetConfigString(ConfigKey.SeekStepOnPause9)
                            skipOnPlay = GetConfigString(ConfigKey.SeekStepOnPlay9)
                            SkipTo(skipOnPause, skipOnPlay)
                        End If
                        'Button *
                        If action.m_key.KeyChar = 42 Then
                            JumpToMarker(-1, True)
                        End If
                        'Button #
                        If action.m_key.KeyChar = 35 Then
                            JumpToMarker(-1, False)
                        End If
                    End If 'aktion.m_key is not nothing

                End If 'Key pressed

                ''ESC
                'If action.m_key.KeyCode = 27 Then
                '    If btnExitHelp.Visible = True Then
                '        Exit Sub
                '    End If
                'End If
                If action.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_PREVIOUS_MENU Then

                    If btnExitHelp IsNot Nothing AndAlso btnExitHelp.Visible = True Then
                        HelpBackgroundImage.Visible = False
                        LoadMoviestripBar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
                        LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
                        GUIControl.FocusControl(GetID, btnHelp.GetID)
                        Exit Sub
                    End If
                End If
                'Wenn in der Cutlist was selektiert wird
                If action.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_SELECT_ITEM And CutList.IsFocused Then
                    ShowCutListDialog()
                End If

                If action.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_SELECT_ITEM And sliderAudioSync.IsFocused Then
                    VRD.AudioSyncValue = sliderAudioSync.IntValue
                    GUIControl.FocusControl(Me.GetID, btnCut.GetID)
                    sliderAudioSync.Visible = False
                    LoadMoviestripBar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
                    LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
                End If
                ' ContexMenu
                If action.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_CONTEXT_MENU Then
                    ShowContextMenu()
                End If
            End If
            MyBase.OnAction(action)
        End Sub

        Protected Overrides Sub OnClicked(ByVal controlId As Integer, ByVal control As MediaPortal.GUI.Library.GUIControl, ByVal actionType As MediaPortal.GUI.Library.Action.ActionType)
            If control Is btnCut Then
                MakeCut()
            End If
            If control Is btnCutNow Then
                UnloadCutbar()
                UnloadMoviestripBar()
                CutTheVideo()
            End If
            If control Is btnHelp Then
                UnloadCutbar()
                UnloadMoviestripBar()
                ShowHelpDialog()
            End If
            If control Is btnExitHelp Then
                HelpBackgroundImage.Visible = False
                LoadMoviestripBar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
                LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
                GUIControl.FocusControl(GetID, btnHelp.GetID)
            End If
            MyBase.OnClicked(controlId, control, actionType)
        End Sub

#End Region

        ''' <summary>
        ''' Beginnt mit dem Schneiden des Videos im Backgroundthread
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub CutTheVideo()
            MyLog.DebugM("There are {0} Markers in the VideoReDo-Cutmarkers-List", VRD.CutMarkerList.Count)

            If VRD.CutMarkerList.Count Mod 2 = 0 Then
            Else
                If HelpConfig.GetConfigString(ConfigKey.CutOnEnd) = False Then
                    MyLog.DebugM("NoEndmarker Dialog wird erstellt")
                    ShowTextDialog(Translation.ErrorOccured, Translation.NoEndmarker)
                    Exit Sub
                Else
                    MyLog.DebugM(String.Format("Automatically adding Cutmarker at the end of the movie at Position {0}.", VRD.LoadedVideoDuration))
                    If IsPlayerPaused = False Then
                        IsPlayerPaused = True
                        g_Player.Pause()
                    End If
                    VRD.SeekToTime(VRD.LoadedVideoDuration)
                    MakeCut()
                End If
            End If
            If CutList.ListItems.Count = 2 Then
                If CutList.ListItems(0).Label2 = GetPlayerTimeString(0) And CutList.ListItems(1).Label2 = GetPlayerTimeString(PlayerDuration) Then
                    MyLog.Warn("Due to setting automated Start- and End-Cutmarkes, the whole Video was cutted out. This is not permitted.")
                    ShowTextDialog(Translation.ErrorOccured, Translation.ForbiddenCutCompleteVideo)
                    Exit Sub
                End If
            End If
            g_Player.Stop()
            GUIWindowManager.ActivateWindow(GetGUIWindow(enumWindows.GUISave), True)
        End Sub
        ''' <summary>
        ''' Erstellt einen Cut - NUR an der MOMENTANEN Position (Keine Positionsangabe möglich!!
        ''' </summary>
        ''' <param name="VideoStartCut">Ob es der anfängliche Startcut ist oder nicht</param>
        ''' <remarks></remarks>
        Private Sub MakeCut(Optional ByVal VideoStartCut As Boolean = False)
            MyLog.DebugM("Creating Cutmarker - TempStartValue={0};TempEndValue={1};Playerposition={2};VRD.GetCursortime={3}", TempStartValue, TempEndValue, g_Player.CurrentPosition, VRD.GetCursorTime)
            If VideoStartCut Then
                TempStartValue = Convert.ToSingle(0)
                Dim lItem As New GUIListItem("Start: ")
                VRD.MakeScreenshot(0, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuality.Thumbnail)
                lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                lItem.Label2 = GetPlayerTimeString(0)
                'CutList.ListItems.Add(lItem)
                GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                VRD.AddMarker(0)
                MyLog.DebugM("The Start-Cutmarker was generated automatically")
                GUIPropertyManager.SetProperty("#itemcount", CutList.ListItems.Count)
                Exit Sub
            End If
            If CutList.ListItems.Count Mod 2 = 0 Then
                Dim lItem As New GUIListItem("Start: ")
                If IsPlayerPaused Then
                    TempStartValue = Convert.ToSingle((VRD.GetCursorTime / 1000) * 100 / g_Player.Duration)
                    VRD.MakeScreenshot(VRD.GetCursorTime, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuality.Thumbnail)
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                    lItem.Label2 = GetPlayerTimeString(VRD.GetCursorTime)
                    'CutList.ListItems.Add(lItem)
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    VRD.AddMarker(VRD.GetCursorTime)
                    MyLog.DebugM("Start Cutmarker was created(Pause) - VRD.GetCursorTime={0} VRD.CutCount={1}", VRD.GetCursorTime, VRD.CutMarkerList.Count)
                    MyLog.DebugM("TempStartValue={0};TempEndValue={1};Playerposition={2};VRD.GetCursortime={3}", TempStartValue, TempEndValue, g_Player.CurrentPosition, VRD.GetCursorTime)
                Else
                    TempStartValue = Convert.ToSingle(g_Player.CurrentPosition * 100 / g_Player.Duration)
                    VRD.MakeScreenshot(g_Player.CurrentPosition * 1000, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuality.Thumbnail)
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                    lItem.Label2 = GetPlayerTimeString(g_Player.CurrentPosition * 1000)
                    'CutList.ListItems.Add(lItem)
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    VRD.AddMarker(g_Player.CurrentPosition * 1000)
                    MyLog.DebugM("Start Cutmarker was created(Play) - VRD.GetCursorTime={0} VRD.CutCount={1}", VRD.GetCursorTime, VRD.CutMarkerList.Count)
                    MyLog.DebugM("TempStartValue={0};TempEndValue={1};Playerposition={2};VRD.GetCursortime={3}", TempStartValue, TempEndValue, g_Player.CurrentPosition, VRD.GetCursorTime)
                End If
            Else
                Dim lItem As New GUIListItem("Stop: ")
                If IsPlayerPaused Then
                    TempEndValue = Convert.ToSingle((VRD.GetCursorTime / 1000) * 100 / g_Player.Duration)
                    lItem.Label2 = GetPlayerTimeString(VRD.GetCursorTime)
                    VRD.MakeScreenshot(VRD.GetCursorTime, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuality.Thumbnail)
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                    'CutList.ListItems.Add(lItem)
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    MyCutbar.AddValues(TempStartValue, TempEndValue)
                    VRD.AddMarker(VRD.GetCursorTime)
                    MyLog.DebugM("End Cutmarker was created - VRD.GetCursorTime={0} VRD.CutCount={1} CutterbarCutCount={2}:{3}", VRD.GetCursorTime, VRD.CutMarkerList.Count, MyCutBar.StartCutValues.Count, MyCutBar.EndCutValues.Count)
                    MyLog.DebugM("TempStartValue={0};TempEndValue={1};Playerposition={2};VRD.GetCursortime={3}", TempStartValue, TempEndValue, g_Player.CurrentPosition, VRD.GetCursorTime)
                Else
                    TempEndValue = Convert.ToSingle(g_Player.CurrentPosition * 100 / g_Player.Duration)
                    lItem.Label2 = GetPlayerTimeString(g_Player.CurrentPosition * 1000)
                    VRD.MakeScreenshot(g_Player.CurrentPosition * 1000, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuality.Thumbnail)
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"

                    'CutList.ListItems.Add(lItem)
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    MyCutbar.AddValues(TempStartValue, TempEndValue)
                    VRD.AddMarker(g_Player.CurrentPosition * 1000)
                    MyLog.DebugM("Start Cutmarker was created - VRD.GetCursorTime={0} VRD.CutCount={1} CutterbarCutCount={2}:{3}", VRD.GetCursorTime, VRD.CutMarkerList.Count, MyCutBar.StartCutValues.Count, MyCutBar.EndCutValues.Count)
                    MyLog.DebugM("TempStartValue={0};TempEndValue={1};Playerposition={2};VRD.GetCursortime={3}", TempStartValue, TempEndValue, g_Player.CurrentPosition, VRD.GetCursorTime)
                End If
                LoadCuts()
            End If
            MyCutbar.Invalidate()
            GUIPropertyManager.SetProperty("#itemcount", CutList.ListItems.Count)
        End Sub

#Region "g_Player Events"
        Friend Sub VideoChange(ByVal type As MediaPortal.Player.g_Player.MediaType, ByVal stoptime As Integer, ByVal filename As String)

        End Sub

        Friend Sub VideoStarted(ByVal type As g_Player.MediaType, ByVal filename As String)

        End Sub

        Friend Sub VideoStopped(ByVal type As MediaPortal.Player.g_Player.MediaType, ByVal stoptime As Integer, ByVal filename As String)
            MyMoviestripbar.MovieStripThumbs.Clear()
            MyMoviestripbar.Invalidate()
        End Sub

        Friend Sub VideoEnded(ByVal type As MediaPortal.Player.g_Player.MediaType, ByVal filename As String)
            MyLog.DebugM("Video Ended. That should not happen!!!")
            g_Player.Play(AktRecToCut.VideoFilename, g_Player.MediaType.Video)
            PlayerPosition = (PlayerDuration - 1000)
            g_Player.SeekAbsolute(PlayerPosition / 1000)
            If IsPlayerPaused = False Then
                g_Player.Pause()
            End If
        End Sub

        Friend Sub RefreshTimerTick(ByVal sender As Object, ByVal e As System.EventArgs)
            GetThumbs(PlayerPosition, ThumbCount) '(g_Player.CurrentPosition * 1000)
            MyCutbar.Invalidate()
            If tmrDelayRefreshOnSkip.Enabled Then
                tmrDelayRefreshOnSkip.Enabled = False
            End If
            If (HelpConfig.GetConfigString(ConfigKey.AlwaysRefreshMoviestripThumbs) = True) And (tmrRefresh.Enabled = False) And (IsPlayerPaused = False) Then
                tmrRefresh.Enabled = True
            End If
        End Sub

        Private IsPlayerPaused As Boolean = False
        Friend Sub CheckPlaybackTick(ByVal sender As Object, ByVal e As System.EventArgs)
            If VRD.AdScanInProgress Then Exit Sub
            If IsPlayerPaused = False Then
                If g_Player.Paused Then
                    IsPlayerPaused = True
                    tmrRefresh.Enabled = False
                    MyLog.DebugM("Player angehalten auf Position: {0} / {1}", g_Player.CurrentPosition, PlayerHelper.GetPlayerTimeString(g_Player.CurrentPosition * 1000))
                    MyLog.DebugM("Gehe für bessere Benutzerführung für die Thumbnailgenerierung eine halbe Sekunde zurück (500ms).")
                    PlayerPosition = PlayerPosition - 500
                    GetThumbs(PlayerPosition, ThumbCount)
                    g_Player.SeekAbsolute(PlayerPosition / 1000)
                    If g_Player.Paused = False Then
                        IsPlayerPaused = True
                        g_Player.Pause()
                    End If
                Else
                    PlayerPosition = Int(g_Player.CurrentPosition * 1000)
                    ctlStillImage.Visible = False
                    If (PlayerPosition) > (PlayerDuration - 1000) Then
                        PlayerPosition = (PlayerDuration - 500)
                        g_Player.SeekAbsolute(PlayerPosition / 1000)
                        g_Player.Pause()
                        tmrRefresh.Enabled = False
                    End If
                End If
            Else
                If g_Player.Paused = False Then
                    tmrRefresh.Enabled = True
                    IsPlayerPaused = False
                End If
            End If
            SetPlayerLabels(VRD, PlayerPosition)
        End Sub
#End Region

#Region "AdDetectiveSubs und Handler"
        Private Sub AdScanStart()
            AddHandler VRD.AdScanStarted, AddressOf AdScanStarted
            VRD.StartAdScan(True, True, False)
        End Sub

        Private Sub AdScanFinished(ByVal sender As Object, ByVal e As AdDetectiveEventArgs)
            RemoveHandler VRD.AdScanAborted, AddressOf AdScanAborted
            RemoveHandler VRD.AdScanCutAdded, AddressOf AdScanCutFound
            RemoveHandler VRD.AdScanFinished, AddressOf AdScanFinished
            tmrAdScan.Enabled = False
            RemoveHandler tmrAdScan.Tick, AddressOf AdScanTimerTick
            AnimWaiting.Visible = False
            UnloadCutbar()
            UnloadMoviestripBar()
            Dim FinDlg As GUIDialogNotify = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_NOTIFY, Integer)), GUIDialogNotify)
            FinDlg.SetHeading(Translation.Done)
            FinDlg.SetText(Translation.AdDetectiveDone)
            FinDlg.TimeOut = 2
            FinDlg.DoModal(Me.GetID)
            MyCutbar.Text = ""
            btnCut.Visible = True
            btnCutNow.Visible = True
            LoadMoviestripBar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
            LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
            If GUIWindowManager.ActiveWindow = GetID Then
                MyLog.DebugM("Lade die gespeicherten Cuts...")
                LoadCuts()
                GUIWindowManager.NeedRefresh()
                MyLog.DebugM("alle Cuts geladen.")
            End If

        End Sub

        Private Sub AdScanStarted(ByVal sender As Object, ByVal e As AdDetectiveEventArgs)
            AddHandler VRD.AdScanCutAdded, AddressOf AdScanCutFound
            AddHandler VRD.AdScanAborted, AddressOf AdScanAborted
            AnimWaiting.Visible = True
            btnCut.Visible = False
            btnCutNow.Visible = False
        End Sub

        Private Sub AdScanCutFound(ByVal sender As Object, ByVal e As AdDetectiveEventArgs)
            Dim startCut As Integer = (e.LastStartCut / PlayerDuration) * 100
            Dim endCut As Integer = (e.LastEndCut / PlayerDuration) * 100
            'MyCutbar.AddValues(startCut, endCut)
            MyLog.DebugM("AdDetective find a Cut: e.LastStartCut:{0},e.LastEndCut:{1}", e.LastStartCut, e.LastEndCut)
            TempStartValue = Convert.ToSingle((e.LastStartCut / PlayerDuration) * 100)
            TempEndValue = Convert.ToSingle((e.LastEndCut / PlayerDuration) * 100)
            MyCutbar.AddValues(TempStartValue, TempEndValue)
            MyCutbar.Invalidate()
            LoadCuts()
        End Sub

        Private Sub AdScanAborted(ByVal sender As Object, ByVal e As AdDetectiveEventArgs)
            AnimWaiting.Visible = False
            tmrAdScan.Enabled = False
            RemoveHandler VRD.AdScanAborted, AddressOf AdScanAborted
            RemoveHandler VRD.AdScanCutAdded, AddressOf AdScanCutFound
            RemoveHandler tmrAdScan.Tick, AddressOf AdScanTimerTick
            MyCutbar.Text = ""
            btnCut.Visible = True
            btnCutNow.Visible = True
        End Sub

        Private Sub AdScanTimerTick(ByVal sender As Object, ByVal e As EventArgs)
            Dim proz As Integer = (VRD.GetCursorTime / PlayerDuration) * 100
            MyCutbar.LineMarkerPosition = proz
            MyCutbar.Text = Translation.AdDetectiveRunning & " - " & proz.ToString & "%"
            MyCutbar.Invalidate()
        End Sub
#End Region

        Private Sub LoadRecordVideoToScreen()
            AnimWaiting.Visible = True
            'Exit Sub
            If IO.File.Exists(AktRecToCut.VideoFilename) Then
                If VRD.MediaToCut = AktRecToCut.VideoFilename Then
                    'Me.CutList.ListItems = Translation.TempCutListItems
                    If VRD.AdScanInProgress = False Then
                        MyLog.DebugM("Loding saved Cutmarkers ...")
                        LoadCuts()
                        MyLog.DebugM("All Cutmarkes loaded.")
                    End If
                Else
                    MyCutbar.StartCutValues.Clear()
                    MyCutbar.EndCutValues.Clear()
                    VRD.LoadMediaToCut(AktRecToCut.VideoFilename)
                    Application.DoEvents()
                    'Die CutOnPlay aus der Config laden und evtl. den Cut erstellen
                End If
                PlayerDuration = VRD.LoadedVideoDuration
                PlayerFramerate = VRD.GetFramerate / 100
                If (HelpConfig.GetConfigString(ConfigKey.CutOnPlay) = True) And (CutList.Count = 0) Then
                    MyLog.Info("'CutOnPlay' set to '{0}' in Preferences. Therefore a first Cutmarker has been generated.", GetConfigString(ConfigKey.CutOnPlay))
                    MakeCut(True)
                End If
                GUIPropertyManager.SetProperty("#itemcount", CutList.ListItems.Count)
                'Die Cutbar mit den ersten Bilder füllen
                If VRD.AdScanInProgress = False Then
                    GetThumbs(0, ThumbCount)
                    g_Player.Play(AktRecToCut.VideoFilename, g_Player.MediaType.Video)
                End If
                SetPlayerLabels(VRD, PlayerPosition)
                LoadMoviestripBar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
                LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
                btnCut.Visible = True
                btnCutNow.Visible = True
            Else
                MyLog.Warn("Error to load the Video {0}", AktRecToCut.VideoFilename)
                GUIWindowManager.GetWindow(enumWindows.GUIstart)
            End If
            AnimWaiting.Visible = False
            MyCutbar.Invalidate()
            If VRD.AdScanInProgress Then
                AnimWaiting.Visible = True
                btnCut.Visible = False
                btnCutNow.Visible = False
            End If
        End Sub

        Private Sub ShowTextDialog(Header As String, Text As String)
            UnloadCutbar()
            UnloadMoviestripBar()
            Dim dlgNoEndmarker As GUIDialogNotify = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_NOTIFY, Integer)), GUIDialogNotify)
            dlgNoEndmarker.SetHeading(Header)
            dlgNoEndmarker.SetText(Text)
            dlgNoEndmarker.TimeOut = 5
            dlgNoEndmarker.DoModal(GetID)
            LoadMoviestripBar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
            LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
            GUIWindowManager.Process()
            dlgNoEndmarker.Reset()
            dlgNoEndmarker = Nothing
        End Sub

        Private Sub ShowHelpDialog()
            HelpBackgroundImage.Visible = True
            Application.DoEvents()
            GUIControl.FocusControl(GetID, btnExitHelp.GetID)
        End Sub

        Private Sub ShowCutListDialog()
            UnloadCutbar()
            UnloadMoviestripBar()
            Dim dlgContext As GUIDialogMenu = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_MENU, Integer)), GUIDialogMenu)
            dlgContext.Reset()
            dlgContext.SetHeading(Translation.CutContextMenu)
            dlgContext.Add(Translation.CutContextChange)
            dlgContext.Add(Translation.CutContextDelete)
            dlgContext.Add(Translation.CutContextJumpTo)
            dlgContext.DoModal(GetID)

            If dlgContext.SelectedLabel = 0 Then
                ChangeCutFromList()
            End If
            If dlgContext.SelectedLabel = 1 Then
                DeleteSelCutFromList(CutList.SelectedListItemIndex)
            End If
            If dlgContext.SelectedLabel = 2 Then
                JumpToMarker(CutList.SelectedListItemIndex)
            End If
            LoadMoviestripBar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
            LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)

            GUIWindowManager.Process()
            dlgContext.Reset()
            dlgContext = Nothing
        End Sub

        Private Sub ChangeCutFromList()

        End Sub

        Private Sub DeleteSelCutFromList(ByVal SelectedMarker As Integer)
            Dim savedPosition As Long = VRD.GetCursorTime

            Dim oldList As List(Of Long) = VRD.CutMarkerList
            If SelectedMarker Mod 2 = 0 Then
                oldList.RemoveAt(SelectedMarker)
                Try
                    oldList.RemoveAt(SelectedMarker)
                Catch
                End Try
            Else
                oldList.RemoveAt(SelectedMarker - 1)
                oldList.RemoveAt(SelectedMarker - 1)
            End If
            VRD.ClearAllSelections()
            CutList.Clear()
            MyCutbar.CutValues = ""
            Dim newCutlist As New List(Of Long)
            newCutlist.AddRange(oldList)
            For Each item In newCutlist
                If CutList.ListItems.Count Mod 2 = 0 Then
                    Dim lItem As New GUIListItem("Start: ")
                    TempStartValue = Convert.ToSingle((item / 1000) * 100 / g_Player.Duration)
                    VRD.MakeScreenshot(VRD.GetCursorTime, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuality.Thumbnail)
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                    lItem.Label2 = GetPlayerTimeString(item)
                    'CutList.ListItems.Add(lItem)
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    VRD.AddMarker(item)
                Else
                    Dim lItem As New GUIListItem("Stop: ")
                    TempEndValue = Convert.ToSingle((item / 1000) * 100 / g_Player.Duration)
                    lItem.Label2 = GetPlayerTimeString(item)
                    VRD.MakeScreenshot(item, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuality.Thumbnail)
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    MyCutbar.AddValues(TempStartValue, TempEndValue)
                    VRD.AddMarker(item)
                End If
            Next
            MyCutbar.Invalidate()
            VRD.CutMarkerList = newCutlist
            VRD.SeekToTime(savedPosition)
        End Sub

        Private Sub ShowContextMenu()
            If VRD.AdScanInProgress Then Exit Sub
            If IsPlayerPaused = False Then
                g_Player.Pause()
            End If
            sliderAudioSync.Visible = False
            UnloadCutbar()
            UnloadMoviestripBar()
            Dim dlgContext As GUIDialogMenu = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_MENU, Integer)), GUIDialogMenu)
            dlgContext.Reset()
            dlgContext.SetHeading(GetConfigString(ConfigKey.ModuleName))
            dlgContext.Add(Translation.StartAdDetectiveScan)
            dlgContext.Add(Translation.ClearCutlist)
            dlgContext.Add(Translation.EditEndFilename)
            If Left(VRD.ReDoVersion, 1) = 4 Then
                dlgContext.Add(Translation.SavingProfile & ": " & VRD.AktSavingProfile)
            End If
            dlgContext.Add(Translation.AudioSyncLabelContext)
            dlgContext.DoModal(GetID)
            If dlgContext.SelectedLabel = 0 Then
                Dim adScan As New Threading.Thread(AddressOf AdScanStart)
                adScan.IsBackground = True
                adScan.Priority = Threading.ThreadPriority.BelowNormal
                AddHandler tmrAdScan.Tick, AddressOf AdScanTimerTick
                AddHandler VRD.AdScanCutAdded, AddressOf AdScanCutFound
                AddHandler VRD.AdScanAborted, AddressOf AdScanAborted
                AddHandler VRD.AdScanFinished, AddressOf AdScanFinished
                tmrAdScan.Interval = 1000
                tmrAdScan.Enabled = True
                tmrAdScan.Start()
                adScan.Start()
            End If
            If dlgContext.SelectedLabel = 1 Then
                CutList.Clear()
                MyCutbar.CutValues = ""
                MyCutbar.Invalidate()
                VRD.CutMarkerList.Clear()
                VRD.ClearAllSelections()
            End If
            If dlgContext.SelectedLabel = 2 Then
                Dim SavingFilename As String
                If Left(VRD.ReDoVersion, 1) = 4 Then
                    SavingFilename = Replace(AktRecToCut.SavingFilename, "%ext%", VRD.GetProfileInfo(VRD.AktSavingProfile).Filetype.ToLower)
                Else
                    SavingFilename = Replace(AktRecToCut.SavingFilename, "%ext%", "mpeg")
                End If
                Dim NewFilename As String = ShowKeyboard(SavingFilename, GetID)
                If NewFilename IsNot Nothing Then
                    AktRecToCut.SavingFilename = NewFilename
                    Translator.SetProperty("#Saving.Name", AktRecToCut.SavingFilename)
                End If
            End If
            If dlgContext.SelectedLabel = 3 Then
                UnloadCutbar()
                UnloadMoviestripBar()
                ShowProfileDialog(GetID)
                LoadMoviestripBar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
                LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
            End If
            If dlgContext.SelectedLabel = 4 Then
                sliderAudioSync.Visible = True
                GUIControl.ShowControl(Me.GetID, sliderAudioSync.GetID)
                GUIControl.FocusControl(Me.GetID, sliderAudioSync.GetID)
                sliderAudioSync.SetRange(-1000, 1000)
                sliderAudioSync.IntValue = VRD.AudioSyncValue
            End If
            If dlgContext.SelectedLabel < 4 Then
                LoadMoviestripBar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
                LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
            End If
            GUIWindowManager.Process()
            dlgContext.Reset()
            dlgContext = Nothing
        End Sub

        Private Sub LoadCuts()
            CutList.Clear()
            Dim VRDList As New List(Of Long)
            VRDList = VRD.LoadCutMarkerList()
            For i = 0 To VRDList.Count - 1
                If CutList.ListItems.Count Mod 2 = 0 Then
                    Dim lItem As New GUIListItem("Start: ")
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                    lItem.Label2 = GetPlayerTimeString(VRDList(i))
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                Else
                    Dim lItem As New GUIListItem("Stop: ")
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                    lItem.Label2 = GetPlayerTimeString(VRDList(i))
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                End If
            Next i
        End Sub

        Private Function SkipTo(ByVal skipOnPause As Long, ByVal skipOnPlay As Long) As Boolean
            Dim EndReached As Boolean = False
            tmrRefresh.Enabled = False
            tmrDelayRefreshOnSkip.Enabled = False
            If IsPlayerPaused Then
                skipOnPause = PlayerPosition + ((1000 / PlayerFramerate) * skipOnPause)
                If skipOnPause < 0 Then
                    skipOnPause = 0
                ElseIf skipOnPause >= (PlayerDuration) Then
                    skipOnPause = (PlayerDuration)
                    EndReached = True
                    g_Player.SeekAbsolute((skipOnPause - 1000) / 1000)
                Else
                    tmrDelayRefreshOnSkip.Enabled = True
                    g_Player.SeekAbsolute(skipOnPause / 1000)
                End If
                If g_Player.Paused = False Then
                    IsPlayerPaused = True
                    tmrRefresh.Enabled = False
                    g_Player.Pause()
                End If
                PlayerPosition = skipOnPause
            Else
                skipOnPlay = Int((g_Player.CurrentPosition * 1000)) + (skipOnPlay * 1000)
                If skipOnPlay < 0 Then
                    skipOnPlay = 0
                ElseIf skipOnPlay >= (PlayerDuration - 500) Then
                    EndReached = True
                    skipOnPlay = PlayerDuration - 5000
                End If
                If (HelpConfig.GetConfigString(ConfigKey.AlwaysRefreshMoviestripThumbs) = True) Then
                    tmrDelayRefreshOnSkip.Enabled = True
                End If
                g_Player.SeekAbsolute(skipOnPlay / 1000)
                If EndReached Then
                    g_Player.Pause()
                Else
                End If
                PlayerPosition = skipOnPlay
            End If
            Return EndReached
        End Function

        Private Function JumpToMarker(Optional ByVal JumpMarker As Integer = -1, Optional ByVal Backwards As Boolean = False) As Integer
            Dim VRDList As New List(Of Long)
            Dim marker As Integer = -1
            VRDList = VRD.LoadCutMarkerList()
            If (JumpMarker = -1) And (VRDList.Count > 0) Then
                If Backwards = True Then
                    For i = 0 To VRDList.Count - 1
                        If VRDList(i) + 1000 >= (g_Player.CurrentPosition * 1000) Then
                            marker = i
                            Exit For
                        End If
                    Next i
                    marker = marker - 1
                    If marker < 0 Then
                        marker = VRDList.Count - 1
                    End If
                Else
                    For i = 0 To VRDList.Count - 1
                        If (VRDList(i) - 1) > (g_Player.CurrentPosition * 1000) Then
                            marker = i
                            Exit For
                        End If
                    Next i
                    If marker = -1 Then
                        marker = 0
                    End If
                End If
                JumpMarker = marker
            End If
            If JumpMarker < VRDList.Count Then
                g_Player.SeekAbsolute(VRDList(JumpMarker) / 1000)
                If g_Player.Paused = False Then
                    IsPlayerPaused = True
                    tmrRefresh.Enabled = False
                    g_Player.Pause()
                End If
                If IsPlayerPaused Or (HelpConfig.GetConfigString(ConfigKey.AlwaysRefreshMoviestripThumbs) = True) Then
                    GetThumbs(VRDList(JumpMarker), ThumbCount)
                End If
            End If
            Return marker
        End Function

        Public Sub GetThumbs(ByVal _Position As Long, ByVal _ThumbCount As Integer)
            Dim factor As Integer = Int(_ThumbCount / 2)
            Dim ThumbList As New ImageList
            ThumbList.ColorDepth = ColorDepth.Depth24Bit
            ThumbList.ImageSize = New Drawing.Size(128, 128)
            MyLog.DebugM("Generating {2} thumbnails for position {0} with a stepping of {1} ms ...", _Position, (1000 / PlayerFramerate), _ThumbCount)
            Try
                For i As Integer = 0 To _ThumbCount - 1
                    If VRD Is Nothing Then Exit Sub
                    Dim temptime As Long = _Position + ((1000 / PlayerFramerate) * (i + 1 - factor))
                    If (temptime < 0) Or (temptime > PlayerDuration) Then
                        ThumbList.Images.Add(NoImage)
                    Else
                        ThumbList.Images.Add(VRD.MakeScreenshotToClipboard(temptime, VideoReDo.ScreenshotQuality.Thumbnail, i))
                    End If
                Next
                If VRD Is Nothing Then Exit Sub
                MyMovieStripBar.MovieThumbs = ThumbList
                MyMovieStripBar.LineMarkerPosition = (factor / _ThumbCount) * 100
                MyMovieStripBar.Invalidate()
                'Für ein Vorschaubild welches in  einem Image im Skin verwendet werden kann
                If g_Player.Paused Then
                    VRD.MakeScreenshot(_Position, Config.GetFolder(Config.Dir.Cache) & "\VideoRedo\StillImage.png", VideoReDo.ScreenshotQuality.good)
                    ctlStillImage.RemoveMemoryImageTexture()
                    ctlStillImage.FileName = Config.GetFolder(Config.Dir.Cache) & "\VideoRedo\StillImage.png"
                    ctlStillImage.Visible = True
                End If
            Catch ex As Exception
                MyLog.Info(ex.Message)
            End Try
            MyLog.DebugM("Done.")
        End Sub

    End Class
End Namespace