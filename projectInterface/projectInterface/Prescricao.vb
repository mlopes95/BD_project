Public Class Prescricao
    Private _id_prescricao As String
    Private _nif_cliente As String

    Public Property Id_prescricao As String
        Get
            Return _id_prescricao
        End Get
        Set(value As String)
            _id_prescricao = value
        End Set
    End Property

    Public Property Nif_cliente As String
        Get
            Return _nif_cliente
        End Get
        Set(value As String)
            _nif_cliente = value
        End Set
    End Property
End Class
