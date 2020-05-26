Public Class Cliente
    Private _nome As String
    Private _NIF As String

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            _nome = value
        End Set
    End Property

    Public Property NIF As String
        Get
            Return _NIF
        End Get
        Set(value As String)
            _NIF = value
        End Set
    End Property
End Class
