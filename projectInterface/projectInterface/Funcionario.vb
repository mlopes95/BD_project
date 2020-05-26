<Serializable()> Public Class Funcionario
    Private _pnome As String
    Private _unome As String
    Private _data_nasc As String
    Private _ID As String
    Private _genero As String
    Private _password As String
    Private _hora_entrada As String
    Private _hora_saida As String
    Private _NIF_farmacia As String

    Public Property Pnome As String
        Get
            Return _pnome
        End Get
        Set(value As String)
            _pnome = value
        End Set
    End Property

    Public Property Unome As String
        Get
            Return _unome
        End Get
        Set(value As String)
            _unome = value
        End Set
    End Property

    Public Property Data_nasc As String
        Get
            Return _data_nasc
        End Get
        Set(value As String)
            _data_nasc = value
        End Set
    End Property

    Public Property ID As String
        Get
            Return _ID
        End Get
        Set(value As String)
            _ID = value
        End Set
    End Property

    Public Property Genero As String
        Get
            Return _genero
        End Get
        Set(value As String)
            _genero = value
        End Set
    End Property

    Public Property Password As String
        Get
            Return _password
        End Get
        Set(value As String)
            _password = value
        End Set
    End Property

    Public Property Hora_entrada As String
        Get
            Return _hora_entrada
        End Get
        Set(value As String)
            _hora_entrada = value
        End Set
    End Property

    Public Property Hora_saida As String
        Get
            Return _hora_saida
        End Get
        Set(value As String)
            _hora_saida = value
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

    Overrides Function ToString() As String
        Return Pnome & "   " & Unome & ", " & ID
    End Function
End Class


