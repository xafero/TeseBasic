# TeseBasic
A Visual Basic .NET (VB.NET) port of text serializer library

## How to use?
```vbnet
Dim adr = New Address With {
            .City = New City With {
                .Name = "Berlin", .State = State.UT, .Code = 12345},
            .Street = "Main Road", .Number = 21, .Postal = 42}
			
Dim tese = New TeseBuilder().SkipNull(True).Create
Using writer = File.OpenWrite("test.txt")
    tese.Serialize(adr, writer)
End Using

Using reader = File.OpenRead("test.txt")
    adr = tese.Deserialize(Of Address)(reader)
End Using
```

## Example storing
```
# 03.09.2016 23:32:28
.m_street=Main Road
.m_number=21
.m_postal=42
.m_city.m_name=Berlin
.m_city.m_state=UT
.m_city.m_code=12345
```

## Example loading
![Image of Debugger](https://raw.githubusercontent.com/xafero/TeseBasic/master/doc/debugging.PNG)
