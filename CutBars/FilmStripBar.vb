Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Design

Public Class FilmStripBar
    Inherits ProgressBase

    ''' <summary>Linemerker im Vordergrund</summary>
    Private LineMarkerOnForeground As Boolean = False
    ''' <summary>Durchsichtigkeit der Values</summary>
    Private m_ValueOpacity As Integer = 100
    ''' <summary>Liste der Filmstripbitmaps</summary>
    Private m_Filmbitmaps As New List(Of Bitmap)
    ''' <summary>Nimmt den String des Auswahldialogs für die Bilder auf</summary>
    Private mPropertyFilmImages As New ImageList

    ''' <summary>Fired, when change the opacity</summary>
    Public Event ValuesOpacityChanged As EventHandler
    Public Event Painted(ByVal sender As Object, ByVal e As ProgressEventArgs)
    ''' <summary>The Listof Bitmaps for the Filmstrip</summary>
    <Browsable(False)> _
    <Category("Werteeinstellung")> _
    <Description("Verlangt ein List(of Single) um die StartCuts oder Terminstarts zu Kennzeichnen oder gibt diese zurück. Die List.Count sollte gleich sein mit der Liste des EndCutValues.Count")> _
    Public Property Filmbitmaps() As List(Of Bitmap)
        Get
            Return Me.m_Filmbitmaps
        End Get
        Set(ByVal value As List(Of Bitmap))
            Me.m_Filmbitmaps = value
            Invalidate()
        End Set
    End Property

    ''' <summary>
    ''' Specifyes the Opacity of the Valuesbars
    ''' </summary>
    <DefaultValue(100)> _
    <Description("Bestimmt den grad der Duchsichtigkeit der Valuesbalken oder gibt diesen zurück. Wert muss >0 und >=100 sein.")> _
    <Category("Werteeinstellung")> _
    Public Property ValuesOpacity() As Integer
        Get
            Return m_ValueOpacity
        End Get
        Set(ByVal value As Integer)
            If value > 0 Or value <= 100 Then
                m_ValueOpacity = value
            End If
            Me.Invalidate()
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets the LineMarker to foreground
    ''' </summary>
    <DefaultValue(False)> _
    <Category("Werteeinstellung")> _
    <Description("Gibt an ob sich der Linemarker vor oder hinter den Filmstreifen befinden soll")> _
   Public Property LineMarkerForeground() As Boolean
        Get
            Return LineMarkerOnForeground
        End Get
        Set(ByVal value As Boolean)
            LineMarkerOnForeground = value
            Invalidate()
            OnLineMarkerChanged(New ProgressEventArgs)
        End Set
    End Property

  



    ''' <summary>
    ''' The Imagelist of the bar
    ''' </summary>
    <DefaultValue("")> _
    <Description("Gibt die Imagelist für die Bilder an welche in der Bar erscheinen sollen. Note: Beim hinzufügen einer Imagelist werden die Bilder Automatisch dem Property 'Filmbitmaps' hinzugefügt")> _
    <Category("Werteeinstellung")> _
    Public Property FilmImages() As ImageList
        Get
            Return mPropertyFilmImages
        End Get
        Set(ByVal value As ImageList)
            For Each itm As Bitmap In value.Images
                Me.Filmbitmaps.Add(itm)
            Next
            mPropertyFilmImages = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim rect As New Rectangle(1, 1, Width - 2, Height - 2)
        Dim g As Graphics = e.Graphics
        g.SmoothingMode = SmoothingMode.HighQuality

        Dim path As GraphicsPath = GetPath(rect)

        ' Draw back gradient
        Using brush As New LinearGradientBrush(rect, LightBackColor, DarkBackColor, LinearGradientMode.Vertical)

            g.FillPath(brush, path)
        End Using
        'Draw Linemarker if Linemarkerforeground = False
        If LineMarkerForeground = False Then
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
        End If

        'Draw the Filmstrip Bitmap ------------
        g.SetClip(path)
        Dim Gesamtbreite As Integer = 0
        Dim Counter As Integer = 0
        Dim bTemp As Bitmap = My.Resources.negativ
        bTemp = PicResizeByHeight(bTemp, rect.Height)
        Do
            Using myimg As New Bitmap(bTemp)
                If Filmbitmaps.Count > 0 Then
                    If Filmbitmaps.Count - 1 >= Counter Then

                        Dim bFilm As New Bitmap(PicResize(Filmbitmaps(Counter), rect.Height - (rect.Height / 100 * 25), bTemp.Width))
                        If bFilm IsNot Nothing Then
                            g.DrawImage(bFilm, New PointF(Gesamtbreite + rect.X, rect.Y + (rect.Height / 100 * 13)))
                        End If
                    End If
                End If
                g.DrawImage(myimg, New PointF(Gesamtbreite + rect.X, rect.Y))
                Gesamtbreite += bTemp.Width - 1 : Counter += 1

            End Using
        Loop Until (Gesamtbreite >= rect.Width)
        bTemp = Nothing
        g.ResetClip()
        '-------------------------------------



        'Check if Startcutvalue.count or Endcutvalue.count is invalid 
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

            'Draw Cutter
            If EndCutValues(i) - StartCutValues(i) <> 0 Then
                ' Draw fill gradient
                Dim c As Color = Color.FromArgb(50, LightFillColor)
                Using brush As New LinearGradientBrush(rect, Color.FromArgb((Me.ValuesOpacity / 100) * 255, LightFillColor), Color.FromArgb((Me.ValuesOpacity / 100) * 255, DarkFillColor), LinearGradientMode.Vertical)
                    Dim clip As New RectangleF(rect.X + CSng(rect.Width) * CSng(StartCutValues(i)) / 100.0F, rect.Y, CSng(rect.Width) * CSng(EndCutValues(i) - StartCutValues(i)) / 100.0F, rect.Height)

                    g.SetClip(clip)
                    g.FillPath(brush, path)
                    g.ResetClip()
                End Using
            End If
        Next
        'Draw Linemarker if Linemarkerforeground = true
        If LineMarkerForeground = True Then
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
        End If

        ' draw light
        Using brush As New SolidBrush(Color.FromArgb(48, Color.White))
            g.SetClip(path)
            g.FillRectangle(brush, New RectangleF(rect.X, rect.Y, rect.Width, rect.Height / 2.0F))
            g.ResetClip()
        End Using


        'Draw Text
        If Text.Length > 0 Then
            Dim fontSize As SizeF = g.MeasureString(Text, Font)
            Dim fontRect As New RectangleF(rect.X + rect.Width / 2.0F - fontSize.Width / 2.0F, rect.Y + rect.Height / 2.0F - fontSize.Height / 2.0F, fontSize.Width, fontSize.Height)
            g.DrawString(Text, Font, New SolidBrush(ForeColor), fontRect)
        End If


        RaiseEvent Painted(Me, New ProgressEventArgs)
    End Sub

    Private mgraphic As Graphics
    Private Property graphic() As Graphics
        Get
            Return mgraphic
        End Get
        Set(ByVal value As Graphics)
            mgraphic = value
        End Set
    End Property

    Friend ReadOnly Property ControlBitmap() As Bitmap
        Get
            Dim BMP As New Bitmap(Me.Width, Me.Height)
            Dim gr As Graphics = Graphics.FromImage(BMP)
            gr.Dispose()
            Return BMP

        End Get
    End Property


#Region "private functions"
    ''' <summary>
    ''' Diese Funktion ändert die größe eines Bilds und gibt es als Bitmap zurück. Hier ist die neue Höhe veränderbar
    ''' </summary>
    ''' <param name="SourceImage">Das Bild dessen größe verändert werden soll</param>
    ''' <param name="NewHeight">Die neue Breite des Bilds, das Größenverhältnis des Bilds wird eingehalten</param>
    Private Function PicResizeByHeight(ByVal SourceImage As Image, ByVal NewHeight As Integer) As Bitmap
        Dim SizeFactor As Decimal = NewHeight / SourceImage.Height
        Dim NewWidth As Integer = SizeFactor * SourceImage.Width
        Dim NewImage As New Bitmap(NewWidth, NewHeight)
        Using G As Graphics = Graphics.FromImage(NewImage)
            G.InterpolationMode = InterpolationMode.HighQualityBicubic
            G.DrawImage(SourceImage, New Rectangle(0, 0, NewWidth, NewHeight))
        End Using
        Return NewImage
    End Function
    ''' <summary>
    ''' Diese Funktion ändert die größe eines Bilds und gibt es als Bitmap zurück. Hier ist die neue Breite und die neue Höhe veränderbar
    ''' </summary>
    Private Function PicResize(ByVal SourceImage As Image, ByVal NewHeight As Integer, ByVal NewWidth As Integer) As Bitmap
        Dim NewImage As New Bitmap(NewWidth, NewHeight)
        Try
            Using G As Graphics = Graphics.FromImage(NewImage)
                G.InterpolationMode = InterpolationMode.HighQualityBicubic
                G.DrawImage(SourceImage, New Rectangle(0, 0, NewWidth, NewHeight))
            End Using
            Return NewImage
        Catch ex As Exception
            Return NewImage
        End Try
    End Function

  

#End Region

End Class
