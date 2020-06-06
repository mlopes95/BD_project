Public Class list_fornecedores
    Private _nome_farm As String
    Private _nif__farm As String
    Private _nome_forn As String
    Private _nif_forn As String

    Public Property Nome_farm As String
        Get
            Return _nome_farm
        End Get
        Set(value As String)
            _nome_farm = value
        End Set
    End Property

    Public Property Nif__farm As String
        Get
            Return _nif__farm
        End Get
        Set(value As String)
            _nif__farm = value
        End Set
    End Property

    Public Property Nome_forn As String
        Get
            Return _nome_forn
        End Get
        Set(value As String)
            _nome_forn = value
        End Set
    End Property

    Public Property Nif_forn As String
        Get
            Return _nif_forn
        End Get
        Set(value As String)
            _nif_forn = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return _nome_forn
    End Function
End Class
