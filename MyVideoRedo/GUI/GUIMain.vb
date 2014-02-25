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
        <SkinControlAttribute(44)> _
        Protected VideoWindow As GUIVideoControl = Nothing
        <SkinControlAttribute(45)> _
        Protected lblAudioResync As GUILabelControl = Nothing
        <SkinControlAttribute(46)> _
        Protected sliderAudioSync As GUISliderControl = Nothing
        <SkinControlAttribute(23)> _
        Protected btnCutNow As GUIButtonControl = Nothing
        <SkinControlAttribute(24)> _
        Protected btnHelp As GUIButtonControl = Nothing
        <SkinControlAttribute(4)> _
        Protected btnCut As GUIButtonControl = Nothing
        <SkinControlAttribute(51)> _
        Protected CutList As GUIListControl = Nothing
        <SkinControlAttribute(71)> _
        Protected CutBarImage As GUIImage = Nothing
        <SkinControlAttribute(13)> _
        Protected AnimWaiting As GUIAnimation = Nothing
        <SkinControlAttribute(25)> _
        Protected HelpBackgroundImage As GUIImage = Nothing
        <SkinControlAttribute(26)> _
        Protected btnExitHelp As GUIButtonControl = Nothing



#End Region

#Region "Variablen"
        Private TempStartValue As Single
        Private TempEndValue As Single
        Friend tmr As New Timer
        Friend tmrAd As New Timer
        Private IsLoadingHDContent As Boolean = False
#End Region

        Public Sub New()

        End Sub

#Region "MP EventSubs"

        Public Overloads Overrides Property GetID() As Integer
            Get
                Return 1209
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
            Return "MyVideoRedo"
        End Function

        Protected Overrides Sub OnPageLoad()
            MyBase.OnPageLoad()
            If GUIWindowManager.ActiveWindow = GetID Then
                If VRD.OutputInProgress = True Then
                    GUIWindowManager.ActivateWindow(1208, True)

                    Exit Sub
                End If



                MyLog.DebugM("Setze Playerhandler PlayBackStarted, PlayBackChanged, PlayBackEnded und PlayBackStopped")
                AddHandler g_Player.PlayBackStarted, AddressOf VideoStarted
                AddHandler g_Player.PlayBackChanged, AddressOf VideoChange
                AddHandler g_Player.PlayBackEnded, AddressOf VideoEnded
                AddHandler g_Player.PlayBackStopped, AddressOf VideoStopped
                MyLog.DebugM("Handler gesetzt")

                'sliderAudioSync.Visible = False
                LoadRecordVideoToScreen()

                ''Workaround um das Fenster von MP wieder in den Fordergrund zu bringen
                Helper.SetMPtoForeground()
                'If VRD.AdScanInProgress Then AddHandler tmrAd.Tick, AddressOf AdScanTimerTick
            End If
        End Sub

        Protected Overrides Sub OnPageDestroy(ByVal new_windowId As Integer)
            'If btnExitHelp.Visible = True Then

            '    Exit Sub
            'End If

            If VRD IsNot Nothing Then
                If VRD.OutputInProgress Then Exit Sub
                If GUIWindowManager.ActiveWindow = 1209 Then ' My Window
                    UnloadCutbar()
                    UnloadFilmstripbar()


                    If VRD.AdScanInProgress Then
                        MyLog.DebugM("Zeige Ja/Nein Dialog für das Abbrechen des AdDetective Scan`s...")

                        If ShowYeyNoDialog(GetID, Translation.ContinueScan, Translation.ContinueScan1) = True Then
                            MyLog.DebugM("Dialog wurde bestätigt, es wird weitergescannt!!")

                        Else
                            MyLog.DebugM("Scan soll abgebrochen werden.")
                            VRD.AbortScan()
                            Do While VRD.AdScanInProgress
                            Loop


                            MyLog.DebugM("Scan wurde abgebrochen")
                        End If

                    End If




                    'tmrAd.Stop()
                    'RemoveHandler tmrAd.Tick, AddressOf AdScanTimerTick
                    tmr.Stop()
                    'VRD.AbortVideoSaving()
                    g_Player.Stop()


                    If new_windowId < GetID Then
                        If VRD.AdScanInProgress = False And VRD.CutMarkerList.Count > 0 Then
                            If ShowYeyNoDialog(GetID, Translation.ClearCutsAtClose, Translation.ClearCutsAtClose1) = True Then
                                myFilmstripBar.StartCutValues.Clear()
                                myFilmstripBar.EndCutValues.Clear()
                                VRD.CutMarkerList.Clear()
                                VRD.ClearAllSelections()
                            Else
                                MyLog.DebugM("Schnitte sollen nicht verworfen werden und werden beibehalten.")
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
                    RemoveHandler tmr.Tick, AddressOf VideoTimerTick
                    'GUIWindowManager.Clear()
                End If
            End If
            'GUIWindowManager.Clear()
            'GUIWindow.Clear()
            'GUIWindowManager.CloseCurrentWindow()
            MyBase.OnPageDestroy(new_windowId)
            'GUIWindowManager.ActivateWindow(1208, True)
        End Sub

        Public Overrides Sub OnAction(ByVal Maction As MediaPortal.GUI.Library.Action)

            Dim AktWinId As Integer = GUIWindowManager.ActiveWindow
            If AktWinId = GetID Then
                Try
                    MyLog.DebugM("Keypress on VideoReDo Screen. KeyChar={0} ; KeyCode={1} ; Actiontype={2}", Maction.m_key.KeyChar, Maction.m_key.KeyCode, Maction.wID.ToString)
                Catch
                    MyLog.DebugM("Action on VideoReDo Screen. Action={0}", Maction.wID.ToString)
                End Try
                If Maction.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_KEY_PRESSED Then

                    If Maction.m_key IsNot Nothing Then
                        'Button 1
                        If Maction.m_key.KeyChar = 49 Then
                            If g_Player.Paused Then
                                GetFilmThumbnails((VRD.GetCursorTime - ((VRD.GetFramerate / 100)) * GetConfigString(ConfigKey.SeekStepOnPause1)))
                            Else
                                g_Player.SeekRelative(GetNegativeInt(GetConfigString(ConfigKey.SeekStepOnPlay1)))
                            End If

                        End If
                        'Button 2
                        If Maction.m_key.KeyChar = 50 Then
                            If VRD.AdScanInProgress Then
                                VRD.AbortScan()
                                VRD.SeekToTime(0)
                                g_Player.SeekAbsolute(0)
                                g_Player.Pause()
                            End If

                        End If
                        'Button 3
                        If Maction.m_key.KeyChar = 51 Then
                            If g_Player.Paused Then
                                GetFilmThumbnails(VRD.GetCursorTime + (((VRD.GetFramerate / 100) + (VRD.GetFramerate / 100)) * GetConfigString(ConfigKey.SeekStepOnPause3)))
                            Else
                                g_Player.SeekRelative(GetConfigString(ConfigKey.SeekStepOnPlay3))
                            End If
                        End If
                        'Button 4
                        If Maction.m_key.KeyChar = 52 Then
                            If g_Player.Paused Then
                                GetFilmThumbnails((VRD.GetCursorTime - ((VRD.GetFramerate / 100) * 1.6) * GetConfigString(ConfigKey.SeekStepOnPause4)))
                            Else
                                g_Player.SeekRelative(GetNegativeInt(GetConfigString(ConfigKey.SeekStepOnPlay3)))
                            End If
                        End If
                        'Button 5
                        If Maction.m_key.KeyChar = 53 Then
                            MakeCut()
                        End If
                        'Button 6
                        If Maction.m_key.KeyChar = 54 Then
                            If g_Player.Paused Then
                                GetFilmThumbnails((VRD.GetCursorTime + ((VRD.GetFramerate / 100) * 0.4) * GetConfigString(ConfigKey.SeekStepOnPause6)))
                            Else
                                g_Player.SeekRelative(GetConfigString(ConfigKey.SeekStepOnPlay6))
                            End If
                        End If
                        'Button 7
                        If Maction.m_key.KeyChar = 55 Then
                            If g_Player.Paused Then
                                GetFilmThumbnails((VRD.GetCursorTime - ((VRD.GetFramerate / 100) * 1.6) * GetConfigString(ConfigKey.SeekStepOnPause7)))
                            Else
                                g_Player.SeekRelative(GetNegativeInt(GetConfigString(ConfigKey.SeekStepOnPlay7)))
                            End If
                        End If
                        'Button 9
                        If Maction.m_key.KeyChar = 57 Then
                            If g_Player.Paused Then
                                GetFilmThumbnails((VRD.GetCursorTime + ((VRD.GetFramerate / 100) * 0.4) * GetConfigString(ConfigKey.SeekStepOnPause9)))
                            Else
                                g_Player.SeekRelative(GetConfigString(ConfigKey.SeekStepOnPlay9))
                            End If
                        End If

                      


                    End If 'aktion.m_key is not nothing

                End If 'Key pressed

                ''ESC
                'If action.m_key.KeyCode = 27 Then
                '    If btnExitHelp.Visible = True Then
                '        Exit Sub
                '    End If

                'End If

                If Maction.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_PREVIOUS_MENU Then

                    If btnExitHelp IsNot Nothing AndAlso btnExitHelp.Visible = True Then
                        HelpBackgroundImage.Visible = False
                        LoadFilmstripbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
                        LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
                        GUIControl.FocusControl(GetID, btnHelp.GetID)
                        Exit Sub
                    End If
                End If

                'Wenn in der Cutlist was selektiert wird
                If Maction.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_SELECT_ITEM And CutList.IsFocused Then
                    ShowCutListDialog()
                End If

                If Maction.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_SELECT_ITEM And sliderAudioSync.IsFocused Then
                    VRD.AudioSyncValue = sliderAudioSync.IntValue
                    GUIControl.FocusControl(Me.GetID, btnCut.GetID)
                    sliderAudioSync.Visible = False
                    LoadFilmstripbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
                    LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
                End If

                ' ContexMenu
                If Maction.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_CONTEXT_MENU Then
                    ShowContextMenu()
                End If
            End If

            MyBase.OnAction(Maction)
        End Sub

        Protected Overrides Sub OnClicked(ByVal controlId As Integer, ByVal control As MediaPortal.GUI.Library.GUIControl, ByVal actionType As MediaPortal.GUI.Library.Action.ActionType)
            If control Is btnCut Then
                MakeCut()
            End If
            If control Is btnCutNow Then
                UnloadCutbar()
                UnloadFilmstripbar()
                CutTheVideo()
            End If
            If control Is btnHelp Then
                UnloadCutbar()
                UnloadFilmstripbar()
                ShowHelpDialog()

            End If
            If control Is btnExitHelp Then
                HelpBackgroundImage.Visible = False
                LoadFilmstripbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
                LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
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
            MyLog.DebugM("Es gibt {0} Marker in der VideoReDo-Liste", VRD.CutMarkerList.Count)

            If VRD.CutMarkerList.Count Mod 2 = 0 Then 'And HelpConfig.GetConfigString(ConfigKey.CutOnEnd) = False Then

            Else
                If HelpConfig.GetConfigString(ConfigKey.CutOnEnd) = False Then
                    MyLog.DebugM("NoEndmarker Dialog wird erstellt")
                    ShowTextDialog("Ups :-)", Translation.KeinEndmarker)
                    Exit Sub
                Else
                    MyLog.DebugM(String.Format("Füge automatisch einen Cut am Ende des Videofiles auf Position {0} ein damit korrekt geschnitten werden kann.", g_Player.Duration * 1000))
                    g_Player.Pause()
                    IsPlayerPaused = True
                    VRD.SeekToTime(g_Player.Duration * 1000)
                    MakeCut()
                End If

            End If
            If CutList.ListItems.Count = 2 Then
                If CutList.ListItems(0).Label2 = GetPlayerTimeString(0) And Mid(CutList.ListItems(1).Label2, 1, 8) = Mid(GetPlayerTimeString(g_Player.Duration * 1000), 1, 8) Then
                    MyLog.Warn("Es wurde durch das automatische setzten von Start und Endmarker quasi das ganze video geschnitten, dies ist nicht zulässig")
                    ShowTextDialog("Ups :-)", Translation.ForbittenCutCompleteVideo)
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
            MyLog.DebugM("Erstelle Cut - TempStartValue={0};TempEndValue={1};Playerposition={2};VRD.GetCursortime={3}", TempStartValue, TempEndValue, g_Player.CurrentPosition, VRD.GetCursorTime)
            If VideoStartCut Then
                TempStartValue = Convert.ToSingle(0)
                Dim lItem As New GUIListItem("StartCut: ")
                VRD.MakeScreenshot(0, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuali.Thumbnail)
                lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                lItem.Label2 = GetPlayerTimeString(0)
                'CutList.ListItems.Add(lItem)
                GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                VRD.AddMarker(0)
                MyLog.DebugM("Der anfängliche Startcut wurde automatisch erstellt")
                Exit Sub
            End If
            If CutList.ListItems.Count Mod 2 = 0 Then
                Dim lItem As New GUIListItem("StartCut: ")
                If IsPlayerPaused Then
                    TempStartValue = Convert.ToSingle((VRD.GetCursorTime / 1000) * 100 / g_Player.Duration)
                    VRD.MakeScreenshot(VRD.GetCursorTime, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuali.Thumbnail)
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                    lItem.Label2 = GetPlayerTimeString(VRD.GetCursorTime)
                    'CutList.ListItems.Add(lItem)
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    VRD.AddMarker(VRD.GetCursorTime)
                    MyLog.DebugM("Startcut wurde erstellt(Pause) - VRD.GetCursorTime={0} VRD.CutCount={1}", VRD.GetCursorTime, VRD.CutMarkerList.Count)
                    MyLog.DebugM("TempStartValue={0};TempEndValue={1};Playerposition={2};VRD.GetCursortime={3}", TempStartValue, TempEndValue, g_Player.CurrentPosition, VRD.GetCursorTime)

                Else
                    TempStartValue = Convert.ToSingle(g_Player.CurrentPosition * 100 / g_Player.Duration)
                    VRD.MakeScreenshot(g_Player.CurrentPosition * 1000, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuali.Thumbnail)
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                    lItem.Label2 = GetPlayerTimeString(g_Player.CurrentPosition * 1000)
                    'CutList.ListItems.Add(lItem)
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    VRD.AddMarker(g_Player.CurrentPosition * 1000)
                    MyLog.DebugM("Startcut wurde erstellt(Play) - VRD.GetCursorTime={0} VRD.CutCount={1}", VRD.GetCursorTime, VRD.CutMarkerList.Count)
                    MyLog.DebugM("TempStartValue={0};TempEndValue={1};Playerposition={2};VRD.GetCursortime={3}", TempStartValue, TempEndValue, g_Player.CurrentPosition, VRD.GetCursorTime)

                End If
            Else
                Dim lItem As New GUIListItem("EndCut: ")
                If IsPlayerPaused Then
                    TempEndValue = Convert.ToSingle((VRD.GetCursorTime / 1000) * 100 / g_Player.Duration)
                    lItem.Label2 = GetPlayerTimeString(VRD.GetCursorTime)
                    VRD.MakeScreenshot(VRD.GetCursorTime, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuali.Thumbnail)
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"

                    'CutList.ListItems.Add(lItem)
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    myFilmstripBar.AddValues(TempStartValue, TempEndValue)
                    VRD.AddMarker(VRD.GetCursorTime)
                    MyLog.DebugM("Endcut wurde erstellt - VRD.GetCursorTime={0} VRD.CutCount={1} CutterbarCutCount={2}:{3}", VRD.GetCursorTime, VRD.CutMarkerList.Count, myFilmstripBar.StartCutValues.Count, myFilmstripBar.EndCutValues.Count)
                    MyLog.DebugM("TempStartValue={0};TempEndValue={1};Playerposition={2};VRD.GetCursortime={3}", TempStartValue, TempEndValue, g_Player.CurrentPosition, VRD.GetCursorTime)

                Else
                    TempEndValue = Convert.ToSingle(g_Player.CurrentPosition * 100 / g_Player.Duration)
                    lItem.Label2 = GetPlayerTimeString(g_Player.CurrentPosition * 1000)
                    VRD.MakeScreenshot(g_Player.CurrentPosition * 1000, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuali.Thumbnail)
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"

                    'CutList.ListItems.Add(lItem)
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    myFilmstripBar.AddValues(TempStartValue, TempEndValue)
                    VRD.AddMarker(g_Player.CurrentPosition * 1000)
                    MyLog.DebugM("Endcut wurde erstellt - VRD.GetCursorTime={0} VRD.CutCount={1} CutterbarCutCount={2}:{3}", VRD.GetCursorTime, VRD.CutMarkerList.Count, myFilmstripBar.StartCutValues.Count, myFilmstripBar.EndCutValues.Count)
                    MyLog.DebugM("TempStartValue={0};TempEndValue={1};Playerposition={2};VRD.GetCursortime={3}", TempStartValue, TempEndValue, g_Player.CurrentPosition, VRD.GetCursorTime)


                End If
            End If
            MyCutbar.Invalidate()

        End Sub


        Dim dlgPrgrs As GUIDialogProgress



#Region "SavingDialog"
        Private SelectedPath As String = ""
        Private Function GetDirDialog(ByVal path As String) As String
            MyLog.DebugM("Erstelle GetDirDialog")
            Dim templist As New List(Of String)
            Dim dlgPath As GUIDialogMenu = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_MENU, Integer)), GUIDialogMenu)
            dlgPath.SetHeading(Translation.searchFolder)
            dlgPath.ShowQuickNumbers = False

            Dim rootInfo As IO.DirectoryInfo

            If path = "Drives" Then
                For Each Drive In System.Environment.GetLogicalDrives()
                    MyLog.DebugM("Setze Menüitem für Ordner '{0}'", Drive)
                    Dim nItem As New GUIListItem
                    nItem.IsFolder = True
                    nItem.Label = Drive
                    nItem.Path = Drive
                    nItem.IconImage = "redoHarddisk.png"
                    Dim dInfo As New DriveInfo(Drive)
                    If dInfo.IsReady Then
                        templist.Add(Drive)
                        dlgPath.Add(nItem)
                    End If
                Next Drive
                dlgPath.DoModal(GetID)
                GUIWindowManager.Process()
                If dlgPath.SelectedLabel = -1 Then Return "Abort"
                Return templist(dlgPath.SelectedLabel)
            Else
                rootInfo = New IO.DirectoryInfo(path)

                If rootInfo.Parent IsNot Nothing Then
                    Dim nItemPArent As New GUIListItem
                    nItemPArent.IsFolder = True
                    nItemPArent.Label = ".." 'Mid(rootInfo.Parent.FullName, InStrRev(rootInfo.Parent.FullName, "\") + 1)
                    nItemPArent.Path = rootInfo.Parent.FullName
                    nItemPArent.IconImage = "redoFolderBack.png"
                    templist.Add(rootInfo.Parent.FullName)
                    dlgPath.Add(nItemPArent)
                Else
                    Dim nItemDrive As New GUIListItem
                    nItemDrive.IsFolder = True
                    nItemDrive.Label = "Drives"
                    nItemDrive.Path = "Drives"
                    nItemDrive.IconImage = "redoHarddisk.png"
                    templist.Add("Drives")
                    dlgPath.Add(nItemDrive)
                End If

                MyLog.DebugM("Setze Menuitem 'Hier speichern'")
                Dim nItem As New GUIListItem
                nItem.IsFolder = True
                nItem.IconImage = "redoCheck.png"
                nItem.Label = Translation.SaveHere
                nItem.Path = Translation.SaveHere

                templist.Add(Translation.SaveHere)
                dlgPath.Add(nItem)


                For Each item As IO.DirectoryInfo In rootInfo.GetDirectories
                    Try
                        MyLog.DebugM("Setze Menüitem für Ordner '{0}'", item.Name)
                        Dim test As New IO.DirectoryInfo(item.FullName)
                        test.GetDirectories()
                        Dim nItem1 As New GUIListItem
                        nItem1.IsFolder = True
                        nItem1.Label = item.Name
                        nItem1.Path = item.FullName
                        nItem1.IconImage = "redoFolder.png"
                        templist.Add(item.FullName)
                        dlgPath.Add(nItem1)
                    Catch ex As System.UnauthorizedAccessException
                        MyLog.Info("Der zugriff auf wurde verweigert Text: {0}", ex.ToString)
                    End Try
                Next

            End If
            dlgPath.DoModal(GetID)
            GUIWindowManager.Process()
            If dlgPath.SelectedLabel = -1 Then Return "Abort"

            Return templist(dlgPath.SelectedLabel)

        End Function


#End Region



#Region "g_Player Events"
        Friend Sub VideoChange(ByVal type As MediaPortal.Player.g_Player.MediaType, ByVal stoptime As Integer, ByVal filename As String)
            'SetPlayerLabels(VRD) 'mypic.Image = VRD.MakeScreenshotToClipboard(VRD.GetCursorTime, VideoReDo.ScreenshotQuali.Schlecht)
        End Sub
        Friend Sub VideoStarted(ByVal type As g_Player.MediaType, ByVal filename As String)
            AddHandler g_Player.PlayBackChanged, AddressOf VideoChange
            tmr.Enabled = True
            tmr.Interval = 200
            AddHandler tmr.Tick, AddressOf VideoTimerTick
            tmr.Start()

            MyLog.DebugM("Ermittle aktuelle Videoformat...")
            Dim CurrFormat As MediaPortal.Player.VideoStreamFormat = g_Player.GetVideoFormat
            MyLog.DebugM("Aktuelles Videoformat des g_players ist {0} mit einer Auflösung von {1} * {2} und einer Bitrate von {3} .", _
                         CurrFormat.streamType.ToString, CurrFormat.width, CurrFormat.height, CurrFormat.bitrate)

            If CurrFormat.streamType = VideoStreamType.H264 Then
                If Microsoft.VisualBasic.Strings.Left(VRD.ReDoVersion, 1) < 4 Then
                    UnloadCutbar()
                    UnloadFilmstripbar()
                    ShowErrorDialog(GetID, Translation.VideoRedoCanNotHD)
                    LoadFilmstripbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
                    LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
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

            GetFilmThumbnails(g_Player.CurrentPosition * 1000)


        End Sub
        Friend Sub VideoStopped(ByVal type As MediaPortal.Player.g_Player.MediaType, ByVal stoptime As Integer, ByVal filename As String)
            'RemoveHandler g_Player.PlayBackChanged, AddressOf VideoChange
            RemoveHandler tmr.Tick, AddressOf VideoTimerTick
            MyCutbar.Filmbitmaps.Clear()
            MyCutbar.Invalidate()
        End Sub
        Friend Sub VideoEnded(ByVal type As MediaPortal.Player.g_Player.MediaType, ByVal filename As String)
            'RemoveHandler g_Player.PlayBackChanged, AddressOf VideoChange
            RemoveHandler tmr.Tick, AddressOf VideoTimerTick


        End Sub
        Private IsPlayerPaused As Boolean = False
        Friend Sub VideoTimerTick(ByVal sender As Object, ByVal e As System.EventArgs)
            If VRD.AdScanInProgress Then Exit Sub
            SetPlayerLabels(VRD)

            If IsPlayerPaused = False Then
                If g_Player.Paused Then
                    MyLog.DebugM("Player angehalten auf Position: {0} / {1}", g_Player.CurrentPosition, PlayerHelper.GetPlayerTimeString(g_Player.CurrentPosition * 1000))
                    MyLog.DebugM("Gehe für bessere Benutzerführung für die Thumbnailgenerierung eine halbe Sekunde zurück (500ms).")

                    GetFilmThumbnails((g_Player.CurrentPosition * 1000) - 500)
                    IsPlayerPaused = True
                End If
            Else
                If g_Player.Paused = False Then
                    IsPlayerPaused = False
                End If
            End If
        End Sub
#End Region

#Region "AdDetectiveSubs und Handler"


        Private Sub StarteAdScan()
            AddHandler VRD.AdScanStarted, AddressOf AdScanStarted
            VRD.StartAdScan(True, True, False)


        End Sub

        Private Sub AdScanFinished(ByVal sender As Object, ByVal e As AdDetectiveEventArgs)
            RemoveHandler VRD.AdScanAborted, AddressOf AdScanAborted
            RemoveHandler VRD.AdScanCutAdded, AddressOf AdScanCutFinded
            RemoveHandler VRD.AdScanFinished, AddressOf AdScanFinished
            tmrAd.Stop()
            RemoveHandler tmrAd.Tick, AddressOf AdScanTimerTick
            AnimWaiting.Visible = False

            UnloadCutbar()
            UnloadFilmstripbar()

            Dim FinDlg As GUIDialogNotify = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_NOTIFY, Integer)), GUIDialogNotify)
            FinDlg.SetHeading(Translation.Done)
            FinDlg.SetText(Translation.AdDetectiveDone)
            FinDlg.TimeOut = 2
            FinDlg.DoModal(Me.GetID)
            myFilmstripBar.Text = ""
            btnCut.Visible = True
            btnCutNow.Visible = True

            LoadFilmstripbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
            LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)


            If GUIWindowManager.ActiveWindow = GetID Then
                MyLog.DebugM("Lade die gespeicherten Cuts...")
                VRD.CutMarkerList.Clear()
                For i = 0 To VRD.CutMarkerList.Count - 1
                    If CutList.ListItems.Count Mod 2 = 0 Then
                        Dim lItem As New GUIListItem("StartCut: ")
                        lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                        lItem.Label2 = GetPlayerTimeString(VRD.CutMarkerList(i))
                        GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    Else
                        Dim lItem As New GUIListItem("EndCut: ")
                        lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                        lItem.Label2 = GetPlayerTimeString(VRD.CutMarkerList(i))
                        GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    End If
                Next i
                MyLog.DebugM("alle Cuts geladen.")
            End If

        End Sub

        Private Sub AdScanStarted(ByVal sender As Object, ByVal e As AdDetectiveEventArgs)
            AddHandler VRD.AdScanCutAdded, AddressOf AdScanCutFinded
            AddHandler VRD.AdScanAborted, AddressOf AdScanAborted
            AnimWaiting.Visible = True
            btnCut.Visible = False
            btnCutNow.Visible = False
        End Sub

        Private Sub AdScanCutFinded(ByVal sender As Object, ByVal e As AdDetectiveEventArgs)
            Dim startCut As Integer = (e.LastStartCut / 1000) * 100 / VRD.LoadedVideoDuration
            Dim endCut As Integer = (e.LastEndCut / 1000) * 100 / VRD.LoadedVideoDuration
            'MyCutbar.AddValues(startCut, endCut)
            MyLog.DebugM("AdDetective find a Cut: e.LastStartCut:{0},e.LastEndCut:{1}", e.LastStartCut, e.LastEndCut)



            TempStartValue = Convert.ToSingle((e.LastStartCut / 1000) * 100 / VRD.LoadedVideoDuration)


            TempEndValue = Convert.ToSingle((e.LastEndCut / 1000) * 100 / VRD.LoadedVideoDuration)

            myFilmstripBar.AddValues(TempStartValue, TempEndValue)

            myFilmstripBar.Invalidate()
        End Sub

        Private Sub AdScanAborted(ByVal sender As Object, ByVal e As AdDetectiveEventArgs)
            AnimWaiting.Visible = False
            RemoveHandler VRD.AdScanAborted, AddressOf AdScanAborted
            RemoveHandler VRD.AdScanCutAdded, AddressOf AdScanCutFinded

            tmrAd.Stop()
            RemoveHandler tmrAd.Tick, AddressOf AdScanTimerTick
            myFilmstripBar.Text = ""
            btnCut.Visible = True
            btnCutNow.Visible = True
        End Sub

        Private Sub AdScanTimerTick(ByVal sender As Object, ByVal e As EventArgs)

            Dim proz As Integer = (VRD.GetCursorTime / 1000) * 100 / VRD.LoadedVideoDuration
            myFilmstripBar.LineMarkerPosition = proz

            myFilmstripBar.Text = Translation.AdDetectiveRunning & " - " & proz.ToString & "%"
            myFilmstripBar.Invalidate()

        End Sub
#End Region



        Private Sub LoadRecordVideoToScreen()
            AnimWaiting.Visible = True
            'Exit Sub
            If IO.File.Exists(AktRecToCut.Filename) Then
                If VRD.MediaToCut = AktRecToCut.VideoFilename Then
                    'Me.CutList.ListItems = Translation.TempCutListItems
                    If VRD.AdScanInProgress = False Then
                        MyLog.DebugM("Lade die gespeicherten Cuts...")
                        For i = 0 To VRD.CutMarkerList.Count - 1
                            If CutList.ListItems.Count Mod 2 = 0 Then
                                Dim lItem As New GUIListItem("StartCut: ")
                                lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                                lItem.Label2 = GetPlayerTimeString(VRD.CutMarkerList(i))
                                GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                            Else
                                Dim lItem As New GUIListItem("EndCut: ")
                                lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                                lItem.Label2 = GetPlayerTimeString(VRD.CutMarkerList(i))
                                GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                            End If
                        Next i
                        MyLog.DebugM("alle Cuts geladen.")
                    End If
                Else
                    myFilmstripBar.StartCutValues.Clear()
                    myFilmstripBar.EndCutValues.Clear()

                    VRD.LoadMediaToCut(Replace(AktRecToCut.Filename, "xml", "ts"))
                    Application.DoEvents()
                    'Die CutOnPlay aus der Config laden und evtl. den Cut erstellen

                    Dim configCutOnPlay As Boolean = HelpConfig.GetConfigString(ConfigKey.CutOnPlay)
                    If Convert.ToBoolean(configCutOnPlay) = True Then
                        MyLog.Info("In den Einstellungen ist 'CutOnPlay' auf '{0}' deshalb wird ein erster Marker gesetzt.", configCutOnPlay.ToString)
                        MakeCut(True)
                    End If
                End If



                'Die Cutbar mit den ersten Bilder füllen
                If VRD.AdScanInProgress = False Then MyCutbar.FilmImages = CreateFilmImageList()
                If VRD.AdScanInProgress = False Then g_Player.Play(Replace(AktRecToCut.Filename, "xml", "ts"), g_Player.MediaType.Video)



                SetPlayerLabels(VRD)


                LoadFilmstripbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
                LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)

                btnCut.Visible = True
                btnCutNow.Visible = True

            Else
                MyLog.Warn("Error to load the Video {0}", AktRecToCut.Filename)
                GUIWindowManager.GetWindow(1208)
            End If
            AnimWaiting.Visible = False
            myFilmstripBar.Invalidate()

            If VRD.AdScanInProgress Then
                AnimWaiting.Visible = True
                btnCut.Visible = False
                btnCutNow.Visible = False
            End If
        End Sub

        Private Sub ShowTextDialog(Header As String, Text As String)
            UnloadCutbar()
            UnloadFilmstripbar()
            Dim dlgNoEndmarker As GUIDialogNotify = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_NOTIFY, Integer)), GUIDialogNotify)
            dlgNoEndmarker.SetHeading(Header)
            dlgNoEndmarker.SetText(Text)
            dlgNoEndmarker.TimeOut = 5
            dlgNoEndmarker.DoModal(GetID)
            LoadFilmstripbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
            LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
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
            UnloadFilmstripbar()
            Dim dlgContext As GUIDialogMenu = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_MENU, Integer)), GUIDialogMenu)
            dlgContext.Reset()
            dlgContext.SetHeading("Cut")
            dlgContext.Add(Translation.DeleteCutDialog)
            dlgContext.Add(Translation.SeekToCutDialog)
            dlgContext.DoModal(GetID)

            If dlgContext.SelectedLabel = 0 Then
                DeleteSelCutFromList()
            End If
            If dlgContext.SelectedLabel = 1 Then
                g_Player.SeekAbsolute(VRD.CutMarkerList(CutList.SelectedListItemIndex) / 1000)
                'g_Player.Pause()
                If IsPlayerPaused Then GetFilmThumbnails(VRD.CutMarkerList(CutList.SelectedListItemIndex))
            End If
            LoadFilmstripbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
            LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)

            GUIWindowManager.Process()
            dlgContext.Reset()
            dlgContext = Nothing
        End Sub

        Private Sub DeleteSelCutFromList()
            Dim savedPosition As Long = VRD.GetCursorTime

            Dim oldList As List(Of Long) = VRD.CutMarkerList
            If CutList.SelectedListItemIndex Mod 2 = 0 Then
                oldList.RemoveAt(CutList.SelectedListItemIndex)
                Try
                    oldList.RemoveAt(CutList.SelectedListItemIndex)
                Catch

                End Try
            Else
                oldList.RemoveAt(CutList.SelectedListItemIndex - 1)
                oldList.RemoveAt(CutList.SelectedListItemIndex - 1)
            End If
            VRD.ClearAllSelections()
            CutList.Clear()
            myFilmstripBar.CutValues = ""
            Dim newCutlist As New List(Of Long)
            newCutlist.AddRange(oldList)
            For Each item In newCutlist
                If CutList.ListItems.Count Mod 2 = 0 Then
                    Dim lItem As New GUIListItem("StartCut: ")

                    TempStartValue = Convert.ToSingle((item / 1000) * 100 / g_Player.Duration)
                    VRD.MakeScreenshot(VRD.GetCursorTime, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuali.Thumbnail)
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"
                    lItem.Label2 = GetPlayerTimeString(item)
                    'CutList.ListItems.Add(lItem)
                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    VRD.AddMarker(item)
                Else
                    Dim lItem As New GUIListItem("EndCut: ")

                    TempEndValue = Convert.ToSingle((item / 1000) * 100 / g_Player.Duration)
                    lItem.Label2 = GetPlayerTimeString(item)
                    VRD.MakeScreenshot(item, Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp", VideoReDo.ScreenshotQuali.Thumbnail)
                    lItem.IconImage = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & CutList.ListItems.Count & ".bmp"


                    GUIControl.AddListItemControl(GetID, CutList.GetID, lItem)
                    myFilmstripBar.AddValues(TempStartValue, TempEndValue)
                    VRD.AddMarker(item)
                End If
                MyCutbar.Invalidate()

            Next
            VRD.CutMarkerList = newCutlist
            VRD.SeekToTime(savedPosition)
        End Sub

        Private Sub ShowContextMenu()
            If VRD.AdScanInProgress Then Exit Sub
            If IsPlayerPaused = False Then g_Player.Pause()
            UnloadCutbar()
            UnloadFilmstripbar()
            Dim dlgContext As GUIDialogMenu = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_MENU, Integer)), GUIDialogMenu)
            dlgContext.Reset()
            dlgContext.Add(Translation.StartAdDetectiveScan)
            dlgContext.Add(Translation.ClearCutlist)
            dlgContext.Add(Translation.EditEndFilename)
            If Left(VRD.ReDoVersion, 1) = 4 Then : dlgContext.Add(Translation.SavingProfile & ": " & VRD.AktSavingProfile) : End If
            dlgContext.Add(Translation.AudioSyncLabelContext)
            dlgContext.DoModal(GetID)

            If dlgContext.SelectedLabel = 0 Then
                CutList.Clear()
                Dim adScan As New Threading.Thread(AddressOf StarteAdScan)
                adScan.IsBackground = True
                adScan.Priority = Threading.ThreadPriority.BelowNormal
                AddHandler tmrAd.Tick, AddressOf AdScanTimerTick
                AddHandler VRD.AdScanCutAdded, AddressOf AdScanCutFinded
                AddHandler VRD.AdScanAborted, AddressOf AdScanAborted
                AddHandler VRD.AdScanFinished, AddressOf AdScanFinished
                tmrAd.Interval = 1000
                tmrAd.Enabled = True
                tmrAd.Start()
                'StarteAdScan()
                adScan.Start()
            End If
            If dlgContext.SelectedLabel = 1 Then
                CutList.Clear()
                myFilmstripBar.CutValues = ""
                myFilmstripBar.Invalidate()
                VRD.ClearAllSelections()
            End If
            If dlgContext.SelectedLabel = 2 Then
                Dim NewFilename As String = ShowKeyboard(AktRecToCut.SavingFilename)
                If NewFilename IsNot Nothing Then AktRecToCut.SavingFilename = NewFilename
            End If
            If dlgContext.SelectedLabel = 3 Then
                ShowProfileDialog()
            End If
            If dlgContext.SelectedLabel = 4 Then
                sliderAudioSync.Visible = True
                GUIControl.ShowControl(Me.GetID, sliderAudioSync.GetID)
                GUIControl.FocusControl(Me.GetID, sliderAudioSync.GetID)
                sliderAudioSync.SetRange(-1000, 1000)
                sliderAudioSync.IntValue = VRD.AudioSyncValue

            End If
            If dlgContext.SelectedLabel < 4 Then
                LoadFilmstripbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
                LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)
            End If


            GUIWindowManager.Process()
            dlgContext.Reset()
            dlgContext = Nothing
        End Sub

        Private Sub ShowProfileDialog()
            UnloadCutbar()
            UnloadFilmstripbar()
            Dim dlgProfiles As GUIDialogMenu = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_MENU, Integer)), GUIDialogMenu)
            dlgProfiles.Reset()
            dlgProfiles.SetHeading("Profile")
            For Each item In VRD.GetProfileList
                dlgProfiles.Add(item)
            Next
            dlgProfiles.DoModal(GetID)
            Dim newprofilename As String = "Nothing"
            Do
                If dlgProfiles.SelectedLabel > -1 Then
                    Dim dlgProfileDetail As GUIProfileDetail = CType(GUIWindowManager.GetWindow(1210), GUIProfileDetail)
                    dlgProfileDetail.Reset()
                    dlgProfileDetail.SetHeading(dlgProfiles.SelectedLabelText)
                    dlgProfileDetail.DoModal(GetID)
                    'MsgBox(dlgProfileDetail.SelectedLabelText)
                    newprofilename = dlgProfileDetail.SelectedLabelText
                    dlgProfileDetail = Nothing
                End If
            Loop While newprofilename = "Nothing"
            VRD.AktSavingProfile = newprofilename

            LoadFilmstripbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml", True), VideoWindow)
            LoadCutbar(GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml"), VideoWindow)

        End Sub

        Private Function ShowKeyboard(ByVal Text As String) As String
            Dim keyboard As VirtualKeyboard = DirectCast(GUIWindowManager.GetWindow(CInt(GUIWindow.Window.WINDOW_VIRTUAL_KEYBOARD)), VirtualKeyboard)
            If keyboard Is Nothing Then
                Return Nothing
            End If
            keyboard.Reset()
            keyboard.Label = Text

            keyboard.SetLabelAsInitialText(True)
            keyboard.DoModal(GetID)
            ' Do something here. The typed value is stored in "keyboard.Text" 
            If keyboard.IsConfirmed Then
                Return keyboard.Text
            Else
                Return Nothing
            End If
        End Function

       



    End Class




End Namespace