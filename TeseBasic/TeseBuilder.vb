
Public Class TeseBuilder
    Private _skipNull As Boolean

    Public Function SkipNull(value As Boolean) As TeseBuilder
        _skipNull = value
        Return Me
    End Function

    Public ReadOnly Property IsSkipNull() As Boolean
        Get
            Return _skipNull
        End Get
    End Property

    Public Function Create() As Tese
        Return New Tese()
    End Function
End Class
