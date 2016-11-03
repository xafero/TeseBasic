
Imports System.Numerics
Imports NUnit.Framework

<TestFixture()>
Public Class TeseTest
    Private tese As Tese

    <SetUp()>
    Public Sub TestSetup()
        tese = (New TeseBuilder()).SkipNull(True).Create()
    End Sub

    <TearDown()>
    Public Sub TestTeardown()
        tese = Nothing
    End Sub

    Private Const txt1 As String = ".firstName=Harry ~ .money=123.89 ~ .pets=13 ~ .houses=42 ~ .home.city.state=IA ~ .home.street=West Ohio Street ~ .home.city.name=Ankeny ~ .sex=m ~ .lastName=Johnson ~ .bits=7 ~ .home.postal=50023 ~ .sleep=10 ~ .home.city.code=1 ~ .id=1 ~ .crazyness=97.5 ~ .male=True ~ .home.number=22 ~ .awake=1 ~ .birth=1970-02-19T02:17:29.348+01:00"

    Private Const secSinceEpoch As Long = 621355968000000000L
    Private Const factor As Integer = 10000

    <Test()>
    Public Sub TestDeserialize()
        Dim cus As Customer = tese.Deserialize(Of Customer)(Deflatten(txt1))
        Assert.AreEqual(1, cus.Id)
        Assert.AreEqual("Harry", cus.FirstName)
        Assert.AreEqual("Johnson", cus.LastName)
        Assert.AreEqual(123.89, cus.Money)
        Assert.AreEqual(True, cus.Male)
        Assert.AreEqual("m"c, cus.Sex)
        Assert.AreEqual(42, cus.Houses)
        Assert.AreEqual(13, cus.Pets)
        Assert.AreEqual(97.5F, cus.Crazyness)
        Assert.AreEqual(CByte(7), cus.Bits)
        Assert.AreEqual(BigInteger.One * 10, cus.Sleep)
        Assert.AreEqual(Decimal.One, cus.Awake)
        Assert.AreEqual(4238249348L, (cus.Birth.Ticks - secSinceEpoch) \ factor)
        Assert.AreEqual(22, cus.Home.Number)
        Assert.AreEqual(50023, cus.Home.Postal)
        Assert.AreEqual("West Ohio Street", cus.Home.Street)
        Assert.AreEqual(1, cus.Home.City.Code)
        Assert.AreEqual("Ankeny", cus.Home.City.Name)
        Assert.AreEqual(State.IA, cus.Home.City.State)
    End Sub

    Private Function Deflatten(txt As String) As [String]
        Dim nl As String = Environment.NewLine
        txt = txt.Replace(" ~ ", nl)
        Return txt
    End Function

    <Test()>
    Public Sub TestSerialize()
        Dim cus As New Customer(1, "Harry", "Johnson", 123.89, True, "m"c, _
         42, CShort(13), 97.5F, CByte(7), BigInteger.One * 10, Decimal.One, _
         New DateTime((4238249348L * factor) + secSinceEpoch + (36000000000L)),
         New Address("West Ohio Street", 22, 50023, New City("Ankeny", State.IA, 1L)))
        Dim txt As String = Flatten(tese.Serialize(cus))
        Assert.AreEqual(txt1, txt)
    End Sub

    Private Function Flatten(txt As String) As [String]
        Dim nl As String = Environment.NewLine
        txt = txt.Split(New String() {nl}, 2, StringSplitOptions.None)(1).Trim()
        txt = txt.Replace(nl, " ~ ")
        Return txt
    End Function
End Class
