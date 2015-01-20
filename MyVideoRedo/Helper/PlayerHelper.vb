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
            MyCutBar.LineMarkerPosition = proz
            MyCutBar.Invalidate()
            Translator.SetProperty("#MyVideoRedo.Translation.Duration", String.Format(Translation.Duration, GetPlayerTimeString(VRD.LoadedVideoDuration.ToString)))
            Translator.SetProperty("#MyVideoRedo.Translation.Position", String.Format(Translation.Position, GetPlayerTimeString(position.ToString)))
            Translator.SetProperty("#MyVideoRedo.Translation.TimeLeft", String.Format(Translation.TimeLeft, GetPlayerTimeString(VRD.LoadedVideoDuration - position)))


        Catch ex As Exception
            MyLog.Error("Error in SetPlayerLabels: {0}", ex.ToString)
        End Try
    End Sub

    Friend Function GetPlayerTimeString(ByVal milliseconds As Long) As String
        Dim ts As TimeSpan = TimeSpan.FromMilliseconds(milliseconds)
        Dim Frame As Integer
        Frame = Int(ts.Milliseconds / (100000 / VRD.GetFramerate))
        Return Format(ts.Hours, "00") & ":" & Format(ts.Minutes, "00") & ":" & Format(ts.Seconds, "00") & " F:" & Format(Frame, "00") & "/" & Format(VRD.GetFramerate / 100, "00")
    End Function



End Module
