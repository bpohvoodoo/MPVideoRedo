<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetupForm
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
        Me.txtRecPath = New System.Windows.Forms.TextBox()
        Me.btnRecDialog = New System.Windows.Forms.Button()
        Me.RecDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.chkAutoStartmarker = New System.Windows.Forms.CheckBox()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBoxFilmFolder = New System.Windows.Forms.GroupBox()
        Me.btnShowParseStrings2 = New System.Windows.Forms.Button()
        Me.txtFilmFolderParsing = New System.Windows.Forms.TextBox()
        Me.chkCreateFilmFolder = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.lblTestVideoParsing = New System.Windows.Forms.Label()
        Me.lblTestSeriesParsing = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblParseSeriesFile = New System.Windows.Forms.Label()
        Me.txtParseSeriesFile = New System.Windows.Forms.TextBox()
        Me.imgParseSeries = New System.Windows.Forms.PictureBox()
        Me.btnShowParseStrings = New System.Windows.Forms.Button()
        Me.lblParseVideofile = New System.Windows.Forms.Label()
        Me.txtParseVideoFile = New System.Windows.Forms.TextBox()
        Me.imgParseVideoFile = New System.Windows.Forms.PictureBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.imgAutoEndMarker = New System.Windows.Forms.PictureBox()
        Me.chkAutoEndmarker = New System.Windows.Forms.CheckBox()
        Me.imgAutoStartmarker = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer7 = New System.Windows.Forms.SplitContainer()
        Me.lblRecPath = New System.Windows.Forms.Label()
        Me.lblSavePath = New System.Windows.Forms.Label()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.txtSavePath = New System.Windows.Forms.TextBox()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.bntSaveDialog = New System.Windows.Forms.Button()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBoxOnPause = New System.Windows.Forms.GroupBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.numBackPause3 = New System.Windows.Forms.NumericUpDown()
        Me.numFFWPause3 = New System.Windows.Forms.NumericUpDown()
        Me.lblSkipPart1Pause = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblSkipPart2Pause = New System.Windows.Forms.Label()
        Me.lblSkipPart3Pause = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.lblBackPause = New System.Windows.Forms.Label()
        Me.numFFWPause2 = New System.Windows.Forms.NumericUpDown()
        Me.lblFFWPause = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.numBackPause1 = New System.Windows.Forms.NumericUpDown()
        Me.numBackPause2 = New System.Windows.Forms.NumericUpDown()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.numFFWPause1 = New System.Windows.Forms.NumericUpDown()
        Me.GroupBoxOnPlay = New System.Windows.Forms.GroupBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.numFFWPlay3 = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.numBackPlay3 = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.numFFWPlay2 = New System.Windows.Forms.NumericUpDown()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.numBackPlay2 = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.numFFWPlay1 = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.numBackPlay1 = New System.Windows.Forms.NumericUpDown()
        Me.lblSkipFFWPlay = New System.Windows.Forms.Label()
        Me.lblSkipBackPlay = New System.Windows.Forms.Label()
        Me.lblSkipPart3Play = New System.Windows.Forms.Label()
        Me.lblSkipPart2Play = New System.Windows.Forms.Label()
        Me.lblSkipPart1Play = New System.Windows.Forms.Label()
        Me.lblconfigureSeekSteps = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.CheckBoxdebugMode = New System.Windows.Forms.CheckBox()
        Me.GroupBoxTVsuiteProfile = New System.Windows.Forms.GroupBox()
        Me.lblFramerate = New System.Windows.Forms.Label()
        Me.lblDeinterlacemode = New System.Windows.Forms.Label()
        Me.lblRatio = New System.Windows.Forms.Label()
        Me.lblResolution = New System.Windows.Forms.Label()
        Me.lblFileType = New System.Windows.Forms.Label()
        Me.lblEncodingType = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnCheckTVsuite = New System.Windows.Forms.Button()
        Me.lblDescriptionTVsuite = New System.Windows.Forms.Label()
        Me.lblDonate = New System.Windows.Forms.LinkLabel()
        Me.SaveDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBoxTVsuiteProfileH264 = New System.Windows.Forms.GroupBox()
        Me.lblFramerateH264 = New System.Windows.Forms.Label()
        Me.lblDeinterlacemodeH264 = New System.Windows.Forms.Label()
        Me.lblRatioH264 = New System.Windows.Forms.Label()
        Me.lblResolutionH264 = New System.Windows.Forms.Label()
        Me.lblFileTypeH264 = New System.Windows.Forms.Label()
        Me.lblEncodingTypeH264 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.ComboBoxH264 = New System.Windows.Forms.ComboBox()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBoxFilmFolder.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.imgParseSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgParseVideoFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.imgAutoEndMarker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgAutoStartmarker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        Me.SplitContainer7.Panel1.SuspendLayout()
        Me.SplitContainer7.Panel2.SuspendLayout()
        Me.SplitContainer7.SuspendLayout()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBoxOnPause.SuspendLayout()
        CType(Me.numBackPause3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFFWPause3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFFWPause2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numBackPause1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numBackPause2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFFWPause1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxOnPlay.SuspendLayout()
        CType(Me.numFFWPlay3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numBackPlay3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFFWPlay2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numBackPlay2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFFWPlay1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numBackPlay1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.GroupBoxTVsuiteProfile.SuspendLayout()
        Me.GroupBoxTVsuiteProfileH264.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRecPath
        '
        Me.txtRecPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtRecPath.Location = New System.Drawing.Point(0, 0)
        Me.txtRecPath.Name = "txtRecPath"
        Me.txtRecPath.Size = New System.Drawing.Size(335, 20)
        Me.txtRecPath.TabIndex = 0
        '
        'btnRecDialog
        '
        Me.btnRecDialog.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRecDialog.Location = New System.Drawing.Point(0, 0)
        Me.btnRecDialog.Name = "btnRecDialog"
        Me.btnRecDialog.Size = New System.Drawing.Size(99, 23)
        Me.btnRecDialog.TabIndex = 1
        Me.btnRecDialog.Text = "Button1"
        Me.btnRecDialog.UseVisualStyleBackColor = True
        '
        'RecDialog
        '
        Me.RecDialog.Description = "Ordner der gespeicherten Aufnahmen"
        Me.RecDialog.ShowNewFolderButton = False
        '
        'chkAutoStartmarker
        '
        Me.chkAutoStartmarker.AutoSize = True
        Me.chkAutoStartmarker.Location = New System.Drawing.Point(31, 24)
        Me.chkAutoStartmarker.Name = "chkAutoStartmarker"
        Me.chkAutoStartmarker.Size = New System.Drawing.Size(109, 17)
        Me.chkAutoStartmarker.TabIndex = 2
        Me.chkAutoStartmarker.Text = "setzte startmarker"
        Me.chkAutoStartmarker.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(610, 435)
        Me.SplitContainer1.SplitterDistance = 37
        Me.SplitContainer1.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(610, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MyVideoReDo"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.TabControl1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.lblDonate)
        Me.SplitContainer2.Size = New System.Drawing.Size(610, 394)
        Me.SplitContainer2.SplitterDistance = 333
        Me.SplitContainer2.TabIndex = 4
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(610, 333)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBoxFilmFolder)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(602, 307)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBoxFilmFolder
        '
        Me.GroupBoxFilmFolder.Controls.Add(Me.btnShowParseStrings2)
        Me.GroupBoxFilmFolder.Controls.Add(Me.txtFilmFolderParsing)
        Me.GroupBoxFilmFolder.Controls.Add(Me.chkCreateFilmFolder)
        Me.GroupBoxFilmFolder.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxFilmFolder.Location = New System.Drawing.Point(3, 250)
        Me.GroupBoxFilmFolder.Name = "GroupBoxFilmFolder"
        Me.GroupBoxFilmFolder.Size = New System.Drawing.Size(596, 51)
        Me.GroupBoxFilmFolder.TabIndex = 7
        Me.GroupBoxFilmFolder.TabStop = False
        Me.GroupBoxFilmFolder.Text = "GroupBoxFilmFolderSettings"
        '
        'btnShowParseStrings2
        '
        Me.btnShowParseStrings2.Location = New System.Drawing.Point(492, 14)
        Me.btnShowParseStrings2.Name = "btnShowParseStrings2"
        Me.btnShowParseStrings2.Size = New System.Drawing.Size(93, 25)
        Me.btnShowParseStrings2.TabIndex = 9
        Me.btnShowParseStrings2.Text = "showstrings"
        Me.btnShowParseStrings2.UseVisualStyleBackColor = True
        '
        'txtFilmFolderParsing
        '
        Me.txtFilmFolderParsing.Location = New System.Drawing.Point(201, 17)
        Me.txtFilmFolderParsing.Name = "txtFilmFolderParsing"
        Me.txtFilmFolderParsing.Size = New System.Drawing.Size(284, 20)
        Me.txtFilmFolderParsing.TabIndex = 8
        '
        'chkCreateFilmFolder
        '
        Me.chkCreateFilmFolder.AutoSize = True
        Me.chkCreateFilmFolder.Location = New System.Drawing.Point(10, 19)
        Me.chkCreateFilmFolder.Name = "chkCreateFilmFolder"
        Me.chkCreateFilmFolder.Size = New System.Drawing.Size(122, 17)
        Me.chkCreateFilmFolder.TabIndex = 0
        Me.chkCreateFilmFolder.Text = "chkCreateFilmFolder"
        Me.chkCreateFilmFolder.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblTestVideoParsing)
        Me.GroupBox3.Controls.Add(Me.lblTestSeriesParsing)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.lblParseSeriesFile)
        Me.GroupBox3.Controls.Add(Me.txtParseSeriesFile)
        Me.GroupBox3.Controls.Add(Me.imgParseSeries)
        Me.GroupBox3.Controls.Add(Me.btnShowParseStrings)
        Me.GroupBox3.Controls.Add(Me.lblParseVideofile)
        Me.GroupBox3.Controls.Add(Me.txtParseVideoFile)
        Me.GroupBox3.Controls.Add(Me.imgParseVideoFile)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(3, 131)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(596, 119)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "groupSaveSettings"
        '
        'lblTestVideoParsing
        '
        Me.lblTestVideoParsing.AutoSize = True
        Me.lblTestVideoParsing.Location = New System.Drawing.Point(43, 51)
        Me.lblTestVideoParsing.Name = "lblTestVideoParsing"
        Me.lblTestVideoParsing.Size = New System.Drawing.Size(16, 13)
        Me.lblTestVideoParsing.TabIndex = 14
        Me.lblTestVideoParsing.Text = "..."
        '
        'lblTestSeriesParsing
        '
        Me.lblTestSeriesParsing.AutoSize = True
        Me.lblTestSeriesParsing.Location = New System.Drawing.Point(44, 96)
        Me.lblTestSeriesParsing.Name = "lblTestSeriesParsing"
        Me.lblTestSeriesParsing.Size = New System.Drawing.Size(16, 13)
        Me.lblTestSeriesParsing.TabIndex = 13
        Me.lblTestSeriesParsing.Text = "..."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Test:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Test:"
        '
        'lblParseSeriesFile
        '
        Me.lblParseSeriesFile.AutoSize = True
        Me.lblParseSeriesFile.Location = New System.Drawing.Point(31, 71)
        Me.lblParseSeriesFile.Name = "lblParseSeriesFile"
        Me.lblParseSeriesFile.Size = New System.Drawing.Size(89, 13)
        Me.lblParseSeriesFile.TabIndex = 10
        Me.lblParseSeriesFile.Text = "lblParseSeriesFile"
        '
        'txtParseSeriesFile
        '
        Me.txtParseSeriesFile.Location = New System.Drawing.Point(184, 68)
        Me.txtParseSeriesFile.Name = "txtParseSeriesFile"
        Me.txtParseSeriesFile.Size = New System.Drawing.Size(301, 20)
        Me.txtParseSeriesFile.TabIndex = 11
        '
        'imgParseSeries
        '
        Me.imgParseSeries.Image = Global.MyVideoRedo.My.Resources.Resources.help
        Me.imgParseSeries.Location = New System.Drawing.Point(6, 68)
        Me.imgParseSeries.Name = "imgParseSeries"
        Me.imgParseSeries.Size = New System.Drawing.Size(19, 17)
        Me.imgParseSeries.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgParseSeries.TabIndex = 9
        Me.imgParseSeries.TabStop = False
        '
        'btnShowParseStrings
        '
        Me.btnShowParseStrings.Location = New System.Drawing.Point(492, 24)
        Me.btnShowParseStrings.Name = "btnShowParseStrings"
        Me.btnShowParseStrings.Size = New System.Drawing.Size(93, 89)
        Me.btnShowParseStrings.TabIndex = 8
        Me.btnShowParseStrings.Text = "showstrings"
        Me.btnShowParseStrings.UseVisualStyleBackColor = True
        '
        'lblParseVideofile
        '
        Me.lblParseVideofile.AutoSize = True
        Me.lblParseVideofile.Location = New System.Drawing.Point(31, 27)
        Me.lblParseVideofile.Name = "lblParseVideofile"
        Me.lblParseVideofile.Size = New System.Drawing.Size(84, 13)
        Me.lblParseVideofile.TabIndex = 7
        Me.lblParseVideofile.Text = "lblParseVideofile"
        '
        'txtParseVideoFile
        '
        Me.txtParseVideoFile.Location = New System.Drawing.Point(184, 24)
        Me.txtParseVideoFile.Name = "txtParseVideoFile"
        Me.txtParseVideoFile.Size = New System.Drawing.Size(301, 20)
        Me.txtParseVideoFile.TabIndex = 7
        '
        'imgParseVideoFile
        '
        Me.imgParseVideoFile.Image = Global.MyVideoRedo.My.Resources.Resources.help
        Me.imgParseVideoFile.Location = New System.Drawing.Point(6, 24)
        Me.imgParseVideoFile.Name = "imgParseVideoFile"
        Me.imgParseVideoFile.Size = New System.Drawing.Size(19, 17)
        Me.imgParseVideoFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgParseVideoFile.TabIndex = 6
        Me.imgParseVideoFile.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.imgAutoEndMarker)
        Me.GroupBox2.Controls.Add(Me.chkAutoEndmarker)
        Me.GroupBox2.Controls.Add(Me.imgAutoStartmarker)
        Me.GroupBox2.Controls.Add(Me.chkAutoStartmarker)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(3, 73)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(596, 58)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "groupCutSettings"
        '
        'imgAutoEndMarker
        '
        Me.imgAutoEndMarker.Image = Global.MyVideoRedo.My.Resources.Resources.help
        Me.imgAutoEndMarker.Location = New System.Drawing.Point(294, 24)
        Me.imgAutoEndMarker.Name = "imgAutoEndMarker"
        Me.imgAutoEndMarker.Size = New System.Drawing.Size(19, 17)
        Me.imgAutoEndMarker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgAutoEndMarker.TabIndex = 8
        Me.imgAutoEndMarker.TabStop = False
        '
        'chkAutoEndmarker
        '
        Me.chkAutoEndmarker.AutoSize = True
        Me.chkAutoEndmarker.Location = New System.Drawing.Point(319, 24)
        Me.chkAutoEndmarker.Name = "chkAutoEndmarker"
        Me.chkAutoEndmarker.Size = New System.Drawing.Size(107, 17)
        Me.chkAutoEndmarker.TabIndex = 7
        Me.chkAutoEndmarker.Text = "setzte endmarker"
        Me.chkAutoEndmarker.UseVisualStyleBackColor = True
        '
        'imgAutoStartmarker
        '
        Me.imgAutoStartmarker.Image = Global.MyVideoRedo.My.Resources.Resources.help
        Me.imgAutoStartmarker.Location = New System.Drawing.Point(6, 24)
        Me.imgAutoStartmarker.Name = "imgAutoStartmarker"
        Me.imgAutoStartmarker.Size = New System.Drawing.Size(19, 17)
        Me.imgAutoStartmarker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgAutoStartmarker.TabIndex = 6
        Me.imgAutoStartmarker.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.SplitContainer3)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(596, 70)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "groupRecordings"
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(3, 16)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.SplitContainer7)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer3.Size = New System.Drawing.Size(590, 51)
        Me.SplitContainer3.SplitterDistance = 143
        Me.SplitContainer3.TabIndex = 7
        '
        'SplitContainer7
        '
        Me.SplitContainer7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer7.IsSplitterFixed = True
        Me.SplitContainer7.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer7.Name = "SplitContainer7"
        Me.SplitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer7.Panel1
        '
        Me.SplitContainer7.Panel1.Controls.Add(Me.lblRecPath)
        '
        'SplitContainer7.Panel2
        '
        Me.SplitContainer7.Panel2.Controls.Add(Me.lblSavePath)
        Me.SplitContainer7.Size = New System.Drawing.Size(143, 51)
        Me.SplitContainer7.SplitterDistance = 25
        Me.SplitContainer7.TabIndex = 7
        '
        'lblRecPath
        '
        Me.lblRecPath.AutoSize = True
        Me.lblRecPath.Location = New System.Drawing.Point(3, 7)
        Me.lblRecPath.Name = "lblRecPath"
        Me.lblRecPath.Size = New System.Drawing.Size(39, 13)
        Me.lblRecPath.TabIndex = 0
        Me.lblRecPath.Text = "Label2"
        '
        'lblSavePath
        '
        Me.lblSavePath.AutoSize = True
        Me.lblSavePath.Location = New System.Drawing.Point(3, 5)
        Me.lblSavePath.Name = "lblSavePath"
        Me.lblSavePath.Size = New System.Drawing.Size(39, 13)
        Me.lblSavePath.TabIndex = 3
        Me.lblSavePath.Text = "Label3"
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer4.IsSplitterFixed = True
        Me.SplitContainer4.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel1
        '
        Me.SplitContainer4.Panel1.Controls.Add(Me.SplitContainer6)
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.SplitContainer5)
        Me.SplitContainer4.Size = New System.Drawing.Size(443, 51)
        Me.SplitContainer4.SplitterDistance = 340
        Me.SplitContainer4.TabIndex = 0
        '
        'SplitContainer6
        '
        Me.SplitContainer6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer6.IsSplitterFixed = True
        Me.SplitContainer6.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer6.Name = "SplitContainer6"
        Me.SplitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer6.Panel1
        '
        Me.SplitContainer6.Panel1.Controls.Add(Me.txtRecPath)
        '
        'SplitContainer6.Panel2
        '
        Me.SplitContainer6.Panel2.Controls.Add(Me.txtSavePath)
        Me.SplitContainer6.Size = New System.Drawing.Size(340, 51)
        Me.SplitContainer6.SplitterDistance = 25
        Me.SplitContainer6.TabIndex = 3
        '
        'txtSavePath
        '
        Me.txtSavePath.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtSavePath.Location = New System.Drawing.Point(0, 0)
        Me.txtSavePath.Name = "txtSavePath"
        Me.txtSavePath.Size = New System.Drawing.Size(335, 20)
        Me.txtSavePath.TabIndex = 2
        '
        'SplitContainer5
        '
        Me.SplitContainer5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer5.IsSplitterFixed = True
        Me.SplitContainer5.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer5.Name = "SplitContainer5"
        Me.SplitContainer5.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer5.Panel1
        '
        Me.SplitContainer5.Panel1.Controls.Add(Me.btnRecDialog)
        '
        'SplitContainer5.Panel2
        '
        Me.SplitContainer5.Panel2.Controls.Add(Me.bntSaveDialog)
        Me.SplitContainer5.Size = New System.Drawing.Size(99, 51)
        Me.SplitContainer5.SplitterDistance = 25
        Me.SplitContainer5.TabIndex = 5
        '
        'bntSaveDialog
        '
        Me.bntSaveDialog.Dock = System.Windows.Forms.DockStyle.Top
        Me.bntSaveDialog.Location = New System.Drawing.Point(0, 0)
        Me.bntSaveDialog.Name = "bntSaveDialog"
        Me.bntSaveDialog.Size = New System.Drawing.Size(99, 23)
        Me.bntSaveDialog.TabIndex = 4
        Me.bntSaveDialog.Text = "Button2"
        Me.bntSaveDialog.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.GroupBoxOnPause)
        Me.TabPage2.Controls.Add(Me.GroupBoxOnPlay)
        Me.TabPage2.Controls.Add(Me.lblconfigureSeekSteps)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(602, 307)
        Me.TabPage2.TabIndex = 3
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBoxOnPause
        '
        Me.GroupBoxOnPause.Controls.Add(Me.Label15)
        Me.GroupBoxOnPause.Controls.Add(Me.numBackPause3)
        Me.GroupBoxOnPause.Controls.Add(Me.numFFWPause3)
        Me.GroupBoxOnPause.Controls.Add(Me.lblSkipPart1Pause)
        Me.GroupBoxOnPause.Controls.Add(Me.Label16)
        Me.GroupBoxOnPause.Controls.Add(Me.lblSkipPart2Pause)
        Me.GroupBoxOnPause.Controls.Add(Me.lblSkipPart3Pause)
        Me.GroupBoxOnPause.Controls.Add(Me.Label17)
        Me.GroupBoxOnPause.Controls.Add(Me.lblBackPause)
        Me.GroupBoxOnPause.Controls.Add(Me.numFFWPause2)
        Me.GroupBoxOnPause.Controls.Add(Me.lblFFWPause)
        Me.GroupBoxOnPause.Controls.Add(Me.Label18)
        Me.GroupBoxOnPause.Controls.Add(Me.numBackPause1)
        Me.GroupBoxOnPause.Controls.Add(Me.numBackPause2)
        Me.GroupBoxOnPause.Controls.Add(Me.Label20)
        Me.GroupBoxOnPause.Controls.Add(Me.Label19)
        Me.GroupBoxOnPause.Controls.Add(Me.numFFWPause1)
        Me.GroupBoxOnPause.Location = New System.Drawing.Point(310, 40)
        Me.GroupBoxOnPause.Name = "GroupBoxOnPause"
        Me.GroupBoxOnPause.Size = New System.Drawing.Size(279, 210)
        Me.GroupBoxOnPause.TabIndex = 2
        Me.GroupBoxOnPause.TabStop = False
        Me.GroupBoxOnPause.Text = "GroupBox6"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(234, 148)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 33
        Me.Label15.Text = "Frames"
        '
        'numBackPause3
        '
        Me.numBackPause3.Location = New System.Drawing.Point(87, 145)
        Me.numBackPause3.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numBackPause3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numBackPause3.Name = "numBackPause3"
        Me.numBackPause3.Size = New System.Drawing.Size(42, 20)
        Me.numBackPause3.TabIndex = 30
        Me.numBackPause3.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numFFWPause3
        '
        Me.numFFWPause3.Location = New System.Drawing.Point(192, 145)
        Me.numFFWPause3.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numFFWPause3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numFFWPause3.Name = "numFFWPause3"
        Me.numFFWPause3.Size = New System.Drawing.Size(39, 20)
        Me.numFFWPause3.TabIndex = 32
        Me.numFFWPause3.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblSkipPart1Pause
        '
        Me.lblSkipPart1Pause.AutoSize = True
        Me.lblSkipPart1Pause.Location = New System.Drawing.Point(9, 67)
        Me.lblSkipPart1Pause.Name = "lblSkipPart1Pause"
        Me.lblSkipPart1Pause.Size = New System.Drawing.Size(45, 13)
        Me.lblSkipPart1Pause.TabIndex = 17
        Me.lblSkipPart1Pause.Text = "Label25"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(132, 148)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(41, 13)
        Me.Label16.TabIndex = 31
        Me.Label16.Text = "Frames"
        '
        'lblSkipPart2Pause
        '
        Me.lblSkipPart2Pause.AutoSize = True
        Me.lblSkipPart2Pause.Location = New System.Drawing.Point(9, 108)
        Me.lblSkipPart2Pause.Name = "lblSkipPart2Pause"
        Me.lblSkipPart2Pause.Size = New System.Drawing.Size(45, 13)
        Me.lblSkipPart2Pause.TabIndex = 18
        Me.lblSkipPart2Pause.Text = "Label24"
        '
        'lblSkipPart3Pause
        '
        Me.lblSkipPart3Pause.AutoSize = True
        Me.lblSkipPart3Pause.Location = New System.Drawing.Point(9, 147)
        Me.lblSkipPart3Pause.Name = "lblSkipPart3Pause"
        Me.lblSkipPart3Pause.Size = New System.Drawing.Size(45, 13)
        Me.lblSkipPart3Pause.TabIndex = 19
        Me.lblSkipPart3Pause.Text = "Label23"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(234, 109)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 13)
        Me.Label17.TabIndex = 29
        Me.Label17.Text = "Frames"
        '
        'lblBackPause
        '
        Me.lblBackPause.Location = New System.Drawing.Point(60, 27)
        Me.lblBackPause.Name = "lblBackPause"
        Me.lblBackPause.Size = New System.Drawing.Size(101, 13)
        Me.lblBackPause.TabIndex = 20
        Me.lblBackPause.Text = "Label22"
        Me.lblBackPause.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'numFFWPause2
        '
        Me.numFFWPause2.Location = New System.Drawing.Point(192, 106)
        Me.numFFWPause2.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numFFWPause2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numFFWPause2.Name = "numFFWPause2"
        Me.numFFWPause2.Size = New System.Drawing.Size(39, 20)
        Me.numFFWPause2.TabIndex = 28
        Me.numFFWPause2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblFFWPause
        '
        Me.lblFFWPause.Location = New System.Drawing.Point(162, 27)
        Me.lblFFWPause.Name = "lblFFWPause"
        Me.lblFFWPause.Size = New System.Drawing.Size(101, 13)
        Me.lblFFWPause.TabIndex = 21
        Me.lblFFWPause.Text = "Label21"
        Me.lblFFWPause.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(132, 109)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(41, 13)
        Me.Label18.TabIndex = 27
        Me.Label18.Text = "Frames"
        '
        'numBackPause1
        '
        Me.numBackPause1.Location = New System.Drawing.Point(87, 65)
        Me.numBackPause1.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numBackPause1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numBackPause1.Name = "numBackPause1"
        Me.numBackPause1.Size = New System.Drawing.Size(42, 20)
        Me.numBackPause1.TabIndex = 22
        Me.numBackPause1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numBackPause2
        '
        Me.numBackPause2.Location = New System.Drawing.Point(87, 106)
        Me.numBackPause2.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numBackPause2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numBackPause2.Name = "numBackPause2"
        Me.numBackPause2.Size = New System.Drawing.Size(42, 20)
        Me.numBackPause2.TabIndex = 26
        Me.numBackPause2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(132, 68)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(41, 13)
        Me.Label20.TabIndex = 23
        Me.Label20.Text = "Frames"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(234, 68)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(41, 13)
        Me.Label19.TabIndex = 25
        Me.Label19.Text = "Frames"
        '
        'numFFWPause1
        '
        Me.numFFWPause1.Location = New System.Drawing.Point(192, 65)
        Me.numFFWPause1.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numFFWPause1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numFFWPause1.Name = "numFFWPause1"
        Me.numFFWPause1.Size = New System.Drawing.Size(39, 20)
        Me.numFFWPause1.TabIndex = 24
        Me.numFFWPause1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'GroupBoxOnPlay
        '
        Me.GroupBoxOnPlay.Controls.Add(Me.Label13)
        Me.GroupBoxOnPlay.Controls.Add(Me.numFFWPlay3)
        Me.GroupBoxOnPlay.Controls.Add(Me.Label14)
        Me.GroupBoxOnPlay.Controls.Add(Me.numBackPlay3)
        Me.GroupBoxOnPlay.Controls.Add(Me.Label11)
        Me.GroupBoxOnPlay.Controls.Add(Me.numFFWPlay2)
        Me.GroupBoxOnPlay.Controls.Add(Me.Label12)
        Me.GroupBoxOnPlay.Controls.Add(Me.numBackPlay2)
        Me.GroupBoxOnPlay.Controls.Add(Me.Label10)
        Me.GroupBoxOnPlay.Controls.Add(Me.numFFWPlay1)
        Me.GroupBoxOnPlay.Controls.Add(Me.Label9)
        Me.GroupBoxOnPlay.Controls.Add(Me.numBackPlay1)
        Me.GroupBoxOnPlay.Controls.Add(Me.lblSkipFFWPlay)
        Me.GroupBoxOnPlay.Controls.Add(Me.lblSkipBackPlay)
        Me.GroupBoxOnPlay.Controls.Add(Me.lblSkipPart3Play)
        Me.GroupBoxOnPlay.Controls.Add(Me.lblSkipPart2Play)
        Me.GroupBoxOnPlay.Controls.Add(Me.lblSkipPart1Play)
        Me.GroupBoxOnPlay.Location = New System.Drawing.Point(8, 40)
        Me.GroupBoxOnPlay.Name = "GroupBoxOnPlay"
        Me.GroupBoxOnPlay.Size = New System.Drawing.Size(283, 210)
        Me.GroupBoxOnPlay.TabIndex = 1
        Me.GroupBoxOnPlay.TabStop = False
        Me.GroupBoxOnPlay.Text = "GroupBox5"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(231, 153)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 13)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "Sec."
        '
        'numFFWPlay3
        '
        Me.numFFWPlay3.Location = New System.Drawing.Point(189, 150)
        Me.numFFWPlay3.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numFFWPlay3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numFFWPlay3.Name = "numFFWPlay3"
        Me.numFFWPlay3.Size = New System.Drawing.Size(39, 20)
        Me.numFFWPlay3.TabIndex = 15
        Me.numFFWPlay3.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(129, 153)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 13)
        Me.Label14.TabIndex = 14
        Me.Label14.Text = "Sec."
        '
        'numBackPlay3
        '
        Me.numBackPlay3.Location = New System.Drawing.Point(84, 150)
        Me.numBackPlay3.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numBackPlay3.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numBackPlay3.Name = "numBackPlay3"
        Me.numBackPlay3.Size = New System.Drawing.Size(42, 20)
        Me.numBackPlay3.TabIndex = 13
        Me.numBackPlay3.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(231, 114)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(29, 13)
        Me.Label11.TabIndex = 12
        Me.Label11.Text = "Sec."
        '
        'numFFWPlay2
        '
        Me.numFFWPlay2.Location = New System.Drawing.Point(189, 111)
        Me.numFFWPlay2.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numFFWPlay2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numFFWPlay2.Name = "numFFWPlay2"
        Me.numFFWPlay2.Size = New System.Drawing.Size(39, 20)
        Me.numFFWPlay2.TabIndex = 11
        Me.numFFWPlay2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(129, 114)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(29, 13)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Sec."
        '
        'numBackPlay2
        '
        Me.numBackPlay2.Location = New System.Drawing.Point(84, 111)
        Me.numBackPlay2.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numBackPlay2.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numBackPlay2.Name = "numBackPlay2"
        Me.numBackPlay2.Size = New System.Drawing.Size(42, 20)
        Me.numBackPlay2.TabIndex = 9
        Me.numBackPlay2.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(231, 73)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 13)
        Me.Label10.TabIndex = 8
        Me.Label10.Text = "Sec."
        '
        'numFFWPlay1
        '
        Me.numFFWPlay1.Location = New System.Drawing.Point(189, 70)
        Me.numFFWPlay1.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numFFWPlay1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numFFWPlay1.Name = "numFFWPlay1"
        Me.numFFWPlay1.Size = New System.Drawing.Size(39, 20)
        Me.numFFWPlay1.TabIndex = 7
        Me.numFFWPlay1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(129, 73)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 6
        Me.Label9.Text = "Sec."
        '
        'numBackPlay1
        '
        Me.numBackPlay1.Location = New System.Drawing.Point(84, 70)
        Me.numBackPlay1.Maximum = New Decimal(New Integer() {500, 0, 0, 0})
        Me.numBackPlay1.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numBackPlay1.Name = "numBackPlay1"
        Me.numBackPlay1.Size = New System.Drawing.Size(42, 20)
        Me.numBackPlay1.TabIndex = 5
        Me.numBackPlay1.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblSkipFFWPlay
        '
        Me.lblSkipFFWPlay.Location = New System.Drawing.Point(165, 27)
        Me.lblSkipFFWPlay.Name = "lblSkipFFWPlay"
        Me.lblSkipFFWPlay.Size = New System.Drawing.Size(95, 13)
        Me.lblSkipFFWPlay.TabIndex = 4
        Me.lblSkipFFWPlay.Text = "Label8"
        Me.lblSkipFFWPlay.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSkipBackPlay
        '
        Me.lblSkipBackPlay.Location = New System.Drawing.Point(63, 27)
        Me.lblSkipBackPlay.Name = "lblSkipBackPlay"
        Me.lblSkipBackPlay.Size = New System.Drawing.Size(95, 13)
        Me.lblSkipBackPlay.TabIndex = 3
        Me.lblSkipBackPlay.Text = "Label7"
        Me.lblSkipBackPlay.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSkipPart3Play
        '
        Me.lblSkipPart3Play.AutoSize = True
        Me.lblSkipPart3Play.Location = New System.Drawing.Point(6, 152)
        Me.lblSkipPart3Play.Name = "lblSkipPart3Play"
        Me.lblSkipPart3Play.Size = New System.Drawing.Size(39, 13)
        Me.lblSkipPart3Play.TabIndex = 2
        Me.lblSkipPart3Play.Text = "Label4"
        '
        'lblSkipPart2Play
        '
        Me.lblSkipPart2Play.AutoSize = True
        Me.lblSkipPart2Play.Location = New System.Drawing.Point(6, 113)
        Me.lblSkipPart2Play.Name = "lblSkipPart2Play"
        Me.lblSkipPart2Play.Size = New System.Drawing.Size(39, 13)
        Me.lblSkipPart2Play.TabIndex = 1
        Me.lblSkipPart2Play.Text = "Label3"
        '
        'lblSkipPart1Play
        '
        Me.lblSkipPart1Play.AutoSize = True
        Me.lblSkipPart1Play.Location = New System.Drawing.Point(6, 72)
        Me.lblSkipPart1Play.Name = "lblSkipPart1Play"
        Me.lblSkipPart1Play.Size = New System.Drawing.Size(39, 13)
        Me.lblSkipPart1Play.TabIndex = 0
        Me.lblSkipPart1Play.Text = "Label2"
        '
        'lblconfigureSeekSteps
        '
        Me.lblconfigureSeekSteps.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblconfigureSeekSteps.Location = New System.Drawing.Point(8, 12)
        Me.lblconfigureSeekSteps.Name = "lblconfigureSeekSteps"
        Me.lblconfigureSeekSteps.Size = New System.Drawing.Size(581, 23)
        Me.lblconfigureSeekSteps.TabIndex = 0
        Me.lblconfigureSeekSteps.Text = "configureSeekSteps"
        Me.lblconfigureSeekSteps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupBox4)
        Me.TabPage3.Controls.Add(Me.DataGridView1)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(602, 307)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Button4)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.TextBox4)
        Me.GroupBox4.Controls.Add(Me.TextBox5)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 212)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(602, 95)
        Me.GroupBox4.TabIndex = 5
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "editReplacementString"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(453, 20)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 48)
        Me.Button5.TabIndex = 6
        Me.Button5.Text = "delReplaceString"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Replace-String:"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(333, 20)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 48)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "addReplaceString"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Original String:"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(89, 22)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(228, 20)
        Me.TextBox4.TabIndex = 1
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(89, 48)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(228, 20)
        Me.TextBox5.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(602, 212)
        Me.DataGridView1.TabIndex = 0
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GroupBoxTVsuiteProfileH264)
        Me.TabPage4.Controls.Add(Me.CheckBoxdebugMode)
        Me.TabPage4.Controls.Add(Me.GroupBoxTVsuiteProfile)
        Me.TabPage4.Controls.Add(Me.btnCheckTVsuite)
        Me.TabPage4.Controls.Add(Me.lblDescriptionTVsuite)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(602, 307)
        Me.TabPage4.TabIndex = 4
        Me.TabPage4.Text = "TVsuite4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'CheckBoxdebugMode
        '
        Me.CheckBoxdebugMode.AutoSize = True
        Me.CheckBoxdebugMode.Location = New System.Drawing.Point(155, 61)
        Me.CheckBoxdebugMode.Name = "CheckBoxdebugMode"
        Me.CheckBoxdebugMode.Size = New System.Drawing.Size(85, 17)
        Me.CheckBoxdebugMode.TabIndex = 4
        Me.CheckBoxdebugMode.Text = "DebugMode"
        Me.CheckBoxdebugMode.UseVisualStyleBackColor = True
        '
        'GroupBoxTVsuiteProfile
        '
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.lblFramerate)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.lblDeinterlacemode)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.lblRatio)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.lblResolution)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.lblFileType)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.lblEncodingType)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.Label23)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.Label22)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.Label21)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.Label8)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.Label7)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.Label4)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.ComboBox1)
        Me.GroupBoxTVsuiteProfile.Location = New System.Drawing.Point(3, 89)
        Me.GroupBoxTVsuiteProfile.Name = "GroupBoxTVsuiteProfile"
        Me.GroupBoxTVsuiteProfile.Size = New System.Drawing.Size(294, 212)
        Me.GroupBoxTVsuiteProfile.TabIndex = 3
        Me.GroupBoxTVsuiteProfile.TabStop = False
        Me.GroupBoxTVsuiteProfile.Text = "TVsuite Profile"
        Me.GroupBoxTVsuiteProfile.Visible = False
        '
        'lblFramerate
        '
        Me.lblFramerate.AutoSize = True
        Me.lblFramerate.Location = New System.Drawing.Point(116, 172)
        Me.lblFramerate.Name = "lblFramerate"
        Me.lblFramerate.Size = New System.Drawing.Size(64, 13)
        Me.lblFramerate.TabIndex = 14
        Me.lblFramerate.Text = "lblFramerate"
        '
        'lblDeinterlacemode
        '
        Me.lblDeinterlacemode.AutoSize = True
        Me.lblDeinterlacemode.Location = New System.Drawing.Point(116, 146)
        Me.lblDeinterlacemode.Name = "lblDeinterlacemode"
        Me.lblDeinterlacemode.Size = New System.Drawing.Size(97, 13)
        Me.lblDeinterlacemode.TabIndex = 13
        Me.lblDeinterlacemode.Text = "lblDeinterlacemode"
        '
        'lblRatio
        '
        Me.lblRatio.AutoSize = True
        Me.lblRatio.Location = New System.Drawing.Point(116, 120)
        Me.lblRatio.Name = "lblRatio"
        Me.lblRatio.Size = New System.Drawing.Size(42, 13)
        Me.lblRatio.TabIndex = 12
        Me.lblRatio.Text = "lblRatio"
        '
        'lblResolution
        '
        Me.lblResolution.AutoSize = True
        Me.lblResolution.Location = New System.Drawing.Point(116, 96)
        Me.lblResolution.Name = "lblResolution"
        Me.lblResolution.Size = New System.Drawing.Size(67, 13)
        Me.lblResolution.TabIndex = 11
        Me.lblResolution.Text = "lblResolution"
        '
        'lblFileType
        '
        Me.lblFileType.AutoSize = True
        Me.lblFileType.Location = New System.Drawing.Point(116, 73)
        Me.lblFileType.Name = "lblFileType"
        Me.lblFileType.Size = New System.Drawing.Size(53, 13)
        Me.lblFileType.TabIndex = 10
        Me.lblFileType.Text = "lblFiletype"
        '
        'lblEncodingType
        '
        Me.lblEncodingType.AutoSize = True
        Me.lblEncodingType.Location = New System.Drawing.Point(116, 51)
        Me.lblEncodingType.Name = "lblEncodingType"
        Me.lblEncodingType.Size = New System.Drawing.Size(82, 13)
        Me.lblEncodingType.TabIndex = 9
        Me.lblEncodingType.Text = "lblEncodingtype"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 172)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(57, 13)
        Me.Label23.TabIndex = 8
        Me.Label23.Text = "Framerate:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 146)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(90, 13)
        Me.Label22.TabIndex = 7
        Me.Label22.Text = "Deinterlacemode:"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 120)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(35, 13)
        Me.Label21.TabIndex = 6
        Me.Label21.Text = "Ratio:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 96)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 13)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Resolution:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(46, 13)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Filetype:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Encodingtype:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(107, 19)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(174, 21)
        Me.ComboBox1.TabIndex = 2
        '
        'btnCheckTVsuite
        '
        Me.btnCheckTVsuite.Location = New System.Drawing.Point(11, 60)
        Me.btnCheckTVsuite.Name = "btnCheckTVsuite"
        Me.btnCheckTVsuite.Size = New System.Drawing.Size(137, 23)
        Me.btnCheckTVsuite.TabIndex = 1
        Me.btnCheckTVsuite.Text = "btnCheckTVsuite"
        Me.btnCheckTVsuite.UseVisualStyleBackColor = True
        '
        'lblDescriptionTVsuite
        '
        Me.lblDescriptionTVsuite.Location = New System.Drawing.Point(8, 7)
        Me.lblDescriptionTVsuite.Name = "lblDescriptionTVsuite"
        Me.lblDescriptionTVsuite.Size = New System.Drawing.Size(581, 50)
        Me.lblDescriptionTVsuite.TabIndex = 0
        Me.lblDescriptionTVsuite.Text = "lblDescriptionTVsuite"
        '
        'lblDonate
        '
        Me.lblDonate.AutoSize = True
        Me.lblDonate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDonate.Location = New System.Drawing.Point(156, 14)
        Me.lblDonate.Name = "lblDonate"
        Me.lblDonate.Size = New System.Drawing.Size(270, 15)
        Me.lblDonate.TabIndex = 0
        Me.lblDonate.TabStop = True
        Me.lblDonate.Text = "Buy me a Coffee over PayPal !! Thanks ;-)"
        '
        'GroupBoxTVsuiteProfileH264
        '
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.lblFramerateH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.lblDeinterlacemodeH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.lblRatioH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.lblResolutionH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.lblFileTypeH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.lblEncodingTypeH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.Label30)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.Label31)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.Label32)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.Label33)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.Label34)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.Label35)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.ComboBoxH264)
        Me.GroupBoxTVsuiteProfileH264.Location = New System.Drawing.Point(303, 89)
        Me.GroupBoxTVsuiteProfileH264.Name = "GroupBoxTVsuiteProfileH264"
        Me.GroupBoxTVsuiteProfileH264.Size = New System.Drawing.Size(293, 212)
        Me.GroupBoxTVsuiteProfileH264.TabIndex = 15
        Me.GroupBoxTVsuiteProfileH264.TabStop = False
        Me.GroupBoxTVsuiteProfileH264.Text = "TVsuite Profile H264"
        Me.GroupBoxTVsuiteProfileH264.Visible = False
        '
        'lblFramerateH264
        '
        Me.lblFramerateH264.AutoSize = True
        Me.lblFramerateH264.Location = New System.Drawing.Point(116, 172)
        Me.lblFramerateH264.Name = "lblFramerateH264"
        Me.lblFramerateH264.Size = New System.Drawing.Size(90, 13)
        Me.lblFramerateH264.TabIndex = 14
        Me.lblFramerateH264.Text = "lblFramerateH264"
        '
        'lblDeinterlacemodeH264
        '
        Me.lblDeinterlacemodeH264.AutoSize = True
        Me.lblDeinterlacemodeH264.Location = New System.Drawing.Point(116, 146)
        Me.lblDeinterlacemodeH264.Name = "lblDeinterlacemodeH264"
        Me.lblDeinterlacemodeH264.Size = New System.Drawing.Size(123, 13)
        Me.lblDeinterlacemodeH264.TabIndex = 13
        Me.lblDeinterlacemodeH264.Text = "lblDeinterlacemodeH264"
        '
        'lblRatioH264
        '
        Me.lblRatioH264.AutoSize = True
        Me.lblRatioH264.Location = New System.Drawing.Point(116, 120)
        Me.lblRatioH264.Name = "lblRatioH264"
        Me.lblRatioH264.Size = New System.Drawing.Size(68, 13)
        Me.lblRatioH264.TabIndex = 12
        Me.lblRatioH264.Text = "lblRatioH264"
        '
        'lblResolutionH264
        '
        Me.lblResolutionH264.AutoSize = True
        Me.lblResolutionH264.Location = New System.Drawing.Point(116, 96)
        Me.lblResolutionH264.Name = "lblResolutionH264"
        Me.lblResolutionH264.Size = New System.Drawing.Size(93, 13)
        Me.lblResolutionH264.TabIndex = 11
        Me.lblResolutionH264.Text = "lblResolutionH264"
        '
        'lblFileTypeH264
        '
        Me.lblFileTypeH264.AutoSize = True
        Me.lblFileTypeH264.Location = New System.Drawing.Point(116, 73)
        Me.lblFileTypeH264.Name = "lblFileTypeH264"
        Me.lblFileTypeH264.Size = New System.Drawing.Size(79, 13)
        Me.lblFileTypeH264.TabIndex = 10
        Me.lblFileTypeH264.Text = "lblFiletypeH264"
        '
        'lblEncodingTypeH264
        '
        Me.lblEncodingTypeH264.AutoSize = True
        Me.lblEncodingTypeH264.Location = New System.Drawing.Point(116, 51)
        Me.lblEncodingTypeH264.Name = "lblEncodingTypeH264"
        Me.lblEncodingTypeH264.Size = New System.Drawing.Size(108, 13)
        Me.lblEncodingTypeH264.TabIndex = 9
        Me.lblEncodingTypeH264.Text = "lblEncodingtypeH264"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(6, 172)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(57, 13)
        Me.Label30.TabIndex = 8
        Me.Label30.Text = "Framerate:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(6, 146)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(90, 13)
        Me.Label31.TabIndex = 7
        Me.Label31.Text = "Deinterlacemode:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(6, 120)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(35, 13)
        Me.Label32.TabIndex = 6
        Me.Label32.Text = "Ratio:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(6, 96)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(60, 13)
        Me.Label33.TabIndex = 5
        Me.Label33.Text = "Resolution:"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(6, 73)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(46, 13)
        Me.Label34.TabIndex = 4
        Me.Label34.Text = "Filetype:"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(6, 51)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(75, 13)
        Me.Label35.TabIndex = 3
        Me.Label35.Text = "Encodingtype:"
        '
        'ComboBoxH264
        '
        Me.ComboBoxH264.FormattingEnabled = True
        Me.ComboBoxH264.Location = New System.Drawing.Point(107, 19)
        Me.ComboBoxH264.Name = "ComboBoxH264"
        Me.ComboBoxH264.Size = New System.Drawing.Size(174, 21)
        Me.ComboBoxH264.TabIndex = 2
        '
        'SetupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 435)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "SetupForm"
        Me.Text = "SetupForm"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBoxFilmFolder.ResumeLayout(False)
        Me.GroupBoxFilmFolder.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.imgParseSeries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgParseVideoFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.imgAutoEndMarker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgAutoStartmarker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer7.Panel1.ResumeLayout(False)
        Me.SplitContainer7.Panel1.PerformLayout()
        Me.SplitContainer7.Panel2.ResumeLayout(False)
        Me.SplitContainer7.Panel2.PerformLayout()
        Me.SplitContainer7.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        Me.SplitContainer4.ResumeLayout(False)
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel1.PerformLayout()
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        Me.SplitContainer6.Panel2.PerformLayout()
        Me.SplitContainer6.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        Me.SplitContainer5.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.GroupBoxOnPause.ResumeLayout(False)
        Me.GroupBoxOnPause.PerformLayout()
        CType(Me.numBackPause3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFFWPause3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFFWPause2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numBackPause1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numBackPause2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFFWPause1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxOnPlay.ResumeLayout(False)
        Me.GroupBoxOnPlay.PerformLayout()
        CType(Me.numFFWPlay3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numBackPlay3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFFWPlay2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numBackPlay2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFFWPlay1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numBackPlay1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.GroupBoxTVsuiteProfile.ResumeLayout(False)
        Me.GroupBoxTVsuiteProfile.PerformLayout()
        Me.GroupBoxTVsuiteProfileH264.ResumeLayout(False)
        Me.GroupBoxTVsuiteProfileH264.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtRecPath As System.Windows.Forms.TextBox
    Friend WithEvents btnRecDialog As System.Windows.Forms.Button
    Friend WithEvents RecDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents chkAutoStartmarker As System.Windows.Forms.CheckBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblSavePath As System.Windows.Forms.Label
    Friend WithEvents txtSavePath As System.Windows.Forms.TextBox
    Friend WithEvents bntSaveDialog As System.Windows.Forms.Button
    Friend WithEvents lblRecPath As System.Windows.Forms.Label
    Friend WithEvents SaveDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents imgAutoStartmarker As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer7 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer6 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnShowParseStrings As System.Windows.Forms.Button
    Friend WithEvents lblParseVideofile As System.Windows.Forms.Label
    Friend WithEvents txtParseVideoFile As System.Windows.Forms.TextBox
    Friend WithEvents imgParseVideoFile As System.Windows.Forms.PictureBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents lblParseSeriesFile As System.Windows.Forms.Label
    Friend WithEvents txtParseSeriesFile As System.Windows.Forms.TextBox
    Friend WithEvents imgParseSeries As System.Windows.Forms.PictureBox
    Friend WithEvents imgAutoEndMarker As System.Windows.Forms.PictureBox
    Friend WithEvents chkAutoEndmarker As System.Windows.Forms.CheckBox
    Friend WithEvents lblDonate As System.Windows.Forms.LinkLabel
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxOnPause As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxOnPlay As System.Windows.Forms.GroupBox
    Friend WithEvents lblSkipFFWPlay As System.Windows.Forms.Label
    Friend WithEvents lblSkipBackPlay As System.Windows.Forms.Label
    Friend WithEvents lblSkipPart3Play As System.Windows.Forms.Label
    Friend WithEvents lblSkipPart2Play As System.Windows.Forms.Label
    Friend WithEvents lblSkipPart1Play As System.Windows.Forms.Label
    Friend WithEvents lblconfigureSeekSteps As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents numBackPause3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numFFWPause3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSkipPart1Pause As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblSkipPart2Pause As System.Windows.Forms.Label
    Friend WithEvents lblSkipPart3Pause As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents lblBackPause As System.Windows.Forms.Label
    Friend WithEvents numFFWPause2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblFFWPause As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents numBackPause1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numBackPause2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents numFFWPause1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents numFFWPlay3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents numBackPlay3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents numFFWPlay2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents numBackPlay2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents numFFWPlay1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents numBackPlay1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblTestVideoParsing As System.Windows.Forms.Label
    Friend WithEvents lblTestSeriesParsing As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxFilmFolder As System.Windows.Forms.GroupBox
    Friend WithEvents btnShowParseStrings2 As System.Windows.Forms.Button
    Friend WithEvents txtFilmFolderParsing As System.Windows.Forms.TextBox
    Friend WithEvents chkCreateFilmFolder As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents btnCheckTVsuite As System.Windows.Forms.Button
    Friend WithEvents lblDescriptionTVsuite As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBoxTVsuiteProfile As System.Windows.Forms.GroupBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents lblFramerate As System.Windows.Forms.Label
    Friend WithEvents lblDeinterlacemode As System.Windows.Forms.Label
    Friend WithEvents lblRatio As System.Windows.Forms.Label
    Friend WithEvents lblResolution As System.Windows.Forms.Label
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents lblEncodingType As System.Windows.Forms.Label
    Friend WithEvents CheckBoxdebugMode As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxTVsuiteProfileH264 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFramerateH264 As System.Windows.Forms.Label
    Friend WithEvents lblDeinterlacemodeH264 As System.Windows.Forms.Label
    Friend WithEvents lblRatioH264 As System.Windows.Forms.Label
    Friend WithEvents lblResolutionH264 As System.Windows.Forms.Label
    Friend WithEvents lblFileTypeH264 As System.Windows.Forms.Label
    Friend WithEvents lblEncodingTypeH264 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxH264 As System.Windows.Forms.ComboBox
End Class
