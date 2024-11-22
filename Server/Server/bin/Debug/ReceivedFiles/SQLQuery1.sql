-- Bảng Quản lý Nhân viên
CREATE TABLE NhanVien (
    NhanVienID INT PRIMARY KEY IDENTITY,    -- Mã nhân viên
    HoTen NVARCHAR(100) NOT NULL,           -- Họ và tên
    NgaySinh DATE,                          -- Ngày sinh
    GioiTinh NVARCHAR(10),                  -- Giới tính
    DiaChi NVARCHAR(255),                   -- Địa chỉ
    SDT NVARCHAR(15),                       -- Số điện thoại
    Email NVARCHAR(100),                    -- Email
    NgayVaoLam DATE,                        -- Ngày vào làm
    ChucVuID INT,                           -- Mã chức vụ
    PhongBanID INT,                         -- Mã phòng ban
    LuongCoBan DECIMAL(18, 2)               -- Mức lương cơ bản
);

-- Bảng Quản lý Chức vụ
CREATE TABLE ChucVu (
    ChucVuID INT PRIMARY KEY IDENTITY,      -- Mã chức vụ
    TenChucVu NVARCHAR(100),                -- Tên chức vụ
    MoTa NVARCHAR(255)                      -- Mô tả về chức vụ
);

-- Bảng Quản lý Phòng ban
CREATE TABLE PhongBan (
    PhongBanID INT PRIMARY KEY IDENTITY,    -- Mã phòng ban
    TenPhongBan NVARCHAR(100),              -- Tên phòng ban
    MoTa NVARCHAR(255)                      -- Mô tả về phòng ban
);

-- Bảng Quản lý Hợp đồng
CREATE TABLE HopDong (
    HopDongID INT PRIMARY KEY IDENTITY,     -- Mã hợp đồng
    NhanVienID INT FOREIGN KEY REFERENCES NhanVien(NhanVienID),  -- Mã nhân viên
    NgayKy DATE,                            -- Ngày ký hợp đồng
    NgayHetHan DATE,                        -- Ngày hết hạn hợp đồng
    LoaiHopDong NVARCHAR(50),               -- Loại hợp đồng (thử việc, chính thức)
    LuongThoaThuan DECIMAL(18, 2)           -- Mức lương thỏa thuận
);

-- Bảng Quản lý Bảo hiểm
CREATE TABLE BaoHiem (
    BaoHiemID INT PRIMARY KEY IDENTITY,     -- Mã bảo hiểm
    NhanVienID INT FOREIGN KEY REFERENCES NhanVien(NhanVienID),  -- Mã nhân viên
    LoaiBaoHiem NVARCHAR(50),               -- Loại bảo hiểm (Bảo hiểm xã hội, y tế)
    MucDong DECIMAL(18, 2),                 -- Mức đóng bảo hiểm
    NgayBatDau DATE,                        -- Ngày bắt đầu bảo hiểm
    NgayKetThuc DATE                        -- Ngày kết thúc bảo hiểm
);

-- Bảng Quản lý Chấm công
CREATE TABLE ChamCong (
    ChamCongID INT PRIMARY KEY IDENTITY,    -- Mã chấm công
    NhanVienID INT FOREIGN KEY REFERENCES NhanVien(NhanVienID),  -- Mã nhân viên
    NgayChamCong DATE,                      -- Ngày chấm công
    CaLamViec NVARCHAR(50),                 -- Ca làm việc
    ThoiGianVao TIME,                       -- Thời gian vào
    ThoiGianRa TIME,                        -- Thời gian ra
    SoGioLam DECIMAL(5, 2),                 -- Số giờ làm việc
    GhiChu NVARCHAR(255)                    -- Ghi chú về công việc
);

-- Bảng Quản lý Lương
CREATE TABLE Luong (
    LuongID INT PRIMARY KEY IDENTITY,       -- Mã lương
    NhanVienID INT FOREIGN KEY REFERENCES NhanVien(NhanVienID),  -- Mã nhân viên
    ThangLuongID INT,                       -- Mã bảng lương (Liên kết với bảng ThangLuong)
    ThangLuong DECIMAL(18, 2),              -- Mức lương theo tháng
    PhuCap DECIMAL(18, 2),                  -- Phụ cấp
    Thue DECIMAL(18, 2),                    -- Thuế
    LuongThucNhan DECIMAL(18, 2)            -- Lương thực nhận (sau khi trừ thuế và các khoản trừ khác)
);

-- Bảng Quản lý Bảng lương
CREATE TABLE ThangLuong (
    ThangLuongID INT PRIMARY KEY IDENTITY,  -- Mã bảng lương
    MucLuong DECIMAL(18, 2),                -- Mức lương
    GhiChu NVARCHAR(255)                    -- Ghi chú về bảng lương (lương cơ bản, lương theo dự án)
);
