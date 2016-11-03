
Public Class Address
    Private m_street As String
    Private m_number As Integer
    Private m_postal As Long
    Private m_city As City

    Public Sub New()
    End Sub

    Public Sub New(street As String, number As Integer, postal As Long, city As City)
        Me.m_street = street
        Me.m_number = number
        Me.m_postal = postal
        Me.m_city = city
    End Sub

    Public Property Street() As String
        Get
            Return m_street
        End Get
        Set(value As String)
            m_street = value
        End Set
    End Property

    Public Property Number() As Integer
        Get
            Return m_number
        End Get
        Set(value As Integer)
            m_number = value
        End Set
    End Property

    Public Property Postal() As Long
        Get
            Return m_postal
        End Get
        Set(value As Long)
            m_postal = value
        End Set
    End Property

    Public Property City() As City
        Get
            Return m_city
        End Get
        Set(value As City)
            m_city = value
        End Set
    End Property
End Class
