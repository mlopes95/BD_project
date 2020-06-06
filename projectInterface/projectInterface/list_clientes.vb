Public Class list_clientes
    Private _nome_farm As String
    Private _NIF_farm As String
    Private _nome_cliente As String
    Private _NIF_cliente As String
    Private _contacto_cliente As String

    Public Property Nome_farm As String
        Get
            Return _nome_farm
        End Get
        Set(value As String)
            _nome_farm = value
        End Set
    End Property

    Public Property NIF_farm As String
        Get
            Return _NIF_farm
        End Get
        Set(value As String)
            _NIF_farm = value
        End Set
    End Property

    Public Property Nome_cliente As String
        Get
            Return _nome_cliente
        End Get
        Set(value As String)
            _nome_cliente = value
        End Set
    End Property

    Public Property NIF_cliente As String
        Get
            Return _NIF_cliente
        End Get
        Set(value As String)
            _NIF_cliente = value
        End Set
    End Property

    Public Property Contacto_cliente As String
        Get
            Return _contacto_cliente
        End Get
        Set(value As String)
            _contacto_cliente = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return _nome_cliente
    End Function
End Class
