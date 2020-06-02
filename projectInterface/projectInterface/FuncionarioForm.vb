Imports System.Data.SqlClient

Public Class FuncionarioForm

    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentContact As Integer
    Dim adding As Boolean

    Private Sub TestConnection()
        Dim CN As New SqlConnection("Data Source = localhost; Integrated Security = true;" &
        "Initial Catalog = Northwind;")
        Try
            CN.Open()
            If CN.State = ConnectionState.Open Then
                MsgBox("Successful connection to database " & CN.Database & " on the " & CN.DataSource &
                " server", MsgBoxStyle.OkOnly, "Connection Test")
            End If
        Catch ex As Exception
            MsgBox("FAILED TO OPEN CONNECTION TO DATABASE DUE TO THE FOLLOWING ERROR" & vbCrLf &
            ex.Message, MsgBoxStyle.Critical, "Connection Test")
        End Try
        If CN.State = ConnectionState.Open Then
            CN.Close()
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles buttonAdd.Click

    End Sub

    Private Sub ButtonEdit_Click(sender As Object, e As EventArgs) Handles buttonEdit.Click

    End Sub

    Private Sub ButtonRemove_Click(sender As Object, e As EventArgs) Handles buttonRemove.Click

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged

    End Sub

    Private Sub FuncionarioForm_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub
End Class
