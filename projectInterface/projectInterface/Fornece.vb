Public Class Fornece
    Private NIF_farmacia As String
    Private NIF_arm As String

    Public Property NIF_farmacia1 As String
        Get
            Return NIF_farmacia
        End Get
        Set(value As String)
            NIF_farmacia = value
        End Set
    End Property

    Public Property NIF_arm1 As String
        Get
            Return NIF_arm
        End Get
        Set(value As String)
            NIF_arm = value
        End Set
    End Property
End Class
