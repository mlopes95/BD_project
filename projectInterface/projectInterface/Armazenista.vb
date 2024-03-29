﻿<Serializable()> Public Class Armazenista
    Private _nome As String
    Private _endereço As String
    Private _telefone As String
    Private _NIF_arm As String
    Private _NIF_farmacia As String

    Public Property Nome As String
        Get
            Return _nome
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("É necessário preencher o campo nome")
                Exit Property
            End If
            _nome = value
        End Set
    End Property

    Public Property Endereço As String
        Get
            Return _endereço
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("É necessário preencher o campo endereço")
                Exit Property
            End If
            _endereço = value
        End Set
    End Property

    Public Property Telefone As String
        Get
            Return _telefone
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("É necessário preencher o campo telefone")
                Exit Property
            End If
            _telefone = value
        End Set
    End Property

    Public Property NIF_arm As String
        Get
            Return _NIF_arm
        End Get
        Set(value As String)
            If value Is Nothing Or value = "" Then
                Throw New Exception("É necessário preencher o campo NIF")
                Exit Property
            End If
            _NIF_arm = value
        End Set
    End Property

    Public Property NIF_farmacia As String
        Get
            Return _NIF_farmacia
        End Get
        Set(value As String)
            _NIF_farmacia = value
        End Set
    End Property

    Overrides Function ToString() As String
        Return _nome
    End Function
End Class
