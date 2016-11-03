
<Serializable()>
Public Class TeseReadException
    Inherits Exception

    Public Sub New(t As Exception)
        MyBase.New("", t)
    End Sub
End Class
