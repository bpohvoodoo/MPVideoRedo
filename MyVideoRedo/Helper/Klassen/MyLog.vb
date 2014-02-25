Imports MediaPortal.GUI.Library

Public NotInheritable Class MyLog
    Private Sub New()
    End Sub
    Public Shared Sub DebugM(ByVal format As String, ByVal ParamArray arg As Object())

        MediaPortal.GUI.Library.Log.Debug("[MyVideoReDo] :: " & format, arg)
        '#If DEBUG Then
        Debug.WriteLine("Debug: " & Now.ToLongTimeString & "." & Now.Millisecond.ToString & ":" & String.Format(format, arg))
        '#End If
    End Sub

    Public Shared Sub [Error](ByVal ex As Exception)
        MediaPortal.GUI.Library.Log.[Error](ex)
        ShowErrorDialog(GUIWindowManager.ActiveWindow, ex.ToString)
        '#If DEBUG Then
        Debug.WriteLine("Error(!): " & Now.ToLongTimeString & "." & Now.Millisecond.ToString & ":" & ex.ToString)
        '#End If
    End Sub

    Public Shared Sub [Error](ByVal format As String, ByVal ParamArray arg As Object())
        MediaPortal.GUI.Library.Log.[Error]("[MyVideoReDo] :: " & format, arg)
        ShowErrorDialog(GUIWindowManager.ActiveWindow, String.Format(format, arg))

        '#If DEBUG Then
        Debug.WriteLine("Error(!): " & Now.ToLongTimeString & "." & Now.Millisecond.ToString & ":" & String.Format(format, arg))
        '#End If
    End Sub

    Public Shared Sub Info(ByVal format As String, ByVal ParamArray arg As Object())
        MediaPortal.GUI.Library.Log.Info("[MyVideoReDo] :: " & format, arg)
        ' If HelpConfig.GetConfigString(ConfigKey.DebugVideoRedo) Then ShowDebugDialog(GUIWindowManager.ActiveWindow, String.Format(format, arg))

        '#If DEBUG Then
        Debug.WriteLine("Info: " & Now.ToLongTimeString & "." & Now.Millisecond.ToString & ":" & String.Format(format, arg))
        '#End If
    End Sub

    Public Shared Sub Warn(ByVal format As String, ByVal ParamArray arg As Object())
        MediaPortal.GUI.Library.Log.Warn("[MyVideoReDo] :: " & format, arg)
        'If HelpConfig.GetConfigString(ConfigKey.DebugVideoRedo) Then ShowDebugDialog(GUIWindowManager.ActiveWindow, String.Format(format, arg))

        '#If DEBUG Then
        Debug.WriteLine("Warn: " & Now.ToLongTimeString & "." & Now.Millisecond.ToString & ":" & String.Format(format, arg))
        '#End If
    End Sub
End Class
