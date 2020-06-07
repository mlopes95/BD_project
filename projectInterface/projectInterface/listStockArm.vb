Public Class listStockArm
    Private _ref_farm As String
    Private _nome_farm As String
    Private _nome_Arm As String
    Private _NIF_arm As String
    Private _quantidade As String

    Public Property Ref_farm As String
        Get
            Return _ref_farm
        End Get
        Set(value As String)
            _ref_farm = value
        End Set
    End Property

    Public Property Nome_farm As String
        Get
            Return _nome_farm
        End Get
        Set(value As String)
            _nome_farm = value
        End Set
    End Property

    Public Property Nome_Arm As String
        Get
            Return _nome_Arm
        End Get
        Set(value As String)
            _nome_Arm = value
        End Set
    End Property

    Public Property Quantidade As String
        Get
            Return _quantidade
        End Get
        Set(value As String)
            _quantidade = value
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

    Public Overrides Function ToString() As String
        Return _nome_farm
    End Function
End Class
