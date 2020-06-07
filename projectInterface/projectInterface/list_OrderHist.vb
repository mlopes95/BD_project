Public Class list_OrderHist
    Private _nome As String
    Private _n_encomenda As String
    Private _data_criacao As String
    Private _data_proc As String
    Private _arm As String

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            _nome = value
        End Set
    End Property

    Public Property N_encomenda As String
        Get
            Return _n_encomenda
        End Get
        Set(value As String)
            _n_encomenda = value
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

    Public Property Arm As String
        Get
            Return _arm
        End Get
        Set(value As String)
            _arm = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return _n_encomenda
    End Function
End Class
