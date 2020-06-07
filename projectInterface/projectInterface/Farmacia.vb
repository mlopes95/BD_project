<Serializable()> Public Class Farmacia
    Private _nome As String
    Private _endereco As String
    Private _telefone As String
    Private _NIF_farmacia As String
    Private _n_alvara As String

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("É necessário preencher o campo nome")
                Exit Property
            End If
            _nome = value
        End Set
    End Property

    Public Property Endereco As String
        Get
            Return _endereco
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("É necessário preencher o campo endereço")
                Exit Property
            End If
            _endereco = value
        End Set
    End Property

    Public Property Telefone As String
        Get
            Return _telefone
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("É necessário preencher o campo telefone")
                Exit Property
            End If
            _telefone = value
        End Set
    End Property

    Public Property NIF_farmacia As String
        Get
            Return _NIF_farmacia
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("É necessário preencher o campo NIF")
                Exit Property
            End If
            _NIF_farmacia = value
        End Set
    End Property

    Public Property N_alvara As String
        Get
            Return _n_alvara
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("É necessário preencher o campo alvará")
                Exit Property
            End If
            _n_alvara = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return _nome
    End Function
End Class
