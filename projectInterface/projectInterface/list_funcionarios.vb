Public Class list_funcionarios
    Private _id As String
    Private _nome As String
    Private _farmacia As String

    Public Property Id As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
        End Set
    End Property

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            _nome = value
        End Set
    End Property

    Public Property Farmacia As String
        Get
            Return _farmacia
        End Get
        Set(value As String)
            _farmacia = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return _nome
    End Function
End Class