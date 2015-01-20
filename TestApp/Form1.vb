Public Class Form1

    Private myVRD As MyVideoRedo.VideoReDo

  
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click



        myVRD = New MyVideoRedo.VideoReDo(Me.chkSilent.Checked)

        Me.lblVRDversion.Text = myVRD.ReDoVersion
        'MyVideoRedo.Helper.SetMPtoForeground()
        myVRD.LoadMediaToCut("\\SERVER\Dokumente\VideoSample\Berlin kocht - TV.Berlin.ts")
        Me.TrackBar1.Maximum = myVRD.LoadedVideoDuration * 100


        AddHandler myVRD.QuickStreamFixNeeded, AddressOf QuickError



    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If myVRD IsNot Nothing Then
            myVRD.Dispose()
            myVRD.Close()
        End If
    End Sub



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        CheckForIllegalCrossThreadCalls = False

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        myVRD.StartVideoSave("\\SERVER\Dokumente\VideoSample\Berlin kocht - TV.Berlin_Fixed.ts")
    End Sub

  

  






    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll

    End Sub

    Private Sub TrackBar1_MouseUp(sender As Object, e As MouseEventArgs) Handles TrackBar1.MouseUp
        If myVRD IsNot Nothing Then
            myVRD.SeekToTime(Me.TrackBar1.Value)
            Me.MovieStripBar1.MovieStripThumbs.Add(myVRD.MakeScreenshotImage(Me.TrackBar1.Value, "C:\Screen.jpg"))
        Else
            MessageBox.Show("VideoRedo ist nicht offen")
        End If

    End Sub

    Private Sub QuickError(sender As Object, e As EventArgs)
        Button3.PerformClick()
        Me.Button1.Text = "Needed!!!!"
    End Sub

   
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If myVRD IsNot Nothing Then
            myVRD.Close()
            myVRD.Dispose()
            myVRD = Nothing
            Dim p() As Process = System.Diagnostics.Process.GetProcesses

            For Each item As Process In p
                If item.ProcessName.Contains("ReDo") Then
                    item.Kill()
                End If
            Next


            myVRD = New MyVideoRedo.VideoReDo(Me.chkSilent.Checked)
            Me.lblVRDversion.Text = myVRD.ReDoVersion
            myVRD.LoadMediaToCut("\\SERVER\Dokumente\VideoSample\Berlin kocht - TV.Berlin.ts", True)
            Me.TrackBar1.Maximum = myVRD.LoadedVideoDuration * 100

            AddHandler myVRD.QuickStreamFixNeeded, AddressOf QuickError

        End If
        




    End Sub
End Class