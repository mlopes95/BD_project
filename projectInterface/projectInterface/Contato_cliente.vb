Public Class Contato_cliente
    Private _contacto
    Private _NIF_cliente

    Public Property Contacto As Object
        Get
            Return _contacto
        End Get
        Set(value As Object)
            _contacto = value
        End Set
    End Property

    Public Property NIF_cliente As Object
        Get
            Return _NIF_cliente
        End Get
        Set(value As Object)
            _NIF_cliente = value
        End Set
    End Property
End Class
