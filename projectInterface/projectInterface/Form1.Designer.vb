<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class openingForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(openingForm))
        Me.farmPanel = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Nome = New System.Windows.Forms.Label()
        Me.textTelefone = New System.Windows.Forms.TextBox()
        Me.textAlvara = New System.Windows.Forms.TextBox()
        Me.textNIF = New System.Windows.Forms.TextBox()
        Me.textEndereco = New System.Windows.Forms.TextBox()
        Me.textNome = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.openPanel = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.listFarmacia = New System.Windows.Forms.Button()
        Me.listArmazenistas = New System.Windows.Forms.Button()
        Me.armPanel = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtArmTelefone = New System.Windows.Forms.TextBox()
        Me.txtArmNIF = New System.Windows.Forms.TextBox()
        Me.txtArmEndereço = New System.Windows.Forms.TextBox()
        Me.txtArmNome = New System.Windows.Forms.TextBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.ListBox2 = New System.Windows.Forms.ListBox()
        Me.farmPanel.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.openPanel.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.armPanel.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'farmPanel
        '
        Me.farmPanel.Controls.Add(Me.Label6)
        Me.farmPanel.Controls.Add(Me.Label5)
        Me.farmPanel.Controls.Add(Me.Label4)
        Me.farmPanel.Controls.Add(Me.Label3)
        Me.farmPanel.Controls.Add(Me.Nome)
        Me.farmPanel.Controls.Add(Me.textTelefone)
        Me.farmPanel.Controls.Add(Me.textAlvara)
        Me.farmPanel.Controls.Add(Me.textNIF)
        Me.farmPanel.Controls.Add(Me.textEndereco)
        Me.farmPanel.Controls.Add(Me.textNome)
        Me.farmPanel.Controls.Add(Me.PictureBox1)
        Me.farmPanel.Controls.Add(Me.ListBox1)
        Me.farmPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.farmPanel.Location = New System.Drawing.Point(0, 0)
        Me.farmPanel.Name = "farmPanel"
        Me.farmPanel.Size = New System.Drawing.Size(800, 450)
        Me.farmPanel.TabIndex = 21
        Me.farmPanel.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(559, 291)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Telefone"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(342, 291)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Alvará"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(559, 239)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 13)
        Me.Label4.TabIndex = 25
        Me.Label4.Text = "NIF"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(342, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Endereço"
        '
        'Nome
        '
        Me.Nome.AutoSize = True
        Me.Nome.Location = New System.Drawing.Point(342, 191)
        Me.Nome.Name = "Nome"
        Me.Nome.Size = New System.Drawing.Size(35, 13)
        Me.Nome.TabIndex = 23
        Me.Nome.Text = "Nome"
        '
        'textTelefone
        '
        Me.textTelefone.BackColor = System.Drawing.SystemColors.Control
        Me.textTelefone.Location = New System.Drawing.Point(562, 307)
        Me.textTelefone.Name = "textTelefone"
        Me.textTelefone.Size = New System.Drawing.Size(173, 20)
        Me.textTelefone.TabIndex = 22
        '
        'textAlvara
        '
        Me.textAlvara.BackColor = System.Drawing.SystemColors.Control
        Me.textAlvara.Location = New System.Drawing.Point(345, 307)
        Me.textAlvara.Name = "textAlvara"
        Me.textAlvara.Size = New System.Drawing.Size(174, 20)
        Me.textAlvara.TabIndex = 21
        '
        'textNIF
        '
        Me.textNIF.BackColor = System.Drawing.SystemColors.Control
        Me.textNIF.Location = New System.Drawing.Point(562, 255)
        Me.textNIF.Name = "textNIF"
        Me.textNIF.Size = New System.Drawing.Size(173, 20)
        Me.textNIF.TabIndex = 20
        '
        'textEndereco
        '
        Me.textEndereco.BackColor = System.Drawing.SystemColors.Control
        Me.textEndereco.Location = New System.Drawing.Point(345, 255)
        Me.textEndereco.Name = "textEndereco"
        Me.textEndereco.Size = New System.Drawing.Size(174, 20)
        Me.textEndereco.TabIndex = 19
        '
        'textNome
        '
        Me.textNome.BackColor = System.Drawing.SystemColors.Control
        Me.textNome.Location = New System.Drawing.Point(345, 207)
        Me.textNome.Name = "textNome"
        Me.textNome.Size = New System.Drawing.Size(174, 20)
        Me.textNome.TabIndex = 18
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(476, 31)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(79, 85)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(2, 2)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(226, 455)
        Me.ListBox1.TabIndex = 1
        '
        'openPanel
        '
        Me.openPanel.Controls.Add(Me.Label1)
        Me.openPanel.Controls.Add(Me.PictureBox2)
        Me.openPanel.Controls.Add(Me.listFarmacia)
        Me.openPanel.Controls.Add(Me.listArmazenistas)
        Me.openPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.openPanel.Location = New System.Drawing.Point(0, 0)
        Me.openPanel.Name = "openPanel"
        Me.openPanel.Size = New System.Drawing.Size(800, 450)
        Me.openPanel.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(200, 154)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(396, 39)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Bem-vindo ao GestFarm"
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(345, 31)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(115, 106)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 22
        Me.PictureBox2.TabStop = False
        '
        'listFarmacia
        '
        Me.listFarmacia.Location = New System.Drawing.Point(316, 217)
        Me.listFarmacia.Name = "listFarmacia"
        Me.listFarmacia.Size = New System.Drawing.Size(168, 58)
        Me.listFarmacia.TabIndex = 21
        Me.listFarmacia.Text = "Listar Farmácias"
        Me.listFarmacia.UseVisualStyleBackColor = True
        '
        'listArmazenistas
        '
        Me.listArmazenistas.Location = New System.Drawing.Point(316, 325)
        Me.listArmazenistas.Name = "listArmazenistas"
        Me.listArmazenistas.Size = New System.Drawing.Size(168, 58)
        Me.listArmazenistas.TabIndex = 20
        Me.listArmazenistas.Text = "Listar Armazenistas"
        Me.listArmazenistas.UseVisualStyleBackColor = True
        '
        'armPanel
        '
        Me.armPanel.Controls.Add(Me.Label2)
        Me.armPanel.Controls.Add(Me.Label8)
        Me.armPanel.Controls.Add(Me.Label9)
        Me.armPanel.Controls.Add(Me.Label10)
        Me.armPanel.Controls.Add(Me.txtArmTelefone)
        Me.armPanel.Controls.Add(Me.txtArmNIF)
        Me.armPanel.Controls.Add(Me.txtArmEndereço)
        Me.armPanel.Controls.Add(Me.txtArmNome)
        Me.armPanel.Controls.Add(Me.PictureBox3)
        Me.armPanel.Controls.Add(Me.ListBox2)
        Me.armPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.armPanel.Location = New System.Drawing.Point(0, 0)
        Me.armPanel.Name = "armPanel"
        Me.armPanel.Size = New System.Drawing.Size(800, 450)
        Me.armPanel.TabIndex = 28
        Me.armPanel.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(559, 239)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Telefone"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(559, 191)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "NIF"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(342, 239)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(53, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Endereço"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(342, 191)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Nome"
        '
        'txtArmTelefone
        '
        Me.txtArmTelefone.BackColor = System.Drawing.SystemColors.Control
        Me.txtArmTelefone.Location = New System.Drawing.Point(562, 255)
        Me.txtArmTelefone.Name = "txtArmTelefone"
        Me.txtArmTelefone.Size = New System.Drawing.Size(173, 20)
        Me.txtArmTelefone.TabIndex = 22
        '
        'txtArmNIF
        '
        Me.txtArmNIF.BackColor = System.Drawing.SystemColors.Control
        Me.txtArmNIF.Location = New System.Drawing.Point(562, 207)
        Me.txtArmNIF.Name = "txtArmNIF"
        Me.txtArmNIF.Size = New System.Drawing.Size(173, 20)
        Me.txtArmNIF.TabIndex = 20
        '
        'txtArmEndereço
        '
        Me.txtArmEndereço.BackColor = System.Drawing.SystemColors.Control
        Me.txtArmEndereço.Location = New System.Drawing.Point(345, 255)
        Me.txtArmEndereço.Name = "txtArmEndereço"
        Me.txtArmEndereço.Size = New System.Drawing.Size(174, 20)
        Me.txtArmEndereço.TabIndex = 19
        '
        'txtArmNome
        '
        Me.txtArmNome.BackColor = System.Drawing.SystemColors.Control
        Me.txtArmNome.Location = New System.Drawing.Point(345, 207)
        Me.txtArmNome.Name = "txtArmNome"
        Me.txtArmNome.Size = New System.Drawing.Size(174, 20)
        Me.txtArmNome.TabIndex = 18
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
        Me.PictureBox3.Location = New System.Drawing.Point(476, 31)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(79, 85)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox3.TabIndex = 17
        Me.PictureBox3.TabStop = False
        '
        'ListBox2
        '
        Me.ListBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox2.FormattingEnabled = True
        Me.ListBox2.Location = New System.Drawing.Point(2, 2)
        Me.ListBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox2.Name = "ListBox2"
        Me.ListBox2.Size = New System.Drawing.Size(226, 455)
        Me.ListBox2.TabIndex = 1
        '
        'openingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.armPanel)
        Me.Controls.Add(Me.openPanel)
        Me.Controls.Add(Me.farmPanel)
        Me.Name = "openingForm"
        Me.Text = "Form1"
        Me.farmPanel.ResumeLayout(False)
        Me.farmPanel.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.openPanel.ResumeLayout(False)
        Me.openPanel.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.armPanel.ResumeLayout(False)
        Me.armPanel.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents farmPanel As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents openPanel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents listFarmacia As Button
    Friend WithEvents listArmazenistas As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Nome As Label
    Friend WithEvents textTelefone As TextBox
    Friend WithEvents textAlvara As TextBox
    Friend WithEvents textNIF As TextBox
    Friend WithEvents textEndereco As TextBox
    Friend WithEvents textNome As TextBox
    Friend WithEvents armPanel As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtArmTelefone As TextBox
    Friend WithEvents txtArmNIF As TextBox
    Friend WithEvents txtArmEndereço As TextBox
    Friend WithEvents txtArmNome As TextBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents ListBox2 As ListBox
End Class
