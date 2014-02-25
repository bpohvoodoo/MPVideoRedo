Imports System.Collections.Generic
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Drawing.Design


''' <summary>
''' Spezielle Progressbar im iTunes Stile mit welcher mehrere Werte angezeigt werden können.
''' </summary>
<ToolboxBitmap(GetType(ProgressBar))> <Description("Eine Progressbar zum darstellen von z.b. Schnittmarken oder einer Timeline")> _
Public Class TimeLineBar
    Inherits ProgressBase


    ''' <summary>
    ''' Number of separators
    ''' </summary>
    Private m_separators As Integer = 10

    ''' <summary>
    ''' Fired, when number of separators changed
    ''' </summary>
    Public Event SeparatorsChanged As EventHandler

    ''' <summary>
    ''' Specifyes the number of separators
    ''' </summary>
    <DefaultValue(10)> _
    Public Overridable Property Separators() As Integer
        Get
            Return Me.m_separators
        End Get
        Set(ByVal value As Integer)
            If Me.m_separators <> value Then
                Me.m_separators = value
                Invalidate()
                OnSeparatorsChanged(New ProgressEventArgs)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Fired, when number of separators changed
    ''' </summary>
    Protected Sub OnSeparatorsChanged(ByVal e As EventArgs)
        RaiseEvent SeparatorsChanged(Me, e)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        'MyBase.OnPaint(e)
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
        If Separators > 0 Then
            Using pen1 As New Pen(Color.FromArgb(48, Color.Black), 1)
                Using pen2 As New Pen(Color.FromArgb(48, Color.White), 1)
                    Dim [step] As Single = CSng(rect.Width) / CSng(Separators + 1)
                    g.SetClip(path)
                    Dim split As Single = rect.X + [step] - 0.5F
                    While split < rect.X + rect.Width - 0.5F
                        g.DrawLine(pen1, split - 0.5F, rect.Y - 0.5F, split - 0.5F, rect.Y + rect.Height - 0.5F)
                        g.DrawLine(pen2, split + 0.5F, rect.Y - 0.5F, split + 0.5F, rect.Y + rect.Height - 0.5F)
                        split += [step]
                    End While
                    g.ResetClip()
                End Using
            End Using
        End If
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

    End Sub

End Class