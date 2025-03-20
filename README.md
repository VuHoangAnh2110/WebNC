# MVC04 - Hệ Thống Quản Lý Sản Phẩm

## 📌 Giới Thiệu
MVC04 là một dự án ASP.NET Core MVC, cung cấp chức năng quản lý sản phẩm, bình luận và hiển thị lịch sử sản phẩm đã xem của người dùng.

## 🚀 Công Nghệ Sử Dụng
- ASP.NET Core MVC
- Entity Framework Core (EF Core)
- SQL Server
- Newtonsoft.Json để xử lý JSON
- Bootstrap 5 để thiết kế giao diện

## 📂 Cấu Trúc Dự Án
```
MVC04/
│-- Controllers/      # Chứa các controller xử lý logic
│-- Models/           # Chứa các model dữ liệu
│-- Views/            # Chứa giao diện người dùng
│-- wwwroot/          # Chứa tài nguyên tĩnh (CSS, JS, hình ảnh,...)
│-- appsettings.json  # Cấu hình ứng dụng
│-- Program.cs        # Cấu hình và khởi động ứng dụng
```

## ⚙️ Cài Đặt

### 1️⃣ Yêu Cầu Hệ Thống
- .NET SDK 6.0+
- SQL Server
- Visual Studio 2022 hoặc VS Code

### 2️⃣ Cài Đặt Dự Án
Clone repo về máy:
```sh
git clone https://github.com/VuHoangAnh2110/WebNC.git
cd MVC04
```
Cài đặt các package cần thiết:
```sh
dotnet restore
```

### 3️⃣ Cấu Hình Cơ Sở Dữ Liệu
Mở `appsettings.json` và chỉnh sửa chuỗi kết nối:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=NAME_DATABASE;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
}
```
Chạy migration để tạo database:
```sh
dotnet ef database update
```

### 4️⃣ Chạy Ứng Dụng
```sh
dotnet run
```
Truy cập: [http://localhost:5000](http://localhost:5000)

## 🔥 Chức Năng Chính
### ✅ Quản Lý Sản Phẩm
- Xem danh sách sản phẩm
- Xem chi tiết sản phẩm
- Lưu sản phẩm đã xem vào session

### ✅ Bình Luận Sản Phẩm
- Người dùng có thể bình luận
- Hiển thị danh sách bình luận

### ✅ Quản Lý Người Dùng
- Đăng nhập / Đăng xuất
- Quản lý session

## 📜 Cách Xử Lý Lịch Sử Sản Phẩm Đã Xem
Khi người dùng xem sản phẩm, hệ thống lưu trữ vào session:
```csharp
HttpContext.Session.SetString("ViewedProducts", JsonConvert.SerializeObject(viewedProducts));
```

## 📬 Liên Hệ
- **Tác giả**: Vũ Hoàng Anh
- **Email**: @example.com

