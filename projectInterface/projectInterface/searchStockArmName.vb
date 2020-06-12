Public Class searchStockArmName
    Private _ref_farmaco As String
    Private _nome_farmaco As String
    Private _nome_arm As String
    Private _quantidade As String
    Private _nome_lab As String
    Private __lab_cod As String
    Private _pa As String

    Public Property Ref_farmaco As String
        Get
            Return _ref_farmaco
        End Get
        Set(value As String)
            _ref_farmaco = value
        End Set
    End Property

    Public Property Nome_farmaco As String
        Get
            Return _nome_farmaco
        End Get
        Set(value As String)
            _nome_farmaco = value
        End Set
    End Property

    Public Property Nome_arm As String
        Get
            Return _nome_arm
        End Get
        Set(value As String)
            _nome_arm = value
        End Set
    End Property

    Public Property Quantidade As String
        Get
            Return _quantidade
        End Get
        Set(value As String)
            _quantidade = value
        End Set
    End Property

    Public Property Nome_lab As String
        Get
            Return _nome_lab
        End Get
        Set(value As String)
            _nome_lab = value
        End Set
    End Property

    Public Property Lab_cod As String
        Get
            Return __lab_cod
        End Get
        Set(value As String)
            __lab_cod = value
        End Set
    End Property

    Public Property Pa As String
        Get
            Return _pa
        End Get
        Set(value As String)
            _pa = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return Nome_farmaco
    End Function
End Class
