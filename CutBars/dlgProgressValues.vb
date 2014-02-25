Imports System.Windows.Forms

Public Class dlgProgressValues
    Private m_Valuelist As String
    Public Property ValueList() As String
        Get
            Return m_Valuelist
        End Get
        Set(ByVal value As String)
            m_Valuelist = value
        End Set
    End Property

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        If Me.ListBox1.Items.Count <> Me.ListBox2.Items.Count Then
            With Me.ErrorProvider1
                .SetIconAlignment(Me.OK_Button, ErrorIconAlignment.MiddleLeft)
                .SetIconPadding(Me.OK_Button, 10)
                .SetError(Me.OK_Button, "Die Anzahl der Werte muss in beiden Listen gleich sein!!" & vbNewLine & "Es muss also für jeden StartValue auch einen EndValue geben bzw. umgekehrt")
            End With
            Exit Sub
        End If
        Me.ErrorProvider1.Clear()
        ValueList = ""
        For i As Integer = 0 To Me.ListBox1.Items.Count - 1
            ValueList += Me.ListBox1.Items(i) & ";"
            ValueList += Me.ListBox2.Items(i) & ";"
        Next
        If Strings.Left(Me.ValueList, 1) = ";" Then
            ValueList = Mid(ValueList, 1, ValueList.Length - 1)
        End If
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub



    Private Sub dlgProgressValues_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ListBox1.Items.Clear()
        Try
            Dim VL As String() = Me.ValueList.Split(";")
            For i As Integer = 0 To VL.Count - 1
                If i Mod 2 = 0 Then
                    If VL(i).Length > 0 Then Me.ListBox1.Items.Add(VL(i))
                Else
                    If VL(i).Length > 0 Then Me.ListBox2.Items.Add(VL(i))
                End If
            Next
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        Try
            Dim nV As Single = Me.TextBox1.Text
            Me.ErrorProvider1.Clear()
        Catch ex As Exception
            With Me.ErrorProvider1
                .SetIconAlignment(Me.TextBox1, ErrorIconAlignment.MiddleRight)
                .SetIconPadding(Me.TextBox1, 10)
                .SetError(Me.TextBox1, "Falsche Eingabe; Eingabe muss vom Type Single sein.")
            End With
        End Try
    End Sub

    Private Sub TextBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox2.KeyUp
        Try
            Dim nV As Single = Me.TextBox2.Text
            'Me.ListBox1.Items.Add(nV)
            Me.ErrorProvider1.Clear()

        Catch ex As Exception
            With Me.ErrorProvider1
                .SetIconAlignment(Me.TextBox2, ErrorIconAlignment.MiddleRight)
                .SetIconPadding(Me.TextBox2, 10)
                .SetError(Me.TextBox2, "Falsche Eingabe; Eingabe muss vom Type Single sein.")
            End With
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim nV As Single = Me.TextBox1.Text
            Me.ListBox1.Items.Add(Me.TextBox1.Text)
            Me.TextBox1.Text = ""
            Me.TextBox1.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim nV As Single = Me.TextBox2.Text
            Me.ListBox2.Items.Add(Me.TextBox2.Text)
            Me.TextBox2.Text = ""
            Me.TextBox2.Focus()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub EintragLöschenSyncronToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EintragLöschenSyncronToolStripMenuItem.Click
        Me.ListBox1.Items.Remove(Me.ListBox1.SelectedItem)
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Me.ListBox2.Items.Remove(Me.ListBox2.SelectedItem)
    End Sub

End Class
