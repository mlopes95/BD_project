Public Class Vende
    Private _id As String
    Private _ref As String

    Public Property Id As String
        Get
            Return _id
        End Get
        Set(value As String)
            _id = value
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
End Class
