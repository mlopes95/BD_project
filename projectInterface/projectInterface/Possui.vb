Public Class Possui
    Private _nr_encom As String
    Private _ref As String

    Public Property Nr_encom As String
        Get
            Return _nr_encom
        End Get
        Set(value As String)
            _nr_encom = value
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
