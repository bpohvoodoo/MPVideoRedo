Imports System
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Windows.Forms.ComponentModel
Imports System.Windows.Forms.Design


Public Class CProgressValueProperty
    Inherits UITypeEditor

    Public Overrides Function GetEditStyle( _
      ByVal context As ITypeDescriptorContext) As UITypeEditorEditStyle
        If Not context Is Nothing AndAlso Not context.Instance Is Nothing Then
            ' Angabe von Stil Modal damit der Dialog aufgerufen wird
            Return UITypeEditorEditStyle.Modal
        End If
        Return UITypeEditorEditStyle.None
    End Function

    Public Overrides Function EditValue( _
      ByVal context As ITypeDescriptorContext, _
      ByVal provider As System.IServiceProvider, _
      ByVal value As [Object]) As [Object]

        ' hier drin aufruf des Formulars und Rückgabe des Wertes.
        Dim dlgValues As New dlgProgressValues
        dlgValues.ValueList = Convert.ToString(value)
        If dlgValues.ShowDialog = DialogResult.OK Then
            Return dlgValues.ValueList
        Else
            Return value
        End If
    End Function
   

End Class
