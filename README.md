☕ Phần mềm Quản lý Quán Cà Phê (WinForms - C#)
🎯 Mục đích dự án

Phần mềm Quản lý Quán Cà Phê được xây dựng nhằm hỗ trợ các chủ quán trong việc:

Quản lý bàn, đồ uống, loại đồ uống, hóa đơn, khách hàng, kho nguyên liệu, nhân viên.

Hỗ trợ quy trình gọi món, tính tiền, thanh toán hóa đơn và báo cáo doanh thu, lợi nhuận.

Giúp tự động hóa các công việc thủ công, giảm sai sót và tăng hiệu quả quản lý.

🧩 Các công nghệ chính sử dụng
Thành phần:	Công nghệ

Ngôn ngữ lập trình:	C# (.NET Framework)

Giao diện người dùng:	Windows Forms (WinForms)

Cơ sở dữ liệu:	Microsoft SQL Server

ORM:	Entity Framework (Database-First)

IDE phát triển:	Visual Studio

Hệ thống quản lý: mã nguồn	Git & GitHub

1️⃣ Yêu cầu hệ thống

Windows 10/11

Visual Studio 2019/2022 (có cài đặt workload .NET Desktop Development)

SQL Server (hoặc SQL Server Express)

.NET Framework 4.7.2 hoặc cao hơn

2️⃣ Các bước cài đặt

B1: Clone dự án từ GitHub

git clone https://github.com/Kiet1204/NMCNPM.git

B2: Mở file solution

Mở file QuanLyCafe.sln trong Visual Studio.

B3: Cấu hình chuỗi kết nối (Connection String)

Mở file App.config

Sửa lại phần:

<connectionStrings>
  <add name="QuanLyCafeEntities"
       connectionString="metadata=res://*/QuanLyCafeModel.csdl|res://*/QuanLyCafeModel.ssdl|res://*/QuanLyCafeModel.msl;
       provider=System.Data.SqlClient;
       provider connection string=&quot;data source=.\SQLEXPRESS;initial catalog=QuanLyCafe;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework&quot;" 
       providerName="System.Data.EntityClient" />
</connectionStrings>

→ thay .\SQLEXPRESS bằng tên SQL Server trên máy của bạn nếu cần.

B4: Khởi tạo cơ sở dữ liệu

Mở SQL Server Management Studio (SSMS)

Chạy file QuanLyCafe.sql (vào thư mục CSDL của project nhấn chọn QuanLyCafe) để tạo cơ sở dữ liệu và các bảng.

B5: Chạy chương trình

Nhấn F5 hoặc chọn Start Debugging trong Visual Studio.
