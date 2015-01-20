Imports System
Imports MediaPortal.GUI.Library
Imports MediaPortal.Dialogs
Imports MediaPortal.Profile
Imports MediaPortal.Configuration
Imports System.IO

Namespace MyVideoRedo
    Public Class GUISaveProgress
        Inherits GUIDialogWindow
        Implements MediaPortal.GUI.Library.IDialogbox
        <SkinControlAttribute(12)> Protected btnExit As GUIButtonControl = Nothing
        <SkinControlAttribute(13)> Protected ctlSavingProgress As GUIProgressControl = Nothing
        <SkinControlAttribute(14)> Protected btnCancel As GUIButtonControl = Nothing
        Private isVideoSaving As Boolean = False
        Private isCanceled As Boolean = False

#Region "MP EventSubs"
        Public Overloads Overrides Property GetID() As Integer
            Get
                Return enumWindows.GUISaveProgress
            End Get
            Set(ByVal value As Integer)
            End Set
        End Property

        Public Overloads Overrides Function Init() As Boolean
            Return Load(GUIGraphicsContext.Skin + "\MyVideoRedoSaveProgress.xml")
        End Function

        Protected Overrides Sub OnPageLoad()
            MyBase.OnPageLoad()
            GUIWindowManager.NeedRefresh()
            AddHandler VRD.SaveVideoStart, AddressOf SaveVideoProgressStart
            AddHandler VRD.SaveVideoProgressCanged, AddressOf SaveVideoProgressChanged
            AddHandler VRD.SaveVideoFinished, AddressOf SaveVideoProgressFinish
            AddHandler VRD.SaveVideoAborted, AddressOf SaveVideoAborted
            ctlSavingProgress.Visible = True
            ctlSavingProgress.Percentage = 0
            Translator.SetProperty("#Saving.Progress.Label1", Translation.Complete & " 0 %")
            Translator.SetProperty("#Saving.Progress.Label2", Translation.CalculatedTimeLeft & Translation.CalculateTimeLeft)
            If (VRD.IsInQuickStreamMode = True) Or (VRD.OutputInProgress = False) Then
                CutTheVideo()
            End If
        End Sub

        Protected Overrides Sub OnPageDestroy(ByVal new_windowId As Integer)
            RemoveHandler VRD.SaveVideoStart, AddressOf SaveVideoProgressStart
            RemoveHandler VRD.SaveVideoProgressCanged, AddressOf SaveVideoProgressChanged
            RemoveHandler VRD.SaveVideoFinished, AddressOf SaveVideoProgressFinish
            RemoveHandler VRD.SaveVideoAborted, AddressOf SaveVideoAborted
            MyBase.OnPageDestroy(new_windowId)
        End Sub

        Public Overrides Sub OnAction(ByVal action As MediaPortal.GUI.Library.Action)
            MyBase.OnAction(action)
        End Sub


        Protected Overrides Sub OnClicked(ByVal controlId As Integer, ByVal control As MediaPortal.GUI.Library.GUIControl, ByVal actionType As MediaPortal.GUI.Library.Action.ActionType)
            isCanceled = False
            If control Is btnCancel Then
                isCanceled = True
                VRD.AbortVideoSaving()
            ElseIf control Is btnExit Then
                isCanceled = False
                PageDestroy()
            End If
            MyBase.OnClicked(controlId, control, actionType)
        End Sub
#End Region

        Public Sub Add1(ByVal pItem As MediaPortal.GUI.Library.GUIListItem) Implements MediaPortal.GUI.Library.IDialogbox.Add

        End Sub

        Public Sub Add1(ByVal strLabel As String) Implements MediaPortal.GUI.Library.IDialogbox.Add

        End Sub

        Public Sub AddLocalizedString(ByVal iLocalizedString As Integer) Implements MediaPortal.GUI.Library.IDialogbox.AddLocalizedString

        End Sub

        Public Sub DoModal1(ByVal dwParentId As Integer) Implements MediaPortal.GUI.Library.IDialogbox.DoModal

        End Sub

        Public Sub Reset1() Implements MediaPortal.GUI.Library.IDialogbox.Reset
            isCanceled = False
        End Sub

        Public ReadOnly Property SelectedId() As Integer Implements MediaPortal.GUI.Library.IDialogbox.SelectedId
            Get
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property SelectedLabel1() As Integer Implements MediaPortal.GUI.Library.IDialogbox.SelectedLabel
            Get

            End Get
        End Property

        Public ReadOnly Property SelectedLabelText() As String Implements MediaPortal.GUI.Library.IDialogbox.SelectedLabelText
            Get
                Return Nothing
            End Get
        End Property

        Public ReadOnly Property Canceled() As Boolean
            Get
                Return isCanceled
            End Get
        End Property


        Public Sub SetHeading(ByVal iString As Integer) Implements MediaPortal.GUI.Library.IDialogbox.SetHeading
            Translator.SetProperty("#SaveCuttedVideo", iString)
        End Sub

        Public Sub SetHeading(ByVal strLine As String) Implements MediaPortal.GUI.Library.IDialogbox.SetHeading
            Translator.SetProperty("#SaveCuttedVideo", strLine)

        End Sub
#Region "SaveVideoSubs"
        Private Sub SaveVideoProgressChanged(ByVal sender As Object, ByVal e As SaveVideoEventArgs)
            MyLog.DebugM("Saving of the file is {0}% complete.", e.PercentageComplete)
            If ctlSavingProgress IsNot Nothing Then
                ctlSavingProgress.Percentage = e.PercentageComplete
                Translator.SetProperty("#Saving.Progress.Label1", Translation.Complete & ": " & Convert.ToInt16(e.PercentageComplete) & " %")
                Translator.SetProperty("#Saving.Progress.Label2", Translation.CalculatedTimeLeft & e.TimeLeft)
            End If
        End Sub
        Private Sub SaveVideoProgressFinish(ByVal sender As Object, ByVal e As SaveVideoEventArgs)
            If ctlSavingProgress IsNot Nothing Then
                ctlSavingProgress.Percentage = 100
                Translator.SetProperty("#Saving.Progress.Label1", Translation.Complete & ": 100 %")
                Translator.SetProperty("#Saving.Progress.Label2", Translation.CalculatedTimeLeft & e.TimeLeft)
            End If
            isCanceled = False
            PageDestroy()
        End Sub
        Private Sub SaveVideoProgressStart(ByVal sender As Object, ByVal e As SaveVideoEventArgs)
            ctlSavingProgress.Percentage = 0
            Translator.SetProperty("#Saving.Progress.Label1", Translation.Complete & ": 0 %")
            Translator.SetProperty("#Saving.Progress.Label2", Translation.CalculatedTimeLeft & Translation.CalculateTimeLeft)
        End Sub
        Private Sub SaveVideoAborted(ByVal sender As Object, ByVal e As SaveVideoEventArgs)
            ctlSavingProgress.Percentage = 0
            Translator.SetProperty("#Saving.Progress.Label1", Translation.Complete & ": 0 %")
            Translator.SetProperty("#Saving.Progress.Label2", Translation.CalculatedTimeLeft & Translation.Abort)
            isCanceled = True
            Do While VRD.OutputInProgress
            Loop
            MyLog.Info("Background thread was aborted.")
            MyLog.DebugM("Deleting incomplete file '{0}' ...", savepath)
            IO.File.Delete(savepath)
            PageDestroy()
        End Sub

        Private tr As Threading.Thread
        Private Sub CutTheVideo()
            tr = New Threading.Thread(AddressOf StartVideoSave)
            tr.IsBackground = True
            tr.Priority = Threading.ThreadPriority.Lowest
            tr.Start()
        End Sub

        Private savepath As String
        Private Sub StartVideoSave()
            savepath = GUIPropertyManager.GetProperty("#Saving.Path") & "\" & GUIPropertyManager.GetProperty("#Saving.Name")
            If VRD.IsInQuickStreamMode Then
                savepath = Replace(AktRecToCut.Filename, ".%ext%", "fixed.%ext%")
            End If
            If IO.Directory.Exists(GUIPropertyManager.GetProperty("#Saving.Path")) = False Then
                ShowNothingFoundDialog(GetID, "The savingpath was incorrect!")
                Exit Sub
            End If
            If Left(VRD.ReDoVersion, 1) = 4 Then
                savepath = Replace(savepath, "%ext%", VRD.GetProfileInfo(VRD.AktSavingProfile).Filetype.ToLower)
            Else
                savepath = Replace(savepath, "%ext%", "mpeg")
            End If
            If IO.Directory.Exists(Mid(savepath, 1, InStrRev(savepath, "\") - 1)) = False Then
                IO.Directory.CreateDirectory(Mid(savepath, 1, InStrRev(savepath, "\") - 1))
            End If
            MyLog.DebugM("Checking for file existance ...")
            If IO.File.Exists(savepath) Then
                MyLog.Info("There is already a file named {0}. Going to add a number...", savepath)

                Dim i As Integer = 1
                Dim fpath As String
                Do
                    fpath = Replace(savepath, ".", i & ".")
                    MyLog.DebugM("Checking file existance '{0}'", fpath)
                    i += 1
                Loop While File.Exists(fpath)
                MyLog.DebugM("The file '{0}' does not exist. Going to use that filename.", fpath)
                savepath = fpath
            Else
                MyLog.Info("The file does not exist. Going to use that filename.")
            End If
            MyLog.Info("The new file will be saved in {0} !", savepath)
            Try
                VRD.StartVideoSave(savepath)
            Catch ex As Threading.ThreadAbortException
                MyLog.Info("Background thread was aborted. {0}", ex.Message)
            End Try
        End Sub
#End Region
    End Class
End Namespace
