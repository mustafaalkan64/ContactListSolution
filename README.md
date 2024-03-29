# Contact List

Bu proje 2 farklı web api projesinden ve farklı layerlardan oluşmaktadır.
Web Api projeleri :

## ContactList.Api

- Kişilerin Listelenmesi,
- Kişilerin Eklenmesi ve Silinmesi
- Kişi İletişim Bilgilerinin Eklenmesi, Silinmesi ve Listelenmnesi
- Kişi Bilgilerinin İletişim Bilgileriyle Detaylarının Getirilmesi
- Raporların Listelenmesi
- Rapor Detaylarının Listelenmesi
- Rapor İsteklerinin Yapılması

## ContactList.Consumer

- ContactList.Api projesinden MassTransit ile RabbitMq queusine publish olan oluşturulmuş rapor taleplerini consume edilerek,
rapor detay bilgilerinin hesaplanıp dbye kaydedildiği bağımsız bir web projesidir.

## Projede Kullanılan Teknolojiler
 
- Asp.net Core 5 Web Api
- Postgres
- EF Core Code First
- Fluent Validation
- Serilog ile Loglama
- AutoMapper
- XUnit Unit Test
- Moq
- EF Core InMemory DbContext

## Projede Kullanılan Tasarımlar ve Principlelar

- Rest Servisleri
- Generic Repository
- Generic Service
- Depedency Injection
- UnitOfWork
- SOLID
- SOA 
- Exception Middleware

## Projenin Ayağa Kaldırılması

- Her iki web projesi içerisindeki (SeturContactList.Api ve SeturContactList.Consumer) appsettings.Development.json içindeki DefaultConnection connection string bilgilerini set edebilirsiniz. Şu an postgres test dataları cloud tabanlı sunucuda saklanmaktadır.
- SeturContactList.Api projesine gelip Package-Manager-Console üzerinden Update-Database komutunu çalıştırın. Veya .NET CLI üzerinden dotnet ef database update komutunu çalıştırabilirisiniz.
- Connection String bilgilerini girdiğiniz database üzerinde tabloları ve seed ettiğim dataları gördüyseniz, solution üzerinden gelip her iki projeyi multiple start ile başlatıp 
RabbitMq ve MassTransit üzerinden her iki uygulamayı publish ve consume edebilirsiniz.



