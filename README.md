# MovieOnline
Website xem phim online cho phía người dùng và quản lý phim cho phía quản trị, ứng dụng sử dụng công nghệ: ngôn ngữ C# MVC ASP.net và MS SQL Server

# Cách cài đặt ứng dụng
- Cài đặt môi trường cần thiết cho ứng dụng (IDE: Visual Studio, hệ quản trị MS SQL Server, các plugin cần thiết như PagedList, v.v...)
- Tạo cơ sở dữ liệu bằng cách add file .mdf và .ldf vào thư mực lưu trữ CSDL của SQL Server, thường đường dẫn sẽ là "C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\", sau đó vào attach database bằng MS SQL Studio
- Sau khi add Database thành công, tiến hành chỉnh sửa đường link kết nối đến CSDL trong ứng dụng trong tệp 'web.config'

# Mô tả
- Ứng dụng chia làm 2 phần cho Client và Amdin
