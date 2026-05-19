# 🚀 Görev Takip Premium (To-Do List)

Bu proje, .NET 8.0 ASP.NET Core MVC mimarisi kullanılarak geliştirilmiş, modern ve premium özelliklere sahip bir görev yönetim sistemidir.

## ✨ Özellikler

- **Premium UI**: Modern tasarım, yumuşak geçişler ve profesyonel renk paleti.
- **Sürükle-Bırak (Drag & Drop)**: Görevlerin durumunu (Yapılacaklar, Devam Edenler, Tamamlananlar) sürükleyerek kolayca güncelleyin.
- **Gece Modu (Dark Mode)**: JavaScript ve CSS değişkenleri ile göz yormayan gece modu desteği.
- **Admin Dashboard**: Chart.js kullanarak veritabanındaki verilerin (görev dağılımı, kullanıcı istatistikleri vb.) görselleştirilmesi.
- **Dışa Aktarma (Export)**: Listelenen verilerin Excel ve PDF formatında indirilmesi (DataTables Buttons ile).
- **Admin Kontrolü**: Adminlerin kullanıcılara görev atayabilmesi ve kullanıcıların tamamlama yüzdelerini takip edebilmesi.
- **Kimlik Doğrulama (Identity)**: Kullanıcı kayıt ve giriş sistemi.

## 🛠️ Kullanılan Teknolojiler

- **Backend**: .NET 8.0, ASP.NET Core MVC
- **Database**: SQL Server (LocalDB), Entity Framework Core
- **Frontend**: Bootstrap 5, FontAwesome 6, CSS Variables
- **Kütüphaneler**: 
  - [SortableJS](https://sortablejs.github.io/Sortable/) (Drag & Drop)
  - [Chart.js](https://www.chartjs.org/) (Grafikler)
  - [DataTables](https://datatables.net/) (Tablo Yönetimi & Export)
  - [SweetAlert2](https://sweetalert2.github.io/) (Şık Bildirimler)

## 📸 Ekran Görüntüleri

> [!NOTE]
> Proje çalıştırıldığında aşağıdaki alanlar görülebilir.

### 1. Kanban Board (Sürükle-Bırak Paneli)
![Kanban Board](https://via.placeholder.com/800x450.png?text=Kanban+Board+Preview)

### 2. Admin Dashboard & Grafikler
![Admin Dashboard](https://via.placeholder.com/800x450.png?text=Admin+Dashboard+Preview)

### 3. Gece Modu Desteği
![Dark Mode](https://via.placeholder.com/800x450.png?text=Dark+Mode+Preview)

## 🚀 Kurulum

1. Projeyi Visual Studio 2022 ile açın.
2. `appsettings.json` dosyasındaki bağlantı dizesini kontrol edin.
3. Paket Yöneticisi Konsolu'nu açın ve şu komutları çalıştırın:
   ```bash
   dotnet ef database update
   ```
4. Projeyi `F5` tuşu ile başlatın.

---
**Geliştiren:** Ali Mert
**Ders:** 11-A Web Tabanlı Uygulama Geliştirme
