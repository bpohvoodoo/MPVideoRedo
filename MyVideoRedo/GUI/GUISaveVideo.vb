Imports System
Imports MediaPortal.GUI.Library
Imports MediaPortal.Dialogs
Imports MediaPortal.Player
Imports MediaPortal.Profile
Imports MediaPortal.Configuration
Imports System.IO

Namespace MyVideoRedo

    Public Class GUISaveVideo
        Inherits GUIWindow


#Region "SkinControls"
        <SkinControlAttribute(11)> Protected ctlDirectoryList As GUIListControl = Nothing
        <SkinControlAttribute(14)> Protected ctlChangeProfile As GUIButtonControl = Nothing
        <SkinControlAttribute(15)> Protected ctlChangeFilename As GUIButtonControl = Nothing
        <SkinControlAttribute(16)> Protected ctlButtonSave As GUIButtonControl = Nothing
        <SkinControlAttribute(20)> Protected ctlVideoPathLabel As GUIFadeLabel = Nothing
        <SkinControlAttribute(21)> Protected ctlVideoNameLabel As GUIFadeLabel = Nothing
#End Region
        Public Overloads Overrides Property GetID() As Integer
            Get
                Return enumWindows.GUISave
            End Get
            Set(ByVal value As Integer)
            End Set
        End Property

        Public Overloads Overrides Function Init() As Boolean
            'Beim initialisieren des Plugin den Screen laden
            Return Load(GUIGraphicsContext.Skin + "\MyVideoRedoSave.xml")
        End Function

        Public Overrides Function GetModuleName() As String
            Return HelpConfig.GetConfigString(ConfigKey.ModuleName) & " - " & Translation.ModuleSaveVideo
        End Function

        Protected Overrides Sub OnPageLoad()
            MyBase.OnPageLoad()
            GUIWindowManager.NeedRefresh()
            FillDirectoryListControl(HelpConfig.GetConfigString(ConfigKey.VideoSavePath))
            Translator.SetProperty("#Saving.Path", HelpConfig.GetConfigString(ConfigKey.VideoSavePath))
            Translator.SetProperty("#Saving.Profile", VRD.AktSavingProfile)
            If VRD.OutputInProgress = True Then
                ctlButtonSave.Visible = False
                If GUIWindowManager.GetPreviousActiveWindow <> enumWindows.GUISave Then
                    ShowSavingDialog()
                End If
            Else
                ctlButtonSave.Visible = True
            End If
            If VRD.IsInQuickStreamMode Then ShowSavingDialog()
        End Sub

        Protected Overrides Sub OnPageDestroy(ByVal new_windowId As Integer)
            'new_windowId = GetGUIWindow(enumWindows.GUIstart)
            MyBase.OnPageDestroy(new_windowId)
            'GUIWindowManager.ActivateWindow(35)
        End Sub

        Public Overrides Sub OnAction(ByVal action As MediaPortal.GUI.Library.Action)
            MyBase.OnAction(action)
        End Sub

        Protected Overrides Sub OnClicked(ByVal controlId As Integer, ByVal control As MediaPortal.GUI.Library.GUIControl, ByVal actionType As MediaPortal.GUI.Library.Action.ActionType)
            If control Is ctlChangeFilename Then
                Dim SavingFilename As String
                If Left(VRD.ReDoVersion, 1) = 4 Then
                    SavingFilename = Replace(AktRecToCut.SavingFilename, "%ext%", VRD.GetProfileInfo(VRD.AktSavingProfile).Filetype.ToLower)
                Else
                    SavingFilename = Replace(AktRecToCut.SavingFilename, "%ext%", "mpeg")
                End If
                Dim NewFilename As String = ShowKeyboard(SavingFilename, GetID)
                If NewFilename IsNot Nothing Then
                    Translator.SetProperty("#Saving.Name", NewFilename)
                End If
            End If

            If control Is ctlChangeProfile Then
                ShowProfileDialog(GetID)
            End If

            If control Is ctlDirectoryList Then 'And ctlDirectoryList.IsFocused Then
                Translator.SetProperty("#Saving.Path", ctlDirectoryList.SelectedListItem.Path)
                FillDirectoryListControl(ctlDirectoryList.SelectedListItem.Path)
            End If

            If control Is ctlButtonSave Then
                GUIButtonControl.DisableControl(GetID, Me.ctlButtonSave.GetID)
                ShowSavingDialog()
            End If
            MyBase.OnClicked(controlId, control, actionType)
        End Sub


        Private Function FillDirectoryListControl(ByVal path As String) As String
            MyLog.DebugM("Clear DirectoryListControlItems")
            ctlDirectoryList.ListItems.Clear()
            Dim rootInfo As IO.DirectoryInfo
            Dim itemcount As Integer
            itemcount = 0
            If path = "Drives" Then
                For Each Drive In IO.DriveInfo.GetDrives()
                    MyLog.DebugM("Set Menüitem für Ordner '{0}'", Drive)
                    Dim dInfo As New DriveInfo(Drive.Name)
                    If dInfo.IsReady Then
                        Dim nItem As New GUIListItem
                        nItem.FileInfo = New MediaPortal.Util.FileInformation(Drive.Name, True)
                        nItem.IsFolder = True
                        nItem.Label = Drive.Name & " " & Drive.VolumeLabel
                        nItem.Path = Drive.Name
                        If dInfo.DriveType = 5 Then
                            nItem.IconImage = "defaultDVDRom.png"
                        ElseIf dInfo.DriveType = 4 Then
                            nItem.IconImage = "defaultNetwork.png"
                        ElseIf dInfo.DriveType = 3 Then
                            nItem.IconImage = "defaultHarddisk.png"
                        Else
                            nItem.IconImage = "defaultHarddisk.png"
                        End If
                        nItem.ThumbnailImage = nItem.IconImage
                        ctlDirectoryList.Add(nItem)
                        itemcount = itemcount + 1
                    Else
                        MyLog.DebugM("Das Laufwerk {0} ist nicht bereit und wird der Liste nicht hinzugefügt...", Drive.Name)
                    End If
                Next Drive
                GUIWindowManager.Process()
                GUIPropertyManager.SetProperty("#itemcount", itemcount)
            Else
                rootInfo = New IO.DirectoryInfo(path)

                If rootInfo.Parent IsNot Nothing Then
                    Dim nItemPArent As New GUIListItem
                    nItemPArent.FileInfo = New MediaPortal.Util.FileInformation(path, True)
                    nItemPArent.IsFolder = True
                    nItemPArent.Label = ".." 'Mid(rootInfo.Parent.FullName, InStrRev(rootInfo.Parent.FullName, "\") + 1)
                    nItemPArent.Path = rootInfo.Parent.FullName
                    nItemPArent.IconImage = "defaultFolderBack.png"
                    ctlDirectoryList.Add(nItemPArent)
                Else
                    Dim nItemDrive As New GUIListItem
                    nItemDrive.Label = ".."
                    nItemDrive.Path = "Drives"
                    nItemDrive.IconImage = "defaultFolderBack.png"
                    ctlDirectoryList.Add(nItemDrive)
                End If

                For Each item As IO.DirectoryInfo In rootInfo.GetDirectories
                    Try
                        MyLog.DebugM("Set Menüitem für Ordner '{0}'", item.Name)
                        Dim nItem1 As New GUIListItem
                        nItem1.FileInfo = New MediaPortal.Util.FileInformation(path, True)
                        nItem1.IsFolder = True
                        nItem1.Label = item.Name
                        nItem1.Path = item.FullName
                        nItem1.IconImage = "defaultFolder.png"
                        nItem1.ThumbnailImage = nItem1.IconImage
                        ctlDirectoryList.Add(nItem1)
                        itemcount = itemcount + 1
                    Catch ex As System.UnauthorizedAccessException
                        MyLog.Info("Der zugriff auf wurde verweigert Text: {0}", ex.ToString)
                        Return Nothing
                    End Try
                Next
                ctlDirectoryList.SelectedListItemIndex = 0
            End If
            GUIPropertyManager.SetProperty("#itemcount", itemcount)
            Return ctlDirectoryList.SelectedListItem.Path
        End Function

        Private Sub ShowSavingDialog()
            Dim dlgSavingProgress As GUISaveProgress = CType(GUIWindowManager.GetWindow(enumWindows.GUISaveProgress), GUISaveProgress)
            dlgSavingProgress.Reset()
            dlgSavingProgress.SetHeading(Translation.SaveCuttedVideo)
            dlgSavingProgress.DoModal(GetID)
            If (dlgSavingProgress.Canceled = False) And (VRD.OutputInProgress = False) Then
                ShowNotifyDialog(GetID, Translation.ModuleSaveVideo, Translation.Done)
                If HelpConfig.GetConfigString(ConfigKey.AlwaysKeepOriginalFile) = False Then
                    MyLog.DebugM("Showing dialog to choose to delete the original file.")
                    If ShowYesNoDialog(GetID, Translation.DeleteOriginalFileTitle, Translation.DeleteOriginalFile) = True Then
                        Try
                            'Dialog acknowledged
                            MyLog.DebugM("Dialog wurde vom User bestätigt.")
                            VRD.Close()
                            MyLog.DebugM("Lösche Original-Videofile '{0}' ...", AktRecToCut.VideoFilename)
                            IO.File.Delete(AktRecToCut.VideoFilename)
                            MyLog.DebugM("Original-Videofile erfolgreich gelöscht")
                            MyLog.DebugM("Lösche XML-File der Aufnahme '{0}' ...", AktRecToCut.Filename)
                            IO.File.Delete(AktRecToCut.Filename)
                            'TODO
                            'delete from database
                            MyLog.DebugM("XML-File erfolgreich gelöscht")
                        Catch ex As Exception
                            MyLog.Error("Kann Datei nicht löschen. {0}", ex.ToString)
                        End Try
                    Else
                        MyLog.DebugM("User hat den Dialog nicht bestätigt, das Originalfile wird beibehalten.")
                    End If
                End If
                GUIWindowManager.ActivateWindow(GetGUIWindow(enumWindows.GUIstart), True)
                Exit Sub
            ElseIf (dlgSavingProgress.Canceled = False) And (VRD.OutputInProgress = True) Then
                ShowNotifyDialog(GetID, Translation.ModuleSaveVideo, Translation.BackgroundSave)
                'GUIWindowManager.ActivateWindow(GetGUIWindow(enumWindows.GUIstart), True)
                'GUIWindowManager.CloseCurrentWindow()
                Exit Sub
            ElseIf (dlgSavingProgress.Canceled = True) Then
                ShowNotifyDialog(GetID, Translation.ModuleSaveVideo, Translation.Abort)
                GUIButtonControl.EnableControl(GetID, Me.ctlButtonSave.GetID)
                GUIWindowManager.NeedRefresh()
            End If
            SetMPtoForeground(HelpConfig.GetConfigString(ConfigKey.ModuleName) & " - " & Translation.ModuleSaveVideo)
        End Sub
    End Class
End Namespace