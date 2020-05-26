Public Class Compra
    Private _NIF_cliente As String
    Private _ref As String

    Public Property NIF_cliente As String
        Get
            Return _NIF_cliente
        End Get
        Set(value As String)
            _NIF_cliente = value
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
End Class
