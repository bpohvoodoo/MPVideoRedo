Imports MediaPortal.GUI.Library
Imports MediaPortal.Player

Module PlayerHelper

    Dim AnzThumbs As Integer = 0
    Dim props As PropertyCollection = GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml")

    Friend Sub SetPlayerLabels(ByVal Redo As VideoReDo)
        Try
            If Redo Is Nothing Then
                MyLog.Warn("The VideoRedo object was 'Nothing' in 'SetPlayerLabels()'. Canceling.")
                Translator.SetProperty("#MyVideoRedo.Translation.Duration", "Error")
                Translator.SetProperty("#MyVideoRedo.Translation.Position", "Error")
                Translator.SetProperty("#MyVideoRedo.Translation.TimeLeft", "Error")

            End If
            Dim proz As Integer = g_Player.CurrentPosition * 100 / VRD.LoadedVideoDuration
            myFilmstripBar.LineMarkerPosition = proz
            myFilmstripBar.Invalidate()
            Translator.SetProperty("#MyVideoRedo.Translation.Duration", String.Format(Translation.Duration, GetPlayerTimeString(g_Player.Duration.ToString * 1000)))
            Translator.SetProperty("#MyVideoRedo.Translation.Position", String.Format(Translation.Position, GetPlayerTimeString(g_Player.CurrentPosition.ToString * 1000)))
            Translator.SetProperty("#MyVideoRedo.Translation.TimeLeft", String.Format(Translation.TimeLeft, GetPlayerTimeString((g_Player.Duration - g_Player.CurrentPosition) * 1000)))

        Catch ex As Exception
            MyLog.Error("Error in SetPlayerLabels: {0}", ex.ToString)
        End Try
    End Sub

    Friend Function GetFilmThumbnails(ByVal milliseconds As Long, Optional ByVal SelektedFrame As Integer = 3) As Boolean
        If AnzThumbs = 0 Then

            AnzThumbs = props("ThumbnailsCount")
        End If

        MyLog.DebugM("Generating {2} thumbnails for position {0} with a stepping of {1} ms ...", milliseconds, VRD.GetFramerate / 100, AnzThumbs)
        Try
            For i As Integer = 0 To AnzThumbs - 1
                If VRD Is Nothing Then Exit Function
                Dim factor As Integer = (AnzThumbs - 1) / 2
                If i < factor Then MyCutbar.Filmbitmaps.Item(i) = VRD.MakeScreenshotToClipboard(milliseconds - ((VRD.GetFramerate / 100) * (factor - i)), VideoReDo.ScreenshotQuali.Schlecht, i)
                If VRD Is Nothing Then Exit Function
                If i = factor Then MyCutbar.Filmbitmaps.Item(i) = VRD.MakeScreenshotToClipboard(milliseconds, VideoReDo.ScreenshotQuali.Schlecht, i)
                If VRD Is Nothing Then Exit Function
                If i > factor Then MyCutbar.Filmbitmaps.Item(i) = VRD.MakeScreenshotToClipboard(milliseconds + ((VRD.GetFramerate / 100) * (GetNegativeInt(factor - i))), VideoReDo.ScreenshotQuali.Schlecht, i)
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
            VRD.SeekToTime(milliseconds)
            'Für ein Vorschaubild welches in einem Image im Skin verwendet werden kann
            Dim tI As System.Drawing.Image = VRD.MakeScreenshotToClipboard(milliseconds)
            tI.Save(Environment.GetFolderPath(Environment.SpecialFolder.InternetCache & "\TempVideoRedoImage.png"))
            Translator.SetProperty("#CurrentFrame", Environment.SpecialFolder.InternetCache & "\TempVideoRedoImage.png")
        Catch ex As Exception
            MyLog.Info(ex.Message)
        End Try
        MyLog.DebugM("Done.")
    End Function

    Friend Function GetPlayerTimeString(ByVal milliseconds As Long) As String
        Dim ts As TimeSpan = TimeSpan.FromMilliseconds(milliseconds)
        Return Format(ts.Hours, "00") & ":" & Format(ts.Minutes, "00") & ":" & Format(ts.Seconds, "00") & "." & Format(ts.Milliseconds, "000")
    End Function



End Module
