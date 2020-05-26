<Serializable()> Public Class Funcionario
    Private _pnome
    Private _unome
    Private _data_nasc
    Private _ID
    Private _genero
    Private _password
    Private _hora_entrada
    Private _hora_saida
    Private _NIF_farmacia

    Public Property Pnome As Object
        Get
            Return _pnome
        End Get
        Set(value As Object)
            _pnome = value
        End Set
    End Property

    Public Property Unome As Object
        Get
            Return _unome
        End Get
        Set(value As Object)
            _unome = value
        End Set
    End Property

    Public Property Data_nasc As Object
        Get
            Return _data_nasc
        End Get
        Set(value As Object)
            _data_nasc = value
        End Set
    End Property

    Public Property ID As Object
        Get
            Return _ID
        End Get
        Set(value As Object)
            _ID = value
        End Set
    End Property

    Public Property Genero As Object
        Get
            Return _genero
        End Get
        Set(value As Object)
            _genero = value
        End Set
    End Property

    Public Property Password As Object
        Get
            Return _password
        End Get
        Set(value As Object)
            _password = value
        End Set
    End Property

    Public Property Hora_entrada As Object
        Get
            Return _hora_entrada
        End Get
        Set(value As Object)
            _hora_entrada = value
        End Set
    End Property

    Public Property Hora_saida As Object
        Get
            Return _hora_saida
        End Get
        Set(value As Object)
            _hora_saida = value
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


    Overrides Function ToString() As String
        Return _pnome & "   " & _unome & ", " & _ID
    End Function
End Class


