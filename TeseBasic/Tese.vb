
Imports System
Imports System.Collections
Imports System.Globalization
Imports System.IO
Imports System.Numerics
Imports System.Reflection
Imports System.Text
Imports Kajabity.Tools.Java

Public Class Tese
    Private Const emptyPrefix As String = ""

    Public Function Deserialize(Of T)(text As String) As T
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(text)
        Using mem As New MemoryStream(bytes)
            Return Deserialize(Of T)(mem)
        End Using
    End Function

    Public Function Deserialize(Of T)(stream As Stream) As T
        Try
            Dim props As New JavaProperties()
            props.Load(stream)
            Return DirectCast(DeserializeFields(emptyPrefix, props, GetType(T)), T)
        Catch e As IOException
            Throw New TeseReadException(e)
        End Try
    End Function

    Private Function DeserializeFields(prefix As String, props As IDictionary, type As Type) As Object
        Try
            Dim obj As Object = Activator.CreateInstance(type)
            Dim fields As FieldInfo() = type.GetFields(BindingFlags.NonPublic Or BindingFlags.Instance)
            For Each field As FieldInfo In fields
                DeserializeField(prefix, obj, field, props)
            Next
            Return obj
        Catch e As Exception
            Throw New TeseReadException(e)
        End Try
    End Function

    Private Sub DeserializeField(prefix As String, obj As Object, field As FieldInfo, props As IDictionary)
        Try
            Dim key As String = field.Name
            Dim objKey As String = String.Format("{0}.{1}", prefix, key)
            Dim val As Object = props(objKey)
            If val Is Nothing Then
                If FindLongerKey(props, objKey) Then
                    ' field.setAccessible(true);
                    field.SetValue(obj, DeserializeFields(objKey, props, field.FieldType))
                End If
                Return
            End If
            ' field.setAccessible(true);
            field.SetValue(obj, FromStr(val.ToString(), field))
        Catch e As Exception
            Throw New TeseReadException(e)
        End Try
    End Sub

    Private Function FindLongerKey(props As IDictionary, shortKey As String) As Boolean
        For Each key As Object In props.Keys
            If key.ToString().StartsWith(shortKey, StringComparison.InvariantCulture) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function FromStr(val As String, field As FieldInfo) As Object
        Dim type As Type = field.FieldType
        If type.IsEnum Then
            Return [Enum].Parse(type, val)
        End If
        Dim cult As CultureInfo = CultureInfo.InvariantCulture
        Select Case type.Name
            Case "Boolean"
                Return [Boolean].Parse(val)
            Case "Byte"
                Return [Byte].Parse(val)
            Case "Char"
                Return [Char].Parse(val)
            Case "Single"
                Return [Single].Parse(val, cult)
            Case "Double"
                Return [Double].Parse(val, cult)
            Case "Int32"
                Return Int32.Parse(val)
            Case "Int16"
                Return Int16.Parse(val)
            Case "Int64"
                Return Int64.Parse(val)
            Case "BigInteger"
                Return BigInteger.Parse(val, cult)
            Case "Decimal"
                Return Decimal.Parse(val, cult)
            Case "DateTime"
                Return DateTime.Parse(val, cult).ToUniversalTime()
            Case "String"
                Return val
            Case Else
                Throw New InvalidOperationException(type & " is not supported!")
        End Select
    End Function

    Public Function Serialize(obj As Object) As String
        Dim bytes As Byte()
        Using mem As New MemoryStream()
            Serialize(obj, mem)
            bytes = mem.ToArray()
        End Using
        Return Encoding.UTF8.GetString(bytes)
    End Function

    Public Sub Serialize(obj As Object, writer As Stream)
        Try
            Dim props As New JavaProperties()
            SerializeFields(emptyPrefix, obj, props)
            props.Store(writer, Nothing)
        Catch e As IOException
            Throw New TeseWriteException(e)
        End Try
    End Sub

    Private Sub SerializeFields(prefix As String, obj As Object, props As IDictionary)
        Dim type As Type = obj.[GetType]()
        Dim fields As FieldInfo() = type.GetFields(BindingFlags.NonPublic Or BindingFlags.Instance)
        For Each field As FieldInfo In fields
            SerializeField(prefix, obj, field, props)
        Next
    End Sub

    Private Sub SerializeField(prefix As String, obj As Object, field As FieldInfo, props As IDictionary)
        Try
            Dim key As String = field.Name
            ' field.setAccessible(true);
            Dim val As Object = field.GetValue(obj)
            Dim objKey As String = String.Format("{0}.{1}", prefix, key)
            Try
                props(objKey) = ToStr(val, field)
            Catch generatedExceptionName As InvalidOperationException
                SerializeFields(objKey, val, props)
            End Try
        Catch e As Exception
            Throw New TeseWriteException(field, e)
        End Try
    End Sub

    Private Function ToStr(value As Object, field As FieldInfo) As String
        Dim type As Type = field.FieldType
        If type.IsEnum Then
            Return value.ToString()
        End If
        Dim cult As CultureInfo = CultureInfo.InvariantCulture
        Select Case type.Name
            Case "DateTime"
                Return DirectCast(value, DateTime).ToString("yyyy-MM-dd'T'HH:mm:ss.fffzzz")
            Case "Single"
                Return CSng(value).ToString(cult)
            Case "Double"
                Return CDbl(value).ToString(cult)
            Case "Decimal"
                Return CDec(value).ToString(cult)
            Case "Boolean", "BigInteger", "Int64", "Char", "Int32", "Byte", _
             "Int16", "String"
                Return value.ToString()
            Case Else
                Throw New InvalidOperationException(type & " is not supported!")
        End Select
    End Function
End Class
