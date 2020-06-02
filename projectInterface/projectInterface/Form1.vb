﻿Imports System.Data.SqlClient

Public Class openingForm
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentSelection As Integer
    Dim adding As Boolean

    Private Sub TestConnection()
        Dim CN As New SqlConnection("Data Source = localhost; Integrated Security = true;" &
        "Initial Catalog = Farmacias;")
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
    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            currentSelection = ListBox1.SelectedIndex
            ShowFarmacia()
        End If
    End Sub

    Private Sub ShowFarmacia()
        If ListBox1.Items.Count = 0 Or currentSelection < 0 Then Exit Sub
        Dim farm As New Farmacia
        farm = CType(ListBox1.Items.Item(currentSelection), Farmacia)
        textNome.Text = farm.Nome
        textEndereco.Text = farm.Endereco
        textNIF.Text = farm.NIF_farmacia
        textTelefone.Text = farm.Telefone
        textAlvara.Text = farm.N_alvara
    End Sub


    Private Sub openingForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        TestConnection()
        CN = New SqlConnection("data source=localhost;integrated security=true;initial catalog=Farmacias")
    End Sub

    Private Sub listFarmacia_Click(sender As Object, e As EventArgs) Handles listFarmacia.Click
        openPanel.Hide()
        ListFarmacias.Show()
        CMD = New SqlCommand
        CMD.Connection = CN

        CMD.CommandText = "SELECT * FROM GestFarm.Farmacia"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox1.Items.Clear()
        While RDR.Read
            Dim F As New Farmacia
            F.Nome = RDR.Item("nome")
            F.Endereco = RDR.Item("endereço")
            F.Telefone = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("telefone")), "", RDR.Item("telefone")))
            F.NIF_farmacia = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nif_farmacia")), "", RDR.Item("nif_farmacia")))
            F.N_alvara = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("n_alvara")), "", RDR.Item("n_alvara")))
            ListBox1.Items.Add(F)
        End While
        CN.Close()
        currentSelection = 0
        ShowFarmacia()
    End Sub
End Class