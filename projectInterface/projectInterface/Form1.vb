Imports System.Data.SqlClient
Public Class openingForm
    Dim CN As SqlConnection
    Dim CMD As SqlCommand
    Dim currentSelection As Integer
    Dim adding As Boolean
    Dim flagNome As Boolean
    Dim flagArmNome As Boolean

    Private Sub TestConnection()
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
        CN = New SqlConnection("Data Source = tcp:mednat.ieeta.pt\SQLSERVER,8101;" &
        "Initial Catalog = p7g6; uid = p7g6; password = 202207059598@Bd")
    End Sub

    Private Sub listFarmacia_Click(sender As Object, e As EventArgs) Handles listFarmacia.Click
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Show()
        listForn.Hide()
        clientePanel.Hide()
        funcPanel.Hide()
        orderHistPanel.Hide()
        stockFarmPanel.Hide()
        listStockArmPanel.Hide()
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
        ShowFarmacia()
    End Sub

    Private Sub listArmazenitas_Click(sender As Object, e As EventArgs) Handles listArmazenistas.Click
        openPanel.Hide()
        armPanel.Show()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Hide()
        funcPanel.Hide()
        orderHistPanel.Hide()
        stockFarmPanel.Hide()
        listStockArmPanel.Hide()
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
        ShowArmazenistas()
    End Sub

    Private Sub listFornecedores_Click(sender As Object, e As EventArgs) Handles listFornecedores.Click
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Hide()
        listForn.Show()
        clientePanel.Hide()
        funcPanel.Hide()
        orderHistPanel.Hide()
        stockFarmPanel.Hide()
        listStockArmPanel.Hide()
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
        ShowLF()
    End Sub

    Private Sub listClientes_Click(sender As Object, e As EventArgs) Handles listClientes.Click
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Show()
        funcPanel.Hide()
        orderHistPanel.Hide()
        stockFarmPanel.Hide()
        listStockArmPanel.Hide()
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
        ListBox4.Items.Clear()
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
        ShowCliente()
    End Sub

    Private Sub buttonListFuncionarios_Click(sender As Object, e As EventArgs) Handles buttonListFuncionarios.Click
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Hide()
        funcPanel.Show()
        orderHistPanel.Hide()
        stockFarmPanel.Hide()
        listStockArmPanel.Hide()
        ShowButtons()
        CMD = New SqlCommand
        CMD.Connection = CN


        Dim nif As New SqlParameter

        nif.ParameterName = "@nif"
        nif.SqlDbType = SqlDbType.Decimal
        nif.Value = textNIF.Text

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nif)

        CMD.CommandText = "SELECT * FROM GestFarm.lista_funcionarios (@nif)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox5.Items.Clear()
        While RDR.Read
            Dim LF As New list_funcionarios
            LF.Farmacia = RDR.Item("Farmacia")
            LF.Id = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ID")), "", RDR.Item("ID")))
            LF.Nome = RDR.Item("Nome")
            ListBox5.Items.Add(LF)
        End While
        CN.Close()
        currentSelection = 0
        ShowFuncionario()
    End Sub

    Private Sub orderHistory_Click(sender As Object, e As EventArgs) Handles orderHistory.Click
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Hide()
        funcPanel.Hide()
        orderHistPanel.Show()
        stockFarmPanel.Hide()
        listStockArmPanel.Hide()
        ShowButtons()
        CMD = New SqlCommand
        CMD.Connection = CN


        Dim nif As New SqlParameter

        nif.ParameterName = "@nif"
        nif.SqlDbType = SqlDbType.Decimal
        nif.Value = textNIF.Text

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nif)

        CMD.CommandText = "SELECT * FROM GestFarm.historico_encomendas (@nif)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox6.Items.Clear()
        While RDR.Read
            Dim OH As New list_OrderHist
            OH.Nome = RDR.Item("Nome")
            OH.N_encomenda = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("N_Encomenda")), "", RDR.Item("N_Encomenda")))
            OH.Data_criacao = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Data_criacao")), "", RDR.Item("Data_criacao")))
            OH.Data_proc = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("Data_processamento")), "", RDR.Item("Data_processamento")))
            OH.Arm = RDR.Item("Armazenista")
            ListBox6.Items.Add(OH)
        End While
        CN.Close()
        currentSelection = 0
        ShowHistorico()
    End Sub

    Private Sub buttonShow_Click(sender As Object, e As EventArgs) Handles buttonShow.Click
        CMD = New SqlCommand
        CMD.Connection = CN

        Dim nif As New SqlParameter

        nif.ParameterName = "@nr_encomenda"
        nif.SqlDbType = SqlDbType.Decimal
        nif.Value = txtNrEncomenda.Text

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nif)

        CMD.CommandText = "SELECT * FROM GestFarm.produtos_numa_encomenda (@nr_encomenda)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox7.Items.Clear()
        While RDR.Read
            Dim LOF As New list_Order_Farmaco
            LOF.Nome_farmaco = RDR.Item("nome_farmaco")
            LOF.Nr_encomenda = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nr_enc")), "", RDR.Item("nr_enc")))
            LOF.Ref = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ref")), "", RDR.Item("ref")))
            LOF.P_activo = RDR.Item("p_ativo")
            ListBox7.Items.Add(LOF)
        End While
        CN.Close()
        currentSelection = 0
        ShowConteudo()
    End Sub

    Private Sub buttonStockFarm_Click(sender As Object, e As EventArgs) Handles buttonStockFarm.Click
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Hide()
        funcPanel.Hide()
        orderHistPanel.Hide()
        stockFarmPanel.Show()
        listStockArmPanel.Hide()
        ShowButtons()
        CMD = New SqlCommand
        CMD.Connection = CN


        Dim nif As New SqlParameter

        nif.ParameterName = "@nif"
        nif.SqlDbType = SqlDbType.Decimal
        nif.Value = textNIF.Text

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nif)

        CMD.CommandText = "SELECT * FROM GestFarm.stock_farmacia (@nif)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox8.Items.Clear()
        While RDR.Read
            Dim SF As New list_stock_farmacia
            SF.Nome = RDR.Item("nome")
            SF.NIF_farmacia = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("NIF_Farmacia")), "", RDR.Item("NIF_Farmacia")))
            SF.Ref_farmaco = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ref_farmaco")), "", RDR.Item("ref_farmaco")))
            SF.Nome_farmaco = RDR.Item("nome_farmaco")
            SF.Quantidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("quantidade")), "", RDR.Item("quantidade")))
            ListBox8.Items.Add(SF)
        End While
        CN.Close()
        currentSelection = 0
        ShowStockFarm()
    End Sub

    Private Sub searchNome_Click(sender As Object, e As EventArgs) Handles searchNome.Click
        CMD = New SqlCommand
        CMD.Connection = CN
        flagNome = True
        Dim nome As New SqlParameter
        Dim nif As New SqlParameter

        nome.ParameterName = "@nome"
        nome.SqlDbType = SqlDbType.VarChar
        nome.Value = txtSearchNome.Text


        nif.ParameterName = "@nif"
        nif.SqlDbType = SqlDbType.Decimal
        nif.Value = txtNIFStockFarm.Text

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nome)
        CMD.Parameters.Add(nif)

        CMD.CommandText = "SELECT * FROM GestFarm.farmaco_por_nome (@nome, @nif)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox9.Items.Clear()
        While RDR.Read
            Dim SN As New search_name
            SN.Nome_farmaco = RDR.Item("nome_farmaco")
            SN.Nome_farmacia = RDR.Item("nome_farmacia")
            SN.Ref = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ref")), "", RDR.Item("ref")))
            SN.Quantidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("quantidade")), "", RDR.Item("quantidade")))
            ListBox9.Items.Add(SN)
        End While
        CN.Close()
        currentSelection = 0
        ShowSearch()
    End Sub

    Private Sub searchPA_Click(sender As Object, e As EventArgs) Handles searchPA.Click
        CMD = New SqlCommand
        CMD.Connection = CN
        flagNome = True
        Dim nome As New SqlParameter
        Dim nif As New SqlParameter

        nome.ParameterName = "@nome"
        nome.SqlDbType = SqlDbType.VarChar
        nome.Value = txtSearchNome.Text


        nif.ParameterName = "@nif"
        nif.SqlDbType = SqlDbType.Decimal
        nif.Value = txtNIFStockFarm.Text

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nome)
        CMD.Parameters.Add(nif)

        CMD.CommandText = "SELECT * FROM GestFarm.lista_farmacos_p_ativo (@nome, @nif)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox9.Items.Clear()
        While RDR.Read
            Dim SPA As New searchPA
            SPA.Nome_farmaco = RDR.Item("nome_farmaco")
            SPA.Nome_farmacia = RDR.Item("nome_farmacia")
            SPA.P_activo = RDR.Item("p_ativo")
            SPA.Ref = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ref")), "", RDR.Item("ref")))
            SPA.Nif_farmacia = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nif_farmacia")), "", RDR.Item("nif_farmacia")))
            SPA.Quantidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("quantidade")), "", RDR.Item("quantidade")))
            ListBox9.Items.Add(SPA)
        End While
        CN.Close()
        currentSelection = 0
        ListBox9.SelectedIndex = currentSelection
        ShowSearch()
    End Sub

    Private Sub listStockArm_Click(sender As Object, e As EventArgs) Handles listStockArm.Click
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Hide()
        funcPanel.Hide()
        orderHistPanel.Hide()
        stockFarmPanel.Hide()
        listStockArmPanel.Show()
        ShowButtons()
        CMD = New SqlCommand
        CMD.Connection = CN


        Dim nif As New SqlParameter

        nif.ParameterName = "@nif"
        nif.SqlDbType = SqlDbType.Decimal
        nif.Value = txtArmNIF.Text

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nif)

        CMD.CommandText = "SELECT * FROM GestFarm.stock_armazenistas (@nif)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox11.Items.Clear()
        While RDR.Read
            Dim SA As New listStockArm
            SA.Nome_Arm = RDR.Item("nome_armazenista")
            SA.NIF_arm = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("nif_arm")), "", RDR.Item("nif_arm")))
            SA.Ref_farm = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ref_farmaco")), "", RDR.Item("ref_farmaco")))
            SA.Nome_farm = RDR.Item("nome_farmaco")
            SA.Quantidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("quantidade")), "", RDR.Item("quantidade")))
            ListBox11.Items.Add(SA)
        End While
        CN.Close()
        currentSelection = 0
        ShowStockArm()
    End Sub

    Private Sub searchArmName_Click(sender As Object, e As EventArgs) Handles searchArmName.Click
        CMD = New SqlCommand
        CMD.Connection = CN
        flagArmNome = True
        Dim nome As New SqlParameter
        Dim nif As New SqlParameter

        nome.ParameterName = "@nome_farmaco"
        nome.SqlDbType = SqlDbType.VarChar
        nome.Value = txtSearchArmName.Text


        nif.ParameterName = "@nif"
        nif.SqlDbType = SqlDbType.Decimal
        nif.Value = txtArmNIF.Text

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nome)
        CMD.Parameters.Add(nif)

        CMD.CommandText = "SELECT * FROM GestFarm.stock_armazenistas_farmaco (@nome_farmaco, @nif)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox10.Items.Clear()
        While RDR.Read
            Dim SAN As New searchStockArmName
            SAN.Nome_farmaco = RDR.Item("nome_farmaco")
            SAN.Nome_arm = RDR.Item("nome_armazenista")
            SAN.Ref_farmaco = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ref_farmaco")), "", RDR.Item("ref_farmaco")))
            SAN.Quantidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("quantidade")), "", RDR.Item("quantidade")))
            ListBox10.Items.Add(SAN)
        End While
        CN.Close()
        currentSelection = 0
        ShowSearchArm()
    End Sub

    Private Sub searchArmPA_Click(sender As Object, e As EventArgs) Handles searchArmPA.Click
        CMD = New SqlCommand
        CMD.Connection = CN
        flagArmNome = False
        Dim nome As New SqlParameter
        Dim nif As New SqlParameter

        nome.ParameterName = "@p_activo"
        nome.SqlDbType = SqlDbType.VarChar
        nome.Value = txtSearchArmPA.Text


        nif.ParameterName = "@nif"
        nif.SqlDbType = SqlDbType.Decimal
        nif.Value = txtArmNIF.Text

        CMD.Parameters.Clear()
        CMD.Parameters.Add(nome)
        CMD.Parameters.Add(nif)

        CMD.CommandText = "SELECT * FROM GestFarm.stock_armazenistas_pa (@p_activo, @nif)"

        CN.Open()
        Dim RDR As SqlDataReader
        RDR = CMD.ExecuteReader
        ListBox10.Items.Clear()
        While RDR.Read
            Dim SAN As New searchStockArmName
            SAN.Nome_farmaco = RDR.Item("nome_farmaco")
            SAN.Nome_arm = RDR.Item("nome_armazenista")
            SAN.Ref_farmaco = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("ref_farmaco")), "", RDR.Item("ref_farmaco")))
            SAN.Quantidade = Convert.ToString(IIf(RDR.IsDBNull(RDR.GetOrdinal("quantidade")), "", RDR.Item("quantidade")))
            ListBox10.Items.Add(SAN)
        End While
        CN.Close()
        currentSelection = 0
        ShowSearchArm()
    End Sub

    Private Sub voltarFarm_Click(sender As Object, e As EventArgs) Handles voltarFarm.Click
        openPanel.Show()
        armPanel.Hide()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Hide()
        funcPanel.Hide()
        orderHistPanel.Hide()
        stockFarmPanel.Hide()
        listStockArmPanel.Hide()
    End Sub
    Private Sub voltarArm_Click(sender As Object, e As EventArgs) Handles voltarArm.Click
        openPanel.Show()
        armPanel.Hide()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Hide()
        funcPanel.Hide()
        orderHistPanel.Hide()
        stockFarmPanel.Hide()
        listStockArmPanel.Hide()
    End Sub
    Private Sub voltarStockArm_Click(sender As Object, e As EventArgs) Handles voltarStockArm.Click
        openPanel.Hide()
        armPanel.Show()
        farmPanel.Hide()
        listForn.Hide()
        clientePanel.Hide()
        funcPanel.Hide()
        orderHistPanel.Hide()
        stockFarmPanel.Hide()
        listStockArmPanel.Hide()
    End Sub
    Private Sub voltarListForn_Click(sender As Object, e As EventArgs) Handles voltarListForn.Click
        backToFarm()
    End Sub

    Private Sub voltarCliente_Click(sender As Object, e As EventArgs) Handles voltarCliente.Click
        backToFarm()
    End Sub

    Private Sub voltarFunc_Click(sender As Object, e As EventArgs) Handles voltarFunc.Click
        backToFarm()
    End Sub

    Private Sub voltarOrdHist_Click(sender As Object, e As EventArgs) Handles voltarOrdHist.Click
        backToFarm()
    End Sub

    Private Sub voltarStock_Click(sender As Object, e As EventArgs) Handles voltarStock.Click
        backToFarm()
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

    Private Sub backToFarm()
        openPanel.Hide()
        armPanel.Hide()
        farmPanel.Show()
        listForn.Hide()
        clientePanel.Hide()
        funcPanel.Hide()
        orderHistPanel.Hide()
        stockFarmPanel.Hide()
        listStockArmPanel.Hide()
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
        txtFFarmacia.ReadOnly = True
        txtIDFuncionario.ReadOnly = True
        txtNFuncionario.ReadOnly = True
        txtNomeOrdHist.ReadOnly = True
        txtNrEncomenda.ReadOnly = True
        txtDataC.ReadOnly = True
        txtDataProc.ReadOnly = True
        txtOHForn.ReadOnly = True
        txtNomeStockFarm.ReadOnly = True
        txtNIFStockFarm.ReadOnly = True
        txtNomeFarmaco.ReadOnly = True
        txtRefFarmaco.ReadOnly = True
        txtQtFarm.ReadOnly = True
        txtNomeFarmaco.ReadOnly = True
        txtRefFarmaco.ReadOnly = True
        txtQtFarm.ReadOnly = True
        txtNomeArm.ReadOnly = True
        txtNIFArm.ReadOnly = True
        txtRefFarmArm.ReadOnly = True
        txtNomeFarmArm.ReadOnly = True
        txtQtArm.ReadOnly = True
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
        txtFFarmacia.ReadOnly = False
        txtIDFuncionario.ReadOnly = False
        txtNFuncionario.ReadOnly = False
        txtNomeOrdHist.ReadOnly = False
        txtNrEncomenda.ReadOnly = False
        txtDataC.ReadOnly = False
        txtDataProc.ReadOnly = False
        txtOHForn.ReadOnly = False
        txtNomeStockFarm.ReadOnly = False
        txtNIFStockFarm.ReadOnly = False
        txtNomeFarmaco.ReadOnly = False
        txtRefFarmaco.ReadOnly = False
        txtQtFarm.ReadOnly = False
        txtNomeFarmaco.ReadOnly = False
        txtRefFarmaco.ReadOnly = False
        txtQtFarm.ReadOnly = False
        txtNomeArm.ReadOnly = False
        txtNIFArm.ReadOnly = False
        txtRefFarmArm.ReadOnly = False
        txtNomeFarmArm.ReadOnly = False
        txtQtArm.ReadOnly = False
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
        txtFFarmacia.Text = ""
        txtIDFuncionario.Text = ""
        txtNFuncionario.Text = ""
        txtNomeStockFarm.Text = ""
        txtNIFStockFarm.Text = ""
        txtNomeFarmaco.Text = ""
        txtRefFarmaco.Text = ""
        txtQtFarm.Text = ""
        txtNomeFarmaco.Text = ""
        txtRefFarmaco.Text = ""
        txtQtFarm.Text = ""
        txtNomeArm.Text = ""
        txtNIFArm.Text = ""
        txtRefFarmArm.Text = ""
        txtNomeFarmArm.Text = ""
        txtQtArm.Text = ""
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

    ''FUNCIONARIO
    Private Sub ListBox5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox5.SelectedIndexChanged
        currentSelection = ListBox5.SelectedIndex
        ShowFuncionario()
    End Sub

    Private Sub ShowFuncionario()
        LockTextFields()
        If ListBox5.Items.Count = 0 Or currentSelection < 0 Then Exit Sub
        Dim LF As New list_funcionarios
        LF = CType(ListBox5.Items.Item(currentSelection), list_funcionarios)
        txtFFarmacia.Text = LF.Farmacia
        txtIDFuncionario.Text = LF.Id
        txtNFuncionario.Text = LF.Nome
    End Sub

    ''HISTORICO ENCOMENDAS
    Private Sub ListBox6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox6.SelectedIndexChanged
        currentSelection = ListBox6.SelectedIndex
        ShowHistorico()
    End Sub

    Private Sub ListBox7_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox7.SelectedIndexChanged
        currentSelection = ListBox7.SelectedIndex
        ShowConteudo()
    End Sub

    Private Sub ShowHistorico()
        LockTextFields()
        If ListBox6.Items.Count = 0 Or currentSelection < 0 Then Exit Sub
        Dim OH As New list_OrderHist
        OH = CType(ListBox6.Items.Item(currentSelection), list_OrderHist)
        txtNomeOrdHist.Text = OH.Nome
        txtNrEncomenda.Text = OH.N_encomenda
        txtDataC.Text = OH.Data_criacao
        txtDataProc.Text = OH.Data_proc
        txtOHForn.Text = OH.Arm
    End Sub

    Private Sub ShowConteudo()
        LockTextFields()
        If ListBox7.Items.Count = 0 Or currentSelection < 0 Then Exit Sub
        Dim LHO As New list_Order_Farmaco
        LHO = CType(ListBox7.Items.Item(currentSelection), list_Order_Farmaco)
        txtFarmacoNome.Text = LHO.Nome_farmaco
        txtFarmacoRef.Text = LHO.Ref
        txtFarmacoPA.Text = LHO.P_activo
    End Sub

    ''STOCK FARMACIA
    Private Sub ListBox8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox8.SelectedIndexChanged
        currentSelection = ListBox8.SelectedIndex
        ShowStockFarm()
    End Sub

    Private Sub ShowStockFarm()
        LockTextFields()
        If ListBox8.Items.Count = 0 Or currentSelection < 0 Then Exit Sub
        Dim SF As New list_stock_farmacia
        SF = CType(ListBox8.Items.Item(currentSelection), list_stock_farmacia)
        txtNomeStockFarm.Text = SF.Nome
        txtNIFStockFarm.Text = SF.NIF_farmacia
        txtNomeFarmaco.Text = SF.Nome_farmaco
        txtRefFarmaco.Text = SF.Ref_farmaco
        txtQtFarm.Text = SF.Quantidade
    End Sub

    Private Sub ListBox9_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox9.SelectedIndexChanged
        currentSelection = ListBox9.SelectedIndex
        ShowSearch()
    End Sub
    Private Sub ShowSearch()
        LockTextFields()
        If ListBox9.Items.Count = 0 Or currentSelection < 0 Then Exit Sub
        If flagNome Then
            Dim SN As New search_name
            SN = CType(ListBox9.Items.Item(currentSelection), search_name)
            txtNomeFarmaco.Text = SN.Nome_farmaco
            txtRefFarmaco.Text = SN.Ref
            txtQtFarm.Text = SN.Quantidade
        Else
            Dim SPA As New searchPA
            SPA = CType(ListBox9.Items.Item(currentSelection), searchPA)
            txtNomeFarmaco.Text = SPA.Nome_farmaco
            txtRefFarmaco.Text = SPA.Ref
            txtQtFarm.Text = SPA.Quantidade
        End If
    End Sub

    ''STOCK ARMAZENISTA
    Private Sub ListBox11_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox11.SelectedIndexChanged
        currentSelection = ListBox11.SelectedIndex
        ShowStockArm()
    End Sub
    Private Sub ShowStockArm()
        LockTextFields()
        If ListBox11.Items.Count = 0 Or currentSelection < 0 Then Exit Sub
        Dim SA As New listStockArm
        SA = CType(ListBox11.Items.Item(currentSelection), listStockArm)
        txtNomeArm.Text = SA.Nome_Arm
        txtNIFArm.Text = SA.NIF_arm
        txtRefFarmArm.Text = SA.Ref_farm
        txtNomeFarmArm.Text = SA.Nome_farm
        txtQtArm.Text = SA.Quantidade
    End Sub

    Private Sub ListBox10_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox10.SelectedIndexChanged
        currentSelection = ListBox10.SelectedIndex
        ShowSearchArm()
    End Sub
    Private Sub ShowSearchArm()
        LockTextFields()
        If ListBox10.Items.Count = 0 Or currentSelection < 0 Then Exit Sub
        If flagArmNome Then
            Dim SAN As New searchStockArmName
            SAN = CType(ListBox10.Items.Item(currentSelection), searchStockArmName)
            txtNomeFarmArm.Text = SAN.Nome_farmaco
            txtRefFarmArm.Text = SAN.Ref_farmaco
            txtQtArm.Text = SAN.Quantidade
        Else
            Dim SAN As New searchStockArmName
            SAN = CType(ListBox10.Items.Item(currentSelection), searchStockArmName)
            txtNomeFarmArm.Text = SAN.Nome_farmaco
            txtRefFarmArm.Text = SAN.Ref_farmaco
            txtQtArm.Text = SAN.Quantidade
        End If
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
