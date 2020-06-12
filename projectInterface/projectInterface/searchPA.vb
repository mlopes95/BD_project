Public Class searchPA
    Private _nome_farmacia As String
    Private _nif_farmacia As String
    Private _ref As String
    Private _nome_farmaco As String
    Private _p_activo As String
    Private _quantidade As String
    Private _nome_lab As String
    Private __lab_cod As String
    Private _pa As String

    Public Property Nome_farmacia As String
        Get
            Return _nome_farmacia
        End Get
        Set(value As String)
            _nome_farmacia = value
        End Set
    End Property

    Public Property Nif_farmacia As String
        Get
            Return _nif_farmacia
        End Get
        Set(value As String)
            _nif_farmacia = value
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

    Public Property Nome_farmaco As String
        Get
            Return _nome_farmaco
        End Get
        Set(value As String)
            _nome_farmaco = value
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

    Public Property Quantidade As String
        Get
            Return _quantidade
        End Get
        Set(value As String)
            _quantidade = value
        End Set
    End Property

    Public Property Nome_lab As String
        Get
            Return _nome_lab
        End Get
        Set(value As String)
            _nome_lab = value
        End Set
    End Property

    Public Property Lab_cod As String
        Get
            Return __lab_cod
        End Get
        Set(value As String)
            __lab_cod = value
        End Set
    End Property

    Public Property Pa As String
        Get
            Return _pa
        End Get
        Set(value As String)
            _pa = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return _nome_farmaco
    End Function
End Class