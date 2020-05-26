Public Class Armazenista
    Private _nome As String
    Private _endereço As String
    Private _telefone As String
    Private _NIF_arm As String
    Private _NIF_farmacia As String

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            _nome = value
        End Set
    End Property

    Public Property Endereço As String
        Get
            Return _endereço
        End Get
        Set(value As String)
            _endereço = value
        End Set
    End Property

    Public Property Telefone As String
        Get
            Return _telefone
        End Get
        Set(value As String)
            _telefone = value
        End Set
    End Property

    Public Property NIF_arm As String
        Get
            Return _NIF_arm
        End Get
        Set(value As String)
            _NIF_arm = value
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
End Class
