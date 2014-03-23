Imports MediaPortal.Profile
Imports MediaPortal.Configuration

Public Class SetupForm
    Dim Replacer As New clsSeriesReplacer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecDialog.Click
        With Me.RecDialog
            .ShowDialog()
            Me.txtRecPath.Text = RecDialog.SelectedPath.ToString
        End With
    End Sub

    Private Sub SetupForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If myVRD IsNot Nothing Then
            myVRD.Close()
            myVRD.Dispose()
        End If
        HelpConfig.SetConfigString(ConfigKey.ModuleName, Me.txtModulName.Text)
        HelpConfig.SetConfigString(ConfigKey.RecordingsPath, Me.txtRecPath.Text)
        HelpConfig.SetConfigString(ConfigKey.VideoSavePath, Me.txtSavePath.Text)
        HelpConfig.SetConfigString(ConfigKey.CutOnPlay, chkAutoStartmarker.Checked)
        HelpConfig.SetConfigString(ConfigKey.CutOnEnd, chkAutoEndmarker.Checked)
        HelpConfig.SetConfigString(ConfigKey.SaveMovieFilename, Me.txtParseMovieFile.Text)
        HelpConfig.SetConfigString(ConfigKey.SaveSeriesFilename, Me.txtParseSeriesFile.Text)
        HelpConfig.SetConfigString(ConfigKey.SeekStepOnPause1, Me.numBackPause1.Value)
        HelpConfig.SetConfigString(ConfigKey.SeekStepOnPause4, Me.numBackPause2.Value)
        HelpConfig.SetConfigString(ConfigKey.SeekStepOnPause7, Me.numBackPause3.Value)
        HelpConfig.SetConfigString(ConfigKey.SeekStepOnPlay1, Me.numBackPlay1.Value)
        HelpConfig.SetConfigString(ConfigKey.SeekStepOnPlay4, Me.numBackPlay2.Value)
        HelpConfig.SetConfigString(ConfigKey.SeekStepOnPlay7, Me.numBackPlay3.Value)
        HelpConfig.SetConfigString(ConfigKey.SeekStepOnPause3, Me.numFFWPause1.Value)
        HelpConfig.SetConfigString(ConfigKey.SeekStepOnPause6, Me.numFFWPause2.Value)
        HelpConfig.SetConfigString(ConfigKey.SeekStepOnPause9, Me.numFFWPause3.Value)
        HelpConfig.SetConfigString(ConfigKey.SeekStepOnPlay3, Me.numFFWPlay1.Value)
        HelpConfig.SetConfigString(ConfigKey.SeekStepOnPlay6, Me.numFFWPlay2.Value)
        HelpConfig.SetConfigString(ConfigKey.SeekStepOnPlay9, Me.numFFWPlay3.Value)
        HelpConfig.SetConfigString(ConfigKey.CreateMoviefolder, Me.chkCreateMovieFolder.Checked)
        HelpConfig.SetConfigString(ConfigKey.MovieFolder, Me.txtParseMovieFolder.Text)
        HelpConfig.SetConfigString(ConfigKey.CreateSeriesfolder, Me.chkCreateSeriesFolder.Checked)
        HelpConfig.SetConfigString(ConfigKey.SeriesFolder, Me.txtParseSeriesFolder.Text)
        HelpConfig.SetConfigString(ConfigKey.DebugVideoRedo, Me.chkDebugMode.Checked)
        HelpConfig.SetConfigString(ConfigKey.ProfileDetails, Me.chkDisableProfileDetails.Checked)
        HelpConfig.SetConfigString(ConfigKey.AlwaysKeepOriginalFile, Me.chkAlwaysKeepOriginalFile.Checked)
        HelpConfig.SetConfigString(ConfigKey.AlwaysKeepCuts, Me.chkAlwaysKeepCuts.Checked)
        HelpConfig.SetConfigString(ConfigKey.AlwaysRefreshMoviestripThumbs, Me.chkAlwaysRefreshMoviestripThumbs.Checked)
        HelpConfig.SetConfigString(ConfigKey.AlwaysRefreshMoviestripThumbsDelay, Me.numAlwaysRefreshMoviestripThumbsDelay.Value)
    End Sub

    Private Sub SetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TranslateSetupForm()
        Me.txtModulName.Text = HelpConfig.GetConfigString(ConfigKey.ModuleName)
        Me.txtRecPath.Text = HelpConfig.GetConfigString(ConfigKey.RecordingsPath)
        Me.txtSavePath.Text = HelpConfig.GetConfigString(ConfigKey.VideoSavePath)
        Me.chkAutoStartmarker.Checked = HelpConfig.GetConfigString(ConfigKey.CutOnPlay)
        Me.chkAutoEndmarker.Checked = HelpConfig.GetConfigString(ConfigKey.CutOnEnd)
        Me.txtParseMovieFile.Text = HelpConfig.GetConfigString(ConfigKey.SaveMovieFilename)
        Me.txtParseSeriesFile.Text = HelpConfig.GetConfigString(ConfigKey.SaveSeriesFilename)
        Me.numBackPause1.Value = HelpConfig.GetConfigString(ConfigKey.SeekStepOnPause1)
        Me.numBackPause2.Value = HelpConfig.GetConfigString(ConfigKey.SeekStepOnPause4)
        Me.numBackPause3.Value = HelpConfig.GetConfigString(ConfigKey.SeekStepOnPause7)
        Me.numBackPlay1.Value = HelpConfig.GetConfigString(ConfigKey.SeekStepOnPlay1)
        Me.numBackPlay2.Value = HelpConfig.GetConfigString(ConfigKey.SeekStepOnPlay4)
        Me.numBackPlay3.Value = HelpConfig.GetConfigString(ConfigKey.SeekStepOnPlay7)
        Me.numFFWPause1.Value = HelpConfig.GetConfigString(ConfigKey.SeekStepOnPause3)
        Me.numFFWPause2.Value = HelpConfig.GetConfigString(ConfigKey.SeekStepOnPause6)
        Me.numFFWPause3.Value = HelpConfig.GetConfigString(ConfigKey.SeekStepOnPause9)
        Me.numFFWPlay1.Value = HelpConfig.GetConfigString(ConfigKey.SeekStepOnPlay3)
        Me.numFFWPlay2.Value = HelpConfig.GetConfigString(ConfigKey.SeekStepOnPlay6)
        Me.numFFWPlay3.Value = HelpConfig.GetConfigString(ConfigKey.SeekStepOnPlay9)
        Me.chkCreateMovieFolder.Checked = HelpConfig.GetConfigString(ConfigKey.CreateMoviefolder)
        Me.txtParseMovieFolder.Text = HelpConfig.GetConfigString(ConfigKey.MovieFolder)
        Me.chkCreateSeriesFolder.Checked = HelpConfig.GetConfigString(ConfigKey.CreateSeriesfolder)
        Me.txtParseSeriesFolder.Text = HelpConfig.GetConfigString(ConfigKey.SeriesFolder)
        Me.chkDebugMode.Checked = HelpConfig.GetConfigString(ConfigKey.DebugVideoRedo)
        Me.chkDisableProfileDetails.Checked = HelpConfig.GetConfigString(ConfigKey.ProfileDetails)
        Me.chkAlwaysKeepCuts.Checked = HelpConfig.GetConfigString(ConfigKey.AlwaysKeepCuts)
        Me.chkAlwaysKeepOriginalFile.Checked = HelpConfig.GetConfigString(ConfigKey.AlwaysKeepOriginalFile)
        Me.chkAlwaysRefreshMoviestripThumbs.Checked = HelpConfig.GetConfigString(ConfigKey.AlwaysRefreshMoviestripThumbs)
        Me.numAlwaysRefreshMoviestripThumbsDelay.Value = HelpConfig.GetConfigString(ConfigKey.AlwaysRefreshMoviestripThumbsDelay)
        Replacer = Replacer.Load()
        'For Each item In Replacer.ReplacerList
        '    MsgBox(item.OriginalString & " - " & item.ReplaceString)
        'Next
        Me.DataGridView1.DataSource = Replacer.ReplacerList


        Me.SaveDialog.SelectedPath = Me.txtSavePath.Text
        Me.RecDialog.SelectedPath = Me.txtRecPath.Text
    End Sub

    Private Sub TranslateSetupForm()
        Translator.TranslateSkin()
        Me.Text = My.Application.Info.Title
        Me.tabCommon1.Text = Translation.GeneralOptions1
        Me.GroupBoxModuleName.Text = Translation.GroupModuleName
        Me.lblModulName.Text = Translation.ModuleName
        Me.GroupBoxRecordings.Text = Translation.GroupRecordingSettingCaption
        Me.lblRecPath.Text = Translation.LabelRecordingsPath
        Me.btnRecDialog.Text = Translation.SearchFolder
        Me.lblSavePath.Text = Translation.LabelSavePath
        Me.bntSaveDialog.Text = Translation.SearchFolder
        Me.RecDialog.Description = Translation.RecordingDialogDescription
        Me.SaveDialog.Description = Translation.SaveDialogDescription
        Me.GroupBoxSaveSettings.Text = Translation.GroupStringSettingCaption

        Me.chkCreateMovieFolder.Text = Translation.CreateMovieSubfolder
        Me.lblParseMoviefile.Text = Translation.ParseMovieFileLabel
        Me.chkCreateSeriesFolder.Text = Translation.CreateSeriesSubfolder
        Me.lblParseSeriesFile.Text = Translation.ParseSeriesFileLabel
        Me.btnShowParseStrings.Text = Translation.ShowFileParserStrings

        Me.tabCommon2.Text = Translation.GeneralOptions2
        Me.GroupBoxCutSettings.Text = Translation.GroupCutSettingCaption
        Me.chkAutoStartmarker.Text = Translation.StartCutAtStart
        Me.chkAutoEndmarker.Text = Translation.AutoEndCutLabel
        Me.GroupBoxDialogs.Text = Translation.GroupDialogs
        Me.chkDisableProfileDetails.Text = Translation.DisableProfileDetails
        Me.chkAlwaysKeepCuts.Text = Translation.AlwaysKeepCuts
        Me.chkAlwaysKeepOriginalFile.Text = Translation.AlwaysKeepOriginalFile
        Me.GroupAlwaysRefreshMoviestripThumbs.Text = Translation.GroupAlwaysRefreshMoviestripThumbs
        Me.chkAlwaysRefreshMoviestripThumbs.Text = Translation.AlwaysRefreshMoviestripThumbs
        Me.lblAlwaysRefreshMoviestripThumbsDelay.Text = Translation.AlwaysRefreshMoviestripThumbsDelay
        Me.lblSeconds.Text = Translation.Seconds

        Me.tabSeekSteps.Text = Translation.ConfigureSeekSteps
        Me.lblconfigureSeekSteps.Text = Translation.ConfigureSeekSteps
        Me.GroupBoxOnPlay.Text = Translation.GroupOnPlayCaption
        Me.lblSkipBackPlay.Text = Translation.Rewind
        Me.lblSkipFFWPlay.Text = Translation.Forward
        Me.lblSkipPart1Play.Text = String.Format(Translation.Step, "1")
        Me.lblSkipPart2Play.Text = String.Format(Translation.Step, "2")
        Me.lblSkipPart3Play.Text = String.Format(Translation.Step, "3")
        Me.lblSeconds1.Text = Translation.Seconds
        Me.lblSeconds2.Text = Translation.Seconds
        Me.lblSeconds3.Text = Translation.Seconds
        Me.lblSeconds4.Text = Translation.Seconds
        Me.lblSeconds5.Text = Translation.Seconds
        Me.lblSeconds6.Text = Translation.Seconds
        Me.GroupBoxOnPause.Text = Translation.GroupOnPauseCaption
        Me.lblBackPause.Text = Translation.RewindStep
        Me.lblFFWPause.Text = Translation.ForwardStep
        Me.lblSkipPart1Pause.Text = String.Format(Translation.Step, "1")
        Me.lblSkipPart2Pause.Text = String.Format(Translation.Step, "2")
        Me.lblSkipPart3Pause.Text = String.Format(Translation.Step, "3")
        Me.lblFrames1.Text = Translation.Frames
        Me.lblFrames2.Text = Translation.Frames
        Me.lblFrames3.Text = Translation.Frames
        Me.lblFrames4.Text = Translation.Frames
        Me.lblFrames5.Text = Translation.Frames
        Me.lblFrames6.Text = Translation.Frames

        Me.tabReplacementStrings.Text = Translation.EditReplacementString
        Me.GroupBoxEditReplacementString.Text = Translation.EditReplacementString
        Me.lblOriginalString.Text = Translation.OriginalString
        Me.lblReplacementString.Text = Translation.ReplacementString
        Me.btnAddReplaceString.Text = Translation.AddReplaceString
        Me.btnDelReplaceString.Text = Translation.DelReplaceString

        Me.tabTVSuite.Text = Translation.TVSuite
        Me.lblDescriptionTVsuite.Text = Translation.DescriptionTVsuiteProfiles
        Me.btnCheckTVsuite.Text = Translation.ButtonCheckTVsuite4
        Me.chkDebugMode.Text = Translation.DebugMode
        Me.GroupBoxTVsuiteProfile.Text = Translation.GroupTVSuiteProfile
        Me.txtEncodingtype.Text = Translation.Encodingtype
        Me.txtFiletype.Text = Translation.Filetype
        Me.txtResolution.Text = Translation.Resolution
        Me.txtRatio.Text = Translation.Ratio
        Me.txtDeinterlacemode.Text = Translation.Deinterlacemode
        Me.txtFramerate.Text = Translation.Framerate
        Me.GroupBoxTVsuiteProfileH264.Text = Translation.GroupTVSuiteProfileH264
        Me.txtEncodingtypeH264.Text = Translation.Encodingtype
        Me.txtFiletypeH264.Text = Translation.Filetype
        Me.txtResolutionH264.Text = Translation.Resolution
        Me.txtRatioH264.Text = Translation.Ratio
        Me.txtDeinterlacemodeH264.Text = Translation.Deinterlacemode
        Me.txtFramerateH264.Text = Translation.Framerate
    End Sub

    Private Sub btnAddReplaceString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddReplaceString.Click

        Dim ri As New ReplacesStrings
        ri.OriginalString = Me.TextBox4.Text
        ri.ReplaceString = Me.TextBox5.Text

        Replacer.ReplacerList.Add(ri)
        Replacer.Save()
        Replacer = Replacer.Load()
        'For Each item In Replacer.ReplacerList
        '    MsgBox(item.OriginalString & " - " & item.ReplaceString)
        'Next
        Me.DataGridView1.DataSource = Replacer.ReplacerList



    End Sub

    Private Sub btnDelReplaceString_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelReplaceString.Click
        Replacer.ReplacerList.RemoveAt(Me.DataGridView1.SelectedRows(0).Index)
        Replacer.Save()
        Replacer = Replacer.Load()
        Me.DataGridView1.DataSource = Replacer.ReplacerList
    End Sub

    Private Sub btnShowParseStrings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShowParseStrings.Click
        Dim info As New InfoParseStrings
        info.Show()
    End Sub

    Private Sub lblDonate_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lblDonate.LinkClicked
        Dim p As Process = Process.Start("")
    End Sub

    Private Sub bntSaveDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bntSaveDialog.Click

        With Me.SaveDialog
            .ShowDialog()
            Me.txtSavePath.Text = .SelectedPath.ToString

        End With
    End Sub

    Private Sub txtParseFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtParseMovieFile.TextChanged, txtParseMovieFile.KeyUp
        Dim temprec As New clsRecordings.Recordings
        temprec.Title = "Superman Returns"
        temprec.StartTime = Now
        temprec.EndTime = DateAdd(DateInterval.Hour, 2, Now)
        temprec.Genre = "Action"
        temprec.Channelname = "Pro7"
        temprec.Filename = "Superman Returns.mpg"
        txtParseMovieFile.Text = CleanFilename(txtParseMovieFile.Text, "_")
        HelpConfig.SetConfigString(ConfigKey.SaveMovieFilename, Me.txtParseMovieFile.Text)
        Me.lblTestMovieParsing.Text = Parse(temprec, txtParseMovieFile.Text)
        temprec = Nothing
    End Sub

    Private Sub txtParseSeriesFile_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtParseSeriesFile.TextChanged, txtParseSeriesFile.KeyUp
        Dim temprec As New clsRecordings.Recordings
        temprec.Title = "The Simpsons"
        temprec.StartTime = Now
        temprec.EndTime = DateAdd(DateInterval.Hour, 2, Now)
        temprec.Genre = "Animation"
        temprec.Channelname = "Pro7"
        temprec.Seriesname = "The Simpsons"
        temprec.SeriesNum = 5
        temprec.EpisodeNum = 13
        temprec.Episodename = "Homer and Apu"
        temprec.Filename = "The Simpsons - Homer and Apu.mpg"
        txtParseSeriesFile.Text = CleanFilename(txtParseSeriesFile.Text, "_")
        HelpConfig.SetConfigString(ConfigKey.SaveSeriesFilename, Me.txtParseSeriesFile.Text)
        Me.lblTestSeriesParsing.Text = Parse(temprec, txtParseSeriesFile.Text)
        temprec = Nothing
    End Sub

    Private Sub txtParseMovieFolder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtParseMovieFolder.TextChanged, txtParseMovieFolder.KeyUp
        Dim temprec As New clsRecordings.Recordings
        temprec.Title = "Superman Returns"
        temprec.StartTime = Now
        temprec.EndTime = DateAdd(DateInterval.Hour, 2, Now)
        temprec.Genre = "Action"
        temprec.Channelname = "Pro7"
        temprec.Filename = "Superman Returns.mpg"
        txtParseMovieFolder.Text = CleanPathname(txtParseMovieFolder.Text, "_")
        HelpConfig.SetConfigString(ConfigKey.MovieFolder, Me.txtParseMovieFolder.Text)
        Me.lblTestMovieFolderParsing.Text = Parse(temprec, txtParseMovieFolder.Text)
        temprec = Nothing
    End Sub

    Private Sub txtParseSeriesFolder_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtParseSeriesFolder.TextChanged, txtParseSeriesFolder.KeyUp
        Dim temprec As New clsRecordings.Recordings
        temprec.Title = "The Simpsons"
        temprec.StartTime = Now
        temprec.EndTime = DateAdd(DateInterval.Hour, 2, Now)
        temprec.Genre = "Animation"
        temprec.Channelname = "Pro7"
        temprec.Seriesname = "The Simpsons"
        temprec.SeriesNum = 5
        temprec.EpisodeNum = 13
        temprec.Episodename = "Homer and Apu"
        temprec.Filename = "The Simpsons - Homer and Apu.mpg"
        txtParseSeriesFolder.Text = CleanPathname(txtParseSeriesFolder.Text, "_")
        HelpConfig.SetConfigString(ConfigKey.SeriesFolder, Me.txtParseSeriesFolder.Text)
        Me.lblTestSeriesFolderParsing.Text = Parse(temprec, txtParseSeriesFolder.Text)
        temprec = Nothing
    End Sub

    Private Sub imgAutoStartmarker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgAutoStartmarker.Click
        MsgBox(Translation.HelpSetStartmarker)
    End Sub

    Private Sub imgAutoEndMarker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgAutoEndMarker.Click
        MsgBox(Translation.HelpSetEndmarker)
    End Sub

    Private Sub imgParseMovieFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgParseMovieFile.Click
        MsgBox(Translation.HelpParseMovieFile)
    End Sub

    Private Sub imgParseSeries_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgParseSeries.Click
        MsgBox(Translation.HelpParseSeriesFile)
    End Sub

    Private Sub imgDisableProfileDetails_Click(sender As Object, e As EventArgs) Handles imgDisableProfileDetails.Click
        MsgBox(Translation.HelpDisableProfileDetails)
    End Sub

    Private Sub txtParseMovieFile_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)

    End Sub

    Dim myVRD As VideoReDo
    Private Sub btnCheckTVsuite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckTVsuite.Click
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        Try
            myVRD = New VideoReDo
            If Strings.Left(myVRD.ReDoVersion, 1) = 4 Then
                Me.btnCheckTVsuite.Enabled = False
                Dim ProfileList As List(Of String) = myVRD.GetProfileList
                For Each item In ProfileList
                    Me.cbxSavingProfile.Items.Add(item)
                    Me.cbxSavingProfileH264.Items.Add(item)
                Next
                Me.GroupBoxTVsuiteProfile.Visible = True
                Me.GroupBoxTVsuiteProfileH264.Visible = True
                For Each item In cbxSavingProfile.Items
                    If item = HelpConfig.GetConfigString(ConfigKey.TVsuiteProfile) Then
                        cbxSavingProfile.SelectedItem = item
                        Exit For
                    End If
                Next
                For Each item In cbxSavingProfileH264.Items
                    If item = HelpConfig.GetConfigString(ConfigKey.TVsuiteProfileH264) Then
                        cbxSavingProfileH264.SelectedItem = item
                        Exit For
                    End If
                Next
            Else
                MsgBox("TVsuite 4 is not active on your system")
                Me.btnCheckTVsuite.Enabled = False
            End If

        Catch ex As SystemException
            If ex.Message.Contains("ActiveX") Then
                MsgBox("VideoRedo is not registered. If you have VideoRedo installed, please start VideoRedo once as administrator and try it again.")
            End If
        Catch ex As Exception
            MsgBox("Error: " & ex.ToString)
        Finally
            Me.Cursor = Windows.Forms.Cursors.Default
            'myVRD.Close()
            'myVRD.Dispose()
        End Try
    End Sub

    Private Sub cbxSavingProfile_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxSavingProfile.SelectedIndexChanged
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        HelpConfig.SetConfigString(ConfigKey.TVsuiteProfile, Me.cbxSavingProfile.Text)
        Dim AktProfile As VideoReDo.VRDProfileInfo
        AktProfile = myVRD.GetProfileInfo(Me.cbxSavingProfile.Text)
        'myVRD.AktSavingProfile = Me.ComboBox1.Text

        Me.lblEncodingtype.Text = AktProfile.Encodingtype
        Me.lblFileType.Text = AktProfile.Filetype
        Me.lblRatio.Text = AktProfile.Ratio
        Me.lblDeinterlacemode.Text = AktProfile.DeintarlaceModus
        Me.lblFramerate.Text = AktProfile.FrameRate
        Me.lblResolution.Text = AktProfile.Resolution
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub

    Private Sub cbxSavingProfileH264_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSavingProfileH264.SelectedIndexChanged
        Me.Cursor = Windows.Forms.Cursors.WaitCursor
        HelpConfig.SetConfigString(ConfigKey.TVsuiteProfileH264, Me.cbxSavingProfileH264.Text)
        Dim AktProfile As VideoReDo.VRDProfileInfo
        AktProfile = myVRD.GetProfileInfo(Me.cbxSavingProfileH264.Text)
        'myVRD.AktSavingProfile = Me.ComboBoxH264.Text

        Me.lblEncodingtypeH264.Text = AktProfile.Encodingtype
        Me.lblFileTypeH264.Text = AktProfile.Filetype
        Me.lblRatioH264.Text = AktProfile.Ratio
        Me.lblDeinterlacemodeH264.Text = AktProfile.DeintarlaceModus
        Me.lblFramerateH264.Text = AktProfile.FrameRate
        Me.lblResolutionH264.Text = AktProfile.Resolution
        Me.Cursor = Windows.Forms.Cursors.Default
    End Sub
End Class