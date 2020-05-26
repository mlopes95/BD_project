Public Class Encomenda
    Private _nr_enc As String
    Private _data_criacao As String
    Private _data_proc As String
    Private _NIF_arm As String

    Public Property Nr_enc As String
        Get
            Return _nr_enc
        End Get
        Set(value As String)
            _nr_enc = value
        End Set
    End Property

    Public Property Data_criacao As String
        Get
            Return _data_criacao
        End Get
        Set(value As String)
            _data_criacao = value
        End Set
    End Property

    Public Property Data_proc As String
        Get
            Return _data_proc
        End Get
        Set(value As String)
            _data_proc = value
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
End Class
