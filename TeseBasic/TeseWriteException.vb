Imports System.Reflection

<Serializable()>
Public Class TeseWriteException
    Inherits Exception

    Public Sub New(t As Exception)
        MyBase.New("", t)
    End Sub

    Public Sub New(field As FieldInfo, e As Exception)
        MyBase.New(Convert.ToString(field) & "", e)
    End Sub
End Class
