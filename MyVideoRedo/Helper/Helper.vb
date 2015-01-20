Imports MediaPortal.Configuration
Imports MediaPortal.Dialogs
Imports MediaPortal.GUI.Library
Imports MediaPortal.Profile
Imports MediaPortal.Util
Imports MyVideoRedo.MyVideoRedo
Imports TvdbLib
Imports TvdbLib.Cache
Imports TvdbLib.Data
Imports TvControl
Imports System.IO
Imports System.Windows.Forms

Public Module Helper
    Friend VRD As VideoReDo
    'Friend Recs As clsRecordings

    Public AktRecToCut As clsRecordings.Recordings

    Public Function CreateFilmImageList() As System.Windows.Forms.ImageList
        MyLog.DebugM("Loading the CutBar with pictures of the first frame ... ")
        Dim props As PropertyCollection = GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml")
        Dim AnzThumbs As Integer = props("ThumbnailsCount")
        Dim listFilmImg As New ImageList
        listFilmImg.ColorDepth = ColorDepth.Depth16Bit
        listFilmImg.ImageSize = New Drawing.Size(128, 128)
        Dim splitter As Integer = 0
        For i As Integer = 0 To AnzThumbs - 1
            listFilmImg.Images.Add(VRD.MakeScreenshotToClipboard(splitter + ((VRD.GetFramerate / 100) * i + 1), 7))
        Next
        MyLog.DebugM("Done.")
        Return listFilmImg
    End Function

    Public Function ParseSaveVideoFilename(ByVal Recording As clsRecordings.Recordings, Optional ByVal IsSerie As Boolean = False) As String
        'Dim newFileName As String = Mid(Recording.VideoFilename, InStrRev(Recording.VideoFilename, "\") + 1)
        Dim Filename As String
        Dim Folder As String = Nothing
        If IsSerie Then
            Filename = HelpConfig.GetConfigString(ConfigKey.SaveSeriesFilename)
            If HelpConfig.GetConfigString(ConfigKey.CreateSeriesfolder) Then
                Folder = HelpConfig.GetConfigString(ConfigKey.SeriesFolder)
                Folder = Parse(Recording, Folder)
            End If
        Else
            Filename = HelpConfig.GetConfigString(ConfigKey.SaveMovieFilename)
            If HelpConfig.GetConfigString(ConfigKey.CreateMoviefolder) Then
                Folder = HelpConfig.GetConfigString(ConfigKey.MovieFolder)
                Folder = Parse(Recording, Folder)
            End If
        End If
        Filename = Parse(Recording, Filename)
        Filename = CleanFilename(Filename, "_")
        Folder = Parse(Recording, Folder)
        Folder = CleanPathname(Folder, "_")
        Filename = Folder & "\" & Filename
        Filename += ".%ext%"
        Return Filename
    End Function

    Public Function GetSaveImagePath(ByVal img As Drawing.Image, SeriesID As Integer) As String
        Try
            Dim mFolder As String = Config.GetFolder(Config.Dir.Cache) & "\VideoRedo\SeriesBanners"
            If IO.Directory.Exists(mFolder) Then
            Else
                IO.Directory.CreateDirectory(mFolder)
            End If
            Dim NewPath As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & SeriesID.ToString & ".jpg"
            If IO.File.Exists(NewPath) Then
                MyLog.DebugM("The deserved thumbnail already exists in '{0}'. Returning path (GetSaveImagePath): ", NewPath)
                Return NewPath
            End If
            'IO.File.Delete(NewPath)
            img.Save(NewPath)
            MyLog.DebugM("The deserved thumbnail was saved at '{0}'. Returning path (GetSaveImagePath): ", NewPath)
            Return NewPath
        Catch ex As Exception
            MyLog.Info("Could not get the deserved thumbnail.(GetSaveImagePath)")
            Return Nothing
        End Try
    End Function

    Public Function GetSaveThumbPath(ByVal Record As clsRecordings.Recordings) As String
        'ffmpeg -an -ss 0:10:0 -t 0:0:0.001 -i "\\HTPC\Daten\Aufnahmen\American Blackout\American Blackout.ts" -f image2 -s 320x200 thumb.jpg
        Dim PreviewThumb As String
        Dim thumbnailFilename = System.IO.Path.GetFileNameWithoutExtension(Record.VideoFilename) + ".jpg"
        PreviewThumb = Thumbs.TVRecorded + "\\" + thumbnailFilename
        If Not Utils.FileExistsInCache(PreviewThumb) Then
            MyLog.DebugM("Thumbnail {0} does not exist in local thumbs folder - get it from TV server", PreviewThumb)
            Try
                Dim thumbData As Byte() = RemoteControl.Instance.GetRecordingThumbnail(thumbnailFilename)
                If (thumbData.Length > 0) Then
                    Dim fs As New FileStream(PreviewThumb, FileMode.Create)
                    fs.Write(thumbData, 0, thumbData.Length)
                    fs.Close()
                    fs.Dispose()
                    Utils.DoInsertExistingFileIntoCache(PreviewThumb)
                Else
                    MyLog.DebugM("Thumbnail {0} not found on TV server", PreviewThumb)
                End If
            Catch ex As Exception
                MyLog.DebugM("Error fetching thumbnail {0} from TV server - {1}", PreviewThumb, ex.Message)
            End Try
        End If
        If Utils.FileExistsInCache(PreviewThumb) Then
            Return PreviewThumb
            Exit Function
        Else
            Try
                MyLog.DebugM("GetSaveThumbnailPath for recording: {0}", Record.VideoFilename)
                Dim mFolder As String = ""
                mFolder = Config.GetFolder(Config.Dir.Cache) & "\VideoRedo"
                MyLog.DebugM("Thumbsfolder: " & mFolder)
                If IO.Directory.Exists(mFolder) Then
                Else
                    MyLog.DebugM("Thumbnailfolder does not exist. Creating folder.")
                    IO.Directory.CreateDirectory(mFolder)
                    MyLog.DebugM("Thumbnailfolder successfully created.")
                End If
                Dim NewPath As String = mFolder & "\" & CleanFilename(Record.Title) & "_" & Record.StartTime.Ticks & ".jpg"
                If IO.File.Exists(NewPath) Then
                    MyLog.DebugM("The deserved thumbnail already exists in '{0}' and is loaded (GetSaveThumbPath) from: ", NewPath)
                    Return NewPath
                Else
                    MyLog.DebugM("The deserved thumbnail does not exists . Trying to extract thumbnail from the videofile (GetShellVideoThumbnail)...")
                    Dim img As Drawing.Bitmap = GetShellVideoThumbnail(Record.VideoFilename)
                    If img Is Nothing Then
                        'img = New Drawing.Bitmap(100, 100, Drawing.Imaging.PixelFormat.Format32bppArgb)
                        img.Save(NewPath)
                    Else
                        img.Save(NewPath)
                        MyLog.DebugM("The deserved thumbnail was saved in '{0}' (GetSaveThumbPath).", NewPath)
                    End If
                    Return NewPath
                End If

            Catch ex As Exception
                MyLog.Info("The deserved thumbnail could not be loaded.(GetSaveThumbPath)")
                Return Nothing
            End Try
        End If
    End Function

    Public Function GetShellVideoThumbnail(ByVal Filename As String) As Drawing.Bitmap
        Try
            Dim ShIcon As New ShellThumbnail
            ShIcon.DesiredSize = New System.Drawing.Size(330, 220)
            Return ShIcon.GetThumbnail(Filename)
        Catch ex As Exception
            MyLog.Info("The deserved thumbnail " & Filename & " could not be loaded.")
            Return Nothing
        End Try
    End Function

#Region "Dialoge"
    Friend Sub ShowNothingFoundDialog(ByVal windowID As Integer, ByVal Text As String, Optional ByVal HeaderText As String = "Nothing found")
        MyLog.DebugM("Creating NothingFound Dialog with message: {0}", Text)
        Dim dlgNotFound As GUIDialogNotify = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_NOTIFY, Integer)), GUIDialogNotify)
        Try
            dlgNotFound.SetHeading(HeaderText)
            dlgNotFound.SetText(Text)
            dlgNotFound.TimeOut = 5
            dlgNotFound.DoModal(windowID)
            GUIWindowManager.Process()
            dlgNotFound.Reset()
            dlgNotFound = Nothing
        Catch ex As Exception
            dlgNotFound.Reset()
            dlgNotFound = Nothing
            MyLog.Error(ex.ToString)
        End Try
    End Sub



    Friend Sub ShowNotifyDialog(ByVal WindowID As Integer, ByVal Title As String, ByVal Text As String)
        MyLog.DebugM("Creating NotifyDialog with message: {0}", Text)
        Dim dlg As GUIDialogNotify = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_NOTIFY, Integer)), GUIDialogNotify)
        Try
            dlg.SetHeading(Title)
            dlg.SetText(Text)
            dlg.TimeOut = 5
            dlg.DoModal(WindowID)
            GUIWindowManager.Process()
            dlg.Reset()
            dlg = Nothing
        Catch ex As Exception
            Try
                dlg.Reset()
                dlg = Nothing
                MyLog.Error(ex.ToString)
            Catch
            End Try
        End Try
    End Sub

    Friend Sub ShowDebugDialog(ByVal windowID As Integer, ByVal Text As String)
        MyLog.DebugM("Creating DebugDialog with message: {0}", Text)
        Dim dlgNotFound As GUIDialogNotify = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_NOTIFY, Integer)), GUIDialogNotify)

        Try

            dlgNotFound.SetHeading("Debug-Message")
            dlgNotFound.SetText(Text)
            dlgNotFound.TimeOut = 5
            dlgNotFound.DoModal(windowID)
            GUIWindowManager.Process()
            dlgNotFound.Reset()
            dlgNotFound = Nothing
            'Threading.Thread.CurrentThread.Sleep(2000)
        Catch ex As Exception
            Try
                dlgNotFound.Reset()
                dlgNotFound = Nothing
                MyLog.Error(ex.ToString)
            Catch
            End Try
        End Try
    End Sub

    Friend Sub ShowErrorDialog(ByVal windowID As Integer, ByVal Text As String)
        MyLog.DebugM("Creating ErrorDialog with message: {0}", Text)
        Dim dlgNotFound As GUIDialogNotify = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_NOTIFY, Integer)), GUIDialogNotify)
        Try
            dlgNotFound.SetHeading("Error-Message")
            dlgNotFound.SetText(Text)
            dlgNotFound.TimeOut = 10
            dlgNotFound.DoModal(windowID)
            GUIWindowManager.Process()
            dlgNotFound.Reset()
            dlgNotFound = Nothing
            'Threading.Thread.CurrentThread.Sleep(2000)
        Catch ex As Exception
            Try
                dlgNotFound.Reset()
                dlgNotFound = Nothing
                MyLog.Error(ex.ToString)
            Catch
            End Try
        Finally

        End Try
    End Sub
#End Region

    Public Function HasPathSubDirectories(ByVal Path As String) As Boolean
        MyLog.DebugM("Checking for existance of subfolders in the folder ...")
        Dim aktDir As New IO.DirectoryInfo(Path)
        If aktDir.Exists Then
            If aktDir.GetDirectories().Count > 0 Then
                MyLog.DebugM("There are {0} subfolders", aktDir.GetDirectories.Count)
                Return True
            Else
                MyLog.DebugM("There are no more subfolders.")
                Return False
            End If
        Else
            MyLog.Warn("HasPathSubDirectories returns that the path is not correct.")
            Return False
        End If
    End Function

    Public Function CleanFilename(ByVal sFilename As String, Optional ByVal sChar As String = "") As String
        ' replace all ineligible characters
        Return System.Text.RegularExpressions.Regex.Replace(sFilename, "[\\/:?*^""<>|]", sChar)
    End Function

    Public Function CleanPathname(ByVal sFilename As String, Optional ByVal sChar As String = "") As String
        ' replace all ineligible characters
        Return System.Text.RegularExpressions.Regex.Replace(sFilename, "[/:?*^""<>|]", sChar)
    End Function

    Public Function GetGUIWindow(ByVal Windows As enumWindows) As Integer
        Return Convert.ToInt16(Windows)
    End Function

    Public Enum enumWindows
        GUIstart = 1208
        GUIMain = 1209
        GUIProfileDetails = 1210
        GUISave = 1211
        GUISaveProgress = 1212
    End Enum

    Public Declare Function FindWindow Lib "user32.dll" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long
    Public Declare Function SetFocusAPI Lib "user32.dll" Alias "SetFocus" (ByVal hWnd As Long) As Long
    Public Declare Function SetForegroundWindow Lib "user32" (ByVal hWnd As Long) As Long

    Public Sub SetMPtoForeground(ModuleScreen As String)
        Dim hWnd As Long
        hWnd = FindWindow(vbNullString, "MediaPortal - " + ModuleScreen)
        SetForegroundWindow(hWnd)
    End Sub

    Public Sub GetProfileDetail(profile As String)
        Dim SavingFilename As String
        If Left(VRD.ReDoVersion, 1) = 4 Then
            SavingFilename = Replace(AktRecToCut.SavingFilename, "%ext%", VRD.GetProfileInfo(profile).Filetype.ToLower)
        Else
            SavingFilename = Replace(AktRecToCut.SavingFilename, "%ext%", "mpeg")
        End If
        Translator.SetProperty("#Saving.Name", SavingFilename)
        Translator.SetProperty("#Saving.Profile", profile)
        Translator.SetProperty("#Profile.Encodingtype", VRD.GetProfileInfo(profile).Encodingtype)
        Translator.SetProperty("#Profile.Filetype", VRD.GetProfileInfo(profile).Filetype)
        Translator.SetProperty("#Profile.Resolution", VRD.GetProfileInfo(profile).Resolution)
        Translator.SetProperty("#Profile.Ratio", VRD.GetProfileInfo(profile).Ratio)
        Translator.SetProperty("#Profile.Deinterlacemode", VRD.GetProfileInfo(profile).DeintarlaceModus)
        Translator.SetProperty("#Profile.Framerate", VRD.GetProfileInfo(profile).FrameRate)

    End Sub

    Public Function Parse(ByVal Recording As clsRecordings.Recordings, ByVal ParseConfig As String) As String
        ParseConfig = Replace(ParseConfig, "%OriginalFilename%", Recording.Filename)
        ParseConfig = Replace(ParseConfig, "%Title%", Recording.Title)
        ParseConfig = Replace(ParseConfig, "%ChannelName%", Recording.Channelname)
        ParseConfig = Replace(ParseConfig, "%StartTime%", Recording.StartTime)
        ParseConfig = Replace(ParseConfig, "%EndTime%", Recording.EndTime)
        ParseConfig = Replace(ParseConfig, "%EpisodeName%", Recording.Episodename)
        ParseConfig = Replace(ParseConfig, "%EpisodeNumber%", Recording.EpisodeNum)
        ParseConfig = Replace(ParseConfig, "%SeriesName%", Recording.Seriesname)
        ParseConfig = Replace(ParseConfig, "%Genre%", Recording.Genre)
        ParseConfig = Replace(ParseConfig, "%SeasonNumber%", Recording.SeriesNum)
        Return ParseConfig
    End Function

    Public Function ShowKeyboard(ByVal Text As String, ByVal WindowID As Integer) As String
        Dim keyboard As VirtualKeyboard = DirectCast(GUIWindowManager.GetWindow(CInt(GUIWindow.Window.WINDOW_VIRTUAL_KEYBOARD)), VirtualKeyboard)
        If keyboard Is Nothing Then
            Return Nothing
        End If
        keyboard.Reset()
        keyboard.Text = Text
        keyboard.DoModal(WindowID)
        ' Do something here. The typed value is stored in "keyboard.Text" 
        If keyboard.IsConfirmed Then
            If keyboard.Text.Length = 0 Then Return Text
            Return keyboard.Text
        Else
            Return Nothing
        End If
    End Function

    Public Function ShowYesNoDialog(ByVal WindowID As Integer, ByVal Title As String, ByVal Text1 As String, Optional ByVal Text2 As String = "", Optional ByVal Text3 As String = "") As Boolean
        MyLog.DebugM("Creating YesNo-Dialog... WindowID:'{0}', Title:'{1}', Text:'{2} {3} {4}'", WindowID, Title, Text1, Text2, Text3)
        Dim dlgDelRec As GUIDialogYesNo = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_YES_NO, Integer)), GUIDialogYesNo)
        dlgDelRec.SetHeading(Title)
        dlgDelRec.SetLine(1, Text1)
        dlgDelRec.SetLine(2, Text2)
        dlgDelRec.SetLine(3, Text3)
        dlgDelRec.DoModal(WindowID)
        MyLog.DebugM("Dialog created...")
        If dlgDelRec.IsConfirmed Then
            MyLog.DebugM("Dialog was answered with YES.")
            Return True
        Else
            MyLog.DebugM("Dialog was answered with NO.")
            Return False
        End If
    End Function

    Public Sub ShowProfileDialog(ByVal GetID As Integer)
        Dim dlgProfiles As GUIDialogMenu = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_MENU, Integer)), GUIDialogMenu)
        dlgProfiles.Reset()
        For Each item In VRD.GetProfileList
            dlgProfiles.Add(item)
        Next
        dlgProfiles.SetHeading(Translation.SavingProfile)
        dlgProfiles.DoModal(GetID)
        If HelpConfig.GetConfigString(ConfigKey.ProfileDetails) = False Then
            Dim newprofilename As String = "Nothing"
            Do
                If dlgProfiles.SelectedLabel > -1 Then
                    Dim dlgProfileDetail As GUIProfileDetail = CType(GUIWindowManager.GetWindow(enumWindows.GUIProfileDetails), GUIProfileDetail)
                    dlgProfileDetail.Reset()
                    dlgProfileDetail.SetHeading(dlgProfiles.SelectedLabelText)
                    dlgProfileDetail.DoModal(GetID)
                    newprofilename = dlgProfileDetail.SelectedLabelText
                    dlgProfileDetail = Nothing
                Else
                    Exit Sub
                End If
            Loop While newprofilename = "Nothing"
            VRD.AktSavingProfile = newprofilename
        Else
            VRD.AktSavingProfile = dlgProfiles.SelectedLabelText
            GetProfileDetail(dlgProfiles.SelectedLabelText)
        End If
    End Sub
End Module