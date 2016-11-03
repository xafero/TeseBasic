
Public Class City
    Private m_name As String
    Private m_state As State
    Private m_code As Long

    Public Sub New()
    End Sub

    Public Sub New(name As String, state As State, code As Long)
        Me.m_name = name
        Me.m_state = state
        Me.m_code = code
    End Sub

    Public Property Name() As String
        Get
            Return m_name
        End Get
        Set(value As String)
            m_name = value
        End Set
    End Property

    Public Property State() As State
        Get
            Return m_state
        End Get
        Set(value As State)
            m_state = value
        End Set
    End Property

    Public Property Code() As Long
        Get
            Return m_code
        End Get
        Set(value As Long)
            m_code = value
        End Set
    End Property
End Class
