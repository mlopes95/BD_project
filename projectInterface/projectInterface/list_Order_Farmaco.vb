Public Class list_Order_Farmaco
    Private _nr_encomenda As String
    Private _nome_farmaco As String
    Private _ref As String
    Private _p_activo As String

    Public Property Nr_encomenda As String
        Get
            Return _nr_encomenda
        End Get
        Set(value As String)
            _nr_encomenda = value
        End Set
    End Property

    Public Property Nome_farmaco As String
        Get
            Return _nome_farmaco
        End Get
        Set(value As String)
            _nome_farmaco = value
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

    Public Property P_activo As String
        Get
            Return _p_activo
        End Get
        Set(value As String)
            _p_activo = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return _nome_farmaco
    End Function
End Class
