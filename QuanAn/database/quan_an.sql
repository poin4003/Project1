CREATE DATABASE QuanAnDB 
GO

USE QuanAnDB
GO

ALTER DATABASE QuanAnDb COLLATE SQL_Latin1_General_CP1_CI_AS;
GO

-- Bảng nhân viên
CREATE TABLE NhanVien 
(
    MaNV INT IDENTITY NOT NULL PRIMARY KEY,
    Ten_dang_nhap NVARCHAR(50) NOT NULL,
    Mat_khau NVARCHAR(1000),
    MaCv INT,
    HoTen NVARCHAR(50) DEFAULT N'Chưa có tên',
    Ngay_dau_di_lam DATE NOT NULL,
    Sdt CHAR(11),
    Trang_thai NVARCHAR(50) DEFAULT N'Đang đi làm',
    CONSTRAINT uc_ten_dang_nhap UNIQUE (Ten_dang_nhap),
)   
GO

-- Bảng chức vụ
CREATE TABLE ChucVu
(
    MaCv INT NOT NULL PRIMARY KEY,
    Chuc_vu NVARCHAR(50) DEFAULT N'Nhân viên'
)
GO

-- Bảng Lương cứng
CREATE TABLE BangLuongCung
(
    MaLuongCung INT IDENTITY NOT NULL PRIMARY KEY,
    Luong_theo_gio FLOAT DEFAULT 0,
    MaCV INT NOT NULL
)
GO

-- Bảng lương phụ
CREATE TABLE BangLuongPhu
(
    MaLuongPhu INT IDENTITY NOT NULL PRIMARY KEY,
    Luong_thuong FLOAT DEFAULT 0,
    Luong_phat FLOAT DEFAULT 0,
    Thang_nhap DATE,
)
GO

-- Bảng Thực đơn
CREATE TABLE ThucDon
(
    MaMN INT IDENTITY NOT NULL PRIMARY KEY,
    Ten_mon NVARCHAR(100) DEFAULT N'Chưa có tên',
    Don_gia FLOAT DEFAULT 0,
)
GO

-- Bảng đơn hàng
CREATE TABLE DonHang
(
    MaDH INT IDENTITY NOT NULL PRIMARY KEY,
    MaNV INT NOT NULL,
    khach_dua FLOAT,
    Tien_thua FLOAT,
    Tong_tien FLOAT,
    Ngay DATE,
)
GO

-- Bảng chi tiết hóa đơn
CREATE TABLE ChiTietDonHang
(
    MaCTDH INT IDENTITY NOT NULL PRIMARY KEY,
    MaDH INT NOT NULL,
    MaMN INT NOT NULL,
    So_luong INT DEFAULT 0,
    Ghi_chu NVARCHAR(100) DEFAULT N'Không có ghi chú',
    Thanh_tien FLOAT
)
GO

-- Bảng lịch làm
CREATE TABLE LichLam 
(
    MaLichLam INT IDENTITY NOT NULL PRIMARY KEY,
    MaNV INT NOT NULL,
    Ngay_lam DATE,
    So_gio_lam INT,
)
GO

-- Khóa ngoại Bảng Nhân viên-Chức vụ
ALTER TABLE NhanVien
ADD CONSTRAINT Fk_nvcv
FOREIGN KEY (MaCv)
REFERENCES ChucVu (MaCv)

-- Khóa ngoại chức vụ-bảng lương cứng
ALTER TABLE BangLuongCung
ADD CONSTRAINT Fk_cvlc
FOREIGN KEY (MaCv)
REFERENCES ChucVu (MaCv)

-- Khóa ngoại bảng lịch làm-Nhân viên
ALTER TABLE LichLam
ADD CONSTRAINT Fk_llnv
FOREIGN KEY (MaNV)
REFERENCES NhanVien (MaNV)

-- Khóa ngoại bảng đơn hàng-Nhân viên
ALTER TABLE DonHang
ADD CONSTRAINT Fk_dhnv
FOREIGN KEY (MaNV)
REFERENCES NhanVien (MaNV)

-- Khóa ngoại Chi tiết đơn hàng-đơn hàng
ALTER TABLE ChiTietDonHang
ADD CONSTRAINT Fk_ctdhdh
FOREIGN KEY (MaDH)
REFERENCES DonHang (MaDH)

-- Khóa ngoại Chi tiết hóa đơn-thực đơn
ALTER TABLE ChiTietDonHang
ADD CONSTRAINT Fk_ctdhtd
FOREIGN KEY (MaMN)
REFERENCES ThucDon (MaMN)
GO

-- Proc cho việc lấy nhân viên theo tên
CREATE PROCEDURE USP_GetStaffByUserName
@userName NVARCHAR(50)
AS 
BEGIN 
    SELECT * FROM NhanVien WHERE Ten_dang_nhap = @userName
END
GO

-- Proc cho việc đăng nhập
CREATE PROC USP_login
@userName NVARCHAR(50), @passWord NVARCHAR(1000)
AS
BEGIN
    SELECT * FROM NhanVien WHERE Ten_dang_nhap = @userName AND Mat_khau = @passWord
END
GO

-- Proc cho việc lấy toàn bộ nhân viên
CREATE PROC USP_GetStaff
AS SELECT * FROM NhanVien
GO

-- Proc cho việc lấy thức ăn theo mã đơn hàng
CREATE PROC USP_GetFoodByMaDH
@maDH INT
AS
BEGIN 
    SELECT ctdh.MaCTDH, td.MaMN, td.Ten_mon, td.Don_gia, ctdh.So_luong, ctdh.Ghi_chu, ctdh.Thanh_tien
    FROM ThucDon as td, ChiTietDonHang as ctdh
    WHERE td.MaMN = ctdh.MaMN AND ctdh.MaDH = @maDH
END
GO

-- Proc cho việc lấy thức ăn với 2 cột dữ liệu giả
CREATE PROCEDURE USP_GetFoodWithFixedExtras
AS
BEGIN
    SELECT 
        f.MaMN, f.Ten_mon, f.Don_gia,
        0 AS so_luong,
        N'' AS ghi_chu,
        0 AS Thanh_tien,
        0 AS MaCTDH
    FROM ThucDon AS f
END
GO

-- Proc cho việc lấy đơn hàng theo mã
CREATE PROC USP_GetOrderByMaDH
@maDH INT
AS 
BEGIN
    SELECT * FROM DonHang
    WHERE MaDH = @maDH
END
GO

-- Proc cho việc lấy đơn hàng có id đơn hàng lớn nhất
CREATE PROC USP_GetOrderWithIDMax
AS 
BEGIN
    SELECT *
    FROM DonHang
    WHERE MaDH = (SELECT MAX(MaDH) FROM DonHang)
END
GO

-- Proc cho việc cập thành tiền 
CREATE PROC USP_UpdateThanhTien
AS
BEGIN
    UPDATE ChiTietDonHang 
    SET Thanh_tien = ctdh.So_luong * td.Don_gia 
    FROM ChiTietDonHang ctdh, ThucDon td, DonHang dh
    WHERE ctdh.MaDH = dh.MaDH AND ctdh.MaMN = td.MaMN
END
GO

-- Proc cho việc cập nhật tổng tiền 
CREATE PROC USP_UpdateTongTien
AS
BEGIN
    UPDATE DonHang
    SET Tong_tien = (SELECT SUM(Thanh_tien) FROM ChiTietDonHang ctdh WHERE ctdh.MaDH = dh.MaDH)
    FROM DonHang dh, ChiTietDonHang ctdh
    WHERE dh.MaDH = ctdh.MaDH
END
GO

-- Proc cho việc cập nhật tiền thừa
CREATE PROC USP_UpdateTienThua
AS 
BEGIN
    UPDATE DonHang
    SET Tien_thua = dh.khach_dua - dh.Tong_tien
    FROM DonHang dh
END
GO

-- Proc cho việc lấy mã chi tiết đơn hàng lớn nhất
CREATE PROC USP_GetMaCTDHMAX
AS
BEGIN 
    SELECT MaCTDH
    FROM ChiTietDonHang
    WHERE MaCTDH = (SELECT MAX(MaCTDH) FROM ChiTietDonHang)
END
GO

-- Proc cho việc xóa thức ăn ra khỏi đơn hàng bằng MaCTDH
CREATE PROC USP_DeleteFoodFromChitietdonhang
@maCTDH INT
AS
BEGIN
    DELETE FROM ChiTietDonHang WHERE MaCTDH = @maCTDH
END
GO

CREATE PROC USP_CreateDonHang
@maNV INT , @ngay DATE
AS
BEGIN
    INSERT INTO DonHang(MaNV, Ngay)
    VALUES (@maNV, @ngay)
END
GO

CREATE PROC USP_AddFoodToChitietdonhang
@maDH INT, @maMN INT, @so_luong INT, @ghi_chu NVARCHAR(100), @thanh_tien FLOAT
AS
BEGIN 
    INSERT INTO ChiTietDonHang(MaDH, MaMN, So_luong, Ghi_chu, Thanh_tien) VALUES
    (@maDH, @maMN, @so_luong, @ghi_chu, @thanh_tien)
END
GO

CREATE PROC USP_UpdateDonHang
@maDH INT, @khach_dua FLOAT, @tong_tien FLOAT, @tien_thua FLOAT
AS
BEGIN 
    UPDATE DonHang 
    SET khach_dua = @khach_dua, Tong_tien = @tong_tien, Tien_thua = @tien_thua
    WHERE MaDH = @maDH
END
GO 

-- Proc dùng để thêm món vào thực đơn
CREATE PROC USP_InsertMonToThucDon
@ten_mon NVARCHAR(100), @don_gia FLOAT
AS 
BEGIN
    INSERT INTO ThucDon(Ten_mon, Don_gia) VALUES (@ten_mon, @don_gia)
END
GO

-- Proc dùng đẻ xóa món khỏi thực đơn
CREATE PROC USP_DeleteMonFromThucDon
@maMN INT
AS 
BEGIN
    DELETE FROM ThucDon WHERE MaMN = @maMn
END 
GO

-- Proc dùng để cập nhật món
CREATE PROC USP_UpdateMon
@maMN INT, @ten_mon NVARCHAR(100), @don_gia FLOAT
AS
BEGIN
    UPDATE ThucDon SET Ten_mon = @ten_mon, Don_gia = @don_gia WHERE MaMn = @maMN
END
GO

GO
-- Proc cho việc lấy đơn hàng theo ngày
CREATE PROC USP_GetDonHangByNgay
@Ngay DATE
AS
BEGIN
    SELECT * FROM DonHang WHERE Ngay = @Ngay
END
GO

-- Proc lấy đơn hàng theo ngày và tổng lương != 0
CREATE PROC USP_GetDonHangByNgayFiled
@Ngay DATE
AS
BEGIN
    SELECT * FROM DonHang
    WHERE Ngay = @Ngay AND Tong_tien != 0
END
GO

--EXEC USP_GetDonHangByNgayFiled @Ngay = '2023-9-8'

-- Proc cho việc lấy đơn hàng theo tháng
CREATE PROC USP_GetDonHangByThang
@Ngay DATE
AS
BEGIN
    SELECT * FROM DonHang WHERE DATEPART(month, Ngay) = DATEPART(month, @Ngay)
END
GO

-- Proc cho việc lấy đơn hàng theo tháng và tổng tiền != 0
CREATE PROC USP_GetDonHangByThangFiled
@Ngay DATE
AS
BEGIN
    SELECT * FROM DonHang 
    WHERE DATEPART(month, Ngay) = DATEPART(month, @Ngay) AND Tong_tien != 0 
END
GO

--EXEC USP_GetDonHangByThangFiled @Ngay = '2023-9-8'

-- Proc cho việc tính tổng doanh thu trong ngày
CREATE PROC USP_GetToTalRevenueOnDay
@Ngay DATE
AS 
BEGIN 
    SELECT SUM(Tong_tien) AS Tong_tien
    FROM DonHang
    WHERE Ngay = @Ngay
END
GO

--EXEC USP_GetToTalRevenueOnDay @Ngay = '2023-09-8'

-- Proc cho việc tính tổng doanh thu trong tháng
CREATE PROC USP_GetTotalRevenueOnMonth
@Ngay DATE
AS 
BEGIN
    SELECT SUM(Tong_tien) AS Tong_tien 
    FROM DonHang 
    WHERE DATEPART(month, Ngay) = DATEPART(month, @Ngay)
END
GO

-- Proc cho việc đếm số đơn trong ngày
CREATE PROC USP_GetCountOfOrderOnDay
@Ngay DATE
AS 
BEGIN
    SELECT COUNT(*) AS So_luong
    FROM DonHang
    WHERE Ngay = @Ngay
END
GO

-- Proc cho việc đếm số đơn trong tháng
CREATE PROC USP_GetCountOfOrderOnMonth
@Ngay DATE
AS 
BEGIN 
    SELECT COUNT(*) AS So_luong 
    FROM DonHang
    WHERE DATEPART(month, Ngay) = DATEPART(month, @Ngay)
END
GO

-- Proc cho việc lấy thức ăn theo mà đơn hàng
CREATE PROC USP_GetFoodListByOrderId
@maDH INT
AS 
BEGIN 
    SELECT td.Ten_mon, ctdh.MaMN, ctdh.So_luong
    FROM ChiTietDonHang ctdh, ThucDon td
    WHERE ctdh.MaDH = @maDH AND ctdh.MaMN = td.MaMN
END
GO

-- Lấy nhân viên đã đi làm
CREATE PROC USP_GetFilteredNhanVienByTrangthai 
AS 
BEGIN
    SELECT * FROM NhanVien
    WHERE Trang_thai = N'Đang đi làm'
END
GO

-- Thêm nhân viên
CREATE PROC USP_AddStaff
@ten_dang_nhap NVARCHAR(50), @mat_khau NVARCHAR(1000), @maCv INT, @hoTen NVARCHAR(50), @ngay_dau_di_lam DATE, @sdt CHAR(11), @trang_thai NVARCHAR(50)
AS
BEGIN
    INSERT INTO NhanVien (Ten_dang_nhap, Mat_khau, MaCv, HoTen, Ngay_dau_di_lam, Sdt, Trang_thai) VALUES
    (@ten_dang_nhap, @mat_khau, @maCv, @hoTen, @ngay_dau_di_lam, @sdt, @trang_thai)
END
GO

-- Sửa nhân viên
CREATE PROC USP_EditStaff
@manv INT, @ten_dang_nhap NVARCHAR(50), @mat_khau NVARCHAR(1000), @MaCv INT, @hoTen NVARCHAR(50), @ngay_dau_di_lam DATE, @sdt CHAR(11), @trang_thai NVARCHAR(50)
AS 
BEGIN
    UPDATE NhanVien 
    SET Ten_dang_nhap = @ten_dang_nhap, Mat_khau = @mat_khau, MaCv = @MaCv, HoTen = @hoTen, Ngay_dau_di_lam = @ngay_dau_di_lam, Sdt = @sdt, Trang_thai = @trang_thai
    WHERE MaNV = @manv
END
GO

-- Lấy các ngày làm dựa vào mã nhân viên
CREATE PROC USP_GetCalendarbyMaNV
@manv INT
AS 
BEGIN 
    SELECT * FROM LichLam
    WHERE MaNV = @manv;
END
GO

-- Thêm lịch làm cho nhân viên
CREATE PROC USP_AddCalendar
@ngay_lam DATE, @manv INT, @so_gio_lam INT
AS 
BEGIN
    INSERT INTO LichLam(Ngay_lam, MaNV, So_gio_lam) VALUES
    (@ngay_lam, @manv, @so_gio_lam)
END
GO

-- Sửa lịch làm cho nhân viên
CREATE PROC USP_EditCalendar
@maLichLam INT, @so_gio_lam INT
AS 
BEGIN
    UPDATE LichLam
    SET So_gio_lam = @so_gio_lam
    WHERE MaLichLam = @maLichLam
END
GO

-- Proc lấy lương theo giờ
CREATE PROC USP_GetLuongTheoGioByMaCV
@macv INT
AS
BEGIN
    SELECT MaLuongCung , Luong_theo_gio AS LuongTheoGio
    FROM BangLuongCung
    WHERE MaCV = @macv
END
GO

-- Proc lấy lương phụ
CREATE PROC USP_GetLuongPhuByThangNam
@ThangNam DATE
AS
BEGIN 
    DECLARE @MaLuongPhu INT
    DECLARE @LuongThuong FLOAT
    DECLARE @LuongPhat FLOAT
    
    SELECT @MaLuongPhu = MaLuongPhu, @LuongThuong = Luong_thuong, @LuongPhat = Luong_phat
    FROM BangLuongPhu
    WHERE FORMAT(Thang_nhap, 'yyyy-MM') = FORMAT(@ThangNam, 'yyyy-MM')

    SELECT @MaLuongPhu AS MaLuongPhu, @LuongThuong AS Luong_thuong, @LuongPhat AS Luong_phat
END
GO

--EXEC USP_GetLuongPhuByThangNam @ThangNam = '2022-1-1'

-- Proc Lấy giờ làm theo tháng và mã nhân viên PROC USP_GetGioLam
CREATE PROC USP_GetGioLam
@manv INT, @thang_nhap DATE
AS
BEGIN
    DECLARE @Tong_gio_lam_trong_thang INT
    ;WITH GioLamThang AS (
        SELECT MaNV, FORMAT(Ngay_lam, 'yyyy-MM') AS Thang, SUM(So_gio_lam) AS TongSoGioLam
        FROM LichLam
        WHERE MaNV = @manv AND FORMAT(Ngay_lam, 'yyyy-MM') = FORMAT(@thang_nhap, 'yyyy-MM')
        GROUP BY MaNV, FORMAT(Ngay_lam, 'yyyy-MM')
    )

    SELECT @Tong_gio_lam_trong_thang = TongSoGioLam
    FROM GioLamThang

    SELECT @Tong_gio_lam_trong_thang AS Tong_gio_lam_trong_thang
END
GO

--EXEC USP_GetGioLam @manv = 1, @thang_nhap = '2022-01-01'

-- Proc thêm lương phụ mới 
CREATE PROC USP_InsertAdditionalSalary
@LuongThuong FLOAT, @LuongPhat FLOAT, @Thang_nhap DATE
AS
BEGIN
    INSERT INTO BangLuongPhu(Luong_thuong, Luong_phat, Thang_nhap) VALUES
    (@LuongThuong, @LuongPhat, @Thang_nhap)
END
GO

--EXEC USP_InsertAdditionalSalary @LuongThuong = 10000, @LuongPhat = 2000, @Thang_nhap = '2023-7-1'

-- Proc cập nhật bảng lương phụ
CREATE PROC USP_UpdateAdditionalSalary
@Thang_nhap DATE, @LuongThuong FLOAT, @LuongPhat FLOAT
AS
BEGIN
    UPDATE BangLuongPhu 
    SET Luong_thuong = @LuongThuong, Luong_phat = @LuongPhat
    WHERE FORMAT(Thang_nhap, 'yyyy-MM') = FORMAT(@Thang_nhap, 'yyyy-MM')
END
GO

--EXEC USP_UpdateAdditionalSalary @Thang_nhap = '2022-2-1', @LuongThuong = 6000, @LuongPhat = 2000

-- Proc cập nhật bảng lương cứng
CREATE PROC USP_UpdateBasicSalary
@MaLuongCung INT, @LuongTheoGio FLOAT
AS
BEGIN
    UPDATE BangLuongCung 
    SET Luong_theo_gio = @LuongTheoGio
    WHERE MaLuongCung = @MaLuongCung
END
GO

--EXEC USP_UpdateBasicSalary @MaLuongCung = 1, @LuongTheoGio = 20000

-- Thêm dữ liệu vào bảng chức vụ
INSERT INTO ChucVu (MaCv, Chuc_vu) VALUES
(001, N'Quản lý'),
(002, N'Nhân viên')
GO

-- Thêm nhân viên vào bảng nhân viên
INSERT INTO NhanVien (Ten_dang_nhap, Mat_khau, HoTen, ngay_dau_di_lam, MaCv, Sdt, Trang_thai) VALUES 
(N'Pchuy', N'12345', N'Nguyễn Lê Anh Huy', '2022-10-2', 001, '091111111', N'Đang đi làm'),
(N'Poin', N'54321', N'ABC', '2022-1-1', 002, '03279999999', N'Đang đi làm')
GO

-- Thêm món vào bảng thực đơn
INSERT INTO ThucDon(Ten_mon, Don_gia) VALUES 
(N'Cơm', 10000)

-- Thêm dữ liệu vào đơn hàng
INSERT INTO DonHang(Tien_thua, Tong_tien, Khach_dua, MaNV, Ngay) VALUES
(0, 0, 0, 002, GETDATE())

-- Thêm dữ liệu vào chi tiết đơn hàng
INSERT INTO ChiTietDonHang(MaDH, MaMN, So_luong, Ghi_chu) VALUES
(1, 001, 1, N'')

-- Thêm lương cứng vào bảng lương cứng
INSERT INTO BangLuongCung(Luong_theo_gio, MaCV) VALUES
(20000, 1),
(10000, 2)

SELECT DonHang.MaDH, Ten_mon, So_luong, Ghi_chu,Thanh_tien
FROM DonHang, ChiTietDonHang, ThucDon
WHERE DonHang.MaDH = ChiTietDonHang.MaDH AND ThucDon.MaMN = ChiTietDonHang.MaMN

