# UdemySignalR Projesi

UdemySignalR Projesi, bir restoranın anlık sipariş aldığı, müşteriler tarafından QR kod ile sipariş verilebilen, anlık bildirim, anlık mesajlaşma, anlık istatistik gibi gerçek zamanlı verileri tutan bir uygulamadır.

## Kullanılan Teknolojiler

- MSSQL
- Entity Framework Core 6.0
- Dapper
- N-tier Architecture
- Clean Code
- API (ASP.NET Core Web API)
- MVC (ASP.NET Core MVC)
- ViewComponent
- AWS S3 Bucket
- Repository Design Pattern
- Unit of Work Design Pattern
- DTO
- AutoMapper
- SignalR
- Identity

## Proje Açıklaması

Bu proje, bir restoranın ihtiyaç duyduğu birçok temel özelliği içeren bir web uygulamasıdır. Müşteriler, restorana QR kodlar aracılığıyla kolayca erişebilir ve sipariş verebilirler. Proje, kullanıcıların gerçek zamanlı olarak sipariş durumunu takip etmelerine olanak tanır ve ayrıca restoran personeli ile müşteriler arasında gerçek zamanlı iletişim sağlar.

Proje, temiz bir kod yapılandırmasına ve modüler bir mimariye sahiptir. N-tier mimarisi kullanılarak, uygulama katmanları mantıksal olarak ayrılmıştır. Entity Framework Core ve Dapper gibi ORM (Object-Relational Mapping) araçları kullanılarak veritabanı işlemleri gerçekleştirilir. Repository ve Unit of Work tasarım desenleri kullanılarak veritabanı işlemleri soyutlanmıştır.

SignalR kütüphanesi, gerçek zamanlı iletişim ve bildirim işlevselliğini sağlar. AWS S3 Bucket, medya dosyalarını depolamak ve sunmak için kullanılır.


