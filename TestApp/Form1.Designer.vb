<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.chkSilent = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblVRDversion = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.MovieStripBar1 = New CutBars.MovieStripBar()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "P9120043.jpg")
        Me.ImageList1.Images.SetKeyName(1, "P9120044.jpg")
        Me.ImageList1.Images.SetKeyName(2, "P9120045.jpg")
        Me.ImageList1.Images.SetKeyName(3, "P9120046.jpg")
        Me.ImageList1.Images.SetKeyName(4, "P9120047.jpg")
        Me.ImageList1.Images.SetKeyName(5, "P9120048.jpg")
        Me.ImageList1.Images.SetKeyName(6, "P9120049.jpg")
        Me.ImageList1.Images.SetKeyName(7, "P9120050.jpg")
        Me.ImageList1.Images.SetKeyName(8, "P9120051.jpg")
        Me.ImageList1.Images.SetKeyName(9, "P9120052.jpg")
        Me.ImageList1.Images.SetKeyName(10, "P9120053.jpg")
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(26, 25)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(97, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Plugin öffnen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'chkSilent
        '
        Me.chkSilent.AutoSize = True
        Me.chkSilent.Location = New System.Drawing.Point(258, 32)
        Me.chkSilent.Name = "chkSilent"
        Me.chkSilent.Size = New System.Drawing.Size(52, 17)
        Me.chkSilent.TabIndex = 1
        Me.chkSilent.Text = "Silent"
        Me.chkSilent.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 76)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "VideoRedo Version:"
        '
        'lblVRDversion
        '
        Me.lblVRDversion.AutoSize = True
        Me.lblVRDversion.Location = New System.Drawing.Point(130, 76)
        Me.lblVRDversion.Name = "lblVRDversion"
        Me.lblVRDversion.Size = New System.Drawing.Size(101, 13)
        Me.lblVRDversion.TabIndex = 3
        Me.lblVRDversion.Text = "VideoRedo Version:"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(953, 29)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(170, 20)
        Me.TextBox1.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(745, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Fenster mit folgendem Titel schliessen:"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(407, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(20, 109)
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(1083, 45)
        Me.TrackBar1.TabIndex = 7
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(129, 25)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(97, 23)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Plugin schliessen"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'MovieStripBar1
        '
        Me.MovieStripBar1.EndCutValues = CType(resources.GetObject("MovieStripBar1.EndCutValues"), System.Collections.Generic.List(Of Single))
        Me.MovieStripBar1.MovieStripThumbs = CType(resources.GetObject("MovieStripBar1.Filmbitmaps"), System.Collections.Generic.List(Of System.Drawing.Bitmap))
        Me.MovieStripBar1.LineMarkerPosition = 0.0!
        Me.MovieStripBar1.Location = New System.Drawing.Point(26, 160)
        Me.MovieStripBar1.Name = "MovieStripBar1"
        Me.MovieStripBar1.Size = New System.Drawing.Size(662, 135)
        Me.MovieStripBar1.StartCutValues = CType(resources.GetObject("MovieStripBar1.StartCutValues"), System.Collections.Generic.List(Of Single))
        Me.MovieStripBar1.TabIndex = 9
        Me.MovieStripBar1.Text = "MovieStripBar1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 422)
        Me.Controls.Add(Me.MovieStripBar1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lblVRDversion)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkSilent)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkSilent As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblVRDversion As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents TrackBar1 As System.Windows.Forms.TrackBar
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents MovieStripBar1 As CutBars.MovieStripBar
End Class
