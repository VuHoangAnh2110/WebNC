MVC04 - Hệ Thống Quản Lý Sản Phẩm

📌 Giới Thiệu

MVC04 là một dự án ASP.NET Core MVC, cung cấp chức năng quản lý sản phẩm, bình luận và hiển thị lịch sử sản phẩm đã xem của người dùng.

🚀 Công Nghệ Sử Dụng

ASP.NET Core MVC

Entity Framework Core (EF Core)

SQL Server

Newtonsoft.Json để xử lý JSON

Bootstrap 5 để thiết kế giao diện

📂 Cấu Trúc Dự Án

⚙️ Cài Đặt

1️⃣ Yêu Cầu Hệ Thống

.NET SDK 6.0+

SQL Server

Visual Studio 2022 hoặc VS Code

2️⃣ Cài Đặt Dự Án

3️⃣ Cấu Hình Cơ Sở Dữ Liệu

Mở appsettings.json và chỉnh sửa chuỗi kết nối:

Chạy migration để tạo database:

4️⃣ Chạy Ứng Dụng

Truy cập: http://localhost:5000

🔥 Chức Năng Chính

✅ Quản Lý Sản Phẩm

Xem danh sách sản phẩm

Xem chi tiết sản phẩm

Lưu sản phẩm đã xem vào session

✅ Bình Luận Sản Phẩm

Người dùng có thể bình luận

Hiển thị danh sách bình luận

✅ Quản Lý Người Dùng

Đăng nhập / Đăng xuất

Quản lý session

📜 Cách Xử Lý Lịch Sử Sản Phẩm Đã Xem

Khi người dùng xem sản phẩm, hệ thống lưu trữ vào session:

Nếu gặp lỗi vòng lặp JSON (Self referencing loop), có thể dùng:

📬 Liên Hệ

Tác giả: Your Name

Email: your-email@example.com

GitHub: github.com/your-repo

