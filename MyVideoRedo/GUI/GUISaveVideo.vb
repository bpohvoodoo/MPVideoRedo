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

        Dim dlgPrgrs As GUIDialogProgress
        Private tr As Threading.Thread
        Private isVideoSaving As Boolean = False

#Region "SkinControls"
        <SkinControlAttribute(11)> _
        Protected ctlDirectoryList As GUIListControl = Nothing
        <SkinControlAttribute(12)> _
        Protected ctlStatusLabel As GUILabelControl = Nothing
        <SkinControlAttribute(13)> _
        Protected ctlSavingProgress As GUIProgressControl = Nothing
        <SkinControlAttribute(14)> _
        Protected ctlChangeProfile As GUIButtonControl = Nothing
        <SkinControlAttribute(15)> _
        Protected ctlChangeFilename As GUIButtonControl = Nothing
        <SkinControlAttribute(16)> _
        Protected ctlButtonSave As GUIButtonControl = Nothing
        <SkinControlAttribute(20)> _
        Protected ctlVideoPathLabel As GUIFadeLabel = Nothing
        <SkinControlAttribute(21)> _
        Protected ctlVideoNameLabel As GUIFadeLabel = Nothing
        <SkinControlAttribute(22)> _
Protected ctlCancelButton As GUIButtonControl = Nothing
#End Region


        Public Sub New()

        End Sub


        Public Overloads Overrides Property GetID() As Integer
            Get
                Return 1211
            End Get
            Set(ByVal value As Integer)
            End Set
        End Property

        Public Overloads Overrides Function Init() As Boolean
            'Beim initialisieren des Plugin den Screen laden
            Return Load(GUIGraphicsContext.Skin + "\MyVideoRedoSave.xml")
        End Function

        Public Overrides Function GetModuleName() As String
            Return "MyVideoRedo - SaveVideo"
        End Function

        Protected Overrides Sub OnPageLoad()
            MyBase.OnPageLoad()
            GUIWindowManager.NeedRefresh()

            FillDirectoryListControl(HelpConfig.GetConfigString(ConfigKey.VideoSavePath))
            Translator.SetProperty("#Saving.Path", HelpConfig.GetConfigString(ConfigKey.VideoSavePath))
            Translator.SetProperty("#Saving.Name", AktRecToCut.SavingFilename)
        
            Translator.SetProperty("#Saving.Profile", VRD.AktSavingProfile)

            
            AddHandler VRD.SaveVideoStart, AddressOf SaveVideoProgressStart
            AddHandler VRD.SaveVideoProgressCanged, AddressOf SaveVideoProgressChanged
            AddHandler VRD.SaveVideoFinished, AddressOf SaveVideoProgressFinish
            If VRD.OutputInProgress = True Then
                ctlStatusLabel.Visible = True
            Else
                ctlStatusLabel.Visible = False
            End If


            If VRD.IsInQuickStreamMode Then CutTheVideo()

        End Sub

        Protected Overrides Sub OnPageDestroy(ByVal new_windowId As Integer)
            RemoveHandler VRD.SaveVideoStart, AddressOf SaveVideoProgressStart
            RemoveHandler VRD.SaveVideoProgressCanged, AddressOf SaveVideoProgressChanged
            RemoveHandler VRD.SaveVideoFinished, AddressOf SaveVideoProgressFinish
            'new_windowId = GetGUIWindow(enumWindows.GUIstart)
            MyBase.OnPageDestroy(new_windowId)
            'GUIWindowManager.ActivateWindow(35)
        End Sub

        Public Overrides Sub OnAction(ByVal action As MediaPortal.GUI.Library.Action)
            MyLog.DebugM("OnAction: {0} ::: {1} ::: {2}", action, action.wID.ToString, action.m_key)
            If action.m_key IsNot Nothing Then
               

                If action.wID = MediaPortal.GUI.Library.Action.ActionType.ACTION_SELECT_ITEM Then
                    If ctlDirectoryList.IsFocused Then
                        Translator.SetProperty("#Saving.Path", ctlDirectoryList.SelectedListItem.Path)
                    End If
                End If

            End If
            MyBase.OnAction(action)
        End Sub

        Protected Overrides Sub OnClicked(ByVal controlId As Integer, ByVal control As MediaPortal.GUI.Library.GUIControl, ByVal actionType As MediaPortal.GUI.Library.Action.ActionType)
            If control Is ctlChangeFilename Then
                Dim NewFilename As String = ShowKeyboard(AktRecToCut.SavingFilename)
                If NewFilename IsNot Nothing Then AktRecToCut.SavingFilename = NewFilename
                Translator.SetProperty("#Saving.Name", AktRecToCut.SavingFilename)
            End If

            If control Is ctlChangeProfile Then
                ShowProfileDialog() : Translator.SetProperty("#Saving.Profile", VRD.AktSavingProfile)
            End If

            If control Is ctlDirectoryList And ctlDirectoryList.IsFocused Then
                FillDirectoryListControl(ctlDirectoryList.SelectedListItem.Path)
                'Translator.SetProperty("#SavingPath", ctlDirectoryList.SelectedListItem.Path)
            End If
            If control Is ctlButtonSave Then
                ctlSavingProgress.Percentage = 0
                Translator.SetProperty("#Saving.Progress.Label1", Translation.Complete & " " & 0 & "%")
                Translator.SetProperty("#Saving.Progress.Label2", Translation.CalculatedResttime & "...")

                ctlStatusLabel.Visible = True
                CutTheVideo()
                'ctlButtonSave.Visible = False
            End If
            If control Is ctlCancelButton Then
                VRD.AbortVideoSaving()
                VRD.OutputInProgress = False
                isVideoSaving = False
                ctlStatusLabel.Visible = False
                ctlButtonSave.Visible = True
                Try
                    tr.Abort()
                Catch ex As Threading.ThreadAbortException
                    MyLog.Info("Backgroundtrhread wurde abgebrochen. {0}", ex.Message)
                    isVideoSaving = False
                    GUIWindowManager.ActivateWindow(GetGUIWindow(enumWindows.GUIMain), True)
                End Try
            End If
            MyBase.OnClicked(controlId, control, actionType)
        End Sub


        Private Function FillDirectoryListControl(ByVal path As String) As String
            MyLog.DebugM("Clear DirectoryListControlItems")
            ctlDirectoryList.ListItems.Clear()
            Dim rootInfo As IO.DirectoryInfo

            If path = "Drives" Then
                For Each Drive In IO.DriveInfo.GetDrives()
                    MyLog.DebugM("Setze Menüitem für Ordner '{0}'", Drive)
                    Dim dInfo As New DriveInfo(Drive.Name)
                    If dInfo.IsReady Then
                        Dim nItem As New GUIListItem
                        nItem.FileInfo = New MediaPortal.Util.FileInformation(Drive.Name, True)
                        nItem.IsFolder = True
                        nItem.Label = Drive.Name & " " & Drive.VolumeLabel
                        nItem.Path = Drive.Name
                        nItem.IconImage = "redoHarddisk.png"
                        ctlDirectoryList.Add(nItem)
                    Else
                        MyLog.DebugM("Das Laufwerk {0} ist nicht bereit und wird der Liste nicht hinzugefügt...", Drive.Name)
                    End If
                Next Drive

                GUIWindowManager.Process()
                Return ctlDirectoryList.SelectedListItem.Path
            Else
                rootInfo = New IO.DirectoryInfo(path)

                If rootInfo.Parent IsNot Nothing Then
                    Dim nItemPArent As New GUIListItem
                    nItemPArent.FileInfo = New MediaPortal.Util.FileInformation(path, True)
                    nItemPArent.IsFolder = True
                    nItemPArent.Label = ".." 'Mid(rootInfo.Parent.FullName, InStrRev(rootInfo.Parent.FullName, "\") + 1)
                    nItemPArent.Path = rootInfo.Parent.FullName
                    nItemPArent.IconImage = "redoFolderBack.png"
                    ctlDirectoryList.Add(nItemPArent)
                Else
                    Dim nItemDrive As New GUIListItem
                    nItemDrive.Label = ".."
                    nItemDrive.Path = "Drives"
                    nItemDrive.IconImage = "redoHarddisk.png"
                    ctlDirectoryList.Add(nItemDrive)
                End If


                For Each item As IO.DirectoryInfo In rootInfo.GetDirectories
                    Try
                        MyLog.DebugM("Setze Menüitem für Ordner '{0}'", item.Name)
                        Dim nItem1 As New GUIListItem
                        nItem1.FileInfo = New MediaPortal.Util.FileInformation(path, True)
                        nItem1.IsFolder = True
                        nItem1.Label = item.Name
                        nItem1.Path = item.FullName
                        nItem1.IconImage = "redoFolder.png"
                        ctlDirectoryList.Add(nItem1)
                    Catch ex As System.UnauthorizedAccessException
                        MyLog.Info("Der zugriff auf wurde verweigert Text: {0}", ex.ToString)
                    End Try
                Next
                ctlDirectoryList.SelectedListItemIndex = 0
            End If


        End Function



        Private Sub CutTheVideo()


            tr = New Threading.Thread(AddressOf StartVideoSave)
            tr.IsBackground = True
            tr.Priority = Threading.ThreadPriority.Lowest
            tr.Start()
           
        End Sub


        ''' <summary>
        ''' Bereitet alles zum schneiden des Videos vor
        ''' </summary>
        ''' <remarks></remarks>
        Private Sub StartVideoSave()


            Dim savepath As String = GUIPropertyManager.GetProperty("#Saving.Path") & "\" & AktRecToCut.SavingFilename
            If VRD.IsInQuickStreamMode Then
                savepath = Replace(AktRecToCut.Filename, ".%ext%", "fixed.%ext%")
            End If


            If IO.Directory.Exists(GUIPropertyManager.GetProperty("#Saving.Path")) = False Then
                ShowNothingFoundDialog(GetID, "Speicherpfad war nicht korrekt")
                Exit Sub
            End If

            If Left(VRD.ReDoVersion, 1) = 4 Then
                AktRecToCut.SavingFilename = Replace(savepath, "%ext%", VRD.GetProfileInfo(VRD.AktSavingProfile).DateiType)
                'AktRecToCut.SavingFilename = Replace(AktRecToCut.SavingFilename, ".%ext%", "")
            Else
                AktRecToCut.SavingFilename = Replace(savepath, "%ext%", "mpeg")
            End If

       
            If IO.Directory.Exists(Mid(savepath, 1, InStrRev(savepath, "\") - 1)) = False Then
                IO.Directory.CreateDirectory(Mid(savepath, 1, InStrRev(savepath, "\") - 1))
            End If

            MyLog.DebugM("Prüfe ob Datei bereits vorhanden...")
            If IO.File.Exists(AktRecToCut.SavingFilename) Then
                MyLog.Info("Der Dateiname {0} existiert bereits, es wird eine Zahl angehängt...", savepath)

                Dim i As Integer = 1 : Dim fpath As String
                Do
                    fpath = Replace(AktRecToCut.SavingFilename, ".", i & ".")
                    MyLog.DebugM("Versuche Datei '{0}'", fpath)
                    i += 1
                Loop While File.Exists(fpath)
                MyLog.DebugM("Datei '{0}' existiert noch nicht, Dateiname wird verwendet", fpath)
                AktRecToCut.SavingFilename = fpath
            Else
                MyLog.Info("Der Dateiname ist noch nicht vorhanden und kann verwendet werden.")
            End If

            MyLog.Info("Das neue Video wird unter {0} gespeichert!!", AktRecToCut.SavingFilename)
            Try
                VRD.StartVideoSave(AktRecToCut.SavingFilename)
                ctlStatusLabel.Visible = True
            Catch ex As Threading.ThreadAbortException
                MyLog.Info("Backgroundtrhread wurde abgebrochen. {0}", ex.Message)
            End Try
        End Sub



#Region "SaveVideoSubs"
        Private Sub SaveVideoProgressChanged(ByVal sender As Object, ByVal e As SaveVideoEvenArgs)
            MyLog.DebugM("Speichern des Videos zu {0}% abgeschlossen.", e.PercentageComplete)
            isVideoSaving = True
         
            If ctlSavingProgress IsNot Nothing Then
                ctlSavingProgress.Percentage = e.PercentageComplete
                Translator.SetProperty("#Saving.Progress.Label1", Translation.Complete & " " & Convert.ToInt16(e.PercentageComplete) & "%")
                Translator.SetProperty("#Saving.Progress.Label2", Translation.CalculatedResttime & e.RestZeit)

            End If

        End Sub
        Private Sub SaveVideoProgressFinish(ByVal sender As Object, ByVal e As SaveVideoEvenArgs)
            ctlStatusLabel.Visible = False
            ctlButtonSave.Visible = True
            If ctlSavingProgress IsNot Nothing Then
                ctlSavingProgress.Percentage = 100
                Translator.SetProperty("#Saving.Progress.Label1", Translation.Complete & " " & Convert.ToInt16(e.PercentageComplete))
                Translator.SetProperty("#Saving.Progress.Label2", Translation.CalculatedResttime & e.RestZeit)

            End If


            isVideoSaving = False

            ShowNotifyDialog(GetID, "MyVideoRedo", Translation.Done)

            Dim hWnd As Long
            hWnd = FindWindow(vbNullString, "MediaPortal - MyVideoReDo - SaveVideo")
            SetForegroundWindow(hWnd)

            'Dialog ob man wirklich löschen will
            Dim dlgDelRec As GUIDialogYesNo = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_YES_NO, Integer)), GUIDialogYesNo)
            dlgDelRec.SetHeading(Translation.DeleteOriginalFileTitle)
            dlgDelRec.SetLine(1, Translation.DeleteOriginalFile)
            dlgDelRec.DoModal(GetID)
            MyLog.DebugM("zeige Dialog ob das Originalfile gelöscht werden soll.")
            If dlgDelRec.IsConfirmed Then
                Try
                    'Dialog bestätigt
                    MyLog.DebugM("Dialog wurde vom User bestätigt.")
                    VRD.Close()
                   
                    'Threading.Thread.CurrentThread.Sleep(1000)
                    MyLog.DebugM("Lösche Original-Videofile '{0}' ...", Replace(AktRecToCut.Filename, ".xml", ".ts"))
                    IO.File.Delete(Replace(AktRecToCut.Filename, ".xml", ".ts"))
                    MyLog.DebugM("Original-Videofile erfolgreich gelöscht")
                    MyLog.DebugM("Lösche XML-File der Aufnahme '{0}' ...", AktRecToCut.Filename)
                    IO.File.Delete(AktRecToCut.Filename)
                    MyLog.DebugM("XML-File erfolgreich gelöscht")
                Catch ex As Exception
                    MyLog.Error("Kann Datei nicht löschen. {0}", ex.ToString)
                End Try
            Else
                MyLog.DebugM("User hat den Dialog nicht bestätigt, das Originalfile wird beibehalten.")
            End If
            dlgDelRec.Reset()
            dlgDelRec = Nothing
            ' MyLog.DebugM("Lade voriges Fenster...")
            GUIWindowManager.ActivateWindow(GetGUIWindow(enumWindows.GUIstart), True)

        End Sub
        Private Sub SaveVideoProgressStart(ByVal sender As Object, ByVal e As SaveVideoEvenArgs)
            'ctlStatusLabel.Visible = True
            isVideoSaving = True



            ctlSavingProgress.Percentage = 0
            Translator.SetProperty("#Saving.Progress.Label1", Translation.Complete & " " & 0 & "%")
            Translator.SetProperty("#Saving.Progress.Label2", Translation.CalculatedResttime & e.RestZeit)

        End Sub

        Private Sub ShowProfileDialog()
            Dim dlgProfiles As GUIDialogMenu = CType(GUIWindowManager.GetWindow(CType(GUIWindow.Window.WINDOW_DIALOG_MENU, Integer)), GUIDialogMenu)
            dlgProfiles.Reset()

            For Each item In VRD.GetProfileList
                dlgProfiles.Add(item)
            Next
            dlgProfiles.SetHeading(Translation.SavingProfile)
            dlgProfiles.DoModal(GetID)
            Dim newprofilename As String = "Nothing"
            Do
                If dlgProfiles.SelectedLabel > -1 Then
                    Dim dlgProfileDetail As GUIProfileDetail = CType(GUIWindowManager.GetWindow(1210), GUIProfileDetail)
                    dlgProfileDetail.Reset()
                    dlgProfileDetail.SetHeading(dlgProfiles.SelectedLabelText)
                    dlgProfileDetail.DoModal(GetID)
                    'MsgBox(dlgProfileDetail.SelectedLabelText)
                    newprofilename = dlgProfileDetail.SelectedLabelText
                    dlgProfileDetail = Nothing
                Else
                    Exit Sub
                End If
            Loop While newprofilename = "Nothing"
            VRD.AktSavingProfile = newprofilename

        End Sub
#End Region

        Private Function ShowKeyboard(ByVal Text As String) As String
            Dim keyboard As VirtualKeyboard = DirectCast(GUIWindowManager.GetWindow(CInt(GUIWindow.Window.WINDOW_VIRTUAL_KEYBOARD)), VirtualKeyboard)
            If keyboard Is Nothing Then
                Return Nothing
            End If
            keyboard.Reset()
            'keyboard.Label = Text

            keyboard.SetLabelAsInitialText(True)
            keyboard.DoModal(GetID)
            ' Do something here. The typed value is stored in "keyboard.Text" 
            If keyboard.IsConfirmed Then
                If keyboard.Text.Length < 3 Then Return Text
                Return keyboard.Text
            Else
                Return Nothing
            End If
        End Function

    End Class

End Namespace