Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Design
<Serializable()> Public MustInherit Class ProgressBase
    Inherits Control

#Region "SpecialProgressBarStyle enumeration"
    ''' <summary>
    ''' Lists possible styles
    ''' </summary>
    Public Enum SpecialProgressBarStyle
        Square
        Round
    End Enum
#End Region


#Region "private fields"
    ''' <summary>
    ''' Style of progress bar ends
    ''' </summary>
    Private m_style As SpecialProgressBarStyle = SpecialProgressBarStyle.Square

    ''' <summary>
    ''' Position of the Linemarker
    ''' </summary>
    ''' <remarks></remarks>
    Private LineMarker As Single = 0

    ''' <summary>
    ''' Thickness of the Linemarker
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LineMarkerThickness As Integer = 4


    ''' <summary>
    ''' Light fill color of gradient
    ''' </summary>
    Private m_lightFillColor As Color = Color.Red

    ''' <summary>
    ''' Dark fill color of gradient
    ''' </summary>
    Private m_darkFillColor As Color = Color.DarkRed

    ''' <summary>
    ''' Light background color of gradient
    ''' </summary>
    Private m_lightBackColor As Color = Color.LightGreen

    ''' <summary>
    ''' Dark background color of gradient
    ''' </summary>
    Private m_darkBackColor As Color = Color.DarkGreen

    ''' <summary>
    ''' Color of the linemarker
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LineMarkerColor As Color = Color.Black

    ''' <summary>
    ''' Starting value of fillage
    ''' </summary>
    Private m_startValue As New List(Of Single)

    ''' <summary>
    ''' Ending value of fillage
    ''' </summary>
    Private m_endValue As New List(Of Single)
#End Region

#Region "public events"
    '''' <summary>
    '''' Fired, when border color changed
    '''' </summary>
    'Public Event BorderColorChanged As EventHandler

    ''' <summary>
    ''' Fired, when light fill color changed
    ''' </summary>
    Public Event LightFillColorChanged As EventHandler

    ''' <summary>
    ''' Fired, when dark fill color changed
    ''' </summary>
    Public Event DarkFillColorChanged As EventHandler

    ''' <summary>
    ''' Fired, when light background color changed
    ''' </summary>
    Public Event LightBackColorChanged As EventHandler

    ''' <summary>
    ''' Fired, when dark background color changed
    ''' </summary>
    Public Event DarkBackColorChanged As EventHandler



    ''' <summary>
    ''' Fired, when starting value changed
    ''' </summary>
    Public Event StartValueChanged(ByVal sender As Object, ByVal e As ProgressEventArgs)

    ''' <summary>
    ''' Fired, when ending value changed
    ''' </summary>
    Public Event EndValueChanged(ByVal sender As Object, ByVal e As ProgressEventArgs)

    ''' <summary>
    ''' Fired, when changed the LineMarkerthickness or Position
    ''' </summary>
    Public Event LineMarkerChanged(ByVal sender As Object, ByVal e As ProgressEventArgs)


#End Region

#Region "properties"
    ''' <summary>
    ''' Specifyes the ending's style
    ''' </summary>
    <DefaultValue(GetType(SpecialProgressBarStyle), "Square")> _
    Public Overridable Property Style() As SpecialProgressBarStyle
        Get
            Return Me.m_style
        End Get
        Set(ByVal value As SpecialProgressBarStyle)
            If Me.m_style <> value Then
                Me.m_style = value
                Invalidate()
                OnStyleChanged(New ProgressEventArgs)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Specifyes the light fill color of gradient
    ''' </summary>
    <DefaultValue(GetType(Color), "Red")> _
    Public Overridable Property LightFillColor() As Color
        Get
            Return Me.m_lightFillColor
        End Get
        Set(ByVal value As Color)
            If Me.m_lightFillColor <> value Then
                Me.m_lightFillColor = value
                Invalidate()
                OnLightFillColorChanged(New ProgressEventArgs)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Specifyes the dark fill color of gradient
    ''' </summary>
    <DefaultValue(GetType(Color), "DarkRed")> _
    Public Overridable Property DarkFillColor() As Color
        Get
            Return Me.m_darkFillColor
        End Get
        Set(ByVal value As Color)
            If Me.m_darkFillColor <> value Then
                Me.m_darkFillColor = value
                Invalidate()
                OnDarkFillColorChanged(New ProgressEventArgs)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Specifyes the light background color of gradient
    ''' </summary>
    <DefaultValue(GetType(Color), "LightGreen")> _
    Public Overridable Property LightBackColor() As Color
        Get
            Return Me.m_lightBackColor
        End Get
        Set(ByVal value As Color)
            If Me.m_lightBackColor <> value Then
                Me.m_lightBackColor = value
                Invalidate()
                OnLightBackColorChanged(New ProgressEventArgs)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Specifyes the dark background color of gradient
    ''' </summary>
    <DefaultValue(GetType(Color), "DarkGreen")> _
    Public Overridable Property DarkBackColor() As Color
        Get
            Return Me.m_darkBackColor
        End Get
        Set(ByVal value As Color)
            If Me.m_darkBackColor <> value Then
                Me.m_darkBackColor = value
                Invalidate()
                OnDarkBackColorChanged(New ProgressEventArgs)
            End If
        End Set
    End Property



    ''' <summary>
    ''' Specifyes starting values
    ''' </summary>
    <Category("Werteeinstellung")> <Description("Verlangt ein List(of Single) um die StartCuts oder Terminstarts zu Kennzeichnen oder gibt diese zurück. Die List.Count sollte gleich sein mit der Liste des EndCutValues.Count")> _
    Public Overridable Property StartCutValues() As List(Of Single)
        Get
            Return Me.m_startValue
        End Get
        Set(ByVal value As List(Of Single))
            If EndCutValues.Count < value.Count Then
                For o As Integer = value.Count - EndCutValues.Count To value.Count
                    EndCutValues.Add(value(o - 1) + 0.1)
                Next
            End If
            Me.m_startValue = value
            Invalidate()
            OnStartValueChanged(New ProgressEventArgs)
        End Set
    End Property

    ''' <summary>
    ''' Specifyes ending values
    ''' </summary>
    <Category("Werteeinstellung")> <Description("Verlangt ein List(of Single) um die EndCuts oder Terminenden zu Kennzeichnen oder gibt diese zurück. Die List.Count sollte gleich sein mit der Liste des StartCutValues.Count")> _
    Public Overridable Property EndCutValues() As List(Of Single)
        Get
            Return Me.m_endValue
        End Get
        Set(ByVal value As List(Of Single))
            If StartCutValues.Count < value.Count Then
                For o1 As Integer = value.Count - StartCutValues.Count To value.Count
                    StartCutValues.Add(value(o1 - 1) - 0.1)
                Next
            End If
            Me.m_endValue = value
            Invalidate()
            OnEndValueChanged(New ProgressEventArgs)
        End Set
    End Property
    ''' <summary>
    ''' Postion of the LineMarker
    ''' </summary>
    <Category("Werteeinstellung")> <Description("Gibt an wo sich der Marker befinden soll oder gibt den Wert der aktuellen Positione zurück")> _
    Public Overridable Property LineMarkerPosition() As Single
        Get
            Return LineMarker
        End Get
        Set(ByVal value As Single)
            If value < 0 Then
                value = 0
            End If
            If value > 100 Then
                value = 100
            End If
            LineMarker = value
            Invalidate()
            OnLineMarkerChanged(New ProgressEventArgs)
        End Set
    End Property

    ''' <summary>
    ''' Thickness of the Linemarker
    ''' </summary>
    <DefaultValue(4)> <Description("Gibt die Linienstärke des Markers an oder gibt diese zurück")> _
    Public Overridable Property LineMarkerThickness() As Integer
        Get
            Return Me.m_LineMarkerThickness
        End Get
        Set(ByVal value As Integer)
            If Me.m_LineMarkerThickness <> value Then
                If value > 10 Or value < 1 Then
                    Throw New Exception("Wert muss zwischen 1 und 10 liegen")
                Else
                    Me.m_LineMarkerThickness = value
                    Invalidate()
                    OnLineMarkerChanged(New ProgressEventArgs)
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Specifyes the color of the linemarker
    ''' </summary>
    <DefaultValue(GetType(Color), "Black")> _
    Public Overridable Property LineMakerColor() As Color
        Get
            Return Me.m_LineMarkerColor
        End Get
        Set(ByVal value As Color)
            If Me.m_LineMarkerColor <> value Then
                Me.m_LineMarkerColor = value
                Invalidate()
                OnLineMarkerChanged(New ProgressEventArgs)
            End If
        End Set
    End Property

    ' String, der die Auswahl aufnehmen kann.
    Private mPropertyCutValues As String

    <DefaultValue("")> _
    <Description("Gibt die Start und EndValues für die Bar an. Hier allerdings mit einem angenehmen Editor welcher den umgang vereinfacht und woduch weniger fehler passieren können.")> _
    <Editor(GetType(CProgressValueProperty), GetType(UITypeEditor))> _
    <Category("Werteeinstellung")> _
    Public Overridable Property CutValues() As String
        ' Property für den Wert.
        Get
            mPropertyCutValues = ""
            For i As Integer = 0 To StartCutValues.Count - 1
                mPropertyCutValues += StartCutValues(i) & ";"
                mPropertyCutValues += EndCutValues(i) & ";"
            Next
            If Strings.Left(mPropertyCutValues, 1) = ";" Then
                mPropertyCutValues = Mid(mPropertyCutValues, 1, mPropertyCutValues.Length - 1)
            End If
            Return mPropertyCutValues
        End Get
        Set(ByVal value As String)
            mPropertyCutValues = value
            StartCutValues.Clear()
            EndCutValues.Clear()
            Dim VM As String() = mPropertyCutValues.Split(";")
            For i As Integer = 0 To VM.Count - 1
                If VM(i).Length > 0 Then
                    If i Mod 2 = 0 Then
                        Me.StartCutValues.Add(VM(i))
                    Else
                        Me.EndCutValues.Add(VM(i))
                    End If
                End If
            Next
            OnStartValueChanged(New ProgressEventArgs)
            OnEndValueChanged(New ProgressEventArgs)
            Me.Invalidate()
        End Set
    End Property

    'Private mMemoryImage As Image = Nothing
    Public Overridable ReadOnly Property MemoryImage() As Image
        Get
            Return Screenshot(Me)
        End Get
    End Property
#End Region

#Region "Constructor"
    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()
        MyBase.New()
        Size = New Size(320, 32)
        DoubleBuffered = True

    End Sub

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="text__1">Text member</param>
    Public Sub New(ByVal text__1 As String)
        MyBase.New(text__1)
        Size = New Size(320, 32)
        DoubleBuffered = True

    End Sub

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="parent">Parent control</param>
    ''' <param name="text__1">Text members</param>
    Public Sub New(ByVal parent As Control, ByVal text__1 As String)
        MyBase.New(parent, text__1)
        Size = New Size(320, 32)
        DoubleBuffered = True

    End Sub

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="text__1">Text member</param>
    ''' <param name="left">X-coordinate</param>
    ''' <param name="top">Y-coordinate</param>
    ''' <param name="width">Width member</param>
    ''' <param name="height">Height member</param>
    Public Sub New(ByVal text__1 As String, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer)
        MyBase.New(text__1, left, top, width, height)
        DoubleBuffered = True

    End Sub

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="parent">Parent control</param>
    ''' <param name="text__1">Text member</param>
    ''' <param name="left">X-coordinate</param>
    ''' <param name="top">Y-coordinate</param>
    ''' <param name="width">Width member</param>
    ''' <param name="height">Height member</param>
    Public Sub New(ByVal parent As Control, ByVal text__1 As String, ByVal left As Integer, ByVal top As Integer, ByVal width As Integer, ByVal height As Integer)
        MyBase.New(parent, text__1, left, top, width, height)
        DoubleBuffered = True

    End Sub
#End Region

#Region "protected members"


    ''' <summary>
    ''' Fired, when light fill color changed
    ''' </summary>
    Protected Sub OnLightFillColorChanged(ByVal e As EventArgs)
        RaiseEvent LightFillColorChanged(Me, e)
    End Sub

    ''' <summary>
    ''' Fired, when dark fill color changed
    ''' </summary>
    Protected Sub OnDarkFillColorChanged(ByVal e As EventArgs)
        RaiseEvent DarkFillColorChanged(Me, e)
    End Sub

    ''' <summary>
    ''' Fired, when light background color changed
    ''' </summary>
    Protected Sub OnLightBackColorChanged(ByVal e As EventArgs)
        RaiseEvent LightBackColorChanged(Me, e)
    End Sub

    ''' <summary>
    ''' Fired, when dark background color changed
    ''' </summary>
    Protected Sub OnDarkBackColorChanged(ByVal e As EventArgs)
        RaiseEvent DarkBackColorChanged(Me, e)
    End Sub



    ''' <summary>
    ''' Fired, when starting value changed
    ''' </summary>
    Protected Sub OnStartValueChanged(ByVal e As ProgressEventArgs)
        e.StartValues = Me.StartCutValues
        e.EndValues = Me.EndCutValues
        e.Linemarkerposition = Me.LineMarkerPosition
        RaiseEvent StartValueChanged(Me, e)
    End Sub

    ''' <summary>
    ''' Fired, when ending value changed
    ''' </summary>
    Protected Sub OnEndValueChanged(ByVal e As ProgressEventArgs)
        e.StartValues = Me.StartCutValues
        e.EndValues = Me.EndCutValues
        e.Linemarkerposition = Me.LineMarkerPosition
        RaiseEvent EndValueChanged(Me, e)
    End Sub

    ''' <summary>
    ''' Fired, when ending value changed
    ''' </summary>
    Protected Sub OnLineMarkerChanged(ByVal e As ProgressEventArgs)
        e.StartValues = Me.StartCutValues
        e.EndValues = Me.EndCutValues
        e.Linemarkerposition = Me.LineMarkerPosition
        RaiseEvent LineMarkerChanged(Me, e)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        Me.Invalidate()
        MyBase.OnResize(e)
    End Sub

    ''' <summary>
    ''' Fired, when size changed
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnSizeChanged(ByVal e As EventArgs)
        If Height > Width Then
            Width = Height
        End If

        MyBase.OnSizeChanged(e)
    End Sub

    ''' <summary>
    ''' Fired, when text changed
    ''' </summary>
    ''' <param name="e"></param>
    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
        Invalidate()
        MyBase.OnTextChanged(e)
    End Sub

    ''' <summary>
    ''' Fired on paint event
    ''' </summary>
    ''' <param name="e">Event arguments</param>
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim rect As New Rectangle(1, 1, Width - 2, Height - 2)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.HighQuality

        Dim path As GraphicsPath = GetPath(rect)

        ' Draw back gradient
        Using brush As New LinearGradientBrush(rect, LightBackColor, DarkBackColor, LinearGradientMode.Vertical)
            g.FillPath(brush, path)
        End Using

        For i As Integer = 0 To StartCutValues.Count - 1

            If EndCutValues.Count < StartCutValues.Count Then
                For o As Integer = StartCutValues.Count - EndCutValues.Count To StartCutValues.Count
                    EndCutValues.Add(StartCutValues(o - 1) + 0.1)
                Next
            End If
            If StartCutValues.Count < EndCutValues.Count Then
                For o1 As Integer = EndCutValues.Count - StartCutValues.Count To EndCutValues.Count
                    StartCutValues.Add(EndCutValues(o1 - 1) - 0.1)
                Next
            End If

            If EndCutValues(i) - StartCutValues(i) <> 0 Then
                ' Draw fill gradient
                Using brush As New LinearGradientBrush(rect, LightFillColor, DarkFillColor, LinearGradientMode.Vertical)
                    Dim clip As New RectangleF(rect.X + CSng(rect.Width) * CSng(StartCutValues(i)) / 100.0F, rect.Y, CSng(rect.Width) * CSng(EndCutValues(i) - StartCutValues(i)) / 100.0F, rect.Height)

                    g.SetClip(clip)
                    g.FillPath(brush, path)
                    g.ResetClip()
                End Using
            End If

        Next

        ' draw light
        Using brush As New SolidBrush(Color.FromArgb(48, Color.White))
            g.SetClip(path)
            g.FillRectangle(brush, New RectangleF(rect.X, rect.Y, rect.Width, rect.Height / 2.0F))
            g.ResetClip()
        End Using
        'Marker
        If LineMarkerPosition >= 0 Then
            Using pen1 As New Pen(LineMakerColor, LineMarkerThickness)
                g.SetClip(path)
                Dim proz As Single = (rect.Width / 100) * LineMarkerPosition

                g.DrawLine(pen1, proz - 0.5F, rect.Y - 0.5F, proz, rect.Y + rect.Height - 0.5F)
                'Oberes Dreieck
                Dim l As New List(Of Point)
                l.Add(New Point(proz - 4.0F - LineMarkerThickness, rect.Y - 0.5F))
                l.Add(New Point(proz + 4.0F + LineMarkerThickness, rect.Y - 0.5F))
                l.Add(New Point(proz, rect.Y + 4.0F + LineMarkerThickness))
                Dim br As Brush = pen1.Brush
                g.FillPolygon(br, l.ToArray)
                g.ResetClip()

                'Unteres Dreieck
                g.SetClip(path)
                Dim l1 As New List(Of Point)
                l1.Add(New Point(proz - 4.0F - LineMarkerThickness, (rect.Y + rect.Height) + 0.5F))
                l1.Add(New Point(proz + 4.0F + LineMarkerThickness, (rect.Y + rect.Height) + 0.5F))
                l1.Add(New Point(proz, rect.Y + rect.Height - 4.0F - LineMarkerThickness))
                g.FillPolygon(br, l1.ToArray)
                g.ResetClip()
            End Using
        End If
        'Text zeichnen
        If Text.Length > 0 Then
            Dim fontSize As SizeF = g.MeasureString(Text, Font)
            Dim fontRect As New RectangleF(rect.X + rect.Width / 2.0F - fontSize.Width / 2.0F, rect.Y + rect.Height / 2.0F - fontSize.Height / 2.0F, fontSize.Width, fontSize.Height)
            g.DrawString(Text, Font, New SolidBrush(ForeColor), fontRect)
        End If

        MyBase.OnPaint(e)
    End Sub
#End Region

#Region "private members"
    Public Function GetPath(ByVal rect As RectangleF) As GraphicsPath
        Dim path As New GraphicsPath()
        Select Case Style
            Case SpecialProgressBarStyle.Square
                path.AddRectangle(rect)
                Exit Select
            Case SpecialProgressBarStyle.Round
                path.AddArc(New RectangleF(rect.X, rect.Y, rect.Height, rect.Height), 90, 180)
                path.AddArc(New RectangleF(rect.X + rect.Width - rect.Height, rect.Y, rect.Height, rect.Height), 270, 180)
                path.CloseFigure()
                Exit Select


        End Select

        Return path
    End Function
#End Region

    ''' <summary>
    ''' Fügt einen neuen Bereich der Bar hinzu feuert die Events und zeichnet das Control anschliessend neu
    ''' Startwert sollte kleiner sein als der Endwert
    ''' </summary>
    ''' <param name="StartValue">Der Startwert des neuen Bereichs</param>
    ''' <param name="EndValue">Der Endwert des neuen Bereichs</param>
    Public Overridable Sub AddValues(ByVal StartValue As Single, ByVal EndValue As Single)
        Me.StartCutValues.Add(StartValue)
        'OnStartValueChanged(ProgressEventArgs.Empty)
        Me.EndCutValues.Add(EndValue)
        'OnEndValueChanged(ProgressEventArgs.Empty)
        Invalidate()
    End Sub

    Public Function Screenshot(ByVal Ctrl As Control) As Bitmap

        Dim w As Integer = Ctrl.Width  ' Breite des Controls
        Dim h As Integer = Ctrl.Height ' Höhe des Controls

        ' Bitmap für das Abbild des Controls / der Form bereitstellen
        Screenshot = New Bitmap(w, h)
        ' Screenshot vornehmen und zurückgeben
        Ctrl.DrawToBitmap(Screenshot, Rectangle.FromLTRB(0, 0, w, h))
        Return Screenshot

    End Function


End Class

