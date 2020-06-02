<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FuncionarioForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FuncionarioForm))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.buttonRemove = New System.Windows.Forms.Button()
        Me.buttonEdit = New System.Windows.Forms.Button()
        Me.buttonAdd = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(2)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ListBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.PictureBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label5)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label4)
        Me.SplitContainer1.Panel2.Controls.Add(Me.buttonRemove)
        Me.SplitContainer1.Panel2.Controls.Add(Me.buttonEdit)
        Me.SplitContainer1.Panel2.Controls.Add(Me.buttonAdd)
        Me.SplitContainer1.Panel2.Controls.Add(Me.DateTimePicker1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CheckBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.CheckBox1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label3)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.TextBox1)
        Me.SplitContainer1.Size = New System.Drawing.Size(600, 417)
        Me.SplitContainer1.SplitterDistance = 227
        Me.SplitContainer1.SplitterWidth = 3
        Me.SplitContainer1.TabIndex = 0
        '
        'ListBox1
        '
        Me.ListBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(0, 0)
        Me.ListBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(226, 416)
        Me.ListBox1.TabIndex = 0
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(139, 10)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(79, 85)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox2.TabIndex = 16
        Me.PictureBox2.TabStop = False
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(139, 241)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(99, 20)
        Me.TextBox4.TabIndex = 15
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(27, 241)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(99, 20)
        Me.TextBox3.TabIndex = 14
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(136, 225)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Hora de saída"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 225)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(84, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Hora de entrada"
        '
        'buttonRemove
        '
        Me.buttonRemove.Location = New System.Drawing.Point(249, 358)
        Me.buttonRemove.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonRemove.Name = "buttonRemove"
        Me.buttonRemove.Size = New System.Drawing.Size(83, 29)
        Me.buttonRemove.TabIndex = 11
        Me.buttonRemove.Text = "Remover"
        Me.buttonRemove.UseVisualStyleBackColor = True
        '
        'buttonEdit
        '
        Me.buttonEdit.Location = New System.Drawing.Point(139, 358)
        Me.buttonEdit.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonEdit.Name = "buttonEdit"
        Me.buttonEdit.Size = New System.Drawing.Size(83, 29)
        Me.buttonEdit.TabIndex = 10
        Me.buttonEdit.Text = "Editar"
        Me.buttonEdit.UseVisualStyleBackColor = True
        '
        'buttonAdd
        '
        Me.buttonAdd.Location = New System.Drawing.Point(27, 358)
        Me.buttonAdd.Margin = New System.Windows.Forms.Padding(2)
        Me.buttonAdd.Name = "buttonAdd"
        Me.buttonAdd.Size = New System.Drawing.Size(83, 29)
        Me.buttonAdd.TabIndex = 9
        Me.buttonAdd.Text = "Adicionar"
        Me.buttonAdd.UseVisualStyleBackColor = True
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Location = New System.Drawing.Point(27, 182)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(151, 20)
        Me.DateTimePicker1.TabIndex = 8
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(262, 185)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(74, 17)
        Me.CheckBox2.TabIndex = 7
        Me.CheckBox2.Text = "Masculino"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(193, 185)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(68, 17)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "Feminino"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 164)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Data de nascimento"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(136, 110)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nome"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 110)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "ID"
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(139, 126)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(194, 20)
        Me.TextBox2.TabIndex = 1
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(27, 126)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(99, 20)
        Me.TextBox1.TabIndex = 0
        '
        'FuncionarioForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 417)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "FuncionarioForm"
        Me.Text = "Funcionario"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.Panel2.PerformLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents CheckBox2 As CheckBox
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents buttonRemove As Button
    Friend WithEvents buttonEdit As Button
    Friend WithEvents buttonAdd As Button
    Friend WithEvents PictureBox2 As PictureBox
End Class
