Imports MediaPortal.GUI.Library
Imports System.IO
Imports System.Drawing.Drawing2D
Imports System.Drawing

Module CutBarhelper

    Friend MyCutbar As New CutBars.FilmStripBar
    Friend myFilmstripBar As New CutBars.StandartCutBar

    Friend Sub LoadCutbar(ByVal BarProperties As PropertyCollection, ByVal VideoWindow As GUIVideoControl)
        MyLog.DebugM("Lade die Filmstripbar mit folgenden Properties:")
        For i As Integer = 0 To BarProperties.Count - 1
            MyLog.DebugM("{0}-Propertie:{1}", BarProperties.Keys(i), BarProperties.Values(i))
        Next

        MyCutbar.Top = VideoWindow.Location.Y + VideoWindow.Size.Height + BarProperties("Top")
        MyCutbar.Left = VideoWindow.Location.X + BarProperties("Left")

        MyCutbar.Width = BarProperties("Width")
        MyCutbar.Height = BarProperties("Height")

        MyCutbar.StartCutValues.Clear()
        MyCutbar.EndCutValues.Clear()


        MyCutbar.LineMarkerForeground = BarProperties("LineMarkerForeground")

        MyCutbar.LineMakerColor = Drawing.Color.FromName(BarProperties("LinemarkerColor"))
        MyCutbar.LineMarkerThickness = BarProperties("LineMarkerThickness")

        MyCutbar.DarkBackColor = Drawing.Color.FromName(BarProperties("DarkBackColor"))
        MyCutbar.LightFillColor = Drawing.Color.FromName(BarProperties("LightFillColor"))
        MyCutbar.LightBackColor = Drawing.Color.FromName(BarProperties("LightBackColor"))
        MyCutbar.DarkFillColor = Drawing.Color.FromName(BarProperties("DarkFillColor"))
        MyCutbar.Enabled = False
        GUIGraphicsContext.form.Controls.Add(MyCutbar)
        GUIGraphicsContext.form.Focus()
        'GUIGraphicsContext.form.Focus()
        MyLog.DebugM("Filmstripbar erfolgreich geladen")
    End Sub
    Friend Sub UnloadCutbar()
        MyLog.DebugM("Entferne Filmstripbar...")
        GUIGraphicsContext.form.Controls.Remove(MyCutbar)
        MyLog.DebugM("Filmstripbar entfernt")
    End Sub

    Friend Sub LoadFilmstripbar(ByVal BarProperties As PropertyCollection, ByVal VideoWindow As GUIVideoControl)
        MyLog.DebugM("Lade die Cutbar mit folgenden Properties:")
        For i As Integer = 0 To BarProperties.Count - 1
            MyLog.DebugM("{0}-Propertie:{1}", BarProperties.Keys(i), BarProperties.Values(i))
        Next

        myFilmstripBar.Top = VideoWindow.Location.Y + VideoWindow.Size.Height + BarProperties("Top")
        myFilmstripBar.Left = VideoWindow.Location.X + BarProperties("Left")
        myFilmstripBar.Width = BarProperties("Width")
        myFilmstripBar.Height = BarProperties("Height")
        'myFilmstripBar.StartCutValues.Clear()
        'myFilmstripBar.EndCutValues.Clear()
        'myFilmstripBar.LineMarkerForeground = True
        myFilmstripBar.LineMarkerThickness = BarProperties("LineMarkerThickness")
        myFilmstripBar.LineMakerColor = Drawing.Color.FromName(BarProperties("LinemarkerColor"))
        myFilmstripBar.LineMarkerThickness = BarProperties("LineMarkerThickness")

        myFilmstripBar.DarkBackColor = Drawing.Color.FromName(BarProperties("DarkBackColor"))
        myFilmstripBar.LightFillColor = Drawing.Color.FromName(BarProperties("LightFillColor"))
        myFilmstripBar.LightBackColor = Drawing.Color.FromName(BarProperties("LightBackColor"))
        myFilmstripBar.DarkFillColor = Drawing.Color.FromName(BarProperties("DarkFillColor"))
        myFilmstripBar.Enabled = False
        GUIGraphicsContext.form.Controls.Add(myFilmstripBar)
        GUIGraphicsContext.form.Focus()
        'GUIGraphicsContext.form.Focus()
        MyLog.DebugM("Cutbar erfolgreich geladen")
    End Sub
    Friend Sub UnloadFilmstripbar()
        MyLog.DebugM("Entferne Cutbar...")
        GUIGraphicsContext.form.Controls.Remove(myFilmstripBar)
        MyLog.DebugM("Cutbar entfernt")
    End Sub


    Friend Function GetCutbarProperties(ByVal XMLfile As String, Optional ByVal Cutbar As Boolean = False) As PropertyCollection
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
                propStart = InStr(XmlText, "Start Filmstripbar-Properties") + 29
                propCount = InStrRev(XmlText, "End Filmstripbar-Properties") - propStart
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
