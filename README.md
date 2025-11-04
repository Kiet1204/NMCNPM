Hướng dẫn clone project từ github về máy và chạy test
Yêu cầu môi trường
Trước khi chạy, cần cài sẵn:

✅ Visual Studio 2019/2022

✅ SQL Server 2019/2022 + SQL Server Management Studio (SSMS)

✅ .NET Framework 4.8

✅ Entity Framework 6.0 (được cài tự động khi restore NuGet packages)

Bước 1: Mở visual studio nhấp chọn  

Bước 2:Nhập https://github.com/Kiet1204/NMCNPM.git vào 
Và clone

Bước 3: Tạo Database
Thư mục CSDL trong repo chứa file script SQL tạo database.
Thực hiện như sau:
1.	Mở SQL Server Management Studio (SSMS).
2.	Kết nối tới server.
3.	Mở thư mục CSDL → QuanLyCafe.sql.
4.	Mở file QuanLyCafe.sql.
5.	Nhấn Execute (F5) để chạy script tạo database, bảng, và dữ liệu mẫu.
6.	Sau khi chạy xong, trong mục Databases sẽ xuất hiện database tên QuanLyCafe. Nếu chưa hiện lên hãy tắc SQL Server Management Studio (SSMS) sau đó mở lại. Database sẽ hiện ra giống như hình minh họa. 

Bước 4. Kiểm tra kết nối Database
Mở file:
App.config
Đảm bảo dòng sau vẫn còn:
data source=.;
initial catalog=QuanLyCafe;
integrated security=True;

Bước 5: Khôi phục thư viện (NuGet)
1. Cài lại hoặc kiểm tra Entity Framework
Mở Tools → NuGet Package Manager → Package Manager Console.
Chạy lệnh:
Install-Package EntityFramework
Chờ cài đặt xong, sau đó build lại.

2. Kiểm tra lại các file .cs
Trong các file như CafeModel.Context.cs, CafeModel.cs, v.v…
→ Đảm bảo có dòng:
using System.Data.Entity;
Nếu thiếu thì thêm vào đầu file.

3. Làm sạch và build lại dự án
Vào menu Build → Clean Solution
Sau đó Build → Rebuild Solution
Nếu build thành công, bạn sẽ thấy dòng:
Build: 1 succeeded, 0 failed

Bước 6: Chạy chương trình
Nhấp chọn Start 
Project sẽ chạy bình thường với giao diện WinForms.
Danh sách mật khẩu-tài khoản đăng nhập khi chạy chương trình nằm trong file excel có trong thư mục CSDL khi vừa clone project về.






ình nằm trong file excel có trong thư mục CSDL khi vừa clone project về

