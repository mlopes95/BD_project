<Serializable()> Public Class Farmacia
    Private _nome
    Private _endereco
    Private _telefone
    Private _NIF_farmacia
    Private _n_alvara

    Public Property Nome As Object
        Get
            Return _nome
        End Get
        Set(value As Object)
            _nome = value
        End Set
    End Property

    Public Property Endereco As Object
        Get
            Return _endereco
        End Get
        Set(value As Object)
            _endereco = value
        End Set
    End Property

    Public Property Telefone As Object
        Get
            Return _telefone
        End Get
        Set(value As Object)
            _telefone = value
        End Set
    End Property

    Public Property NIF_farmacia As Object
        Get
            Return _NIF_farmacia
        End Get
        Set(value As Object)
            _NIF_farmacia = value
        End Set
    End Property

    Public Property N_alvara As Object
        Get
            Return _n_alvara
        End Get
        Set(value As Object)
            _n_alvara = value
        End Set
    End Property
End Class
