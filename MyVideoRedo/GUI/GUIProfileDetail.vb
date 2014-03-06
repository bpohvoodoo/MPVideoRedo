Imports System
Imports MediaPortal.GUI.Library
Imports MediaPortal.Dialogs
Imports MediaPortal.Profile
Imports MediaPortal.Configuration

Namespace MyVideoRedo
    Public Class GUIProfileDetail
        Inherits GUIDialogWindow
        Implements MediaPortal.GUI.Library.IDialogbox

        <SkinControlAttribute(12)> Protected btnExit As GUIButtonControl = Nothing
        <SkinControlAttribute(13)> Protected btnUseIt As GUIButtonControl = Nothing
        <SkinControlAttribute(14)> Protected btnCancel As GUILabelControl = Nothing

        Private DoExit As Boolean = -1
        Private AktProfile As VideoReDo.VRDProfileInfo


#Region "MP EventSubs"
        Public Overloads Overrides Property GetID() As Integer
            Get
                Return 1210
            End Get
            Set(ByVal value As Integer)
            End Set
        End Property

        Public Overloads Overrides Function Init() As Boolean

            Return Load(GUIGraphicsContext.Skin + "\MyVideoRedoProfileDetail.xml")
        End Function



        Protected Overrides Sub OnPageLoad()
            MyBase.OnPageLoad()
            ' If GUIWindowManager.ActiveWindow = 1210 Then
            'Translator.TranslateSkin()
            'Translator.SetProperty("#Profile.Name", "Hallo Du")
            'End If
        End Sub

        Protected Overrides Sub OnPageDestroy(ByVal new_windowId As Integer)
            If GUIWindowManager.ActiveWindow = GetID Then ' My Window

            End If
            MyBase.OnPageDestroy(new_windowId)
        End Sub

        Public Overrides Sub OnAction(ByVal action As MediaPortal.GUI.Library.Action)

            Dim AktWinId As Integer = GUIWindowManager.ActiveWindow

            MyBase.OnAction(action)
        End Sub



        Protected Overrides Sub OnClicked(ByVal controlId As Integer, ByVal control As MediaPortal.GUI.Library.GUIControl, ByVal actionType As MediaPortal.GUI.Library.Action.ActionType)
            If control Is btnUseIt Then
                'VRD.AktSavingProfile = AktProfile.DateiType.ToLower
                GetProfileDetail(AktProfile.Profilename)
                PageDestroy()
            Else
                AktProfile.Profilename = VRD.AktSavingProfile
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

        End Sub

        Public ReadOnly Property SelectedId() As Integer Implements MediaPortal.GUI.Library.IDialogbox.SelectedId
            Get

            End Get
        End Property

        Public ReadOnly Property SelectedLabel1() As Integer Implements MediaPortal.GUI.Library.IDialogbox.SelectedLabel
            Get

            End Get
        End Property

        Public ReadOnly Property SelectedLabelText() As String Implements MediaPortal.GUI.Library.IDialogbox.SelectedLabelText
            Get
                Return AktProfile.Profilename
            End Get
        End Property

        Public Sub SetHeading(ByVal iString As Integer) Implements MediaPortal.GUI.Library.IDialogbox.SetHeading
            Translator.SetProperty("#ProfileTmp.Name", iString)
        End Sub

        Public Sub SetHeading(ByVal strLine As String) Implements MediaPortal.GUI.Library.IDialogbox.SetHeading
            Translator.SetProperty("#ProfileTmp.Name", strLine)
            AktProfile = VRD.GetProfileInfo(strLine)
            AktProfile.Profilename = strLine
            Translator.SetProperty("#ProfileTmp.Encodingtype", AktProfile.Encodingtype)
            Translator.SetProperty("#ProfileTmp.Filetype", AktProfile.DateiType)
            Translator.SetProperty("#ProfileTmp.Resolution", AktProfile.Resolution)
            Translator.SetProperty("#ProfileTmp.Ratio", AktProfile.Ratio)
            Translator.SetProperty("#ProfileTmp.Deinterlacemode", AktProfile.DeintarlaceModus)
            Translator.SetProperty("#ProfileTmp.Framerate", AktProfile.FrameRate)
        End Sub

    End Class
End Namespace
