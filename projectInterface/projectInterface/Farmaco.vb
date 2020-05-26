Public Class Farmaco
    Private _nome As String
    Private _ref As String
    Private _preco As String
    Private _p_ativo As String
    Private _IVA As String
    Private _ID_func As String
    Private _codigo_lab As String
    Private ID_prescricao As String
    Private _n_venda As String

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            _nome = value
        End Set
    End Property

    Public Property Ref As String
        Get
            Return _ref
        End Get
        Set(value As String)
            _ref = value
        End Set
    End Property

    Public Property Preco As String
        Get
            Return _preco
        End Get
        Set(value As String)
            _preco = value
        End Set
    End Property

    Public Property P_ativo As String
        Get
            Return _p_ativo
        End Get
        Set(value As String)
            _p_ativo = value
        End Set
    End Property

    Public Property IVA As String
        Get
            Return _IVA
        End Get
        Set(value As String)
            _IVA = value
        End Set
    End Property

    Public Property ID_func As String
        Get
            Return _ID_func
        End Get
        Set(value As String)
            _ID_func = value
        End Set
    End Property

    Public Property Codigo_lab As String
        Get
            Return _codigo_lab
        End Get
        Set(value As String)
            _codigo_lab = value
        End Set
    End Property

    Public Property ID_prescricao1 As String
        Get
            Return ID_prescricao
        End Get
        Set(value As String)
            ID_prescricao = value
        End Set
    End Property

    Public Property N_venda As String
        Get
            Return _n_venda
        End Get
        Set(value As String)
            _n_venda = value
        End Set
    End Property
End Class
