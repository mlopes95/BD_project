Public Class list_stock_farmacia
    Private _nome As String
    Private _NIF_farmacia As String
    Private _ref_farmaco As String
    Private _nome_farmaco As String
    Private _quantidade As String

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            _nome = value
        End Set
    End Property

    Public Property NIF_farmacia As String
        Get
            Return _NIF_farmacia
        End Get
        Set(value As String)
            _NIF_farmacia = value
        End Set
    End Property

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

    Public Property Quantidade As String
        Get
            Return _quantidade
        End Get
        Set(value As String)
            _quantidade = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return _nome_farmaco
    End Function
End Class
