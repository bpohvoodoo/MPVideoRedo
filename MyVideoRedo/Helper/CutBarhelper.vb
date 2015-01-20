Imports MediaPortal.GUI.Library
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Drawing

Module CutBarhelper

    Friend MyMovieStripBar As New CutBars.MovieStripBar
    Friend MyCutBar As New CutBars.StandardCutBar

    Friend Sub LoadMoviestripBar(ByVal BarProperties As PropertyCollection, ByVal VideoWindow As GUIVideoControl)
        MyLog.DebugM("Loading the Filmstripbar with properties of: ")
        For i As Integer = 0 To BarProperties.Count - 1
            MyLog.DebugM("{0}-Property: {1}", BarProperties.Keys(i), BarProperties.Values(i))
        Next
        MyMovieStripBar.Top = VideoWindow.Location.Y + VideoWindow.Size.Height + BarProperties("Top")
        MyMovieStripBar.Left = VideoWindow.Location.X + BarProperties("Left")
        MyMovieStripBar.Width = BarProperties("Width")
        MyMovieStripBar.Height = BarProperties("Height")
        MyMovieStripBar.StartCutValues.Clear()
        MyMovieStripBar.EndCutValues.Clear()
        MyMovieStripBar.LineMarkerForeground = BarProperties("LineMarkerForeground")
        MyMovieStripBar.LineMakerColor = Drawing.Color.FromName(BarProperties("LinemarkerColor"))
        MyMovieStripBar.LineMarkerThickness = BarProperties("LineMarkerThickness")
        MyMovieStripBar.DarkBackColor = Drawing.Color.FromName(BarProperties("DarkBackColor"))
        MyMovieStripBar.LightFillColor = Drawing.Color.FromName(BarProperties("LightFillColor"))
        MyMovieStripBar.LightBackColor = Drawing.Color.FromName(BarProperties("LightBackColor"))
        MyMovieStripBar.DarkFillColor = Drawing.Color.FromName(BarProperties("DarkFillColor"))
        MyMovieStripBar.Enabled = False
        GUIGraphicsContext.form.Controls.Add(MyMovieStripBar)
        GUIGraphicsContext.form.Focus()
        'GUIGraphicsContext.form.Focus()
        MyLog.DebugM("Filmstripbar successfully loaded.")
    End Sub
    Friend Sub UnloadMoviestripBar()
        MyLog.DebugM("Removing the Moviestripbar...")
        GUIGraphicsContext.form.Controls.Remove(MyMovieStripBar)
        MyLog.DebugM("Moviestripbar was removed.")
    End Sub

    Friend Sub LoadCutbar(ByVal BarProperties As PropertyCollection, ByVal VideoWindow As GUIVideoControl)
        MyLog.DebugM("Loading the Cutbar with properties of: ")
        For i As Integer = 0 To BarProperties.Count - 1
            MyLog.DebugM("{0}-Property: {1}", BarProperties.Keys(i), BarProperties.Values(i))
        Next
        MyCutBar.Top = VideoWindow.Location.Y + VideoWindow.Size.Height + BarProperties("Top")
        MyCutBar.Left = VideoWindow.Location.X + BarProperties("Left")
        MyCutBar.Width = BarProperties("Width")
        MyCutBar.Height = BarProperties("Height")
        'myFilmstripBar.StartCutValues.Clear()
        'myFilmstripBar.EndCutValues.Clear()
        'myFilmstripBar.LineMarkerForeground = True
        MyCutBar.LineMarkerThickness = BarProperties("LineMarkerThickness")
        MyCutBar.LineMakerColor = Drawing.Color.FromName(BarProperties("LinemarkerColor"))
        MyCutBar.LineMarkerThickness = BarProperties("LineMarkerThickness")
        MyCutBar.DarkBackColor = Drawing.Color.FromName(BarProperties("DarkBackColor"))
        MyCutBar.LightFillColor = Drawing.Color.FromName(BarProperties("LightFillColor"))
        MyCutBar.LightBackColor = Drawing.Color.FromName(BarProperties("LightBackColor"))
        MyCutBar.DarkFillColor = Drawing.Color.FromName(BarProperties("DarkFillColor"))
        MyCutBar.Enabled = False
        GUIGraphicsContext.form.Controls.Add(MyCutBar)
        GUIGraphicsContext.form.Focus()
        'GUIGraphicsContext.form.Focus()
        MyLog.DebugM("Cutbar successfully loaded.")
    End Sub

    Friend Sub UnloadCutBar()
        MyLog.DebugM("Removing the Cutbar...")
        GUIGraphicsContext.form.Controls.Remove(MyCutBar)
        MyLog.DebugM("Cutbar was removed.")
    End Sub

    Friend Function GetCutBarProperties(ByVal XMLfile As String, Optional ByVal Cutbar As Boolean = False) As PropertyCollection
        GetCutbarProperties = New PropertyCollection
        Dim objDateiLeser As New StreamReader(XMLfile)
        Dim XmlText As String = objDateiLeser.ReadToEnd()
        objDateiLeser.Close()
        objDateiLeser = Nothing

        If XmlText IsNot Nothing Then
            Dim propStart As Integer, propCount As Integer
            If Cutbar Then
                propStart = InStr(XmlText, "Start Cutbar-Properties") + 29
                propCount = InStrRev(XmlText, "End Cutbar-Properties") - propStart
            Else
                propStart = InStr(XmlText, "Start MoviestripBar-Properties") + 29
                propCount = InStrRev(XmlText, "End MoviestripBar-Properties") - propStart
            End If
            Dim newText As String = Mid(XmlText, propStart, propCount)

            Dim arrPropStrings As String() = Split(newText, ";")

            For i As Integer = 0 To arrPropStrings.Length - 1
                For o = 0 To 50
                    arrPropStrings(i) = Replace(arrPropStrings(i), " ", "")
                    arrPropStrings(i) = Replace(arrPropStrings(i), vbNewLine, "")
                Next
                GetCutbarProperties.Add(Left(arrPropStrings(i), InStr(arrPropStrings(i), "=") - 1), Mid(arrPropStrings(i), InStr(arrPropStrings(i), "=") + 1))
            Next
            Return GetCutbarProperties
        Else
            Return Nothing
        End If
    End Function
End Module
