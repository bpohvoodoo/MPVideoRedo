Imports System
Imports System.IO
Imports System.Windows.Forms
Imports MediaPortal.GUI.Library
Imports MediaPortal.Dialogs
Imports MediaPortal.Player
Imports MediaPortal.Profile
Imports MediaPortal.Configuration

Imports TvdbLib
Imports TvdbLib.Cache
Imports TvdbLib.Data




Namespace MyVideoRedo
    <PluginIcons("MyVideoRedo.hover_myVideoReDo.png", "MyVideoRedo.myVideoReDo_disbled.png")> _
    Public Class GUIStart
        Inherits GUIWindow
        Implements ISetupForm

#Region "Skin Controls"
        <SkinControlAttribute(10)> _
        Protected ctlRecList As GUIListControl = Nothing
        <SkinControlAttribute(40)> _
        Protected ctlEpisodesList As GUIListControl = Nothing
        <SkinControlAttribute(4)> _
        Protected ctlCheckUseAsSeries As GUICheckButton = Nothing
        <SkinControlAttribute(60)> _
        Protected ctlDummyAsSeries As GUILabelControl = Nothing
        <SkinControlAttribute(52)> _
        Protected ctlWaiting As GUIAnimation = Nothing
        <SkinControlAttribute(51)> _
        Protected ctlWaitingEpisodes As GUIAnimation = Nothing
        <SkinControlAttribute(32)> _
        Protected ctlTextBoxSeriesDescription As GUITextScrollUpControl = Nothing
        <SkinControlAttribute(21)> _
        Protected ctlbtnCutVideo As GUIButtonControl = Nothing
        <SkinControlAttribute(30)> _
        Protected ctlImgTest As GUIImage = Nothing
#End Region

#Region "iSetupFormImplementation"

        Public Function Author() As String Implements MediaPortal.GUI.Library.ISetupForm.Author
            Return "NoFear23m"
        End Function

        Public Function CanEnable() As Boolean Implements MediaPortal.GUI.Library.ISetupForm.CanEnable
            Return True
        End Function

        Public Function DefaultEnabled() As Boolean Implements MediaPortal.GUI.Library.ISetupForm.DefaultEnabled
            Return True
        End Function

        Public Function Description() As String Implements MediaPortal.GUI.Library.ISetupForm.Description
            Return "Plugin zum schneiden von Videos mit Hilfe von VideoRedo"
        End Function

        Public Function GetHome(ByRef strButtonText As String, ByRef strButtonImage As String, ByRef strButtonImageFocus As String, ByRef strPictureImage As String) As Boolean Implements MediaPortal.GUI.Library.ISetupForm.GetHome
            strButtonText = PluginName() : strButtonImage = String.Empty : strButtonImageFocus = String.Empty : strPictureImage = "hover_myVideoReDo.png" : Return True
        End Function

        Public Function GetWindowId() As Integer Implements MediaPortal.GUI.Library.ISetupForm.GetWindowId
            Return 1208
        End Function

        Public Function HasSetup() As Boolean Implements MediaPortal.GUI.Library.ISetupForm.HasSetup
            Return True
        End Function

        Public Overrides Function GetModuleName() As String
            Return PluginName()
        End Function

        Public Function PluginName() As String Implements MediaPortal.GUI.Library.ISetupForm.PluginName
            Return "MyVideoRedo"
        End Function

        Protected Overridable ReadOnly Property SerializeName() As String
            Get
                Return PluginName()
            End Get
        End Property

        Public Sub ShowPlugin() Implements MediaPortal.GUI.Library.ISetupForm.ShowPlugin
            'Damit die Config auch übersetzt wird
            Translator.TranslateSkin()
            Dim setup As New SetupForm : setup.Show()
        End Sub

        Public Overloads Overrides Property GetID() As Integer
            Get
                Return 1208
            End Get
            Set(ByVal value As Integer)
            End Set
        End Property


        Public Overloads Overrides Function Init() As Boolean
            'Beim initialisieren des Plugin den Screen laden
           AddHandler GUIGraphicsContext.form.KeyDown, AddressOf FormKeyDown
            Return Load(GUIGraphicsContext.Skin + "\MyVideoRedoStart.xml")
        End Function

#End Region

#Region "Variablen"
        Private RecRootPath As String
        Friend RecList As clsRecordings
        Private lastSelRecording As clsRecordings.Recordings
        Friend AktEpisode As TvdbEpisode
        Friend AktSerie As TvdbSeries
        'Der Thread für das abrufen der Serieninfos
        Dim trSeries As New Threading.Thread(AddressOf GetSeriesInfosBackground)
#End Region





        Protected Overrides Sub OnPageLoad()
            MyBase.OnPageLoad()
            
            GUIWindowManager.NeedRefresh()

            If GUIWindowManager.ActiveWindow = GetID Then
                'Erstmal irgendwas in die Labels schreiben damit es beim laden nicht so doof aussieht.
                Translator.SetProperty("#RecordingTitle", " ")
                Translator.SetProperty("#RecordingGenre", " ")
                Translator.SetProperty("#RecordingEpisodename", " ")

                'Wird gerade was geschnitten
                If VRD IsNot Nothing Then
                    If VRD.OutputInProgress = True Then
                        If GUIWindowManager.GetPreviousActiveWindow <> 1209 Then 'Wenn geschnitten wird dann direkt in das ProgressWindow gehen
                            GUIWindowManager.ActivateWindow(1211, True)
                            Exit Sub
                        End If
                        GUIButtonControl.DisableControl(GetID, Me.ctlbtnCutVideo.GetID)
                    Else
                        GUIButtonControl.EnableControl(GetID, Me.ctlbtnCutVideo.GetID)
                    End If
                End If

                If g_Player.Playing Then g_Player.StopAndKeepTimeShifting() 'Falls ein Stream läuft dann stoppen
                Translator.TranslateSkin()
                ctlWaiting.Visible = False
                ctlCheckUseAsSeries.Label = Translation.UseVideoAsSeries
                RecRootPath = HelpConfig.GetConfigString(ConfigKey.RecordingsPath)
                If RecRootPath = "" Or IO.Directory.Exists(RecRootPath) = False Then
                    ShowErrorDialog(Me.GetID, Translation.RecordingPathIncorrect)
                    GUIWindowManager.ActivateWindow(1211, True)
                    Exit Sub
                End If
                FillRecListControl(RecRootPath)

                If ctlRecList.ListItems.Count > 0 Then
                    For i As Integer = 0 To ctlRecList.ListItems.Count - 1
                        If ctlRecList.ListItems(i).IsFolder = False Then
                            ctlRecList.SelectedListItemIndex = i
                            SetRecordingsDetails(ctlRecList.SelectedListItem)
                            Exit For
                        End If
                    Next

                Else
                    'Wenn es keine Aufnahmen gibt
                    ShowNothingFoundDialog(GetID, Translation.NoRecordingsAviable, Translation.NothinFound)
                    GUIWindowManager.CloseCurrentWindow()
                    Exit Sub
                End If


                If VRD Is Nothing Then
                    'Debugmodus aus oder ein. Je nach dem wird das Fenster von VRD angezeigt oder nicht
                    If HelpConfig.GetConfigString(ConfigKey.DebugVideoRedo) Then
                        VRD = New VideoReDo(False)
                    Else
                        VRD = New VideoReDo(True)
                    End If
                    AddHandler VRD.QuickStreamFixNeeded, AddressOf QuickStreamFixIsNeeding
                End If

                MyLog.Info("VideoReDo Version:{0}", VRD.ReDoVersion)
                'Workaround um das Fenster von MP wieder in den Fordergrund zu bringen
                '#If DEBUG Then
                '#Else

                MyLog.DebugM("Bringe MediaPortal wieder in den Fordergrund...")
                Helper.SetMPtoForeground()
                MyLog.DebugM("Mediaportal wieder im Fordergrund")
                '#End If

            End If
        End Sub


        Public Overrides Sub OnAction(ByVal action As MediaPortal.GUI.Library.Action)
            MyBase.OnAction(action)
            Try
                If GUIWindowManager.ActiveWindow = GetID Then
                    If action.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_SELECT_ITEM Or action.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_MOVE_DOWN Or action.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_MOVE_UP Then
                        If ctlRecList.IsFocused Then
                            RecList_ItemSelected(False)
                        End If
                    End If
                    If action.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_SELECT_ITEM Then
                        If ctlEpisodesList.IsFocused Then
                            EpisodeList_ItemSelected()
                        End If
                    End If

                    If action.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_CONTEXT_MENU Then
                        ' MsgBox("Context")
                    End If
                    Translator.SetProperty("#RecordingNewFilename", lastSelRecording.SavingFilename)
                End If
            Catch ex As Exception
                MyLog.Error(ex)
            End Try

        End Sub


        Protected Overrides Sub OnClicked(ByVal controlId As Integer, ByVal control As MediaPortal.GUI.Library.GUIControl, ByVal actionType As MediaPortal.GUI.Library.Action.ActionType)
            MyBase.OnClicked(controlId, control, actionType)
            '---Recordingliste---
            If control Is ctlRecList Then
                RecList_ItemSelected(True)
            End If
            '---UseAsSeries Checkbutton---
            If control Is ctlCheckUseAsSeries Then
                btnUseAsSeries_Clicked()
            End If
            '--- Die Episodenliste---
            If control Is ctlEpisodesList Then
                EpisodeList_ItemSelected()
            End If
            '--- DerCut-Button ---
            If control Is ctlbtnCutVideo Then
                'GUIWindowManager.Clear()
                btnCutVideo_Clicked()
            End If
        End Sub







        ''' <summary>
        ''' Füllt das ListControl für Aufnahmen mit den Aufnahmen und den Ordnern im RecordingPath
        ''' </summary>
        ''' <param name="RecordingPath">Der Pfad der aktuell geladen werden soll</param>
        Private Sub FillRecListControl(ByVal RecordingPath As String)
            ctlRecList.ListItems.Clear()
            RecList = New clsRecordings(RecordingPath)
            MyLog.DebugM("Fülle Recordinglistcontrol mit Path {0}", RecordingPath)
            MyLog.DebugM("Es gibt im aktuellen Pfad {0} Aufnahmen zu laden.", RecList.lRecordings.Count)
            'Wenn es nicht der RecordingRoot ist dann .. einfügen
            If RecordingPath <> RecRootPath Then
                Dim lItem As New GUIListItem
                lItem.ItemId = ctlRecList.ListItems.Count - 1
                lItem.Label = ".."

                lItem.IconImage = "redoFolderBack.png"
                lItem.IsFolder = True
                lItem.Path = Directory.GetParent(RecordingPath).FullName
                MyLog.DebugM("Fülle Recordinglistcontrol mit Ordnerlabel {0} und Pfad: {1}", lItem.Label, lItem.Path)
                'ctlRecList.ListView.ListItems.Add(lItem)
                GUIControl.AddListItemControl(GetID, ctlRecList.GetID, lItem)
            End If
            'Erst Liste mit Ordnern Füllen
            Try
                For Each dire In Directory.GetDirectories(RecordingPath)
                    Dim lItem As New GUIListItem
                    lItem.ItemId = ctlRecList.ListItems.Count - 1
                    lItem.Label = Path.GetFileName(dire)
                    lItem.IconImage = "redoFolder.png"
                    lItem.IsFolder = True
                    lItem.Path = dire
                    MyLog.DebugM("Fülle Recordinglistcontrol mit Ordnerlabel {0} und Pfad: {1}", lItem.Label, lItem.Path)
                    GUIControl.AddListItemControl(GetID, ctlRecList.GetID, lItem)
                Next


                'Jetzt mit den Aufnamen im Pfad füllen
                For Each item As clsRecordings.Recordings In RecList.lRecordings
                    Dim lItem As New GUIListItem
                    lItem.Label = item.Title & " - " & item.Channelname
                    lItem.ItemId = ctlRecList.ListItems.Count - 1
                    lItem.Label2 = item.StartTime.Date
                    lItem.Path = item.VideoFilename

                    lItem.IconImage = GetSaveThumbPath(item)



                    lItem.IsFolder = False
                    MyLog.DebugM("Fülle Recordinglistcontrol mit VideoFile {0} und Pfad: {1}", lItem.Label, lItem.Path)
                    GUIControl.AddListItemControl(GetID, ctlRecList.GetID, lItem)
                Next
                ctlRecList.SelectedListItemIndex = 0
                MyLog.Info("Es wurden {0} Aufnahmen in der aktuellen Ansicht geladen.", RecList.lRecordings.Count)
            Catch ex As IO.IOException
                MyLog.Warn("Fehler in FillRecListControl():{0}", ex.ToString)
            End Try
        End Sub

        ''' <summary>
        ''' Recordingliste wurd ein Item selectiert bzw. wurde geklickt
        ''' </summary>
        ''' <param name="Sel"></param>
        ''' <remarks></remarks>
        Private Sub RecList_ItemSelected(ByVal Sel As Boolean)
            ctlCheckUseAsSeries.Selected = False
            ctlDummyAsSeries.Visible = False
            MyLog.DebugM("RecordingListControl wurde geklickt")
            'Ist es eine Datei oder ein Ordner

            If ctlRecList.SelectedListItem.IsFolder Then
                MyLog.DebugM("Auswahl ist ein Ordner. Auswahl:{0} ; Index:{1}", ctlRecList.SelectedListItem.Label, ctlRecList.SelectedItem)
                If Sel Then FillRecListControl(ctlRecList.SelectedListItem.Path)
                SetRecordingsDetails(ctlRecList.SelectedListItem)
            Else
                ctlCheckUseAsSeries.Visible = True
                ctlbtnCutVideo.Visible = True
                MyLog.DebugM("Auswahl ist ein File. Auswahl:{0} ; Index:{1}", ctlRecList.SelectedListItem.Label, ctlRecList.SelectedItem)
                SetRecordingsDetails(ctlRecList.SelectedListItem)
                If Sel Then GUIControl.FocusControl(GetID, ctlbtnCutVideo.GetID)
            End If

        End Sub

        ''' <summary>
        ''' Episodeliste wurde ein Item selectiert bzw. wurde geklickt
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub EpisodeList_ItemSelected()
            For Each item In ctlEpisodesList.ListItems
                If item.IconImage <> "" Then
                    item.IconImage = ""
                End If
            Next
            ctlEpisodesList.SelectedListItem.IconImage = "redoSelectedEpisode.png"
            AktEpisode = AktSerie.Episodes(ctlEpisodesList.SelectedListItemIndex)

            If AktSerie.Genre.Count > 0 Then lastSelRecording.Genre = AktSerie.Genre(0)
            lastSelRecording.SeriesNum = AktEpisode.SeasonNumber
            lastSelRecording.EpisodeNum = AktEpisode.EpisodeNumber
            lastSelRecording.Episodename = AktEpisode.EpisodeName
            lastSelRecording.Seriesname = AktSerie.SeriesName
            Translator.SetProperty("#RecordingNewFilename", lastSelRecording.SavingFilename)

        End Sub

        ''' <summary>
        ''' Die Sub für den Backgroundthread welche die Serieninfos abruft
        ''' </summary>
        Private Sub GetSeriesInfosBackground()
            Try
                Dim SetSerie As TvdbSeries = GetAktSerie(GetAktRecording(ctlRecList.SelectedListItem.Path))
                AktSerie = SetSerie
                ctlWaiting.Visible = False
                If SetSerie IsNot Nothing Then
                    ctlWaiting.Visible = True
                    ctlDummyAsSeries.Visible = True
                    FillSeriesSkinProperties(SetSerie)
                    ctlWaiting.Visible = False
                Else
                    ctlDummyAsSeries.Visible = False
                    ctlCheckUseAsSeries.Selected = False
                End If
            Catch ex As System.Threading.ThreadAbortException
                ctlWaiting.Visible = False
                ctlEpisodesList.ListItems.Clear()
                MyLog.DebugM("Backgroundthread wurde beendet")
            End Try
        End Sub

        ''' <summary>
        ''' Setzt die Labels im Skin mit den Daten der aktuellen Aufnahme und die Variable 'lastSelRecording'
        ''' </summary>
        ''' <param name="SelItem">Das aktuell selektierte Objekt in der GUIListControl</param>
        Private Sub SetRecordingsDetails(ByVal SelItem As GUIListItem)
            Try
                MyLog.DebugM("Fülle RecordingDetail-Labels im Skin. Aktuelle selektion: {0}", SelItem.Path)
                If SelItem.IsFolder Then
                    Translator.SetProperty("#RecordingTitle", Translation.Title & ": " & SelItem.Label)
                    Translator.SetProperty("#RecordingGenre", " ")
                    Translator.SetProperty("#RecordingEpisodename", " ")
                    Translator.SetProperty("#RecordingImage", "")
                    ctlbtnCutVideo.Visible = False : ctlCheckUseAsSeries.Visible = False
                Else
                    Dim item As clsRecordings.Recordings = GetAktRecording(SelItem.Path)
                    lastSelRecording = item

                    Translator.SetProperty("#RecordingTitle", Translation.Title & ": " & item.Title)
                    Translator.SetProperty("#RecordingGenre", Translation.Genre & ": " & item.Genre)

                    If item.SeriesNum = 0 OrElse item.EpisodeNum = 0 Then
                        Translator.SetProperty("#RecordingEpisodename", Translation.EpisodeTitle & ": " & item.Episodename)
                    Else
                        Dim SeriesNumb As String = "S" & item.SeriesNum.ToString("00") & "E" & item.EpisodeNum.ToString("00")
                        Translator.SetProperty("#RecordingEpisodename", Translation.EpisodeTitle & ": " & item.Episodename & " (" & SeriesNumb & ")")
                    End If

                    Translator.SetProperty("#RecordingNewFilename", Translation.NewFilename & ": " & item.VideoFilename)
                    Translator.SetProperty("#RecordingImage", SelItem.IconImage)

                    ctlbtnCutVideo.Visible = True : ctlCheckUseAsSeries.Visible = True
                End If
            Catch ex As Exception
                MyLog.Error("Fehler in SetRecordingsDetails. Fehler: {0}", ex.ToString)
            End Try
        End Sub

        ''' <summary>
        ''' Setzt die SkinPropertie mit den Infos einer Serie und füllt die Episodenliste
        ''' </summary>
        ''' <param name="Serie">Die Serie als TVdbSeries</param>
        Private Sub FillSeriesSkinProperties(ByVal Serie As TvdbSeries)
            MyLog.Info("Fülle Serien-SkinProperties mit Infos aus der Serie {0}", Serie.SeriesName)
            Dim selIndex As Integer = 0
            AktSerie = Serie
            Try
                Translator.SetProperty("#NewSeriesName", Serie.SeriesName)
                If Serie.PosterBanners.Count > 0 Then
                    Serie.PosterBanners(0).LoadBanner()
                    Dim SeriesBanner As String = GetSaveImagePath(Serie.PosterBanners(0).BannerImage, Serie.Id)
                    Translator.SetProperty("#Seriescover", SeriesBanner)
                    MyLog.DebugM("Serienbanner wurde von {0} geladen.", SeriesBanner)
                Else
                    'DEFAULT BANNER Laden
                    Translator.SetProperty("#Seriescover", " ")
                    MyLog.DebugM("Kein Serienbanner vorhanden - leehrstring geladen")
                End If
                Translator.SetProperty("#NewSeriesOverview", Serie.Overview)
                ctlTextBoxSeriesDescription.Label = Serie.Overview
                ctlEpisodesList.ListItems.Clear()
                ctlWaitingEpisodes.Visible = True
                MyLog.Info("Beginne mit dem Füllen der Episodenliste der Serie {0}. Es sind {1} Episoden vorhanden...", Serie.SeriesName, Serie.Episodes.Count)
                For Each eps As TvdbEpisode In Serie.Episodes
                    Dim epsLitem As New GUIListItem
                    epsLitem.Label = eps.EpisodeName
                    epsLitem.Label2 = String.Format("S{0}E{1}", eps.SeasonNumber, eps.EpisodeNumber)
                    MyLog.DebugM("Füge Episode {0} - {1} der GUI-List hinzu", epsLitem.Label, epsLitem.Label2)

                    Dim vergleich As New MyStringComparer

                    MyLog.Info("Vergleiche Epsisodentitel der Aufnahme ('{0}') mit dem Titel der OnlineEpisode ('{1}')", GetAktRecording(ctlRecList.SelectedListItem.Path).Episodename, eps.EpisodeName)

                    Dim VergleichProz As Single = 0
                    Try
                        If GetAktRecording(ctlRecList.SelectedListItem.Path).Episodename.Length < 3 Or eps.EpisodeName.Length < 3 Then
                            VergleichProz = 0
                        Else
                            VergleichProz = vergleich.IsEqual(GetAktRecording(ctlRecList.SelectedListItem.Path).Episodename, eps.EpisodeName)
                        End If
                    Catch ex As IndexOutOfRangeException
                        VergleichProz = 0
                        MyLog.Info("Überlauf beim vergleichen der beiden Strings festgestellt, folge wird übersprungen...")
                    Catch ex As Exception
                        VergleichProz = 0
                        MyLog.Warn("Fehler beim vergleichen der beiden Strings festgestellt. Fehler: " & ex.ToString)
                    End Try

                    MyLog.DebugM("Vergleich ergab eine Übereinstimmung von {0}%", VergleichProz * 100)
                    If VergleichProz > 0.9 Then
                        MyLog.Info("Der Vergleich ergab {0}% und wird somit markiert und die Veriablen werden aktualisiert. Aktuelle Episode: {1}", VergleichProz * 100, eps.EpisodeName)
                        'epsLitem.ThumbnailImage = "redoSelectedEpisode.png"
                        epsLitem.IconImage = "redoSelectedEpisode.png"
                        Translator.SetProperty("#NewSeriesName", Serie.SeriesName & " - " & String.Format("S{0}E{1}", eps.SeasonNumber, eps.EpisodeNumber))
                        selIndex = ctlEpisodesList.ListItems.Count
                        AktEpisode = eps
                    End If
                    GUIControl.AddListItemControl(GetID, ctlEpisodesList.GetID, epsLitem)
                Next
                ctlEpisodesList.SelectedListItemIndex = selIndex
                ctlEpisodesList.Item(selIndex).Selected = True
                GUIControl.RefreshControl(GetID, ctlEpisodesList.GetID)
                ctlWaitingEpisodes.Visible = False
                GUIControl.FocusControl(GetID, ctlEpisodesList.GetID)
                'ctlEpisodesList.Visible = True
            Catch ex As Exception
                MyLog.Error("Fehler in FillSeriesSkinProperties. Fehler: {0}", ex.ToString)
            End Try

        End Sub

        ''' <summary>
        ''' Durchsucht die clsRecordings nach übereinstimmung durch Pfad und gibt die Aufnahme als Objekt zurück
        ''' </summary>
        ''' <param name="Path">Den Pfad der Aufnahme</param>
        Private Function GetAktRecording(ByVal Path As String) As clsRecordings.Recordings
            For Each item As clsRecordings.Recordings In RecList.lRecordings
                If item.VideoFilename = Path Then
                    MyLog.DebugM("Gebe aktuelle Aufnahme zurück. Aktuell: {0}", item.Filename)
                    Return item
                    Exit For
                End If
            Next
            MyLog.Warn("Achtung, aktuell zurückgegebene Aufnahme ist Nothing")
            Return Nothing
        End Function

        ''' <summary>
        ''' Läd Online eine Serie nach den Angaben in einem RecordingsObjekt und gibt die Serie zurück
        ''' </summary>
        Private Function GetAktSerie(ByVal AktRec As clsRecordings.Recordings) As TvdbSeries
            Try
                MyLog.DebugM("GetAktSerie()")
                ctlDummyAsSeries.Visible = False
                ctlWaiting.Visible = True
                MyLog.DebugM("Instanziere den Replacer...")
                Dim Replacer As New clsSeriesReplacer

                Dim LanguageString As String = HelpConfig.GetConfigString(ConfigKey.FavSeriesLanguage)
                Try
                    LanguageString = Translator.Lang
                    MyLog.Info("Ermittelte Sprache:(Aus CultureInfo) {0}", LanguageString)
                Catch ex As Exception
                    LanguageString = HelpConfig.GetConfigString(ConfigKey.FavSeriesLanguage)
                    MyLog.Warn("Ermittelte Sprache:(Aus Config) {0}", LanguageString)
                End Try

                Dim prov As New XmlCacheProvider(HelpConfig.GetConfigString(ConfigKey.TVdbAPICachePath))
                Dim TheTVdbHandler As New TvdbHandler(prov, HelpConfig.GetConfigString(ConfigKey.TVdbAPI))
                Dim m_languages As List(Of TvdbLanguage) = TheTVdbHandler.Languages
                Dim SerieDirekt As TvdbLib.Data.TvdbSeries = Nothing
                Dim listFoundedSeries As New List(Of TvdbLib.Data.TvdbSearchResult)

                MyLog.DebugM("Initialisiere den Cache für TheTVdbLib")
                TheTVdbHandler.InitCache()

                MyLog.DebugM("Setzte tvDB-sprache...")
                'Seriensprache festlegen
                Dim myLanguages As TvdbLanguage = Nothing
                For l = 0 To m_languages.Count - 1
                    Debug.WriteLine(m_languages(l).Name)
                    If m_languages(l).Abbriviation = LanguageString Then myLanguages = m_languages(l)
                Next
                'Wenn nicht in der Sprache vorhanden dann Default Language nehmen (English)
                If myLanguages Is Nothing Then myLanguages = TvdbLanguage.DefaultLanguage
                MyLog.Info("tvDB-Sprache ist {0}", myLanguages.Name)

                MyLog.DebugM("Beginne mit dem unbenennen des Seriennamens für bessere Suchergebnisse")
                'Die ReplaceStrings laden damit wir die Serie unbenennen können
                Replacer = Replacer.Load()
                Dim ReplaceSeriesID As Integer = 0
                Dim NewSeriesTitle As String = AktRec.Title
                MyLog.Info("Originaler Serienname aus den Aufnahmen: {0}", NewSeriesTitle)
                If Replacer.ReplacerList.Count > 0 Then
                    MyLog.Info("Es wurden insgesamt {0} Replacer gefunden, beginne mit abarbeitung", Replacer.ReplacerList.Count)
                    For Each item In Replacer.ReplacerList

                        MyLog.Info("Vergleiche RecordingTitel '{0}' mit Originalstring aus Replacerklasse '{1}'", AktRec.Title.ToLower, item.OriginalString.ToLower)
                        If AktRec.Title.ToLower = item.OriginalString.ToLower Then
                            MyLog.DebugM("Werte waren gleich, ersetzte Suchstring für Serie")
                            MyLog.Info("Versuche ob der Replace {0} von {1} in eine Zahl gewandelt werden kann...", item.ReplaceString, item.OriginalString)
                            Int32.TryParse(item.ReplaceString, ReplaceSeriesID)
                            If ReplaceSeriesID > 0 Then
                                MyLog.Info("Erfolgreich umgewandelt, schleife wird verlassen da die Serie DIREKT geladen werden kann.")
                                Exit For
                            Else
                                MyLog.Info("{0} konnte nicht in eine Zahl umgewandelt werden", item.ReplaceString)
                            End If
                            NewSeriesTitle = Replace(NewSeriesTitle, item.OriginalString, item.ReplaceString)
                            MyLog.Info("Neuer Serientitel mit dem gesucht wird: {0}", NewSeriesTitle)
                            Exit For
                        Else
                            MyLog.Info("Werte waren ungleich, versuche nächsten Replacer")
                        End If
                    Next
                Else
                    MyLog.Info("Da keine Replacer gefunden wurden wird versucht die Serie durch kürzen des Titels zu finden.")
                    Dim cutIndex As Integer = InStr(NewSeriesTitle, " ")
                    If cutIndex > 0 Then NewSeriesTitle = Mid(NewSeriesTitle, 1, cutIndex - 1)
                    MyLog.Info("Suche mit dem String '{0}'", NewSeriesTitle)


                End If


                If ReplaceSeriesID > 0 Then
                    'direkt die Serie mit der ID holen
                    MyLog.Info("Serie wird direkt abgerufen mit der SeriesID {0}", ReplaceSeriesID)
                    SerieDirekt = TheTVdbHandler.GetSeries(ReplaceSeriesID, myLanguages, True, False, True)
                    MyLog.Info("Serie erfolgreich geladen. Serientitel: {0}", SerieDirekt.SeriesName)
                    ctlDummyAsSeries.Visible = True
                    Return SerieDirekt
                Else
                    'Suche nach Serien
                    MyLog.Info("Serie wird über die Engine mit Suchstring '{0}' gesucht.", NewSeriesTitle)
                    listFoundedSeries = TheTVdbHandler.SearchSeries(NewSeriesTitle)
                    MyLog.Info("Suche ergab {0} treffer.", listFoundedSeries.Count.ToString)
                End If
                'Wenn es nur ein Suchergebniss gibt dann direkt laden.
                If listFoundedSeries.Count = 1 Then
                    MyLog.Info("Es wurde nur {0} Serien gefunden, verwende diese", listFoundedSeries.Count)
                    MyLog.Info("Verwende Serie {0}", listFoundedSeries(0).SeriesName)
                    ctlDummyAsSeries.Visible = True
                    Return TheTVdbHandler.GetSeries(listFoundedSeries(0).Id, myLanguages, True, False, True)
                End If
                'Es gibt mehrere Ergebnisse
                If listFoundedSeries.Count > 0 Then
                    MyLog.Info("Es wurden {0} Serien gefunden, beginne mit erstellung des Dialogs zum auswählen", listFoundedSeries.Count)
                    Dim SeriesDlg As GUIDialogMenu = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_MENU, Integer)), GUIDialogMenu)
                    SeriesDlg.Reset()
                    SeriesDlg.SetHeading(Translation.ChooseSeries)
                    SeriesDlg.ShowQuickNumbers = False
                    For Each item In listFoundedSeries
                        MyLog.DebugM("Erstelle Listitem für Serie {0}...", item.SeriesName)
                        MyLog.DebugM("Rufe Serieninfos ab...")
                        Dim TempSerie As TvdbLib.Data.TvdbSeries = TheTVdbHandler.GetSeries(item.Id, myLanguages, True, False, True)
                        MyLog.DebugM("Infos abgerufen")
                        MyLog.DebugM("Lade Banner für Serie {0}", item.SeriesName)
                        Do Until TempSerie.BannersLoaded

                        Loop
                        MyLog.DebugM("Banner geladen")
                        Dim mItem As New GUIListItem()
                        mItem.Label = item.SeriesName
                        If TempSerie.PosterBanners.Count > 0 Then
                            TempSerie.PosterBanners(0).LoadBanner()
                            '    mItem.IconImageBig = GetSaveImagePath(TempSerie.PosterBanners(0).BannerImage, TempSerie.Id)
                            mItem.IconImage = GetSaveImagePath(TempSerie.PosterBanners(0).BannerImage, TempSerie.Id)

                            MyLog.DebugM("Poster geladen: {0}", GetSaveImagePath(TempSerie.PosterBanners(0).BannerImage, TempSerie.Id))
                        End If
                        SeriesDlg.Add(mItem)
                        MyLog.DebugM("Menüitem hinzugefügt")
                    Next

                    MyLog.DebugM("Erstelle Listitem für das suchen über die OnScreen Tastatur...")
                    Dim mItemKeyboard As New GUIListItem()
                    mItemKeyboard.Label = Translation.SearchWithAnotherString
                    'mItemKeyboard.IconImageBig = GetSaveImagePath(TempSerie.PosterBanners(0).BannerImage)
                    mItemKeyboard.IconImage = "redoKeyboard.png"
                    SeriesDlg.Add(mItemKeyboard)
                    MyLog.DebugM("Menüitem hinzugefügt")

                    ctlWaiting.Visible = False
                    MyLog.DebugM("Zeige Dialog für Serienauswahl...")
                    SeriesDlg.DoModal(GetID)
                    ctlWaiting.Visible = True
                    Dim selindex As Integer = SeriesDlg.SelectedLabel
                    'Bei abbruch Dialog zeigen
                    If selindex = -1 Then ShowNothingFoundDialog(GetID, Translation.UserAbortDialog, "Aborted") : Return Nothing
                    If selindex = listFoundedSeries.Count Then
                        Return GetSerieWithKeyboard(NewSeriesTitle)
                    End If
                    ctlDummyAsSeries.Visible = True
                    Return TheTVdbHandler.GetSeries(listFoundedSeries(selindex).Id, myLanguages, True, False, True)

                Else
                    Dim KeySerie As TvdbSeries = GetSerieWithKeyboard(NewSeriesTitle)
                    If KeySerie Is Nothing Then
                        'KEINE SERIE GEFUNDEN,ABBRUCHDIALOG ZEIGEN
                        ShowNothingFoundDialog(GetID, Translation.NoSeriesFoundDialog)
                        ctlDummyAsSeries.Visible = False
                        ctlWaiting.Visible = False
                        Return Nothing
                    Else
                        Return KeySerie
                    End If
                End If
            Catch ex As Exception
                MyLog.Error("Fehler in GetAktSerie() - Fehler: {0}", ex.ToString)
                Return Nothing
            End Try
        End Function


        Private Sub FormKeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            MyLog.DebugM("Form KeyDown. Key: {0}", e.KeyCode)
        End Sub







#Region "btnCutVideo & btnUseAsSeries"

        Private Sub btnUseAsSeries_Clicked()
            If ctlCheckUseAsSeries.Selected Then
                ctlWaiting.Visible = True
                ctlEpisodesList.ListItems.Clear()
                'Falls noch ein Thread läuft dann zuerst beenden
                If trSeries.IsAlive Then
                    trSeries.Abort()
                    ctlWaitingEpisodes.Visible = False
                    MyLog.DebugM("Warte auf beendigung des Backgroudthreads...")
                    Do Until trSeries.IsAlive = False
                        Threading.Thread.CurrentThread.Sleep(100)
                    Loop
                    MyLog.DebugM("Backgroudthreads wurde beendet")
                End If
                trSeries = New Threading.Thread(AddressOf GetSeriesInfosBackground)
                trSeries.IsBackground = True
                trSeries.Priority = Threading.ThreadPriority.Lowest
                trSeries.Start()
            Else
                ctlEpisodesList.Clear()
                ctlDummyAsSeries.Visible = False
                ctlWaiting.Visible = False
                ctlWaitingEpisodes.Visible = False
            End If
        End Sub

        Private Sub btnCutVideo_Clicked()
            If ctlCheckUseAsSeries.Selected Then
                'es ist eine Serie
                lastSelRecording.Genre = AktSerie.Genre(0)
                lastSelRecording.SeriesNum = AktEpisode.SeasonNumber
                lastSelRecording.EpisodeNum = AktEpisode.EpisodeNumber
                lastSelRecording.Episodename = AktEpisode.EpisodeName
                lastSelRecording.Seriesname = AktSerie.SeriesName
                lastSelRecording.SavingFilename = ParseSaveVideoFilename(lastSelRecording, True)
                AktRecToCut = lastSelRecording
            Else
                'es ist ein film
                ctlWaiting.Visible = True
                lastSelRecording.SavingFilename = ParseSaveVideoFilename(lastSelRecording)
                AktRecToCut = lastSelRecording
            End If
            MyLog.Info("LastSelRecording.Savingfilename: {0}", lastSelRecording.SavingFilename)

            GUIWindowManager.ActivateWindow(1209)

        End Sub

#End Region

#Region "Dialoge"


        Private Function GetSerieWithKeyboard(ByVal Text As String) As TvdbSeries
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
                AktRecToCut.Title = keyboard.Text
                Return GetAktSerie(AktRecToCut)
            Else
                Exit Function
            End If
        End Function

#End Region








        Protected Overrides Sub OnPageDestroy(ByVal new_windowId As Integer)
            MyBase.OnPageDestroy(new_windowId)
            If new_windowId < 1208 Or new_windowId > 1211 Then 'Wenn kein Fenster vom Plugin
                MyLog.DebugM("Startseite wird geschlossen...")
                'System.Diagnostics.Process.GetProcessesByName("VRDQuickstreamfix")(0).Kill()
                If VRD IsNot Nothing Then
                    MyLog.DebugM("VRD.CutMarkerList.count = {0} ; VRD is Nothing = {1}", VRD.CutMarkerList.Count, IIf(VRD Is Nothing, "True", "False").ToString)

                    'Dialog ob man wirklich beenden will
                    MyLog.DebugM("Zeige Dialog ob VRD gelöscht werden sollen...")
                    Dim dlgDelRec As GUIDialogYesNo = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_YES_NO, Integer)), GUIDialogYesNo)
                    dlgDelRec.SetHeading(Translation.CloseVRD)
                    dlgDelRec.SetLine(1, Translation.CloseVRD1)
                    dlgDelRec.DoModal(GetID)

                    If dlgDelRec.IsConfirmed Then
                        MyLog.DebugM("Dialog wurde bestätigt... VRD-Objekte werden zerstört.")
                        VRD.Close()
                        VRD.Dispose()
                        VRD = Nothing
                    Else
                        MyLog.DebugM("User hat den Dialog nicht bestätigt, VRD wird beendet.")
                    End If
                    MyLog.DebugM("Zerstöre Dialogobjekte...")
                    dlgDelRec.Reset()
                    dlgDelRec = Nothing
                    MyLog.DebugM("Dialogobjekte zerstört")
                End If
                MyLog.DebugM("Startseite geschlossen")
            Else
                'GUIWindowManager.Clear()
            End If
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        Private Sub QuickStreamFixIsNeeding(sender As Object, e As EventArgs)
            Dim Title As String = "QuickStreamfix needed..."
            Dim Text As String = "Die Datei benötigt einen Quickstreamfix, ohne diesen kann das File nicht bearbeitet werden. Möchtest du einen Quickstreamfix durchführen oder abbrechen?"
            Dim oldMedia As String = Nothing
            If VRD IsNot Nothing Then
                oldMedia = VRD.MediaToCut
                g_Player.Stop()
                VRD = Nothing
                Dim p() As Process = System.Diagnostics.Process.GetProcesses
                For Each item As Process In p
                    If item.ProcessName.Contains("ReDo") Then

                        item.Kill()
                        MyLog.DebugM("VideoRedo Process wurde gekillt...")
                        'Exit For
                    End If
                Next
            End If
            UnloadFilmstripbar()
            UnloadCutbar()
            If ShowYeyNoDialog(GUIWindowManager.ActiveWindow, Title, Text) = True Then
                If oldMedia IsNot Nothing Then
                    VRD = New VideoReDo(False)
                    VRD.LoadMediaToCut(oldMedia, True)
                    ctlWaiting.Visible = True
                    lastSelRecording.SavingFilename = ParseSaveVideoFilename(lastSelRecording)
                    AktRecToCut = lastSelRecording
                End If
                MyLog.Info("LastSelRecording.Savingfilename: {0}", lastSelRecording.SavingFilename)

                GUIWindowManager.ActivateWindow(1211)

            End If

        End Sub

    End Class
End Namespace
