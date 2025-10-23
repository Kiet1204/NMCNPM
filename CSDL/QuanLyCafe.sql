



-- ==========================
-- TẠO DATABASE
-- ==========================
CREATE DATABASE QuanLyCafe;
GO
USE QuanLyCafe;
GO

-- ==========================
-- BẢNG NHÂN VIÊN
-- ==========================
CREATE TABLE NhanVien (
    MaNV VARCHAR(10) NOT NULL PRIMARY KEY,
    TenNV NVARCHAR(200) NULL,
    GioiTinh NVARCHAR(20) NULL,
    SDT NVARCHAR(30) NULL,
    NgayVaoLam DATE NULL,
    MatKhau NVARCHAR(128) NULL,
    Quyen NVARCHAR(100) NULL,
    LuongCoBanTheoGio DECIMAL(10,2) NULL
);


INSERT INTO NhanVien (MaNV, TenNV, GioiTinh, SDT, NgayVaoLam, MatKhau, Quyen, LuongCoBanTheoGio)
VALUES
('NGUYET', N'Nguyễn Văn A', N'Nữ', '0214521256', '2002-08-11', 
 '120420', N'Quản trị viên', NULL),

('NV001', N'Nguyễn Văn A', N'Nam', '0123456789', '2002-01-01', 
 '13abcc5c2a75188406a4ce39655a9f4878c352b287c9caf1c83c44b13f4f16c7', N'Nhân viên', 20000.00),

('NV002', N'Trần Thị B', N'Nữ', '0987654321', '2002-01-05', 
 'bef57ec7f53a6d40beb640a780a639c83bc29ac8a9816f1f6c4a2d7b9a5e4b7d', N'Nhân viên', NULL);


-- ==========================
-- BẢNG KHÁCH HÀNG
-- ==========================
CREATE TABLE KhachHang (
    MaKH INT NOT NULL,                 -- Mã khách hàng, kiểu số nguyên, không NULL
    TenKH NVARCHAR(200) NULL,          -- Tên khách hàng, có thể NULL
    SDT NVARCHAR(30) NULL,             -- Số điện thoại, có thể NULL
    DiaChi NVARCHAR(510) NULL,         -- Địa chỉ, có thể NULL
    CONSTRAINT PK_KhachHang_2725CF1E16F484EB PRIMARY KEY CLUSTERED (MaKH ASC)
);
GO

-- ==========================
-- BẢNG LOẠI ĐỒ UỐNG
-- ==========================
CREATE TABLE LoaiDoUong (
    MaLoai INT NOT NULL,
    TenLoai NVARCHAR(200) NULL,
    CONSTRAINT PK_LoaiDoUong PRIMARY KEY (MaLoai)
);
GO

-- ==========================
-- BẢNG ĐỒ UỐNG
-- ==========================
CREATE TABLE DoUong (
    MaDU VARCHAR(10) NOT NULL,
    TenDU NVARCHAR(200) NULL,
    MaLoai INT NULL,
    DonGia DECIMAL(10, 2) NULL,
    CONSTRAINT PK_DoUong PRIMARY KEY (MaDU),
    CONSTRAINT FK_DoUong_MaLoai FOREIGN KEY (MaLoai) REFERENCES LoaiDoUong(MaLoai)
);
GO

-- ==========================
-- BẢNG BÀN
-- ==========================
CREATE TABLE Ban (
    MaBan INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    SucChua INT NULL,
    TrangThai NVARCHAR(100) NULL
);
GO

-- ==========================
-- BẢNG HÓA ĐƠN
-- ==========================
CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) NOT NULL,
    NgayLap DATETIME NULL,
    MaNV VARCHAR(10) NULL,
    MaKH INT NULL,
    MaBan INT NULL,
    TongTien DECIMAL(9,2) NULL,
    TrangThai NVARCHAR(100) NULL,
    CONSTRAINT PK_HoaDon PRIMARY KEY (MaHD),
    CONSTRAINT FK_HoaDon_MaNV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_HoaDon_MaKH FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH)
);
GO

-- ==========================
-- BẢNG CHI TIẾT HÓA ĐƠN
-- ==========================
CREATE TABLE ChiTietHoaDon (
    MaHD INT NOT NULL,
    MaDU VARCHAR(10) NOT NULL,
    SoLuong INT NULL,
    DonGia DECIMAL(10,2) NULL,
    ThanhTien DECIMAL(12,2) NULL,
    CONSTRAINT PK_ChiTietHoaDon PRIMARY KEY (MaHD, MaDU),
    CONSTRAINT FK_ChiTietHoaDon_MaHD FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    CONSTRAINT FK_ChiTietHoaDon_MaDU FOREIGN KEY (MaDU) REFERENCES DoUong(MaDU)
);

GO

-- ==========================
-- BẢNG NGUYÊN LIỆU
-- ==========================
CREATE TABLE NguyenLieu (
    MaNL INT IDENTITY(1,1) NOT NULL,
    TenNL NVARCHAR(200) NOT NULL,
    DonViTinh NVARCHAR(100) NOT NULL,
    SoLuongTon FLOAT NULL CONSTRAINT DF_NguyenLieu_SoLuongTon DEFAULT(0),
    SoLuongToiThieu FLOAT NULL CONSTRAINT DF_NguyenLieu_SoLuongToiThieu DEFAULT(0),
    GhiChu NVARCHAR(510) NULL,
    CONSTRAINT PK_NguyenLieu PRIMARY KEY (MaNL)
);
GO

-- ==========================
-- BẢNG CÔNG THỨC ĐỒ UỐNG
-- ==========================
CREATE TABLE CongThucDoUong (
    MaDU VARCHAR(10) NOT NULL,
    MaNL INT NOT NULL,
    SoLuongDung FLOAT NOT NULL,
    CONSTRAINT PK_CongThucDoUong PRIMARY KEY (MaDU, MaNL),
    CONSTRAINT FK_CongThucDoUong_MaDU FOREIGN KEY (MaDU) REFERENCES DoUong(MaDU),
    CONSTRAINT FK_CongThucDoUong_MaNL FOREIGN KEY (MaNL) REFERENCES NguyenLieu(MaNL)
);

GO

-- ==========================
-- BẢNG PHIẾU NHẬP KHO
-- ==========================
CREATE TABLE PhieuNhapKho (
    MaPN INT IDENTITY(1,1) NOT NULL,
    NgayNhap DATETIME NULL CONSTRAINT DF_PhieuNhapKho_NgayNhap DEFAULT (GETDATE()),
    MaNV VARCHAR(10) NOT NULL,
    TongTien MONEY NULL CONSTRAINT DF_PhieuNhapKho_TongTien DEFAULT (0),
    CONSTRAINT PK_PhieuNhapKho PRIMARY KEY (MaPN),
    CONSTRAINT FK_PhieuNhapKho_MaNV FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);
GO

-- ==========================
-- BẢNG CHI TIẾT PHIẾU NHẬP
-- ==========================
CREATE TABLE ChiTietPhieuNhap (
    MaPN INT NOT NULL,
    MaNL INT NOT NULL,
    SoLuongNhap FLOAT NOT NULL,
    DonGiaNhap MONEY NOT NULL,
    CONSTRAINT PK_ChiTietPhieuNhap PRIMARY KEY (MaPN, MaNL),
    CONSTRAINT FK_ChiTietPhieuNhap_MaPN FOREIGN KEY (MaPN) REFERENCES PhieuNhapKho(MaPN),
    CONSTRAINT FK_ChiTietPhieuNhap_MaNL FOREIGN KEY (MaNL) REFERENCES NguyenLieu(MaNL)
);
GO

-- ==========================
-- BẢNG CHẤM CÔNG
-- ==========================
CREATE TABLE ChamCong (
    MaCC INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    MaNV VARCHAR(10) NOT NULL,
    NgayLam DATE NOT NULL,
    GioVao TIME(7) NULL,
    GioRa TIME(7) NULL,
    SoGioLam NUMERIC(17,6) NULL,
    TrangThai NVARCHAR(100) NULL,
    GhiChu NVARCHAR(510) NULL,
    CONSTRAINT FK_ChamCong_NhanVien FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

GO
