# Contact List Case Çalışması

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

## ContactList.Consume

- ContactList.Api projesinden MassTransit ile RabbitMq queusine publish olan oluşturulmuş rapor isteklerinin consume edilerek,
rapor detay bilgilerinin hesaplanıp dbye kaydedildiği bağımsız bir web projesidir.

## Projede Kullanılan Teknolojiler
 
- Asp.net Core 5 Web Api
- Postgres
- Entity Framework Code First
- Fluent Validation
- Serilog ile File üzerinde loglama sağlanması
- AutoMapper
- XUnit Unit Test
- Moq

## Projede Kullanılan Tasarımlar ve Principlelar

- Generic Repository
- Generic Service
- Depedency Injection
- UnitOfWork
- SOLID
- SOA 
- Exception Middleware

## Projenin Ayağa Kaldırılması

- Her iki web projesi içerisindeki (SeturContactList.Api ve SeturContactList.Consume) appsettings.Development.json içindeki DefaultConnection connection string bilgilerini set edin.
- SeturContactList.Api projesine gelip Package-Manager-Console üzerinden Update-Database komutunu çalıştırın. Veya .NET CLI üzerinden dotnet ef database update komutunu çalıştırabilirisiniz.
- Connection String bilgilerini girdiğiniz database üzerinde tabloları ve seed ettiğim dataları gördüyseniz, solution üzerinden gelip her iki projeyi multiple start ile başlatıp 
RabbitMq ve MassTransit üzerinden her iki uygulamayı publish ve consume edebilirsiniz.



