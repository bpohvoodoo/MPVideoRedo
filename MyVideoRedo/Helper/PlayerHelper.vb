Imports MediaPortal.Configuration
Imports MediaPortal.GUI.Library
Imports MediaPortal.Player

Module PlayerHelper
    Dim props As PropertyCollection = GetCutbarProperties(GUIGraphicsContext.Skin + "\MyVideoRedo.xml")

    Friend Sub SetPlayerLabels(ByVal Redo As VideoReDo, ByVal position As Long)
        Try
            If Redo Is Nothing Then
                MyLog.Warn("The VideoRedo object was 'Nothing' in 'SetPlayerLabels()'. Canceling.")
                Translator.SetProperty("#MyVideoRedo.Translation.Duration", Translation.ErrorOccured)
                Translator.SetProperty("#MyVideoRedo.Translation.Position", Translation.ErrorOccured)
                Translator.SetProperty("#MyVideoRedo.Translation.TimeLeft", Translation.ErrorOccured)

            End If
            Dim proz As Integer = ((g_Player.CurrentPosition * 1000) / VRD.LoadedVideoDuration) * 100
            myFilmstripBar.LineMarkerPosition = proz
            myFilmstripBar.Invalidate()
            Translator.SetProperty("#MyVideoRedo.Translation.Duration", String.Format(Translation.Duration, GetPlayerTimeString(VRD.LoadedVideoDuration.ToString)))
            Translator.SetProperty("#MyVideoRedo.Translation.Position", String.Format(Translation.Position, GetPlayerTimeString(position.ToString)))
            Translator.SetProperty("#MyVideoRedo.Translation.TimeLeft", String.Format(Translation.TimeLeft, GetPlayerTimeString(VRD.LoadedVideoDuration - position)))


        Catch ex As Exception
            MyLog.Error("Error in SetPlayerLabels: {0}", ex.ToString)
        End Try
    End Sub

    Friend Function GetFilmstripThumbnails(ByVal milliseconds As Long, Optional ByVal EndCut As Boolean = false, Optional ByVal ThumbAmount As Integer = 0) As Boolean
        If ThumbAmount = 0 Then
            ThumbAmount = props("ThumbnailsCount")
        End If
        MyLog.DebugM("Generating {2} thumbnails for position {0} with a stepping of {1} ms ...", milliseconds, (100000 / VRD.GetFramerate), ThumbAmount)
        Dim factor As Integer = Int(ThumbAmount / 2)
        Try
            For i As Integer = 0 To ThumbAmount - 1
                If VRD Is Nothing Then Exit Function
                Dim temptime As Long = milliseconds + ((100000 / VRD.GetFramerate) * (i + 1 - factor))
                If (temptime < 0) Or (temptime > VRD.LoadedVideoDuration) Then
                    MyCutbar.Filmbitmaps.Item(i) = Nothing
                Else
                    MyCutbar.Filmbitmaps.Item(i) = VRD.MakeScreenshotToClipboard(temptime, VideoReDo.ScreenshotQuality.poor, i)
                End If
            Next
            MyCutbar.Invalidate()
            If VRD Is Nothing Then Exit Function
            MyCutbar.LineMarkerPosition = (factor / ThumbAmount) * 100
            'Für ein Vorschaubild welches in  einem Image im Skin verwendet werden kann
            If g_Player.Paused Then
                VRD.SeekToTime(milliseconds)
                Dim StillImage As System.Drawing.Image = VRD.MakeScreenshotToClipboard(milliseconds, VideoReDo.ScreenshotQuality.original)
                StillImage.Save(Config.GetFolder(Config.Dir.Thumbs) & "\VideoRedo\StillImage.png")
                MyLog.DebugM("Generating stillimage for #Currentframe for position {0} ", milliseconds)
                StillImage.Dispose()
            End If
        Catch ex As Exception
            MyLog.Info(ex.Message)
        End Try
        MyLog.DebugM("Done.")
    End Function


    Friend Function GetPlayerTimeString(ByVal milliseconds As Long) As String
        Dim ts As TimeSpan = TimeSpan.FromMilliseconds(milliseconds)
        Dim Frame As Integer
        Frame = Int(ts.Milliseconds / (100000 / VRD.GetFramerate))
        Return Format(ts.Hours, "00") & ":" & Format(ts.Minutes, "00") & ":" & Format(ts.Seconds, "00") & " F:" & Format(Frame, "00") & "/" & Format(VRD.GetFramerate / 100, "00")
    End Function



End Module
