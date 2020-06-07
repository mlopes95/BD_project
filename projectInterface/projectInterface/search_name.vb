Public Class search_name
    Private _nome_farmacia As String
    Private _nome_farmaco As String
    Private _ref As String
    Private _quantidade As String

    Public Property Nome_farmacia As String
        Get
            Return _nome_farmacia
        End Get
        Set(value As String)
            _nome_farmacia = value
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

    Public Property Quantidade As String
        Get
            Return _quantidade
        End Get
        Set(value As String)
            _quantidade = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return Nome_farmaco
    End Function
End Class
