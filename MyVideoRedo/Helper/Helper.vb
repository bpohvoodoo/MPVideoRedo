Imports System.Windows.Forms
Imports MediaPortal.Dialogs
Imports MediaPortal.GUI.Library
Imports TvdbLib
Imports TvdbLib.Cache
Imports TvdbLib.Data
Imports MediaPortal.Profile
Imports MediaPortal.Configuration

Public Module Helper
    Friend VRD As VideoReDo
    'Friend Recs As clsRecordings

    Public AktRecToCut As clsRecordings.Recordings

    Public Function CreateFilmImageList() As System.Windows.Forms.ImageList
        MyLog.DebugM("Lade die CutBar mit den Bildern der ersten Frames...")
        Dim props As PropertyCollection = GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml")
        Dim AnzThumbs As Integer = props("ThumbnailsCount")
        Dim listFilmImg As New ImageList
        listFilmImg.ColorDepth = ColorDepth.Depth16Bit
        listFilmImg.ImageSize = New Drawing.Size(128, 128)
        Dim splitter As Integer = 0
        For i As Integer = 0 To AnzThumbs - 1
            listFilmImg.Images.Add(VRD.MakeScreenshotToClipboard(splitter + ((VRD.GetFramerate / 100) * i + 1), 7))

        Next
        MyLog.DebugM("Erledigt")
        Return listFilmImg
    End Function


    Public Function ParseSaveVideoFilename(ByVal Recording As clsRecordings.Recordings, Optional ByVal IsSerie As Boolean = False) As String
        Dim newFileName As String = Mid(Recording.VideoFilename, InStrRev(Recording.VideoFilename, "\") + 1)
        Dim ParseConfig As String
        If IsSerie Then
            ParseConfig = HelpConfig.GetConfigString(ConfigKey.SaveSeriesFilename)
            ParseConfig = Replace(ParseConfig, "%Title%", Recording.Title)
            ParseConfig = Replace(ParseConfig, "%ChannelName%", Recording.Channelname)
            ParseConfig = Replace(ParseConfig, "%StartTime%", Recording.StartTime)
            ParseConfig = Replace(ParseConfig, "%EndTime%", Recording.EndTime)
            ParseConfig = Replace(ParseConfig, "%EpisodeName%", Recording.Episodename)
            ParseConfig = Replace(ParseConfig, "%EpisodeNumber%", Recording.EpisodeNum)
            ParseConfig = Replace(ParseConfig, "%SeriesName%", Recording.Seriesname)
            ParseConfig = Replace(ParseConfig, "%Genre%", Recording.Genre)
            ParseConfig = Replace(ParseConfig, "%SeasonNumber%", Recording.SeriesNum)

            ParseConfig = CleanFilename(ParseConfig, "_")
        Else
            ParseConfig = HelpConfig.GetConfigString(ConfigKey.SaveFilename)
            ParseConfig = Replace(ParseConfig, "%Title%", Recording.Title)
            ParseConfig = Replace(ParseConfig, "%ChannelName%", Recording.Channelname)
            ParseConfig = Replace(ParseConfig, "%StartTime%", Recording.StartTime)
            ParseConfig = Replace(ParseConfig, "%EndTime%", Recording.EndTime)
            ParseConfig = Replace(ParseConfig, "%EpisodeName%", Recording.Episodename)
            ParseConfig = Replace(ParseConfig, "%EpisodeNumber%", Recording.EpisodeNum)
            ParseConfig = Replace(ParseConfig, "%SeriesName%", Recording.Seriesname)
            ParseConfig = Replace(ParseConfig, "%Genre%", Recording.Genre)
            ParseConfig = Replace(ParseConfig, "%SeasonNumber%", Recording.SeriesNum)

            ParseConfig = CleanFilename(ParseConfig, "_")
            If HelpConfig.GetConfigString(ConfigKey.CreateFilmfolder) Then
                Dim tFolder As String = HelpConfig.GetConfigString(ConfigKey.FilmFolderParsing)
                tFolder = Replace(tFolder, "%Title%", Recording.Title)
                tFolder = Replace(tFolder, "%ChannelName%", Recording.Channelname)
                tFolder = Replace(tFolder, "%StartTime%", Recording.StartTime)
                tFolder = Replace(tFolder, "%EndTime%", Recording.EndTime)
                tFolder = Replace(tFolder, "%EpisodeName%", Recording.Episodename)
                tFolder = Replace(tFolder, "%EpisodeNumber%", Recording.EpisodeNum)
                tFolder = Replace(tFolder, "%SeriesName%", Recording.Seriesname)
                tFolder = Replace(tFolder, "%Genre%", Recording.Genre)
                tFolder = Replace(tFolder, "%SeasonNumber%", Recording.SeriesNum)
                ParseConfig = CleanPathname(tFolder, "_") & "\" & CleanFilename(ParseConfig, "_")
            End If
        End If
        newFileName = ParseConfig


        newFileName += ".%ext%"
        Return newFileName
    End Function



    Public Function GetSaveImagePath(ByVal img As Drawing.Image, SeriesID As Integer) As String
        Try
            Dim mFolder As String = Config.GetFolder(Config.Dir.Thumbs) & "\VideoRedo\SeriesBanners"
            If IO.Directory.Exists(mFolder) Then

            Else
                IO.Directory.CreateDirectory(mFolder)
            End If
            Dim NewPath As String = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) & "\" & SeriesID.ToString & ".jpg"
            If IO.File.Exists(NewPath) Then
                MyLog.DebugM("Das angeforderte Bild war bereits unter '{0}' vorhanden. Gebe dieses zurück.(GetSaveImagePath)", NewPath)
                Return NewPath
            End If
            'IO.File.Delete(NewPath)
            img.Save(NewPath)
            MyLog.DebugM("Das angeforderte Bild wurde unter '{0}' gespeichert. Gebe neues Bild zurück.(GetSaveImagePath)", NewPath)
            Return NewPath
        Catch ex As Exception
            MyLog.Info("Das angeforderte Bild konnte nicht geladen werden.(GetSaveImagePath)")
            Return ""
        End Try
    End Function

    Public Function GetSaveThumbPath(ByVal Record As clsRecordings.Recordings) As String
        Try
            MyLog.DebugM("GetSaveThumbnailPath für Aufnahme: {0}", Record.Filename)
            Dim mFolder As String = ""
            mFolder = Config.GetFolder(Config.Dir.Thumbs) & "\VideoRedo"
            MyLog.DebugM("Thumbsfolder: " & mFolder)
            If IO.Directory.Exists(mFolder) Then

            Else
                MyLog.DebugM("Thumbnailfolder nicht vorhanden... erstelle Folder...")
                IO.Directory.CreateDirectory(mFolder)
                MyLog.DebugM("Thumbnailfolder erfolgreich erstellt.")
            End If


            Dim NewPath As String = mFolder & "\" & CleanFilename(Record.Title) & "_" & Record.StartTime.Ticks & ".jpg"


            If IO.File.Exists(NewPath) Then
                MyLog.DebugM("Das angeforderte Bild war vorhanden unter '{0}' und wird geladen.(GetSaveThumbPath)", NewPath)
                Return NewPath
            Else
                MyLog.DebugM("Das angeforderte Bild war NICHT vorhanden. Es wird versucht ein Bild aus der Datei zu extrahieren (GetShellVideoThumbnail)...")
                Dim img As Drawing.Bitmap = GetShellVideoThumbnail(Record.VideoFilename)
                If img Is Nothing Then
                    'img = New Drawing.Bitmap(100, 100, Drawing.Imaging.PixelFormat.Format32bppArgb)
                    img.Save(NewPath)
                Else
                    img.Save(NewPath)
                    MyLog.DebugM("Das angeforderte Bild wurde unter '{0}' gespeichert.(GetSaveThumbPath)", NewPath)
                End If
                Return NewPath
            End If

        Catch ex As Exception
            MyLog.Info("Das angeforderte Bild konnte nicht geladen werden.(GetSaveThumbPath)")
            Return ""
        End Try
    End Function



    Public Function GetShellVideoThumbnail(ByVal Filename As String) As Drawing.Bitmap
        Try
            Dim ShIcon As New ShellThumbnail
            ShIcon.DesiredSize = New System.Drawing.Size(330, 220)

            Return ShIcon.GetThumbnail(Filename)
        Catch ex As Exception
            MyLog.Info("Das Videothumbnail für " & Filename & " konnte leider nicht geladen werden.")
            Return Nothing
        End Try
    End Function

#Region "Dialoge"
    Friend Sub ShowNothingFoundDialog(ByVal windowID As Integer, ByVal Text As String, Optional ByVal HeaderText As String = "Nothing found")
        MyLog.DebugM("NothingFound Dialog wird erstellt mit Meldung: {0}", Text)
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
        MyLog.DebugM("NotifyDialog wird erstellt mit Meldung: {0}", Text)
        Dim dlg As GUIDialogNotify = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_NOTIFY, Integer)), GUIDialogNotify)

        Try

            dlg.SetHeading(Title)
            dlg.SetText(Text)
            dlg.TimeOut = 5
            dlg.DoModal(WindowID)
            GUIWindowManager.Process()
            dlg.Reset()
            dlg = Nothing
            'Threading.Thread.CurrentThread.Sleep(2000)
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
        MyLog.DebugM("DebugDialog wird erstellt mit Meldung: {0}", Text)
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

        MyLog.DebugM("ErrorDialog wird erstellt mit Meldung: {0}", Text)
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

    Friend Function ShowYeyNoDialog(ByVal WindowID As Integer, ByVal Title As String, ByVal Text As String) As Boolean
        MyLog.DebugM("Erstelle YesNo-Dialog... WindowID:'{0}', Title:'{1}', Text:'{2}'", WindowID, Title, Text)
        Dim dlgDelRec As GUIDialogYesNo = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_YES_NO, Integer)), GUIDialogYesNo)
        dlgDelRec.SetHeading(Title)
        dlgDelRec.SetLine(1, Text)
        dlgDelRec.DoModal(WindowID)
        MyLog.DebugM("Dialog erstellt...")
        If dlgDelRec.IsConfirmed Then
            MyLog.DebugM("Dialog wurde mit JA beantwortet")
            Return True
        Else
            MyLog.DebugM("Dialog wurde mit NEIN beantwortet")
            Return False
        End If
    End Function

#End Region

    Public Function GetNegativeInt(ByVal PositiveInt) As Integer
        Return PositiveInt * (-1)
    End Function

    Public Function HasPathSubDirectories(ByVal Path As String) As Boolean
        MyLog.DebugM("Prüfe ob Ordner Unterordner hat...")
        Dim aktDir As New IO.DirectoryInfo(Path)
        If aktDir.Exists Then
            If aktDir.GetDirectories().Count > 0 Then
                MyLog.DebugM("Es gibt {0} Unterordner", aktDir.GetDirectories.Count)
                Return True
            Else
                MyLog.DebugM("Es gibt keine Unterordner mehr")
                Return False
            End If
        Else
            MyLog.Warn("HasPathSubDirectories gibt zurück das der Pfad nicht korrekt ist.")
            Return False
        End If

    End Function

    Public Function CleanFilename(ByVal sFilename As String, Optional ByVal sChar As String = "") As String

        ' alle nicht zulässigen Zeichen ersetzen
        Return System.Text.RegularExpressions.Regex.Replace(sFilename, "[\\/:?*^""<>|]", sChar)
    End Function

    Public Function CleanPathname(ByVal sFilename As String, Optional ByVal sChar As String = "") As String

        ' alle nicht zulässigen Zeichen ersetzen
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
    End Enum


    Public Declare Function FindWindow Lib "user32.dll" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long
    Public Declare Function SetFocusAPI Lib "user32.dll" Alias "SetFocus" (ByVal hWnd As Long) As Long
    Public Declare Function SetForegroundWindow Lib "user32" (ByVal hWnd As Long) As Long

    Public Sub SetMPtoForeground()
        Dim hWnd As Long
        hWnd = FindWindow(vbNullString, "MediaPortal - MyVideoRedo")
        SetForegroundWindow(hWnd)
    End Sub
End Module
