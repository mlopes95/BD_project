Imports System.Data.SqlClient
Public Class openingForm
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentSelection As Integer
    Dim adding As Boolean

    Private Sub TestConnectionToDB()
        Dim CN As New SqlConnection("Data Source = tcp:mednat.ieeta.pt\SQLSERVER,8101;" &
        "Initial Catalog = p7g6; uid = p7g6; password = 202207059598@Bd")
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

    ''BUTTONS AND LISTBOXES----------------------------------------------------------------------------------------------------------
    '' Farmácias
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex > -1 Then
            currentSelection = ListBox1.SelectedIndex
            ShowFarmacia()
        End If
    End Sub
    Private Sub buttonAdd_Click(sender As Object, e As EventArgs) Handles buttonAdd.Click
        ClearFields()
        UnlockTextFields()
        adding = True
        ListBox1.Enabled = False
        HideButtons()
    End Sub
    Private Sub buttonEdit_Click(sender As Object, e As EventArgs) Handles buttonEdit.Click
        currentSelection = ListBox1.SelectedIndex
        If currentSelection < 0 Then
            MsgBox("Please select a contact to edit")
            Exit Sub
        End If
        UnlockTextFields()
        textNIF.ReadOnly = True
        adding = False
        HideButtons()
        ListBox1.Enabled = False
    End Sub

    Private Sub buttonRemove_Click(sender As Object, e As EventArgs) Handles buttonRemove.Click
        If ListBox1.SelectedIndex > -1 Then
            Try
                RemoveFarmacia(CType(ListBox1.SelectedItem, Farmacia).NIF_farmacia)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
            ListBox1.Items.RemoveAt(ListBox1.SelectedIndex)
            If currentSelection = ListBox1.Items.Count Then currentSelection = ListBox1.Items.Count - 1
            If currentSelection = -1 Then
                ClearFields()
                MsgBox("There are no more contacts")
            Else
                ShowFarmacia()
            End If
        End If
    End Sub

    Private Sub buttonOk_Click(sender As Object, e As EventArgs) Handles buttonOk.Click
        SaveFarmacia()
        Dim idx As Integer = ListBox1.FindString(textNIF.Text)
        ListBox1.SelectedIndex = idx
        ListBox1.Enabled = True
        ShowButtons()
    End Sub

    Private Sub buttonCancel_Click(sender As Object, e As EventArgs) Handles buttonCancel.Click
        ListBox1.Enabled = True
        If ListBox1.Items.Count > 0 Then
            currentSelection = ListBox1.SelectedIndex
            If currentSelection < 0 Then currentSelection = 0
            ShowFarmacia()
        Else
            ClearFields()
            LockTextFields()
        End If
        ShowButtons()
    End Sub

    ''Armazenista
    Private Sub ListBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox2.SelectedIndexChanged
        If ListBox2.SelectedIndex > -1 Then
            currentSelection = ListBox2.SelectedIndex
            ShowArmazenistas()
        End If
    End Sub
    Private Sub buttonAddArm_Click(sender As Object, e As EventArgs) Handles buttonAddArm.Click
        ClearFields()
        UnlockTextFields()
        adding = True
        ListBox2.Enabled = False
        HideButtonsArm()
    End Sub

    Private Sub buttonEditArm_Click(sender As Object, e As EventArgs) Handles buttonEditArm.Click
        currentSelection = ListBox2.SelectedIndex
        If currentSelection < 0 Then
            MsgBox("Por favor selecione um armazenista para editar")
            Exit Sub
        End If
        UnlockTextFields()
        txtArmNIF.ReadOnly = True
        adding = False
        HideButtonsArm()
        ListBox2.Enabled = False
    End Sub
    Private Sub buttonRemoveArm_Click(sender As Object, e As EventArgs) Handles buttonRemoveArm.Click
        If ListBox2.SelectedIndex > -1 Then
            Try
                RemoveArmazenista(CType(ListBox2.SelectedItem, Armazenista).NIF_arm)
            Catch ex As Exception
                MsgBox(ex.Message)
                Exit Sub
            End Try
            ListBox2.Items.RemoveAt(ListBox2.SelectedIndex)
            If currentSelection = ListBox2.Items.Count Then currentSelection = ListBox2.Items.Count - 1
            If currentSelection = -1 Then
                ClearFields()
                MsgBox("Não há mais armazenistas")
            Else
                ShowArmazenistas()
            End If
        End If
    End Sub

    Private Sub buttonOkArm_Click(sender As Object, e As EventArgs) Handles buttonOkArm.Click
        SaveArmazenista()
        Dim idx As Integer = ListBox2.FindString(txtArmNIF.Text)
        ListBox2.SelectedIndex = idx
        ListBox2.Enabled = True
        ShowButtonsArm()
    End Sub

    '' ON LOAD & LISTS-----------------------------------------------------------------------------------------------
    Private Sub openingForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        TestConnection()
        ShowButtons()
        CN = New SqlConnection("data source=localhost;integrated security=true;initial catalog=Farmacias")
    End Sub

    Private Sub listFarmacia_Click(sender As Object, e As EventArgs) Handles listFarmacia.Click
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Show()
        listForn.Hide()
        clientePanel.Hide()
        ShowButtons()
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
        ListBox1.SelectedIndex = currentSelection
        ShowFarmacia()
    End Sub

    Private Sub listArmazenitas_Click(sender As Object, e As EventArgs) Handles listArmazenistas.Click
        openPanel.Hide()
        armPanel.Show()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Hide()
        ShowButtonsArm()
        CMD = New SqlCommand
        CMD.Connection = CN

        CMD.CommandText = "SELECT * FROM GestFarm.Armazenista"
        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox2.Items.Clear()
        While RDR.Read
            Dim A As New Armazenista
            A.Nome = RDR.Item("nome")
            A.Endereço = RDR.Item("endereço")
            A.Telefone = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("telefone")), "", RDR.Item("telefone")))
            A.NIF_arm = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("NIF_arm")), "", RDR.Item("NIF_arm")))
            ListBox2.Items.Add(A)
        End While
        CN.Close()
        currentSelection = 0
        ListBox2.SelectedIndex = currentSelection
        ShowArmazenistas()
    End Sub

    Private Sub listFornecedores_Click(sender As Object, e As EventArgs) Handles listFornecedores.Click
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Hide()
        listForn.Show()
        clientePanel.Hide()
        ShowButtons()
        CMD = New SqlCommand
        CMD.Connection = CN


        Dim nif As New SqlParameter

        nif.ParameterName = "@nif"
        nif.SqlDbType = SqlDbType.Decimal
        nif.Value = textNIF.Text

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nif)

        CMD.CommandText = "SELECT * FROM GestFarm.lista_fornecedores (@nif)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox3.Items.Clear()
        While RDR.Read
            Dim LF As New list_fornecedores
            LF.Nome_farm = RDR.Item("Farmacia")
            LF.Nif__farm = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("NIF_farmacia")), "", RDR.Item("NIF_farmacia")))
            LF.Nome_forn = RDR.Item("Fornecedor")
            LF.Nif_forn = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("NIF_arm")), "", RDR.Item("NIF_arm")))
            ListBox3.Items.Add(LF)
        End While
        CN.Close()
        currentSelection = 0
        ListBox3.SelectedIndex = currentSelection
        ShowLF()
    End Sub

    Private Sub listClientes_Click(sender As Object, e As EventArgs) Handles listClientes.Click
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Show()
        ShowButtons()
        CMD = New SqlCommand
        CMD.Connection = CN


        Dim nif As New SqlParameter

        nif.ParameterName = "@nif"
        nif.SqlDbType = SqlDbType.Decimal
        nif.Value = textNIF.Text

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nif)

        CMD.CommandText = "SELECT * FROM GestFarm.clientes_farmacia (@nif)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox3.Items.Clear()
        While RDR.Read
            Dim LC As New list_clientes
            LC.Nome_farm = RDR.Item("nome_farmacia")
            LC.NIF_farm = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("NIF_farmacia")), "", RDR.Item("NIF_farmacia")))
            LC.Nome_cliente = RDR.Item("nome_cliente")
            LC.NIF_cliente = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nif_cliente")), "", RDR.Item("nif_cliente")))
            LC.Contacto_cliente = RDR.Item("contacto")
            ListBox4.Items.Add(LC)
        End While
        CN.Close()
        currentSelection = 0
        ListBox4.SelectedIndex = currentSelection
        ShowCliente()
    End Sub
    Private Sub buttonListFuncionarios_Click(sender As Object, e As EventArgs) Handles buttonListFuncionarios.Click

    End Sub

    Private Sub orderHistory_Click(sender As Object, e As EventArgs) Handles orderHistory.Click

    End Sub

    Private Sub buttonStockFarm_Click(sender As Object, e As EventArgs) Handles buttonStockFarm.Click

    End Sub

    Private Sub voltarFarm_Click(sender As Object, e As EventArgs) Handles voltarFarm.Click
        openPanel.Show()
        armPanel.Hide()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Hide()
    End Sub
    Private Sub voltarArm_Click(sender As Object, e As EventArgs) Handles voltarArm.Click
        openPanel.Show()
        armPanel.Hide()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Hide()
    End Sub
    Private Sub voltarListForn_Click(sender As Object, e As EventArgs) Handles voltarListForn.Click
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Show()
        listForn.Hide()
        clientePanel.Hide()
    End Sub

    Private Sub voltarCliente_Click(sender As Object, e As EventArgs) Handles voltarCliente.Click
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Show()
        listForn.Hide()
        clientePanel.Hide()
    End Sub

    ' HELPER FUNCTIONS-----------------------------------------------------------------------------------------------------------
    ' FARMÁCIA
    Private Sub ShowFarmacia()
        LockTextFields()
        If ListBox1.Items.Count = 0 Or currentSelection < 0 Then Exit Sub
        Dim farm As New Farmacia
        farm = CType(ListBox1.Items.Item(currentSelection), Farmacia)
        textNome.Text = farm.Nome
        textEndereco.Text = farm.Endereco
        textNIF.Text = farm.NIF_farmacia
        textTelefone.Text = farm.Telefone
        textAlvara.Text = farm.N_alvara
    End Sub

    Private Sub LockTextFields()
        textNome.ReadOnly = True
        textEndereco.ReadOnly = True
        textNIF.ReadOnly = True
        textTelefone.ReadOnly = True
        textAlvara.ReadOnly = True
        txtArmNome.ReadOnly = True
        txtArmEndereço.ReadOnly = True
        txtArmNIF.ReadOnly = True
        txtArmTelefone.ReadOnly = True
        txtFarm.ReadOnly = True
        txtNIFfarm.ReadOnly = True
        txtForn.ReadOnly = True
        txtNIFForn.ReadOnly = True
        txtCFarm.ReadOnly = True
        txtCNIFfarm.ReadOnly = True
        txtNcliente.ReadOnly = True
        txtNIFcliente.ReadOnly = True
        txtContacto.ReadOnly = True
    End Sub

    Private Sub UnlockTextFields()
        textNome.ReadOnly = False
        textEndereco.ReadOnly = False
        textNIF.ReadOnly = False
        textTelefone.ReadOnly = False
        textAlvara.ReadOnly = False
        txtArmNome.ReadOnly = False
        txtArmEndereço.ReadOnly = False
        txtArmNIF.ReadOnly = False
        txtArmTelefone.ReadOnly = False
        txtFarm.ReadOnly = False
        txtNIFfarm.ReadOnly = False
        txtForn.ReadOnly = False
        txtNIFForn.ReadOnly = False
        txtCFarm.ReadOnly = False
        txtCNIFfarm.ReadOnly = False
        txtNcliente.ReadOnly = False
        txtNIFcliente.ReadOnly = False
        txtContacto.ReadOnly = False
    End Sub

    Private Sub ClearFields()
        textNome.Text = ""
        textEndereco.Text = ""
        textNIF.Text = ""
        textTelefone.Text = ""
        textAlvara.Text = ""
        txtArmNome.Text = ""
        txtArmEndereço.Text = ""
        txtArmNIF.Text = ""
        txtArmTelefone.Text = ""
        txtFarm.Text = ""
        txtNIFfarm.Text = ""
        txtForn.Text = ""
        txtNIFForn.Text = ""
        txtCFarm.Text = ""
        txtCNIFfarm.Text = ""
        txtNcliente.Text = ""
        txtNIFcliente.Text = ""
        txtContacto.Text = ""
    End Sub

    Private Sub HideButtons()
        buttonAdd.Visible = False
        buttonEdit.Visible = False
        buttonRemove.Visible = False
        buttonOk.Visible = True
        buttonCancel.Visible = True
    End Sub
    Private Sub ShowButtons()
        buttonAdd.Visible = True
        buttonEdit.Visible = True
        buttonRemove.Visible = True
        buttonOk.Visible = False
        buttonCancel.Visible = False
    End Sub

    Private Sub SaveFarmacia()
        Dim F As New Farmacia
        F.Nome = textNome.Text
        F.Endereco = textEndereco.Text
        F.Telefone = textTelefone.Text
        F.NIF_farmacia = textNIF.Text
        F.N_alvara = textAlvara.Text
        If adding Then
            InsertFarmacia(F)
            ListBox1.Items.Add(F)
        Else
            updateFarmacia(F)
            ListBox1.Items(currentSelection) = F
        End If
    End Sub

    ''ARMAZENISTA
    Private Sub ShowArmazenistas()
        LockTextFields()
        If ListBox2.Items.Count = 0 Or currentSelection < 0 Then Exit Sub
        Dim arm As New Armazenista
        arm = CType(ListBox2.Items.Item(currentSelection), Armazenista)
        txtArmNome.Text = arm.Nome
        txtArmEndereço.Text = arm.Endereço
        txtArmNIF.Text = arm.NIF_arm
        txtArmTelefone.Text = arm.Telefone
    End Sub
    Private Sub HideButtonsArm()
        buttonAddArm.Visible = False
        buttonEditArm.Visible = False
        buttonRemoveArm.Visible = False
        buttonOkArm.Visible = True
        buttonCancelArm.Visible = True
    End Sub
    Private Sub ShowButtonsArm()
        buttonAddArm.Visible = True
        buttonEditArm.Visible = True
        buttonRemoveArm.Visible = True
        buttonOkArm.Visible = False
        buttonCancelArm.Visible = False
    End Sub

    Private Sub SaveArmazenista()
        Dim A As New Armazenista
        A.Nome = txtArmNome.Text
        A.Endereço = txtArmEndereço.Text
        A.Telefone = txtArmTelefone.Text
        A.NIF_arm = txtArmNIF.Text
        If adding Then
            InsertArmazenista(A)
            ListBox2.Items.Add(A)
        Else
            updateArmazenista(A)
            ListBox2.Items(currentSelection) = A
        End If
    End Sub

    ''LISTA DE FORNECEDORES
    Private Sub ListBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox3.SelectedIndexChanged
        currentSelection = ListBox3.SelectedIndex
        ShowLF()
    End Sub
    Private Sub ShowLF()
        LockTextFields()
        If ListBox3.Items.Count = 0 Or currentSelection < 0 Then Exit Sub
        Dim LF As New list_fornecedores
        LF = CType(ListBox3.Items.Item(currentSelection), list_fornecedores)
        txtFarm.Text = LF.Nome_farm
        txtNIFfarm.Text = LF.Nif__farm
        txtForn.Text = LF.Nome_forn
        txtNIFForn.Text = LF.Nif_forn
    End Sub

    ''CLIENTES
    Private Sub ListBox4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox4.SelectedIndexChanged
        currentSelection = ListBox4.SelectedIndex
        ShowCliente()
    End Sub
    Private Sub ShowCliente()
        LockTextFields()
        If ListBox4.Items.Count = 0 Or currentSelection < 0 Then Exit Sub
        Dim LC As New list_clientes
        LC = CType(ListBox4.Items.Item(currentSelection), list_clientes)
        txtCFarm.Text = LC.Nome_farm
        txtCNIFfarm.Text = LC.NIF_farm
        txtNcliente.Text = LC.Nome_cliente
        txtNIFcliente.Text = LC.NIF_cliente
        txtContacto.Text = LC.Contacto_cliente
    End Sub


    '' INSERTS // UPDATES // DELETES-------------------------------------------------------------------------------------------------------
    ''FARMACIAS
    Private Sub InsertFarmacia(ByVal F As Farmacia)
        Dim nome As New SqlParameter
        Dim endereco As New SqlParameter
        Dim telefone As New SqlParameter
        Dim NIF_farmacia As New SqlParameter
        Dim n_alvara As New SqlParameter

        nome.ParameterName = "@nome"
        nome.SqlDbType = SqlDbType.VarChar
        nome.Value = F.Nome

        endereco.ParameterName = "@endereço"
        endereco.SqlDbType = SqlDbType.VarChar
        endereco.Value = F.Endereco

        telefone.ParameterName = "@telefone"
        telefone.SqlDbType = SqlDbType.Decimal
        telefone.Value = F.Telefone

        NIF_farmacia.ParameterName = "@NIF_farmacia"
        NIF_farmacia.SqlDbType = SqlDbType.Decimal
        NIF_farmacia.Value = F.NIF_farmacia

        n_alvara.ParameterName = "@n_alvara"
        n_alvara.SqlDbType = SqlDbType.Int
        n_alvara.Value = F.N_alvara

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nome)
        CMD.Parameters.Add(endereco)
        CMD.Parameters.Add(telefone)
        CMD.Parameters.Add(NIF_farmacia)
        CMD.Parameters.Add(n_alvara)
        CMD.CommandText =
                           "EXEC GestFarm.p_InsertFarmacia @nome, @endereço, @telefone, @NIF_farmacia, @n_alvara"

        CN.Open()

        CMD.ExecuteNonQuery()

        CN.Close()
    End Sub

    Private Sub updateFarmacia(ByVal F As Farmacia)
        Dim nome As New SqlParameter
        Dim endereco As New SqlParameter
        Dim telefone As New SqlParameter
        Dim NIF_farmacia As New SqlParameter
        Dim n_alvara As New SqlParameter

        nome.ParameterName = "@nome"
        nome.SqlDbType = SqlDbType.VarChar
        nome.Value = F.Nome

        endereco.ParameterName = "@endereço"
        endereco.SqlDbType = SqlDbType.VarChar
        endereco.Value = F.Endereco

        telefone.ParameterName = "@telefone"
        telefone.SqlDbType = SqlDbType.Decimal
        telefone.Value = F.Telefone

        NIF_farmacia.ParameterName = "@NIF_farmacia"
        NIF_farmacia.SqlDbType = SqlDbType.Decimal
        NIF_farmacia.Value = F.NIF_farmacia

        n_alvara.ParameterName = "@n_alvara"
        n_alvara.SqlDbType = SqlDbType.Int
        n_alvara.Value = F.N_alvara

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nome)
        CMD.Parameters.Add(endereco)
        CMD.Parameters.Add(telefone)
        CMD.Parameters.Add(NIF_farmacia)
        CMD.Parameters.Add(n_alvara)
        CMD.CommandText =
                           "EXEC GestFarm.p_UpdateFarmacia @nome, @endereço, @telefone, @NIF_farmacia, @n_alvara"

        CN.Open()

        CMD.ExecuteNonQuery()

        CN.Close()
    End Sub

    Private Sub RemoveFarmacia(ByVal NIF As String)
        Dim NIF_farmacia As New SqlParameter
        NIF_farmacia.ParameterName = "@NIF_farmacia"
        NIF_farmacia.SqlDbType = SqlDbType.Decimal
        NIF_farmacia.Value = NIF

        CMD.Parameters.Clear()
        CMD.Parameters.Add(NIF_farmacia)
        CMD.CommandText = "EXEC GestFarm.p_DeleteFarmacia @NIF_farmacia "

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to delete contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub

    ''ARMAZENISTAS
    Private Sub InsertArmazenista(ByVal A As Armazenista)
        Dim nome As New SqlParameter
        Dim endereco As New SqlParameter
        Dim telefone As New SqlParameter
        Dim NIF_arm As New SqlParameter

        nome.ParameterName = "@nome"
        nome.SqlDbType = SqlDbType.VarChar
        nome.Value = A.Nome

        endereco.ParameterName = "@endereço"
        endereco.SqlDbType = SqlDbType.VarChar
        endereco.Value = A.Endereço

        telefone.ParameterName = "@telefone"
        telefone.SqlDbType = SqlDbType.Decimal
        telefone.Value = A.Telefone

        NIF_arm.ParameterName = "@NIF_arm"
        NIF_arm.SqlDbType = SqlDbType.Decimal
        NIF_arm.Value = A.NIF_arm

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nome)
        CMD.Parameters.Add(endereco)
        CMD.Parameters.Add(telefone)
        CMD.Parameters.Add(NIF_arm)
        CMD.CommandText =
                           "EXEC GestFarm.p_InsertArmazenista @nome, @NIF_arm, @telefone, @endereço"

        CN.Open()

        CMD.ExecuteNonQuery()

        CN.Close()
    End Sub

    Private Sub updateArmazenista(ByVal A As Armazenista)
        Dim nome As New SqlParameter
        Dim endereco As New SqlParameter
        Dim telefone As New SqlParameter
        Dim NIF_arm As New SqlParameter

        nome.ParameterName = "@nome"
        nome.SqlDbType = SqlDbType.VarChar
        nome.Value = A.Nome

        endereco.ParameterName = "@endereço"
        endereco.SqlDbType = SqlDbType.VarChar
        endereco.Value = A.Endereço

        telefone.ParameterName = "@telefone"
        telefone.SqlDbType = SqlDbType.Decimal
        telefone.Value = A.Telefone

        NIF_arm.ParameterName = "@NIF_arm"
        NIF_arm.SqlDbType = SqlDbType.Decimal
        NIF_arm.Value = A.NIF_arm

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nome)
        CMD.Parameters.Add(endereco)
        CMD.Parameters.Add(telefone)
        CMD.Parameters.Add(NIF_arm)
        CMD.CommandText =
                           "EXEC GestFarm.p_UpdateArmazenista @nome, @NIF_arm, @telefone, @endereço"

        CN.Open()

        CMD.ExecuteNonQuery()

        CN.Close()
    End Sub

    Private Sub RemoveArmazenista(ByVal NIF As String)
        Dim NIF_farmacia As New SqlParameter
        NIF_farmacia.ParameterName = "@NIF_arm"
        NIF_farmacia.SqlDbType = SqlDbType.Decimal
        NIF_farmacia.Value = NIF

        CMD.Parameters.Clear()
        CMD.Parameters.Add(NIF_farmacia)
        CMD.CommandText = "EXEC GestFarm.p_DeleteArmazenista @NIF_arm "

        CN.Open()
        Try
            CMD.ExecuteNonQuery()
        Catch ex As Exception
            Throw New Exception("Failed to delete contact in database. " & vbCrLf & "ERROR MESSAGE: " & vbCrLf & ex.Message)
        Finally
            CN.Close()
        End Try
    End Sub
End Class
