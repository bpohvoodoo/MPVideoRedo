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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SetupForm))
        Me.RecDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.tabCommon1 = New System.Windows.Forms.TabPage()
        Me.GroupBoxSaveSettings = New System.Windows.Forms.GroupBox()
        Me.lblTestSeriesFolderParsing = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblTestMovieFolderParsing = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtParseSeriesFolder = New System.Windows.Forms.TextBox()
        Me.chkCreateSeriesFolder = New System.Windows.Forms.CheckBox()
        Me.txtParseMovieFolder = New System.Windows.Forms.TextBox()
        Me.chkCreateMovieFolder = New System.Windows.Forms.CheckBox()
        Me.lblTestMovieParsing = New System.Windows.Forms.Label()
        Me.lblTestSeriesParsing = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblParseSeriesFile = New System.Windows.Forms.Label()
        Me.txtParseSeriesFile = New System.Windows.Forms.TextBox()
        Me.imgParseSeries = New System.Windows.Forms.PictureBox()
        Me.btnShowParseStrings = New System.Windows.Forms.Button()
        Me.lblParseMoviefile = New System.Windows.Forms.Label()
        Me.txtParseMovieFile = New System.Windows.Forms.TextBox()
        Me.imgParseMovieFile = New System.Windows.Forms.PictureBox()
        Me.GroupBoxRecordings = New System.Windows.Forms.GroupBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer7 = New System.Windows.Forms.SplitContainer()
        Me.lblRecPath = New System.Windows.Forms.Label()
        Me.lblSavePath = New System.Windows.Forms.Label()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer6 = New System.Windows.Forms.SplitContainer()
        Me.txtRecPath = New System.Windows.Forms.TextBox()
        Me.txtSavePath = New System.Windows.Forms.TextBox()
        Me.SplitContainer5 = New System.Windows.Forms.SplitContainer()
        Me.btnRecDialog = New System.Windows.Forms.Button()
        Me.bntSaveDialog = New System.Windows.Forms.Button()
        Me.GroupBoxModuleName = New System.Windows.Forms.GroupBox()
        Me.lblModulName = New System.Windows.Forms.Label()
        Me.txtModulName = New System.Windows.Forms.TextBox()
        Me.tabCommon2 = New System.Windows.Forms.TabPage()
        Me.GroupAlwaysRefreshMoviestripThumbs = New System.Windows.Forms.GroupBox()
        Me.lblSeconds = New System.Windows.Forms.Label()
        Me.numAlwaysRefreshMoviestripThumbsDelay = New System.Windows.Forms.NumericUpDown()
        Me.lblAlwaysRefreshMoviestripThumbsDelay = New System.Windows.Forms.Label()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.chkAlwaysRefreshMoviestripThumbs = New System.Windows.Forms.CheckBox()
        Me.GroupBoxDialogs = New System.Windows.Forms.GroupBox()
        Me.chkAlwaysKeepOriginalFile = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.chkAlwaysKeepCuts = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.chkDisableProfileDetails = New System.Windows.Forms.CheckBox()
        Me.imgDisableProfileDetails = New System.Windows.Forms.PictureBox()
        Me.GroupBoxCutSettings = New System.Windows.Forms.GroupBox()
        Me.imgAutoEndMarker = New System.Windows.Forms.PictureBox()
        Me.chkAutoEndmarker = New System.Windows.Forms.CheckBox()
        Me.imgAutoStartmarker = New System.Windows.Forms.PictureBox()
        Me.chkAutoStartmarker = New System.Windows.Forms.CheckBox()
        Me.tabSeekSteps = New System.Windows.Forms.TabPage()
        Me.GroupBoxOnPause = New System.Windows.Forms.GroupBox()
        Me.lblFrames6 = New System.Windows.Forms.Label()
        Me.numBackPause3 = New System.Windows.Forms.NumericUpDown()
        Me.numFFWPause3 = New System.Windows.Forms.NumericUpDown()
        Me.lblSkipPart1Pause = New System.Windows.Forms.Label()
        Me.lblFrames3 = New System.Windows.Forms.Label()
        Me.lblSkipPart2Pause = New System.Windows.Forms.Label()
        Me.lblSkipPart3Pause = New System.Windows.Forms.Label()
        Me.lblFrames5 = New System.Windows.Forms.Label()
        Me.lblBackPause = New System.Windows.Forms.Label()
        Me.numFFWPause2 = New System.Windows.Forms.NumericUpDown()
        Me.lblFFWPause = New System.Windows.Forms.Label()
        Me.lblFrames2 = New System.Windows.Forms.Label()
        Me.numBackPause1 = New System.Windows.Forms.NumericUpDown()
        Me.numBackPause2 = New System.Windows.Forms.NumericUpDown()
        Me.lblFrames1 = New System.Windows.Forms.Label()
        Me.lblFrames4 = New System.Windows.Forms.Label()
        Me.numFFWPause1 = New System.Windows.Forms.NumericUpDown()
        Me.GroupBoxOnPlay = New System.Windows.Forms.GroupBox()
        Me.lblSeconds6 = New System.Windows.Forms.Label()
        Me.numFFWPlay3 = New System.Windows.Forms.NumericUpDown()
        Me.lblSeconds3 = New System.Windows.Forms.Label()
        Me.numBackPlay3 = New System.Windows.Forms.NumericUpDown()
        Me.lblSeconds5 = New System.Windows.Forms.Label()
        Me.numFFWPlay2 = New System.Windows.Forms.NumericUpDown()
        Me.lblSeconds2 = New System.Windows.Forms.Label()
        Me.numBackPlay2 = New System.Windows.Forms.NumericUpDown()
        Me.lblSeconds4 = New System.Windows.Forms.Label()
        Me.numFFWPlay1 = New System.Windows.Forms.NumericUpDown()
        Me.lblSeconds1 = New System.Windows.Forms.Label()
        Me.numBackPlay1 = New System.Windows.Forms.NumericUpDown()
        Me.lblSkipFFWPlay = New System.Windows.Forms.Label()
        Me.lblSkipBackPlay = New System.Windows.Forms.Label()
        Me.lblSkipPart3Play = New System.Windows.Forms.Label()
        Me.lblSkipPart2Play = New System.Windows.Forms.Label()
        Me.lblSkipPart1Play = New System.Windows.Forms.Label()
        Me.lblconfigureSeekSteps = New System.Windows.Forms.Label()
        Me.tabReplacementStrings = New System.Windows.Forms.TabPage()
        Me.GroupBoxEditReplacementString = New System.Windows.Forms.GroupBox()
        Me.btnDelReplaceString = New System.Windows.Forms.Button()
        Me.lblReplacementString = New System.Windows.Forms.Label()
        Me.btnAddReplaceString = New System.Windows.Forms.Button()
        Me.lblOriginalString = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.tabTVSuite = New System.Windows.Forms.TabPage()
        Me.GroupBoxTVsuiteProfileH264 = New System.Windows.Forms.GroupBox()
        Me.lblFramerateH264 = New System.Windows.Forms.Label()
        Me.lblDeinterlacemodeH264 = New System.Windows.Forms.Label()
        Me.lblRatioH264 = New System.Windows.Forms.Label()
        Me.lblResolutionH264 = New System.Windows.Forms.Label()
        Me.lblFileTypeH264 = New System.Windows.Forms.Label()
        Me.lblEncodingtypeH264 = New System.Windows.Forms.Label()
        Me.txtFramerateH264 = New System.Windows.Forms.Label()
        Me.txtDeinterlacemodeH264 = New System.Windows.Forms.Label()
        Me.txtRatioH264 = New System.Windows.Forms.Label()
        Me.txtResolutionH264 = New System.Windows.Forms.Label()
        Me.txtFiletypeH264 = New System.Windows.Forms.Label()
        Me.txtEncodingtypeH264 = New System.Windows.Forms.Label()
        Me.cbxSavingProfileH264 = New System.Windows.Forms.ComboBox()
        Me.chkDebugMode = New System.Windows.Forms.CheckBox()
        Me.GroupBoxTVsuiteProfile = New System.Windows.Forms.GroupBox()
        Me.lblFramerate = New System.Windows.Forms.Label()
        Me.lblDeinterlacemode = New System.Windows.Forms.Label()
        Me.lblRatio = New System.Windows.Forms.Label()
        Me.lblResolution = New System.Windows.Forms.Label()
        Me.lblFileType = New System.Windows.Forms.Label()
        Me.lblEncodingtype = New System.Windows.Forms.Label()
        Me.txtFramerate = New System.Windows.Forms.Label()
        Me.txtDeinterlacemode = New System.Windows.Forms.Label()
        Me.txtRatio = New System.Windows.Forms.Label()
        Me.txtResolution = New System.Windows.Forms.Label()
        Me.txtFiletype = New System.Windows.Forms.Label()
        Me.txtEncodingtype = New System.Windows.Forms.Label()
        Me.cbxSavingProfile = New System.Windows.Forms.ComboBox()
        Me.btnCheckTVsuite = New System.Windows.Forms.Button()
        Me.lblDescriptionTVsuite = New System.Windows.Forms.Label()
        Me.lblDonate = New System.Windows.Forms.LinkLabel()
        Me.SaveDialog = New System.Windows.Forms.FolderBrowserDialog()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tabCommon1.SuspendLayout()
        Me.GroupBoxSaveSettings.SuspendLayout()
        CType(Me.imgParseSeries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgParseMovieFile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxRecordings.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.SplitContainer7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer7.Panel1.SuspendLayout()
        Me.SplitContainer7.Panel2.SuspendLayout()
        Me.SplitContainer7.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel1.SuspendLayout()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer6.Panel1.SuspendLayout()
        Me.SplitContainer6.Panel2.SuspendLayout()
        Me.SplitContainer6.SuspendLayout()
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer5.Panel1.SuspendLayout()
        Me.SplitContainer5.Panel2.SuspendLayout()
        Me.SplitContainer5.SuspendLayout()
        Me.GroupBoxModuleName.SuspendLayout()
        Me.tabCommon2.SuspendLayout()
        Me.GroupAlwaysRefreshMoviestripThumbs.SuspendLayout()
        CType(Me.numAlwaysRefreshMoviestripThumbsDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxDialogs.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgDisableProfileDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxCutSettings.SuspendLayout()
        CType(Me.imgAutoEndMarker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgAutoStartmarker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabSeekSteps.SuspendLayout()
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
        Me.tabReplacementStrings.SuspendLayout()
        Me.GroupBoxEditReplacementString.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabTVSuite.SuspendLayout()
        Me.GroupBoxTVsuiteProfileH264.SuspendLayout()
        Me.GroupBoxTVsuiteProfile.SuspendLayout()
        Me.SuspendLayout()
        '
        'RecDialog
        '
        Me.RecDialog.Description = "Ordner der gespeicherten Aufnahmen"
        Me.RecDialog.ShowNewFolderButton = False
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
        Me.Label1.Size = New System.Drawing.Size(610, 38)
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
        Me.TabControl1.Controls.Add(Me.tabCommon1)
        Me.TabControl1.Controls.Add(Me.tabCommon2)
        Me.TabControl1.Controls.Add(Me.tabSeekSteps)
        Me.TabControl1.Controls.Add(Me.tabReplacementStrings)
        Me.TabControl1.Controls.Add(Me.tabTVSuite)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(610, 333)
        Me.TabControl1.TabIndex = 3
        '
        'tabCommon1
        '
        Me.tabCommon1.Controls.Add(Me.GroupBoxSaveSettings)
        Me.tabCommon1.Controls.Add(Me.GroupBoxRecordings)
        Me.tabCommon1.Controls.Add(Me.GroupBoxModuleName)
        Me.tabCommon1.Location = New System.Drawing.Point(4, 22)
        Me.tabCommon1.Name = "tabCommon1"
        Me.tabCommon1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabCommon1.Size = New System.Drawing.Size(602, 307)
        Me.tabCommon1.TabIndex = 0
        Me.tabCommon1.Text = "tabCommon1"
        Me.tabCommon1.UseVisualStyleBackColor = True
        '
        'GroupBoxSaveSettings
        '
        Me.GroupBoxSaveSettings.Controls.Add(Me.lblTestSeriesFolderParsing)
        Me.GroupBoxSaveSettings.Controls.Add(Me.Label7)
        Me.GroupBoxSaveSettings.Controls.Add(Me.lblTestMovieFolderParsing)
        Me.GroupBoxSaveSettings.Controls.Add(Me.Label5)
        Me.GroupBoxSaveSettings.Controls.Add(Me.txtParseSeriesFolder)
        Me.GroupBoxSaveSettings.Controls.Add(Me.chkCreateSeriesFolder)
        Me.GroupBoxSaveSettings.Controls.Add(Me.txtParseMovieFolder)
        Me.GroupBoxSaveSettings.Controls.Add(Me.chkCreateMovieFolder)
        Me.GroupBoxSaveSettings.Controls.Add(Me.lblTestMovieParsing)
        Me.GroupBoxSaveSettings.Controls.Add(Me.lblTestSeriesParsing)
        Me.GroupBoxSaveSettings.Controls.Add(Me.Label3)
        Me.GroupBoxSaveSettings.Controls.Add(Me.Label2)
        Me.GroupBoxSaveSettings.Controls.Add(Me.lblParseSeriesFile)
        Me.GroupBoxSaveSettings.Controls.Add(Me.txtParseSeriesFile)
        Me.GroupBoxSaveSettings.Controls.Add(Me.imgParseSeries)
        Me.GroupBoxSaveSettings.Controls.Add(Me.btnShowParseStrings)
        Me.GroupBoxSaveSettings.Controls.Add(Me.lblParseMoviefile)
        Me.GroupBoxSaveSettings.Controls.Add(Me.txtParseMovieFile)
        Me.GroupBoxSaveSettings.Controls.Add(Me.imgParseMovieFile)
        Me.GroupBoxSaveSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxSaveSettings.Location = New System.Drawing.Point(3, 111)
        Me.GroupBoxSaveSettings.Name = "GroupBoxSaveSettings"
        Me.GroupBoxSaveSettings.Size = New System.Drawing.Size(596, 203)
        Me.GroupBoxSaveSettings.TabIndex = 26
        Me.GroupBoxSaveSettings.TabStop = False
        Me.GroupBoxSaveSettings.Text = "GroupBoxSaveSettings"
        '
        'lblTestSeriesFolderParsing
        '
        Me.lblTestSeriesFolderParsing.AutoSize = True
        Me.lblTestSeriesFolderParsing.Location = New System.Drawing.Point(45, 180)
        Me.lblTestSeriesFolderParsing.Name = "lblTestSeriesFolderParsing"
        Me.lblTestSeriesFolderParsing.Size = New System.Drawing.Size(16, 13)
        Me.lblTestSeriesFolderParsing.TabIndex = 23
        Me.lblTestSeriesFolderParsing.Text = "..."
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Test:"
        '
        'lblTestMovieFolderParsing
        '
        Me.lblTestMovieFolderParsing.AutoSize = True
        Me.lblTestMovieFolderParsing.Location = New System.Drawing.Point(45, 138)
        Me.lblTestMovieFolderParsing.Name = "lblTestMovieFolderParsing"
        Me.lblTestMovieFolderParsing.Size = New System.Drawing.Size(16, 13)
        Me.lblTestMovieFolderParsing.TabIndex = 21
        Me.lblTestMovieFolderParsing.Text = "..."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 138)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "Test:"
        '
        'txtParseSeriesFolder
        '
        Me.txtParseSeriesFolder.Location = New System.Drawing.Point(202, 158)
        Me.txtParseSeriesFolder.Name = "txtParseSeriesFolder"
        Me.txtParseSeriesFolder.Size = New System.Drawing.Size(284, 20)
        Me.txtParseSeriesFolder.TabIndex = 19
        '
        'chkCreateSeriesFolder
        '
        Me.chkCreateSeriesFolder.AutoSize = True
        Me.chkCreateSeriesFolder.Location = New System.Drawing.Point(11, 160)
        Me.chkCreateSeriesFolder.Name = "chkCreateSeriesFolder"
        Me.chkCreateSeriesFolder.Size = New System.Drawing.Size(133, 17)
        Me.chkCreateSeriesFolder.TabIndex = 18
        Me.chkCreateSeriesFolder.Text = "chkCreateSeriesFolder"
        Me.chkCreateSeriesFolder.UseVisualStyleBackColor = True
        '
        'txtParseMovieFolder
        '
        Me.txtParseMovieFolder.Location = New System.Drawing.Point(201, 116)
        Me.txtParseMovieFolder.Name = "txtParseMovieFolder"
        Me.txtParseMovieFolder.Size = New System.Drawing.Size(284, 20)
        Me.txtParseMovieFolder.TabIndex = 16
        '
        'chkCreateMovieFolder
        '
        Me.chkCreateMovieFolder.AutoSize = True
        Me.chkCreateMovieFolder.Location = New System.Drawing.Point(10, 118)
        Me.chkCreateMovieFolder.Name = "chkCreateMovieFolder"
        Me.chkCreateMovieFolder.Size = New System.Drawing.Size(133, 17)
        Me.chkCreateMovieFolder.TabIndex = 15
        Me.chkCreateMovieFolder.Text = "chkCreateMovieFolder"
        Me.chkCreateMovieFolder.UseVisualStyleBackColor = True
        '
        'lblTestMovieParsing
        '
        Me.lblTestMovieParsing.AutoSize = True
        Me.lblTestMovieParsing.Location = New System.Drawing.Point(43, 51)
        Me.lblTestMovieParsing.Name = "lblTestMovieParsing"
        Me.lblTestMovieParsing.Size = New System.Drawing.Size(16, 13)
        Me.lblTestMovieParsing.TabIndex = 14
        Me.lblTestMovieParsing.Text = "..."
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
        Me.txtParseSeriesFile.Location = New System.Drawing.Point(201, 68)
        Me.txtParseSeriesFile.Name = "txtParseSeriesFile"
        Me.txtParseSeriesFile.Size = New System.Drawing.Size(284, 20)
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
        Me.btnShowParseStrings.Location = New System.Drawing.Point(494, 24)
        Me.btnShowParseStrings.Name = "btnShowParseStrings"
        Me.btnShowParseStrings.Size = New System.Drawing.Size(99, 154)
        Me.btnShowParseStrings.TabIndex = 8
        Me.btnShowParseStrings.Text = "btnShowParseStrings"
        Me.btnShowParseStrings.UseVisualStyleBackColor = True
        '
        'lblParseMoviefile
        '
        Me.lblParseMoviefile.AutoSize = True
        Me.lblParseMoviefile.Location = New System.Drawing.Point(31, 27)
        Me.lblParseMoviefile.Name = "lblParseMoviefile"
        Me.lblParseMoviefile.Size = New System.Drawing.Size(86, 13)
        Me.lblParseMoviefile.TabIndex = 7
        Me.lblParseMoviefile.Text = "lblParseMoviefile"
        '
        'txtParseMovieFile
        '
        Me.txtParseMovieFile.Location = New System.Drawing.Point(202, 24)
        Me.txtParseMovieFile.Name = "txtParseMovieFile"
        Me.txtParseMovieFile.Size = New System.Drawing.Size(283, 20)
        Me.txtParseMovieFile.TabIndex = 7
        '
        'imgParseMovieFile
        '
        Me.imgParseMovieFile.Image = Global.MyVideoRedo.My.Resources.Resources.help
        Me.imgParseMovieFile.Location = New System.Drawing.Point(6, 24)
        Me.imgParseMovieFile.Name = "imgParseMovieFile"
        Me.imgParseMovieFile.Size = New System.Drawing.Size(19, 17)
        Me.imgParseMovieFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgParseMovieFile.TabIndex = 6
        Me.imgParseMovieFile.TabStop = False
        '
        'GroupBoxRecordings
        '
        Me.GroupBoxRecordings.Controls.Add(Me.SplitContainer3)
        Me.GroupBoxRecordings.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxRecordings.Location = New System.Drawing.Point(3, 41)
        Me.GroupBoxRecordings.Name = "GroupBoxRecordings"
        Me.GroupBoxRecordings.Size = New System.Drawing.Size(596, 70)
        Me.GroupBoxRecordings.TabIndex = 25
        Me.GroupBoxRecordings.TabStop = False
        Me.GroupBoxRecordings.Text = "GroupBoxRecordings"
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
        Me.lblRecPath.Size = New System.Drawing.Size(59, 13)
        Me.lblRecPath.TabIndex = 0
        Me.lblRecPath.Text = "lblRecPath"
        '
        'lblSavePath
        '
        Me.lblSavePath.AutoSize = True
        Me.lblSavePath.Location = New System.Drawing.Point(3, 5)
        Me.lblSavePath.Name = "lblSavePath"
        Me.lblSavePath.Size = New System.Drawing.Size(64, 13)
        Me.lblSavePath.TabIndex = 3
        Me.lblSavePath.Text = "lblSavePath"
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
        'txtRecPath
        '
        Me.txtRecPath.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtRecPath.Location = New System.Drawing.Point(0, 0)
        Me.txtRecPath.Name = "txtRecPath"
        Me.txtRecPath.Size = New System.Drawing.Size(340, 20)
        Me.txtRecPath.TabIndex = 0
        '
        'txtSavePath
        '
        Me.txtSavePath.Dock = System.Windows.Forms.DockStyle.Top
        Me.txtSavePath.Location = New System.Drawing.Point(0, 0)
        Me.txtSavePath.Name = "txtSavePath"
        Me.txtSavePath.Size = New System.Drawing.Size(340, 20)
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
        'btnRecDialog
        '
        Me.btnRecDialog.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnRecDialog.Location = New System.Drawing.Point(0, 0)
        Me.btnRecDialog.Name = "btnRecDialog"
        Me.btnRecDialog.Size = New System.Drawing.Size(99, 23)
        Me.btnRecDialog.TabIndex = 1
        Me.btnRecDialog.Text = "btnRecDialog"
        Me.btnRecDialog.UseVisualStyleBackColor = True
        '
        'bntSaveDialog
        '
        Me.bntSaveDialog.Dock = System.Windows.Forms.DockStyle.Top
        Me.bntSaveDialog.Location = New System.Drawing.Point(0, 0)
        Me.bntSaveDialog.Name = "bntSaveDialog"
        Me.bntSaveDialog.Size = New System.Drawing.Size(99, 23)
        Me.bntSaveDialog.TabIndex = 4
        Me.bntSaveDialog.Text = "bntSaveDialog"
        Me.bntSaveDialog.UseVisualStyleBackColor = True
        '
        'GroupBoxModuleName
        '
        Me.GroupBoxModuleName.Controls.Add(Me.lblModulName)
        Me.GroupBoxModuleName.Controls.Add(Me.txtModulName)
        Me.GroupBoxModuleName.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxModuleName.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxModuleName.Name = "GroupBoxModuleName"
        Me.GroupBoxModuleName.Size = New System.Drawing.Size(596, 38)
        Me.GroupBoxModuleName.TabIndex = 23
        Me.GroupBoxModuleName.TabStop = False
        Me.GroupBoxModuleName.Text = "GroupBoxModuleName"
        '
        'lblModulName
        '
        Me.lblModulName.AutoSize = True
        Me.lblModulName.Location = New System.Drawing.Point(8, 16)
        Me.lblModulName.Name = "lblModulName"
        Me.lblModulName.Size = New System.Drawing.Size(74, 13)
        Me.lblModulName.TabIndex = 11
        Me.lblModulName.Text = "lblModulName"
        '
        'txtModulName
        '
        Me.txtModulName.Location = New System.Drawing.Point(150, 12)
        Me.txtModulName.Name = "txtModulName"
        Me.txtModulName.Size = New System.Drawing.Size(335, 20)
        Me.txtModulName.TabIndex = 8
        '
        'tabCommon2
        '
        Me.tabCommon2.Controls.Add(Me.GroupAlwaysRefreshMoviestripThumbs)
        Me.tabCommon2.Controls.Add(Me.GroupBoxDialogs)
        Me.tabCommon2.Controls.Add(Me.GroupBoxCutSettings)
        Me.tabCommon2.Location = New System.Drawing.Point(4, 22)
        Me.tabCommon2.Name = "tabCommon2"
        Me.tabCommon2.Size = New System.Drawing.Size(602, 307)
        Me.tabCommon2.TabIndex = 5
        Me.tabCommon2.Text = "tabCommon2"
        Me.tabCommon2.UseVisualStyleBackColor = True
        '
        'GroupAlwaysRefreshMoviestripThumbs
        '
        Me.GroupAlwaysRefreshMoviestripThumbs.Controls.Add(Me.lblSeconds)
        Me.GroupAlwaysRefreshMoviestripThumbs.Controls.Add(Me.numAlwaysRefreshMoviestripThumbsDelay)
        Me.GroupAlwaysRefreshMoviestripThumbs.Controls.Add(Me.lblAlwaysRefreshMoviestripThumbsDelay)
        Me.GroupAlwaysRefreshMoviestripThumbs.Controls.Add(Me.PictureBox4)
        Me.GroupAlwaysRefreshMoviestripThumbs.Controls.Add(Me.chkAlwaysRefreshMoviestripThumbs)
        Me.GroupAlwaysRefreshMoviestripThumbs.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupAlwaysRefreshMoviestripThumbs.Location = New System.Drawing.Point(0, 156)
        Me.GroupAlwaysRefreshMoviestripThumbs.Name = "GroupAlwaysRefreshMoviestripThumbs"
        Me.GroupAlwaysRefreshMoviestripThumbs.Size = New System.Drawing.Size(602, 52)
        Me.GroupAlwaysRefreshMoviestripThumbs.TabIndex = 23
        Me.GroupAlwaysRefreshMoviestripThumbs.TabStop = False
        Me.GroupAlwaysRefreshMoviestripThumbs.Text = "GroupAlwaysRefreshMoviestripThumbs"
        '
        'lblSeconds
        '
        Me.lblSeconds.AutoSize = True
        Me.lblSeconds.Location = New System.Drawing.Point(530, 28)
        Me.lblSeconds.Name = "lblSeconds"
        Me.lblSeconds.Size = New System.Drawing.Size(59, 13)
        Me.lblSeconds.TabIndex = 10
        Me.lblSeconds.Text = "lblSeconds"
        '
        'numAlwaysRefreshMoviestripThumbsDelay
        '
        Me.numAlwaysRefreshMoviestripThumbsDelay.Location = New System.Drawing.Point(482, 24)
        Me.numAlwaysRefreshMoviestripThumbsDelay.Maximum = New Decimal(New Integer() {60, 0, 0, 0})
        Me.numAlwaysRefreshMoviestripThumbsDelay.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numAlwaysRefreshMoviestripThumbsDelay.Name = "numAlwaysRefreshMoviestripThumbsDelay"
        Me.numAlwaysRefreshMoviestripThumbsDelay.Size = New System.Drawing.Size(42, 20)
        Me.numAlwaysRefreshMoviestripThumbsDelay.TabIndex = 9
        Me.numAlwaysRefreshMoviestripThumbsDelay.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'lblAlwaysRefreshMoviestripThumbsDelay
        '
        Me.lblAlwaysRefreshMoviestripThumbsDelay.AutoSize = True
        Me.lblAlwaysRefreshMoviestripThumbsDelay.Location = New System.Drawing.Point(316, 27)
        Me.lblAlwaysRefreshMoviestripThumbsDelay.Name = "lblAlwaysRefreshMoviestripThumbsDelay"
        Me.lblAlwaysRefreshMoviestripThumbsDelay.Size = New System.Drawing.Size(200, 13)
        Me.lblAlwaysRefreshMoviestripThumbsDelay.TabIndex = 8
        Me.lblAlwaysRefreshMoviestripThumbsDelay.Text = "lblAlwaysRefreshMoviestripThumbsDelay"
        '
        'PictureBox4
        '
        Me.PictureBox4.Image = Global.MyVideoRedo.My.Resources.Resources.help
        Me.PictureBox4.Location = New System.Drawing.Point(6, 24)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 6
        Me.PictureBox4.TabStop = False
        '
        'chkAlwaysRefreshMoviestripThumbs
        '
        Me.chkAlwaysRefreshMoviestripThumbs.AutoSize = True
        Me.chkAlwaysRefreshMoviestripThumbs.Location = New System.Drawing.Point(31, 26)
        Me.chkAlwaysRefreshMoviestripThumbs.Name = "chkAlwaysRefreshMoviestripThumbs"
        Me.chkAlwaysRefreshMoviestripThumbs.Size = New System.Drawing.Size(200, 17)
        Me.chkAlwaysRefreshMoviestripThumbs.TabIndex = 2
        Me.chkAlwaysRefreshMoviestripThumbs.Text = "chkAlwaysRefreshMoviestripThumbs"
        Me.chkAlwaysRefreshMoviestripThumbs.UseVisualStyleBackColor = True
        '
        'GroupBoxDialogs
        '
        Me.GroupBoxDialogs.Controls.Add(Me.chkAlwaysKeepOriginalFile)
        Me.GroupBoxDialogs.Controls.Add(Me.PictureBox2)
        Me.GroupBoxDialogs.Controls.Add(Me.chkAlwaysKeepCuts)
        Me.GroupBoxDialogs.Controls.Add(Me.PictureBox1)
        Me.GroupBoxDialogs.Controls.Add(Me.chkDisableProfileDetails)
        Me.GroupBoxDialogs.Controls.Add(Me.imgDisableProfileDetails)
        Me.GroupBoxDialogs.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxDialogs.Location = New System.Drawing.Point(0, 52)
        Me.GroupBoxDialogs.Name = "GroupBoxDialogs"
        Me.GroupBoxDialogs.Size = New System.Drawing.Size(602, 104)
        Me.GroupBoxDialogs.TabIndex = 22
        Me.GroupBoxDialogs.TabStop = False
        Me.GroupBoxDialogs.Text = "GroupBoxDialogs"
        '
        'chkAlwaysKeepOriginalFile
        '
        Me.chkAlwaysKeepOriginalFile.AutoSize = True
        Me.chkAlwaysKeepOriginalFile.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.chkAlwaysKeepOriginalFile.Location = New System.Drawing.Point(32, 78)
        Me.chkAlwaysKeepOriginalFile.Name = "chkAlwaysKeepOriginalFile"
        Me.chkAlwaysKeepOriginalFile.Size = New System.Drawing.Size(153, 17)
        Me.chkAlwaysKeepOriginalFile.TabIndex = 22
        Me.chkAlwaysKeepOriginalFile.Text = "chkAlwaysKeepOriginalFile"
        Me.chkAlwaysKeepOriginalFile.UseMnemonic = False
        Me.chkAlwaysKeepOriginalFile.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.MyVideoRedo.My.Resources.Resources.help
        Me.PictureBox2.Location = New System.Drawing.Point(7, 77)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 23
        Me.PictureBox2.TabStop = False
        '
        'chkAlwaysKeepCuts
        '
        Me.chkAlwaysKeepCuts.AutoSize = True
        Me.chkAlwaysKeepCuts.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.chkAlwaysKeepCuts.Location = New System.Drawing.Point(32, 50)
        Me.chkAlwaysKeepCuts.Name = "chkAlwaysKeepCuts"
        Me.chkAlwaysKeepCuts.Size = New System.Drawing.Size(123, 17)
        Me.chkAlwaysKeepCuts.TabIndex = 20
        Me.chkAlwaysKeepCuts.Text = "chkAlwaysKeepCuts"
        Me.chkAlwaysKeepCuts.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.MyVideoRedo.My.Resources.Resources.help
        Me.PictureBox1.Location = New System.Drawing.Point(7, 49)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(19, 17)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 21
        Me.PictureBox1.TabStop = False
        '
        'chkDisableProfileDetails
        '
        Me.chkDisableProfileDetails.AutoSize = True
        Me.chkDisableProfileDetails.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.chkDisableProfileDetails.Location = New System.Drawing.Point(32, 22)
        Me.chkDisableProfileDetails.Name = "chkDisableProfileDetails"
        Me.chkDisableProfileDetails.Size = New System.Drawing.Size(140, 17)
        Me.chkDisableProfileDetails.TabIndex = 18
        Me.chkDisableProfileDetails.Text = "chkDisableProfileDetails"
        Me.chkDisableProfileDetails.UseVisualStyleBackColor = True
        '
        'imgDisableProfileDetails
        '
        Me.imgDisableProfileDetails.Image = Global.MyVideoRedo.My.Resources.Resources.help
        Me.imgDisableProfileDetails.Location = New System.Drawing.Point(7, 21)
        Me.imgDisableProfileDetails.Name = "imgDisableProfileDetails"
        Me.imgDisableProfileDetails.Size = New System.Drawing.Size(19, 17)
        Me.imgDisableProfileDetails.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgDisableProfileDetails.TabIndex = 19
        Me.imgDisableProfileDetails.TabStop = False
        '
        'GroupBoxCutSettings
        '
        Me.GroupBoxCutSettings.Controls.Add(Me.imgAutoEndMarker)
        Me.GroupBoxCutSettings.Controls.Add(Me.chkAutoEndmarker)
        Me.GroupBoxCutSettings.Controls.Add(Me.imgAutoStartmarker)
        Me.GroupBoxCutSettings.Controls.Add(Me.chkAutoStartmarker)
        Me.GroupBoxCutSettings.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBoxCutSettings.Location = New System.Drawing.Point(0, 0)
        Me.GroupBoxCutSettings.Name = "GroupBoxCutSettings"
        Me.GroupBoxCutSettings.Size = New System.Drawing.Size(602, 52)
        Me.GroupBoxCutSettings.TabIndex = 21
        Me.GroupBoxCutSettings.TabStop = False
        Me.GroupBoxCutSettings.Text = "GroupBoxCutSettings"
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
        Me.chkAutoEndmarker.Location = New System.Drawing.Point(319, 25)
        Me.chkAutoEndmarker.Name = "chkAutoEndmarker"
        Me.chkAutoEndmarker.Size = New System.Drawing.Size(117, 17)
        Me.chkAutoEndmarker.TabIndex = 7
        Me.chkAutoEndmarker.Text = "chkAutoEndmarker"
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
        'chkAutoStartmarker
        '
        Me.chkAutoStartmarker.AutoSize = True
        Me.chkAutoStartmarker.Location = New System.Drawing.Point(31, 25)
        Me.chkAutoStartmarker.Name = "chkAutoStartmarker"
        Me.chkAutoStartmarker.Size = New System.Drawing.Size(120, 17)
        Me.chkAutoStartmarker.TabIndex = 2
        Me.chkAutoStartmarker.Text = "chkAutoStartmarker"
        Me.chkAutoStartmarker.UseVisualStyleBackColor = True
        '
        'tabSeekSteps
        '
        Me.tabSeekSteps.Controls.Add(Me.GroupBoxOnPause)
        Me.tabSeekSteps.Controls.Add(Me.GroupBoxOnPlay)
        Me.tabSeekSteps.Controls.Add(Me.lblconfigureSeekSteps)
        Me.tabSeekSteps.Location = New System.Drawing.Point(4, 22)
        Me.tabSeekSteps.Name = "tabSeekSteps"
        Me.tabSeekSteps.Padding = New System.Windows.Forms.Padding(3)
        Me.tabSeekSteps.Size = New System.Drawing.Size(602, 307)
        Me.tabSeekSteps.TabIndex = 3
        Me.tabSeekSteps.Text = "tabSeekSteps"
        Me.tabSeekSteps.UseVisualStyleBackColor = True
        '
        'GroupBoxOnPause
        '
        Me.GroupBoxOnPause.Controls.Add(Me.lblFrames6)
        Me.GroupBoxOnPause.Controls.Add(Me.numBackPause3)
        Me.GroupBoxOnPause.Controls.Add(Me.numFFWPause3)
        Me.GroupBoxOnPause.Controls.Add(Me.lblSkipPart1Pause)
        Me.GroupBoxOnPause.Controls.Add(Me.lblFrames3)
        Me.GroupBoxOnPause.Controls.Add(Me.lblSkipPart2Pause)
        Me.GroupBoxOnPause.Controls.Add(Me.lblSkipPart3Pause)
        Me.GroupBoxOnPause.Controls.Add(Me.lblFrames5)
        Me.GroupBoxOnPause.Controls.Add(Me.lblBackPause)
        Me.GroupBoxOnPause.Controls.Add(Me.numFFWPause2)
        Me.GroupBoxOnPause.Controls.Add(Me.lblFFWPause)
        Me.GroupBoxOnPause.Controls.Add(Me.lblFrames2)
        Me.GroupBoxOnPause.Controls.Add(Me.numBackPause1)
        Me.GroupBoxOnPause.Controls.Add(Me.numBackPause2)
        Me.GroupBoxOnPause.Controls.Add(Me.lblFrames1)
        Me.GroupBoxOnPause.Controls.Add(Me.lblFrames4)
        Me.GroupBoxOnPause.Controls.Add(Me.numFFWPause1)
        Me.GroupBoxOnPause.Location = New System.Drawing.Point(310, 40)
        Me.GroupBoxOnPause.Name = "GroupBoxOnPause"
        Me.GroupBoxOnPause.Size = New System.Drawing.Size(279, 210)
        Me.GroupBoxOnPause.TabIndex = 2
        Me.GroupBoxOnPause.TabStop = False
        Me.GroupBoxOnPause.Text = "GroupBoxOnPause"
        '
        'lblFrames6
        '
        Me.lblFrames6.AutoSize = True
        Me.lblFrames6.Location = New System.Drawing.Point(234, 148)
        Me.lblFrames6.Name = "lblFrames6"
        Me.lblFrames6.Size = New System.Drawing.Size(57, 13)
        Me.lblFrames6.TabIndex = 33
        Me.lblFrames6.Text = "lblFrames6"
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
        Me.lblSkipPart1Pause.Size = New System.Drawing.Size(93, 13)
        Me.lblSkipPart1Pause.TabIndex = 17
        Me.lblSkipPart1Pause.Text = "lblSkipPart1Pause"
        '
        'lblFrames3
        '
        Me.lblFrames3.AutoSize = True
        Me.lblFrames3.Location = New System.Drawing.Point(132, 148)
        Me.lblFrames3.Name = "lblFrames3"
        Me.lblFrames3.Size = New System.Drawing.Size(57, 13)
        Me.lblFrames3.TabIndex = 31
        Me.lblFrames3.Text = "lblFrames3"
        '
        'lblSkipPart2Pause
        '
        Me.lblSkipPart2Pause.AutoSize = True
        Me.lblSkipPart2Pause.Location = New System.Drawing.Point(9, 108)
        Me.lblSkipPart2Pause.Name = "lblSkipPart2Pause"
        Me.lblSkipPart2Pause.Size = New System.Drawing.Size(93, 13)
        Me.lblSkipPart2Pause.TabIndex = 18
        Me.lblSkipPart2Pause.Text = "lblSkipPart2Pause"
        '
        'lblSkipPart3Pause
        '
        Me.lblSkipPart3Pause.AutoSize = True
        Me.lblSkipPart3Pause.Location = New System.Drawing.Point(9, 147)
        Me.lblSkipPart3Pause.Name = "lblSkipPart3Pause"
        Me.lblSkipPart3Pause.Size = New System.Drawing.Size(93, 13)
        Me.lblSkipPart3Pause.TabIndex = 19
        Me.lblSkipPart3Pause.Text = "lblSkipPart3Pause"
        '
        'lblFrames5
        '
        Me.lblFrames5.AutoSize = True
        Me.lblFrames5.Location = New System.Drawing.Point(234, 109)
        Me.lblFrames5.Name = "lblFrames5"
        Me.lblFrames5.Size = New System.Drawing.Size(57, 13)
        Me.lblFrames5.TabIndex = 29
        Me.lblFrames5.Text = "lblFrames5"
        '
        'lblBackPause
        '
        Me.lblBackPause.Location = New System.Drawing.Point(60, 27)
        Me.lblBackPause.Name = "lblBackPause"
        Me.lblBackPause.Size = New System.Drawing.Size(101, 13)
        Me.lblBackPause.TabIndex = 20
        Me.lblBackPause.Text = "lblBackPause"
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
        Me.lblFFWPause.Text = "lblFFWPause"
        Me.lblFFWPause.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblFrames2
        '
        Me.lblFrames2.AutoSize = True
        Me.lblFrames2.Location = New System.Drawing.Point(132, 109)
        Me.lblFrames2.Name = "lblFrames2"
        Me.lblFrames2.Size = New System.Drawing.Size(57, 13)
        Me.lblFrames2.TabIndex = 27
        Me.lblFrames2.Text = "lblFrames2"
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
        'lblFrames1
        '
        Me.lblFrames1.AutoSize = True
        Me.lblFrames1.Location = New System.Drawing.Point(132, 68)
        Me.lblFrames1.Name = "lblFrames1"
        Me.lblFrames1.Size = New System.Drawing.Size(57, 13)
        Me.lblFrames1.TabIndex = 23
        Me.lblFrames1.Text = "lblFrames1"
        '
        'lblFrames4
        '
        Me.lblFrames4.AutoSize = True
        Me.lblFrames4.Location = New System.Drawing.Point(234, 68)
        Me.lblFrames4.Name = "lblFrames4"
        Me.lblFrames4.Size = New System.Drawing.Size(57, 13)
        Me.lblFrames4.TabIndex = 25
        Me.lblFrames4.Text = "lblFrames4"
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
        Me.GroupBoxOnPlay.Controls.Add(Me.lblSeconds6)
        Me.GroupBoxOnPlay.Controls.Add(Me.numFFWPlay3)
        Me.GroupBoxOnPlay.Controls.Add(Me.lblSeconds3)
        Me.GroupBoxOnPlay.Controls.Add(Me.numBackPlay3)
        Me.GroupBoxOnPlay.Controls.Add(Me.lblSeconds5)
        Me.GroupBoxOnPlay.Controls.Add(Me.numFFWPlay2)
        Me.GroupBoxOnPlay.Controls.Add(Me.lblSeconds2)
        Me.GroupBoxOnPlay.Controls.Add(Me.numBackPlay2)
        Me.GroupBoxOnPlay.Controls.Add(Me.lblSeconds4)
        Me.GroupBoxOnPlay.Controls.Add(Me.numFFWPlay1)
        Me.GroupBoxOnPlay.Controls.Add(Me.lblSeconds1)
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
        Me.GroupBoxOnPlay.Text = "GroupBoxOnPlay"
        '
        'lblSeconds6
        '
        Me.lblSeconds6.AutoSize = True
        Me.lblSeconds6.Location = New System.Drawing.Point(231, 153)
        Me.lblSeconds6.Name = "lblSeconds6"
        Me.lblSeconds6.Size = New System.Drawing.Size(65, 13)
        Me.lblSeconds6.TabIndex = 16
        Me.lblSeconds6.Text = "lblSeconds6"
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
        'lblSeconds3
        '
        Me.lblSeconds3.AutoSize = True
        Me.lblSeconds3.Location = New System.Drawing.Point(129, 153)
        Me.lblSeconds3.Name = "lblSeconds3"
        Me.lblSeconds3.Size = New System.Drawing.Size(65, 13)
        Me.lblSeconds3.TabIndex = 14
        Me.lblSeconds3.Text = "lblSeconds3"
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
        'lblSeconds5
        '
        Me.lblSeconds5.AutoSize = True
        Me.lblSeconds5.Location = New System.Drawing.Point(231, 114)
        Me.lblSeconds5.Name = "lblSeconds5"
        Me.lblSeconds5.Size = New System.Drawing.Size(65, 13)
        Me.lblSeconds5.TabIndex = 12
        Me.lblSeconds5.Text = "lblSeconds5"
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
        'lblSeconds2
        '
        Me.lblSeconds2.AutoSize = True
        Me.lblSeconds2.Location = New System.Drawing.Point(129, 114)
        Me.lblSeconds2.Name = "lblSeconds2"
        Me.lblSeconds2.Size = New System.Drawing.Size(65, 13)
        Me.lblSeconds2.TabIndex = 10
        Me.lblSeconds2.Text = "lblSeconds2"
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
        'lblSeconds4
        '
        Me.lblSeconds4.AutoSize = True
        Me.lblSeconds4.Location = New System.Drawing.Point(231, 73)
        Me.lblSeconds4.Name = "lblSeconds4"
        Me.lblSeconds4.Size = New System.Drawing.Size(65, 13)
        Me.lblSeconds4.TabIndex = 8
        Me.lblSeconds4.Text = "lblSeconds4"
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
        'lblSeconds1
        '
        Me.lblSeconds1.AutoSize = True
        Me.lblSeconds1.Location = New System.Drawing.Point(129, 73)
        Me.lblSeconds1.Name = "lblSeconds1"
        Me.lblSeconds1.Size = New System.Drawing.Size(65, 13)
        Me.lblSeconds1.TabIndex = 6
        Me.lblSeconds1.Text = "lblSeconds1"
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
        Me.lblSkipFFWPlay.Text = "lblSkipFFWPlay"
        Me.lblSkipFFWPlay.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSkipBackPlay
        '
        Me.lblSkipBackPlay.Location = New System.Drawing.Point(63, 27)
        Me.lblSkipBackPlay.Name = "lblSkipBackPlay"
        Me.lblSkipBackPlay.Size = New System.Drawing.Size(95, 13)
        Me.lblSkipBackPlay.TabIndex = 3
        Me.lblSkipBackPlay.Text = "lblSkipBackPlay"
        Me.lblSkipBackPlay.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'lblSkipPart3Play
        '
        Me.lblSkipPart3Play.AutoSize = True
        Me.lblSkipPart3Play.Location = New System.Drawing.Point(6, 152)
        Me.lblSkipPart3Play.Name = "lblSkipPart3Play"
        Me.lblSkipPart3Play.Size = New System.Drawing.Size(83, 13)
        Me.lblSkipPart3Play.TabIndex = 2
        Me.lblSkipPart3Play.Text = "lblSkipPart3Play"
        '
        'lblSkipPart2Play
        '
        Me.lblSkipPart2Play.AutoSize = True
        Me.lblSkipPart2Play.Location = New System.Drawing.Point(6, 113)
        Me.lblSkipPart2Play.Name = "lblSkipPart2Play"
        Me.lblSkipPart2Play.Size = New System.Drawing.Size(83, 13)
        Me.lblSkipPart2Play.TabIndex = 1
        Me.lblSkipPart2Play.Text = "lblSkipPart2Play"
        '
        'lblSkipPart1Play
        '
        Me.lblSkipPart1Play.AutoSize = True
        Me.lblSkipPart1Play.Location = New System.Drawing.Point(6, 72)
        Me.lblSkipPart1Play.Name = "lblSkipPart1Play"
        Me.lblSkipPart1Play.Size = New System.Drawing.Size(83, 13)
        Me.lblSkipPart1Play.TabIndex = 0
        Me.lblSkipPart1Play.Text = "lblSkipPart1Play"
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
        'tabReplacementStrings
        '
        Me.tabReplacementStrings.Controls.Add(Me.GroupBoxEditReplacementString)
        Me.tabReplacementStrings.Controls.Add(Me.DataGridView1)
        Me.tabReplacementStrings.Location = New System.Drawing.Point(4, 22)
        Me.tabReplacementStrings.Name = "tabReplacementStrings"
        Me.tabReplacementStrings.Size = New System.Drawing.Size(602, 307)
        Me.tabReplacementStrings.TabIndex = 2
        Me.tabReplacementStrings.Text = "tabReplacementStrings"
        Me.tabReplacementStrings.UseVisualStyleBackColor = True
        '
        'GroupBoxEditReplacementString
        '
        Me.GroupBoxEditReplacementString.Controls.Add(Me.btnDelReplaceString)
        Me.GroupBoxEditReplacementString.Controls.Add(Me.lblReplacementString)
        Me.GroupBoxEditReplacementString.Controls.Add(Me.btnAddReplaceString)
        Me.GroupBoxEditReplacementString.Controls.Add(Me.lblOriginalString)
        Me.GroupBoxEditReplacementString.Controls.Add(Me.TextBox4)
        Me.GroupBoxEditReplacementString.Controls.Add(Me.TextBox5)
        Me.GroupBoxEditReplacementString.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBoxEditReplacementString.Location = New System.Drawing.Point(0, 212)
        Me.GroupBoxEditReplacementString.Name = "GroupBoxEditReplacementString"
        Me.GroupBoxEditReplacementString.Size = New System.Drawing.Size(602, 95)
        Me.GroupBoxEditReplacementString.TabIndex = 5
        Me.GroupBoxEditReplacementString.TabStop = False
        Me.GroupBoxEditReplacementString.Text = "GroupBoxEditReplacementString"
        '
        'btnDelReplaceString
        '
        Me.btnDelReplaceString.Location = New System.Drawing.Point(522, 20)
        Me.btnDelReplaceString.Name = "btnDelReplaceString"
        Me.btnDelReplaceString.Size = New System.Drawing.Size(75, 48)
        Me.btnDelReplaceString.TabIndex = 6
        Me.btnDelReplaceString.Text = "btnDelReplaceString"
        Me.btnDelReplaceString.UseVisualStyleBackColor = True
        '
        'lblReplacementString
        '
        Me.lblReplacementString.AutoSize = True
        Me.lblReplacementString.Location = New System.Drawing.Point(8, 51)
        Me.lblReplacementString.Name = "lblReplacementString"
        Me.lblReplacementString.Size = New System.Drawing.Size(107, 13)
        Me.lblReplacementString.TabIndex = 5
        Me.lblReplacementString.Text = "lblReplacementString"
        '
        'btnAddReplaceString
        '
        Me.btnAddReplaceString.Location = New System.Drawing.Point(436, 20)
        Me.btnAddReplaceString.Name = "btnAddReplaceString"
        Me.btnAddReplaceString.Size = New System.Drawing.Size(75, 48)
        Me.btnAddReplaceString.TabIndex = 3
        Me.btnAddReplaceString.Text = "btnAddReplaceString"
        Me.btnAddReplaceString.UseVisualStyleBackColor = True
        '
        'lblOriginalString
        '
        Me.lblOriginalString.AutoSize = True
        Me.lblOriginalString.Location = New System.Drawing.Point(8, 25)
        Me.lblOriginalString.Name = "lblOriginalString"
        Me.lblOriginalString.Size = New System.Drawing.Size(79, 13)
        Me.lblOriginalString.TabIndex = 4
        Me.lblOriginalString.Text = "lblOriginalString"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(128, 22)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(294, 20)
        Me.TextBox4.TabIndex = 1
        '
        'TextBox5
        '
        Me.TextBox5.Location = New System.Drawing.Point(128, 48)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(294, 20)
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
        'tabTVSuite
        '
        Me.tabTVSuite.Controls.Add(Me.GroupBoxTVsuiteProfileH264)
        Me.tabTVSuite.Controls.Add(Me.chkDebugMode)
        Me.tabTVSuite.Controls.Add(Me.GroupBoxTVsuiteProfile)
        Me.tabTVSuite.Controls.Add(Me.btnCheckTVsuite)
        Me.tabTVSuite.Controls.Add(Me.lblDescriptionTVsuite)
        Me.tabTVSuite.Location = New System.Drawing.Point(4, 22)
        Me.tabTVSuite.Name = "tabTVSuite"
        Me.tabTVSuite.Padding = New System.Windows.Forms.Padding(3)
        Me.tabTVSuite.Size = New System.Drawing.Size(602, 307)
        Me.tabTVSuite.TabIndex = 4
        Me.tabTVSuite.Text = "tabTVSuite"
        Me.tabTVSuite.UseVisualStyleBackColor = True
        '
        'GroupBoxTVsuiteProfileH264
        '
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.lblFramerateH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.lblDeinterlacemodeH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.lblRatioH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.lblResolutionH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.lblFileTypeH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.lblEncodingtypeH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.txtFramerateH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.txtDeinterlacemodeH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.txtRatioH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.txtResolutionH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.txtFiletypeH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.txtEncodingtypeH264)
        Me.GroupBoxTVsuiteProfileH264.Controls.Add(Me.cbxSavingProfileH264)
        Me.GroupBoxTVsuiteProfileH264.Location = New System.Drawing.Point(303, 89)
        Me.GroupBoxTVsuiteProfileH264.Name = "GroupBoxTVsuiteProfileH264"
        Me.GroupBoxTVsuiteProfileH264.Size = New System.Drawing.Size(293, 212)
        Me.GroupBoxTVsuiteProfileH264.TabIndex = 15
        Me.GroupBoxTVsuiteProfileH264.TabStop = False
        Me.GroupBoxTVsuiteProfileH264.Text = "GroupBoxTVsuiteProfileH264"
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
        'lblEncodingtypeH264
        '
        Me.lblEncodingtypeH264.AutoSize = True
        Me.lblEncodingtypeH264.Location = New System.Drawing.Point(116, 51)
        Me.lblEncodingtypeH264.Name = "lblEncodingtypeH264"
        Me.lblEncodingtypeH264.Size = New System.Drawing.Size(108, 13)
        Me.lblEncodingtypeH264.TabIndex = 9
        Me.lblEncodingtypeH264.Text = "lblEncodingtypeH264"
        '
        'txtFramerateH264
        '
        Me.txtFramerateH264.AutoSize = True
        Me.txtFramerateH264.Location = New System.Drawing.Point(6, 172)
        Me.txtFramerateH264.Name = "txtFramerateH264"
        Me.txtFramerateH264.Size = New System.Drawing.Size(91, 13)
        Me.txtFramerateH264.TabIndex = 8
        Me.txtFramerateH264.Text = "txtFramerateH264"
        '
        'txtDeinterlacemodeH264
        '
        Me.txtDeinterlacemodeH264.AutoSize = True
        Me.txtDeinterlacemodeH264.Location = New System.Drawing.Point(6, 146)
        Me.txtDeinterlacemodeH264.Name = "txtDeinterlacemodeH264"
        Me.txtDeinterlacemodeH264.Size = New System.Drawing.Size(124, 13)
        Me.txtDeinterlacemodeH264.TabIndex = 7
        Me.txtDeinterlacemodeH264.Text = "txtDeinterlacemodeH264"
        '
        'txtRatioH264
        '
        Me.txtRatioH264.AutoSize = True
        Me.txtRatioH264.Location = New System.Drawing.Point(6, 120)
        Me.txtRatioH264.Name = "txtRatioH264"
        Me.txtRatioH264.Size = New System.Drawing.Size(69, 13)
        Me.txtRatioH264.TabIndex = 6
        Me.txtRatioH264.Text = "txtRatioH264"
        '
        'txtResolutionH264
        '
        Me.txtResolutionH264.AutoSize = True
        Me.txtResolutionH264.Location = New System.Drawing.Point(6, 96)
        Me.txtResolutionH264.Name = "txtResolutionH264"
        Me.txtResolutionH264.Size = New System.Drawing.Size(94, 13)
        Me.txtResolutionH264.TabIndex = 5
        Me.txtResolutionH264.Text = "txtResolutionH264"
        '
        'txtFiletypeH264
        '
        Me.txtFiletypeH264.AutoSize = True
        Me.txtFiletypeH264.Location = New System.Drawing.Point(6, 73)
        Me.txtFiletypeH264.Name = "txtFiletypeH264"
        Me.txtFiletypeH264.Size = New System.Drawing.Size(80, 13)
        Me.txtFiletypeH264.TabIndex = 4
        Me.txtFiletypeH264.Text = "txtFiletypeH264"
        '
        'txtEncodingtypeH264
        '
        Me.txtEncodingtypeH264.AutoSize = True
        Me.txtEncodingtypeH264.Location = New System.Drawing.Point(6, 51)
        Me.txtEncodingtypeH264.Name = "txtEncodingtypeH264"
        Me.txtEncodingtypeH264.Size = New System.Drawing.Size(109, 13)
        Me.txtEncodingtypeH264.TabIndex = 3
        Me.txtEncodingtypeH264.Text = "txtEncodingtypeH264"
        '
        'cbxSavingProfileH264
        '
        Me.cbxSavingProfileH264.FormattingEnabled = True
        Me.cbxSavingProfileH264.Location = New System.Drawing.Point(107, 19)
        Me.cbxSavingProfileH264.Name = "cbxSavingProfileH264"
        Me.cbxSavingProfileH264.Size = New System.Drawing.Size(174, 21)
        Me.cbxSavingProfileH264.TabIndex = 2
        '
        'chkDebugMode
        '
        Me.chkDebugMode.AutoSize = True
        Me.chkDebugMode.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.chkDebugMode.Location = New System.Drawing.Point(155, 64)
        Me.chkDebugMode.Name = "chkDebugMode"
        Me.chkDebugMode.Size = New System.Drawing.Size(103, 17)
        Me.chkDebugMode.TabIndex = 4
        Me.chkDebugMode.Text = "chkDebugMode"
        Me.chkDebugMode.UseVisualStyleBackColor = True
        '
        'GroupBoxTVsuiteProfile
        '
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.lblFramerate)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.lblDeinterlacemode)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.lblRatio)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.lblResolution)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.lblFileType)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.lblEncodingtype)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.txtFramerate)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.txtDeinterlacemode)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.txtRatio)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.txtResolution)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.txtFiletype)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.txtEncodingtype)
        Me.GroupBoxTVsuiteProfile.Controls.Add(Me.cbxSavingProfile)
        Me.GroupBoxTVsuiteProfile.Location = New System.Drawing.Point(3, 89)
        Me.GroupBoxTVsuiteProfile.Name = "GroupBoxTVsuiteProfile"
        Me.GroupBoxTVsuiteProfile.Size = New System.Drawing.Size(294, 212)
        Me.GroupBoxTVsuiteProfile.TabIndex = 3
        Me.GroupBoxTVsuiteProfile.TabStop = False
        Me.GroupBoxTVsuiteProfile.Text = "GroupBoxTVsuiteProfile"
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
        'lblEncodingtype
        '
        Me.lblEncodingtype.AutoSize = True
        Me.lblEncodingtype.Location = New System.Drawing.Point(116, 51)
        Me.lblEncodingtype.Name = "lblEncodingtype"
        Me.lblEncodingtype.Size = New System.Drawing.Size(82, 13)
        Me.lblEncodingtype.TabIndex = 9
        Me.lblEncodingtype.Text = "lblEncodingtype"
        '
        'txtFramerate
        '
        Me.txtFramerate.AutoSize = True
        Me.txtFramerate.Location = New System.Drawing.Point(6, 172)
        Me.txtFramerate.Name = "txtFramerate"
        Me.txtFramerate.Size = New System.Drawing.Size(65, 13)
        Me.txtFramerate.TabIndex = 8
        Me.txtFramerate.Text = "txtFramerate"
        '
        'txtDeinterlacemode
        '
        Me.txtDeinterlacemode.AutoSize = True
        Me.txtDeinterlacemode.Location = New System.Drawing.Point(6, 146)
        Me.txtDeinterlacemode.Name = "txtDeinterlacemode"
        Me.txtDeinterlacemode.Size = New System.Drawing.Size(98, 13)
        Me.txtDeinterlacemode.TabIndex = 7
        Me.txtDeinterlacemode.Text = "txtDeinterlacemode"
        '
        'txtRatio
        '
        Me.txtRatio.AutoSize = True
        Me.txtRatio.Location = New System.Drawing.Point(6, 120)
        Me.txtRatio.Name = "txtRatio"
        Me.txtRatio.Size = New System.Drawing.Size(43, 13)
        Me.txtRatio.TabIndex = 6
        Me.txtRatio.Text = "txtRatio"
        '
        'txtResolution
        '
        Me.txtResolution.AutoSize = True
        Me.txtResolution.Location = New System.Drawing.Point(6, 96)
        Me.txtResolution.Name = "txtResolution"
        Me.txtResolution.Size = New System.Drawing.Size(68, 13)
        Me.txtResolution.TabIndex = 5
        Me.txtResolution.Text = "txtResolution"
        '
        'txtFiletype
        '
        Me.txtFiletype.AutoSize = True
        Me.txtFiletype.Location = New System.Drawing.Point(6, 73)
        Me.txtFiletype.Name = "txtFiletype"
        Me.txtFiletype.Size = New System.Drawing.Size(54, 13)
        Me.txtFiletype.TabIndex = 4
        Me.txtFiletype.Text = "txtFiletype"
        '
        'txtEncodingtype
        '
        Me.txtEncodingtype.AutoSize = True
        Me.txtEncodingtype.Location = New System.Drawing.Point(6, 51)
        Me.txtEncodingtype.Name = "txtEncodingtype"
        Me.txtEncodingtype.Size = New System.Drawing.Size(83, 13)
        Me.txtEncodingtype.TabIndex = 3
        Me.txtEncodingtype.Text = "txtEncodingtype"
        '
        'cbxSavingProfile
        '
        Me.cbxSavingProfile.FormattingEnabled = True
        Me.cbxSavingProfile.Location = New System.Drawing.Point(107, 19)
        Me.cbxSavingProfile.Name = "cbxSavingProfile"
        Me.cbxSavingProfile.Size = New System.Drawing.Size(174, 21)
        Me.cbxSavingProfile.TabIndex = 2
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
        Me.lblDonate.Location = New System.Drawing.Point(304, 22)
        Me.lblDonate.Name = "lblDonate"
        Me.lblDonate.Size = New System.Drawing.Size(53, 15)
        Me.lblDonate.TabIndex = 0
        Me.lblDonate.TabStop = True
        Me.lblDonate.Text = "Donate"
        '
        'SetupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(610, 435)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SetupForm"
        Me.Text = "SetupForm"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tabCommon1.ResumeLayout(False)
        Me.GroupBoxSaveSettings.ResumeLayout(False)
        Me.GroupBoxSaveSettings.PerformLayout()
        CType(Me.imgParseSeries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgParseMovieFile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxRecordings.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer7.Panel1.ResumeLayout(False)
        Me.SplitContainer7.Panel1.PerformLayout()
        Me.SplitContainer7.Panel2.ResumeLayout(False)
        Me.SplitContainer7.Panel2.PerformLayout()
        CType(Me.SplitContainer7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer7.ResumeLayout(False)
        Me.SplitContainer4.Panel1.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        Me.SplitContainer6.Panel1.ResumeLayout(False)
        Me.SplitContainer6.Panel1.PerformLayout()
        Me.SplitContainer6.Panel2.ResumeLayout(False)
        Me.SplitContainer6.Panel2.PerformLayout()
        CType(Me.SplitContainer6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer6.ResumeLayout(False)
        Me.SplitContainer5.Panel1.ResumeLayout(False)
        Me.SplitContainer5.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer5.ResumeLayout(False)
        Me.GroupBoxModuleName.ResumeLayout(False)
        Me.GroupBoxModuleName.PerformLayout()
        Me.tabCommon2.ResumeLayout(False)
        Me.GroupAlwaysRefreshMoviestripThumbs.ResumeLayout(False)
        Me.GroupAlwaysRefreshMoviestripThumbs.PerformLayout()
        CType(Me.numAlwaysRefreshMoviestripThumbsDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxDialogs.ResumeLayout(False)
        Me.GroupBoxDialogs.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgDisableProfileDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxCutSettings.ResumeLayout(False)
        Me.GroupBoxCutSettings.PerformLayout()
        CType(Me.imgAutoEndMarker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgAutoStartmarker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabSeekSteps.ResumeLayout(False)
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
        Me.tabReplacementStrings.ResumeLayout(False)
        Me.GroupBoxEditReplacementString.ResumeLayout(False)
        Me.GroupBoxEditReplacementString.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabTVSuite.ResumeLayout(False)
        Me.tabTVSuite.PerformLayout()
        Me.GroupBoxTVsuiteProfileH264.ResumeLayout(False)
        Me.GroupBoxTVsuiteProfileH264.PerformLayout()
        Me.GroupBoxTVsuiteProfile.ResumeLayout(False)
        Me.GroupBoxTVsuiteProfile.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RecDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents tabCommon1 As System.Windows.Forms.TabPage
    Friend WithEvents SaveDialog As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents tabReplacementStrings As System.Windows.Forms.TabPage
    Friend WithEvents btnAddReplaceString As System.Windows.Forms.Button
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBoxEditReplacementString As System.Windows.Forms.GroupBox
    Friend WithEvents lblOriginalString As System.Windows.Forms.Label
    Friend WithEvents lblReplacementString As System.Windows.Forms.Label
    Friend WithEvents btnDelReplaceString As System.Windows.Forms.Button
    Friend WithEvents lblDonate As System.Windows.Forms.LinkLabel
    Friend WithEvents tabSeekSteps As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxOnPause As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxOnPlay As System.Windows.Forms.GroupBox
    Friend WithEvents lblSkipFFWPlay As System.Windows.Forms.Label
    Friend WithEvents lblSkipBackPlay As System.Windows.Forms.Label
    Friend WithEvents lblSkipPart3Play As System.Windows.Forms.Label
    Friend WithEvents lblSkipPart2Play As System.Windows.Forms.Label
    Friend WithEvents lblSkipPart1Play As System.Windows.Forms.Label
    Friend WithEvents lblconfigureSeekSteps As System.Windows.Forms.Label
    Friend WithEvents lblFrames6 As System.Windows.Forms.Label
    Friend WithEvents numBackPause3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numFFWPause3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSkipPart1Pause As System.Windows.Forms.Label
    Friend WithEvents lblFrames3 As System.Windows.Forms.Label
    Friend WithEvents lblSkipPart2Pause As System.Windows.Forms.Label
    Friend WithEvents lblSkipPart3Pause As System.Windows.Forms.Label
    Friend WithEvents lblFrames5 As System.Windows.Forms.Label
    Friend WithEvents lblBackPause As System.Windows.Forms.Label
    Friend WithEvents numFFWPause2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblFFWPause As System.Windows.Forms.Label
    Friend WithEvents lblFrames2 As System.Windows.Forms.Label
    Friend WithEvents numBackPause1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents numBackPause2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblFrames1 As System.Windows.Forms.Label
    Friend WithEvents lblFrames4 As System.Windows.Forms.Label
    Friend WithEvents numFFWPause1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSeconds6 As System.Windows.Forms.Label
    Friend WithEvents numFFWPlay3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSeconds3 As System.Windows.Forms.Label
    Friend WithEvents numBackPlay3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSeconds5 As System.Windows.Forms.Label
    Friend WithEvents numFFWPlay2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSeconds2 As System.Windows.Forms.Label
    Friend WithEvents numBackPlay2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSeconds4 As System.Windows.Forms.Label
    Friend WithEvents numFFWPlay1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblSeconds1 As System.Windows.Forms.Label
    Friend WithEvents numBackPlay1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents tabTVSuite As System.Windows.Forms.TabPage
    Friend WithEvents btnCheckTVsuite As System.Windows.Forms.Button
    Friend WithEvents lblDescriptionTVsuite As System.Windows.Forms.Label
    Friend WithEvents cbxSavingProfile As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBoxTVsuiteProfile As System.Windows.Forms.GroupBox
    Friend WithEvents txtRatio As System.Windows.Forms.Label
    Friend WithEvents txtResolution As System.Windows.Forms.Label
    Friend WithEvents txtFiletype As System.Windows.Forms.Label
    Friend WithEvents txtEncodingtype As System.Windows.Forms.Label
    Friend WithEvents txtDeinterlacemode As System.Windows.Forms.Label
    Friend WithEvents txtFramerate As System.Windows.Forms.Label
    Friend WithEvents lblFramerate As System.Windows.Forms.Label
    Friend WithEvents lblDeinterlacemode As System.Windows.Forms.Label
    Friend WithEvents lblRatio As System.Windows.Forms.Label
    Friend WithEvents lblResolution As System.Windows.Forms.Label
    Friend WithEvents lblFileType As System.Windows.Forms.Label
    Friend WithEvents lblEncodingtype As System.Windows.Forms.Label
    Friend WithEvents chkDebugMode As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxTVsuiteProfileH264 As System.Windows.Forms.GroupBox
    Friend WithEvents lblFramerateH264 As System.Windows.Forms.Label
    Friend WithEvents lblDeinterlacemodeH264 As System.Windows.Forms.Label
    Friend WithEvents lblRatioH264 As System.Windows.Forms.Label
    Friend WithEvents lblResolutionH264 As System.Windows.Forms.Label
    Friend WithEvents lblFileTypeH264 As System.Windows.Forms.Label
    Friend WithEvents lblEncodingtypeH264 As System.Windows.Forms.Label
    Friend WithEvents txtFramerateH264 As System.Windows.Forms.Label
    Friend WithEvents txtDeinterlacemodeH264 As System.Windows.Forms.Label
    Friend WithEvents txtRatioH264 As System.Windows.Forms.Label
    Friend WithEvents txtResolutionH264 As System.Windows.Forms.Label
    Friend WithEvents txtFiletypeH264 As System.Windows.Forms.Label
    Friend WithEvents txtEncodingtypeH264 As System.Windows.Forms.Label
    Friend WithEvents cbxSavingProfileH264 As System.Windows.Forms.ComboBox
    Friend WithEvents tabCommon2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBoxDialogs As System.Windows.Forms.GroupBox
    Friend WithEvents chkAlwaysKeepOriginalFile As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents chkAlwaysKeepCuts As System.Windows.Forms.CheckBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents chkDisableProfileDetails As System.Windows.Forms.CheckBox
    Friend WithEvents imgDisableProfileDetails As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBoxCutSettings As System.Windows.Forms.GroupBox
    Friend WithEvents imgAutoEndMarker As System.Windows.Forms.PictureBox
    Friend WithEvents chkAutoEndmarker As System.Windows.Forms.CheckBox
    Friend WithEvents imgAutoStartmarker As System.Windows.Forms.PictureBox
    Friend WithEvents chkAutoStartmarker As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBoxSaveSettings As System.Windows.Forms.GroupBox
    Friend WithEvents lblTestSeriesFolderParsing As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTestMovieFolderParsing As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtParseSeriesFolder As System.Windows.Forms.TextBox
    Friend WithEvents chkCreateSeriesFolder As System.Windows.Forms.CheckBox
    Friend WithEvents txtParseMovieFolder As System.Windows.Forms.TextBox
    Friend WithEvents chkCreateMovieFolder As System.Windows.Forms.CheckBox
    Friend WithEvents lblTestMovieParsing As System.Windows.Forms.Label
    Friend WithEvents lblTestSeriesParsing As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblParseSeriesFile As System.Windows.Forms.Label
    Friend WithEvents txtParseSeriesFile As System.Windows.Forms.TextBox
    Friend WithEvents imgParseSeries As System.Windows.Forms.PictureBox
    Friend WithEvents btnShowParseStrings As System.Windows.Forms.Button
    Friend WithEvents lblParseMoviefile As System.Windows.Forms.Label
    Friend WithEvents txtParseMovieFile As System.Windows.Forms.TextBox
    Friend WithEvents imgParseMovieFile As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBoxRecordings As System.Windows.Forms.GroupBox
    Friend WithEvents SplitContainer3 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer7 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblRecPath As System.Windows.Forms.Label
    Friend WithEvents lblSavePath As System.Windows.Forms.Label
    Friend WithEvents SplitContainer4 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer6 As System.Windows.Forms.SplitContainer
    Friend WithEvents txtRecPath As System.Windows.Forms.TextBox
    Friend WithEvents txtSavePath As System.Windows.Forms.TextBox
    Friend WithEvents SplitContainer5 As System.Windows.Forms.SplitContainer
    Friend WithEvents btnRecDialog As System.Windows.Forms.Button
    Friend WithEvents bntSaveDialog As System.Windows.Forms.Button
    Friend WithEvents GroupBoxModuleName As System.Windows.Forms.GroupBox
    Friend WithEvents lblModulName As System.Windows.Forms.Label
    Friend WithEvents txtModulName As System.Windows.Forms.TextBox
    Friend WithEvents GroupAlwaysRefreshMoviestripThumbs As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents chkAlwaysRefreshMoviestripThumbs As System.Windows.Forms.CheckBox
    Friend WithEvents lblAlwaysRefreshMoviestripThumbsDelay As System.Windows.Forms.Label
    Friend WithEvents lblSeconds As System.Windows.Forms.Label
    Friend WithEvents numAlwaysRefreshMoviestripThumbsDelay As System.Windows.Forms.NumericUpDown
End Class
