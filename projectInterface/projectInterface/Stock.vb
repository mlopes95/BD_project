Public Class Stock
    Private _NIF As String
    Private _ref As String
    Private _quantidade As String

    Public Property NIF As String
        Get
            Return _NIF
        End Get
        Set(value As String)
            _NIF = value
        End Set
    End Property

    Public Property Ref As String
        Get
            Return _ref
        End Get
        Set(value As String)
            _ref = value
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
End Class
