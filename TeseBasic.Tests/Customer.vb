
Imports System.Numerics

Public Class Customer
    Private m_id As Long
    Private m_firstName As String
    Private m_lastName As String
    Private m_money As Double
    Private m_male As Boolean
    Private m_home As Address
    Private m_sex As Char
    Private m_houses As Integer
    Private m_pets As Short
    Private m_crazyness As Single
    Private m_bits As Byte
    Private m_sleep As BigInteger
    Private m_awake As Decimal
    Private m_birth As DateTime

    Public Sub New()
    End Sub

    Public Sub New(id As Long, firstName As String, lastName As String, money As Double, male As Boolean, sex As Char, _
     houses As Integer, pets As Short, crazyness As Single, bits As Byte, sleep As BigInteger, awake As Decimal, _
     birth As DateTime, home As Address)
        Me.m_id = id
        Me.m_firstName = firstName
        Me.m_lastName = lastName
        Me.m_money = money
        Me.m_male = male
        Me.m_sex = sex
        Me.m_houses = houses
        Me.m_pets = pets
        Me.m_crazyness = crazyness
        Me.m_bits = bits
        Me.m_sleep = sleep
        Me.m_awake = awake
        Me.m_birth = birth
        Me.m_home = home
    End Sub

    Public Property Id() As Long
        Get
            Return m_id
        End Get
        Set(value As Long)
            m_id = value
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return m_firstName
        End Get
        Set(value As String)
            m_firstName = value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return m_lastName
        End Get
        Set(value As String)
            m_lastName = value
        End Set
    End Property

    Public Property Money() As Double
        Get
            Return m_money
        End Get
        Set(value As Double)
            m_money = value
        End Set
    End Property

    Public Property Male() As Boolean
        Get
            Return m_male
        End Get
        Set(value As Boolean)
            m_male = value
        End Set
    End Property

    Public Property Home() As Address
        Get
            Return m_home
        End Get
        Set(value As Address)
            m_home = value
        End Set
    End Property

    Public Property Sex() As Char
        Get
            Return m_sex
        End Get
        Set(value As Char)
            m_sex = value
        End Set
    End Property

    Public Property Houses() As Integer
        Get
            Return m_houses
        End Get
        Set(value As Integer)
            m_houses = value
        End Set
    End Property

    Public Property Pets() As Short
        Get
            Return m_pets
        End Get
        Set(value As Short)
            m_pets = value
        End Set
    End Property

    Public Property Crazyness() As Single
        Get
            Return m_crazyness
        End Get
        Set(value As Single)
            m_crazyness = value
        End Set
    End Property

    Public Property Bits() As Byte
        Get
            Return m_bits
        End Get
        Set(value As Byte)
            m_bits = value
        End Set
    End Property

    Public Property Sleep() As BigInteger
        Get
            Return m_sleep
        End Get
        Set(value As BigInteger)
            m_sleep = value
        End Set
    End Property

    Public Property Awake() As Decimal
        Get
            Return m_awake
        End Get
        Set(value As Decimal)
            m_awake = value
        End Set
    End Property

    Public Property Birth() As DateTime
        Get
            Return m_birth
        End Get
        Set(value As DateTime)
            m_birth = value
        End Set
    End Property
End Class
