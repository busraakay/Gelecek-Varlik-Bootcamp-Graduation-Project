# 🚀 Gelecek Varlık Bootcamp Bitirme Projesi
Bir sitede yöneticinin aidat ve diğer faturaların yönetimini sağlayan sistemdir.

## ⚙️ Kullanılan Teknolojiler
- ASP.Net 5 ile Entity Framework Core
- AutoMapper
- SOLID Principles
- Dependency Injection
- Extensions kavramı
- Kurumsal Mimaride Proje tasarımı
- CodeFirst yaklaşımı
- Generic yapılar 

#### Proje 6 katmandan oluşur:
- 
  - Entity Layer
  - Data Access Layer
  - Business Logic Layer
  - Interface Layer
  - WebApi
  - MongoApi (Kredi Kartı Servisi)

## 📷 Ekran Görüntüleri
![resim1](https://github.com/busraakay/Gelecek-Varlik-Bootcamp-Graduation-Project/blob/main/Resimler/resim1.PNG)
![resim2](https://github.com/busraakay/Gelecek-Varlik-Bootcamp-Graduation-Project/blob/main/Resimler/resim2.PNG)
![resim3](https://github.com/busraakay/Gelecek-Varlik-Bootcamp-Graduation-Project/blob/main/Resimler/resim3.PNG)
![resim4](https://github.com/busraakay/Gelecek-Varlik-Bootcamp-Graduation-Project/blob/main/Resimler/resim4.PNG)

### Veritabanı Diagramı
![database](https://github.com/busraakay/GelecekVarlikBitirmeOdevi/blob/main/databaseDiagram.PNG)

- Projede ilk başta adminin login olması gerekmektedir. Daha sonra register işlemiyle kullanıcıları ekleyebilir.
- Projede yetkilendirme ve kimlik doğrulaması işlemleri için **ASP.NET Core Identity** kullanılmıştır.
- ASP.NET Core Identity'deki AspNetUsers, AspNetRoles, AspNetUserRoles tabloları aktif olarak kullanılmıştır.
- Messages tablosu mail ile iletilen mesajlar için kullanılmışır.
- Houses tablosu projedeki her bir daire için kullanılmıştır.
- Payments tablosu aidat işlemleri için kullanılmıştır.
- Invoices tablosu fatura(su, doğalgaz, elektrik) işlemleri için kullanılmıştır.
- Ödeme işlemi için CreditCard.WepApi ile mangoDb'den alınan veriler üzerinden hesaplama ve işlemler yapılır.
- Projede React.js ile istenilen arayüz yapımına zaman kalmamıştır.
## 📝 İsterler

Bir sitede yöneticisiniz. Sitenizde yer alan dairelerin aidat ve ortak kullanım elektrik, su ve doğalgaz
faturalarının yönetimini bir sistem üzerinden yapacaksınız.
İki tip kullanıcınız var.

### 1-Admin/Yönetici
- Daire bilgilerini girebilir.
- İkamet eden kullanıcı bilgilerini girer.
- Daire başına ödenmesi gereken aidat ve fatura bilgilerini girer(Aylık olarak). Toplu veya tek
tek atama yapılabilir.
- Gelen ödeme bilgilerini görür.
- Gelen mesajları görür.
- Mesajların okunmuş/okunmamış/yeni mesaj olduğu anlaşılmalı.
- Aylık olarak borç-alacak listesini görür.
- Kişileri listeler, düzenler, siler.
- Daire/konut bilgilerini listeler, düzenler siler.
### 2-Kullanıcı
- Kendisine atanan fatura ve aidat bilgilerini görür.
- Sadece kredi kartı ile ödeme yapabilir.
- Yöneticiye mesaj gönderebilir.
- Mesajların okunmuş/okunmamış/yeni mesaj olduğu anlaşılmalı.
- Yaptığı ödemelerini görür.

### Daire/Konut bilgilerinde
- Hangi blokda
- Durumu (Dolu-boş)
- Tipi (2+1 vb.)
- Bulunduğu kat
- Daire numarası
- Daire sahibi veya kiracı

### Kullanıcı bilgilerinde

- Ad-soyad
- TCNo
- E-Mail
- Telefon
- Araç bilgisi(varsa plaka no)

### Sistem kullanılmaya başladığında ilk olarak

1. Yönetici daire bilgilerini girer.
2. Kullanıcı bilgilerini girer.Giriş yapması için otomatik olarak bir şifre oluşturulur.
3. Kullanıcıları dairelere atar
4. Ay bazlı olarak aidat bilgilerini girer.
5. Ay bazlı olarak fatura bilgilerini girer

Arayüz dışında kullanıcıların kredi kartı ile ödeme yapabilmesi için ayrı bir servis yazılacaktır. <br>
Bu servisde sistemde ki her bir kullanıcı için banka bilgileri(bakiye, kredi kartı no vb.) kontrol edilerek
ödeme yapılması sağlanır. <br>
Ödeme sadece kredi kartı ile yapılabilir. <br>

### Projede kullanılacaklar:

1. Web projesi backend için .Net Core, frontend için React.js kullanın.
2. Sistemin yönetimi/database için MS SQL Server kullanın.
3. Kredi kartı servisi için. Veriler mongodb de tutulacak. Servis .Net WebApi olarak yazılacaktır.
4. Mümkün olduğu kadar derslerde işlenen konular projeye entegre edilmelidir.



## 👩‍💻 Büşra Akay
