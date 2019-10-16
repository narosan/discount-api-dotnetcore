**API DotNet Core**
===
*Após o `git clone`, é necessário navegar para dentro do diretório e 
utilizar o comando `dotnet run`*
---
O End Point é `localhost:5000/promotion`
Metodo -> `GET`
---
Exemplo do JSON para utilizar
`
{
 "_id": "5d8a8bb3751cbf9ce00b5b6d",
 "Date": "2019-09-24T21:33:38.929Z",
 "TotalPrice": "93.00000",
 "Sessions": {
 "Event": {
 "Id": 20988,
 "Name": "It - Capítulo 2"
 },
 "Date": "2019-10-19T20:00:00.000Z",
 "Theatre": {
 "Id": 6,
 "Name": "Roxy"
 },
 "Tickets": [
 {
 "Id": 23,
 "Name": "Meia",
 "Price": "31.00000"
 },
 {
 "Id": 45,
 "Name": "Inteira",
 "Price": "62.00000"
 }
 ]
 },
 "Promocode": "b9E65dCf"
}
`