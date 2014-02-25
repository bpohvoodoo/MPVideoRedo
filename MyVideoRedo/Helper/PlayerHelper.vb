Imports MediaPortal.GUI.Library
Imports MediaPortal.Player

Module PlayerHelper

    Dim AnzThumbs As Integer = 0
    Dim props As PropertyCollection = GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml")

    Friend Sub SetPlayerLabels(ByVal Redo As VideoReDo)
        Try
            If Redo Is Nothing Then
                MyLog.Warn("Das VideoRedo Objekt war in 'SetPlayerLabels()' Nothing, es wird abgebrochen.")
                Translator.SetProperty("#MyVideoRedo.Translation.duration", "Error")
                Translator.SetProperty("#MyVideoRedo.Translation.position", "Error")
                Translator.SetProperty("#MyVideoRedo.Translation.resttime", "Error")

            End If
            Dim proz As Integer = g_Player.CurrentPosition * 100 / VRD.LoadedVideoDuration
            myFilmstripBar.LineMarkerPosition = proz
            myFilmstripBar.Invalidate()
            Translator.SetProperty("#MyVideoRedo.Translation.duration", String.Format(Translation.duration, GetPlayerTimeString(g_Player.Duration.ToString * 1000)))
            Translator.SetProperty("#MyVideoRedo.Translation.position", String.Format(Translation.position, GetPlayerTimeString(g_Player.CurrentPosition.ToString * 1000)))
            Translator.SetProperty("#MyVideoRedo.Translation.resttime", String.Format(Translation.resttime, GetPlayerTimeString((g_Player.Duration - g_Player.CurrentPosition) * 1000)))

        Catch ex As Exception
            MyLog.Error("Fehler in SetPlayerLabels:{0}", ex.ToString)
        End Try
    End Sub

    Friend Function GetFilmThumbnails(ByVal Millisekunden As Long, Optional ByVal SelektedFrame As Integer = 3) As Boolean
        If AnzThumbs = 0 Then

            AnzThumbs = props("ThumbnailsCount")
        End If

        MyLog.DebugM("Generiere {2} Thumbnails für Grundposition {0} mit einem Step von {1} ms...", Millisekunden, VRD.GetFramerate / 100, AnzThumbs)
        Try
            For i As Integer = 0 To AnzThumbs - 1
                If VRD Is Nothing Then Exit Function
                Dim factor As Integer = (AnzThumbs - 1) / 2
                If i < factor Then MyCutbar.Filmbitmaps.Item(i) = VRD.MakeScreenshotToClipboard(Millisekunden - ((VRD.GetFramerate / 100) * (factor - i)), VideoReDo.ScreenshotQuali.Schlecht, i)
                If VRD Is Nothing Then Exit Function
                If i = factor Then MyCutbar.Filmbitmaps.Item(i) = VRD.MakeScreenshotToClipboard(Millisekunden, VideoReDo.ScreenshotQuali.Schlecht, i)
                If VRD Is Nothing Then Exit Function
                If i > factor Then MyCutbar.Filmbitmaps.Item(i) = VRD.MakeScreenshotToClipboard(Millisekunden + ((VRD.GetFramerate / 100) * (GetNegativeInt(factor - i))), VideoReDo.ScreenshotQuali.Schlecht, i)
            Next
            If VRD Is Nothing Then Exit Function
            'MyCutbar.Filmbitmaps.Item(0) = VRD.MakeScreenshotToClipboard(Millisekunden - ((VRD.GetFramerate / 100) * 2))
            'MyCutbar.Filmbitmaps.Item(1) = VRD.MakeScreenshotToClipboard(Millisekunden - (VRD.GetFramerate / 100))
            'MyCutbar.Filmbitmaps.Item(2) = VRD.MakeScreenshotToClipboard(Millisekunden)
            'MyCutbar.Filmbitmaps.Item(3) = VRD.MakeScreenshotToClipboard(Millisekunden + (VRD.GetFramerate / 100))
            'MyCutbar.Filmbitmaps.Item(4) = VRD.MakeScreenshotToClipboard(Millisekunden + ((VRD.GetFramerate / 100) * 2))
            'MyLog.DebugM("Thumbnails erfolgreich generiert, setze Linemarkerposition der Bar auf {0}", (100 / AnzThumbs) * (SelektedFrame))
            MyCutbar.LineMarkerPosition = 50
            'VRD zurücksetzten zum aktuelen Frame
            VRD.SeekToTime(Millisekunden)
            'Für ein Vorschaubild welches in einem Image im Skin verwendet werden kann
            Dim tI As System.Drawing.Image = VRD.MakeScreenshotToClipboard(Millisekunden)
            tI.Save(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache & "\TempVideoRedoImage.png"))
            Translator.SetProperty("#CurrentFrame", Environment.SpecialFolder.InternetCache & "\TempVideoRedoImage.png")
        Catch ex As Exception
            MyLog.Info(ex.Message)
        End Try
        MyLog.DebugM("Erfolgreich")
    End Function

    Friend Function GetPlayerTimeString(ByVal Millisekunden As Long) As String
        Dim ts As TimeSpan = TimeSpan.FromMilliseconds(Millisekunden)
        Return Format(ts.Hours, "00") & ":" & Format(ts.Minutes, "00") & ":" & Format(ts.Seconds, "00") & "." & Format(ts.Milliseconds, "000")
    End Function



End Module
