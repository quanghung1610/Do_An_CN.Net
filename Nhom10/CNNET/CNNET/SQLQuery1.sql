CREATE DATABASE QLSHOPQUANAO 
GO
USE QLSHOPQUANAO
GO
use Master
drop database QLSHOPQUANAO
CREATE TABLE SANPHAM
(
MASP char(5) not null,
MALOAI CHAR(5) NOT NULL,
TENSP Nvarchar(50) ,
GIABANTHAMKHAO INT,
SIZE INT,
CHATLIEU CHAR(5),
MAUSAC NCHAR(10),
HINH image,
Constraint PK_SP Primary Key(MASP)
)


select * from SANPHAM
DELETE FROM SANPHAM


select * from SANPHAM where TENSP like'%Á%'

CREATE TABLE LOAI
( 
	MALOAI CHAR(5) NOT NULL,
	TENLOAI NVARCHAR(30),
	CONSTRAINT PK_LA PRIMARY KEY(MALOAI)
)
insert into Loai
Values ('L01',N'Áo tay dài'),
	   ('L02',N'Quần Dài'),
	   ('L03',N'Áo thun'),
	   ('L04',N'Quần Jean'),
	   ('L05',N'Áo tay dài') 
SELECT * FROM LOAI
DELETE FROM LOAI
CREATE TABLE KHACH
(
	MAKH char(5) not null,
	TENKH nvarchar(50),
	NGAYSINH DATE,
	NGAYDK DATE ,CHECK(NGAYDK>NGAYSINH),
	GTINH NVARCHAR(5),
	DCHI nvarchar(50),
	SDT NCHAR(11),
	Constraint PK_KH Primary Key(MAKH)
)
set dateformat dmy
insert into KHACH 
values('KH001',N'Nguyễn Thành Trung','12/09/1998','12/12/2019',N'Nam',N'Tân Phú','0987643245'),
	  ('KH002',N'Nguyễn Thị Thanh Thúy','08/10/1997','07/11/2020',N'Nữ',N'Quận 4','0978326150'),
	  ('KH003',N'Trần Thanh Nhung','01/10/1996','08/12/2020',N'Nữ',N'Bình Tân','0351197541'),
	  ('KH004',N'Nguyễn Quốc Sơn','12/10/1998','07/12/2020',N'Nam',N'Quận 2','0986163186'),
	  ('KH005',N'Nguyễn Hồng Văn','06/3/1995','09/7/2020',N'Nữ',N'Long An','0354269441'),
      ('KH006',N'Lê Quốc Tuấn','01/5/1999','09/6/2020',N'Nam',N'Quận 8','0361582648')
SELECT * FROM KHACH

CREATE TABLE NHANVIEN
(
	MANV CHAR(5) NOT NULL, --PHAN QUYEN
	TENNV NVARCHAR(50),
	NGAYSINH DATE,
	GTINH NVARCHAR(5),
	NGAYVAOLAM DATE,
	DCHI nvarchar(50),
	SDT NCHAR(11),
	USERNAME char(50),
	PASSW char(50),
	QUYEN NVARCHAR(50),
	CONSTRAINT FK_NV PRIMARY KEY(MANV)
)
drop table Nhanvien
insert into NHANVIEN 
values('NV001',N'Nguyễn Văn Nam','09/12/1999',N'Nam','04/11/2019',N'TP HCM','0356126709',N'NhanVien','123','NhanVien'),
('NV002',N'Trần Văn Hiền','09/10/1999',N'Nam','03/11/2019',N'Tân Phú','0376178634',N'Admin','123','Admin'),
('NV003',N'Nguyễn Thúy Nga','09/11/1998',N'Nữ','02/12/2019',N'Quận 12','0375712098',N'NhanVien','123','NhanVien'),
('NV004',N'Hồ Thị My','09/5/1999',N'Nữ','05/12/2019',N'Quận 6','0971422801',N'NhanVien','123','NhanVien'),
('NV005',N'Lê Trần Quốc Bảo','12/12/2000',N'Nam','06/12/2019',N'Bình Chánh','0717482640',N'NhanVien','123','Admin')
SELECT * FROM NHANVIEN
DELETE FROM NHANVIEN

insert into NHANVIEN 
values('NV015',N'Nguyễn Văn A','09/12/1998',N'Nam','04/11/2018',N'TP HCM','0356126719','NV','456',N'NhanVien')

CREATE TABLE HOADON
(
	MAHD char(5) not null,
	NGAYBAN DATE,
	MAKH CHAR(5),
	MANV CHAR(5),
	GIAMGIA FLOAT,	--GIAM TREN CA HOA DON
	THANHTOAN FLOAT,
	Constraint PK_HD Primary Key(MAHD)
)
SET DATEFORMAT DMY
insert into HOADON 
values ('HD01','12/08/2020','KH001','NV002',5,250000),
	   ('HD02','13/09/2019','KH003','NV004',10,200000),
	   ('HD03','15/10/2018','KH002','NV003',5,170000),
	   ('HD04','20/04/2020','KH004','NV001',5,130000),
	   ('HD05','19/09/2020','KH005','NV005',10,200000),
	   ('HD06','20/08/2020','KH006','NV006',10,200000)
SELECT * FROM HOADON

CREATE TABLE CHITIETHD
(
	MAHD char(5) NOT NULL,
	MASP char(5) NOT NULL,
	SOLUONG INT,
	GIABAN INT,	
	THANHTIEN FLOAT,
	Constraint PK_CTHD Primary Key(MAHD,MASP)
)
insert into CHITIETHD
values ('HD01','SP03',2,300000,600000),
	   ('HD02','SP01',1,500000,500000),
	   ('HD03','SP02',2,250000,500000),
	   ('HD04','SP05',2,400000,800000),
	   ('HD05','SP04',3,200000,600000)
SELECT * FROM CHITIETHD
DELETE FROM CHITIETHD
CREATE TABLE NHACUNGCAP
(
	MACC CHAR(5) NOT NULL,
	TENNCC NVARCHAR(50),
	DCHI varchar(30),
	SDT NCHAR(11),
	CONSTRAINT PK_NC PRIMARY KEY(MACC)
)

insert into NHACUNGCAP
values('CC01',N'Công Ty TNHH Một Thành Viên',N'Đồng Khởi','0938687118'),
	  ('CC02',N'Đạt Tiến',N'Quận Phú Nhuận','0978613621'),
	  ('CC03',N'Xưởng May Jeans Thuận Hải',N'Linh Đông,Thủ Đức','0975617511'),
	  ('CC04',N'Công Ty TNHH May Nguồn Lực',N'Q.12, TP.HCM','0975412387'),
	  ('CC05',N'Công Ty TNHH May Mặc Chiến Lược Xanh',N'Tân Bình','0917614399')
SELECT * FROM NHACUNGCAP

CREATE TABLE NHAPHANG
(
	MANH CHAR(5) NOT NULL,
	MACC CHAR(5),
	NGAYNHAP DATE,
	TONGTIEN FLOAT,
	CONSTRAINT PK_NH PRIMARY KEY(MANH)
)

insert into NHAPHANG
values('NH01','CC01','17/10/2011',53000000),
	  ('NH02','CC03','12/06/2017',50000000),
	  ('NH03','CC05','19/06/2019',20000000),
	  ('NH04','CC02','16/01/2020',14000000),
	  ('NH05','CC04','05/03/2020',30000000)
select * from NHAPHANG

CREATE TABLE CHITIETNHAPHANG
(
	MANH char(5) NOT NULL,
	MASP char(5) NOT NULL,
	GIANHAP INT,	
	THANHTIEN FLOAT,
	Constraint PK_CTNH Primary Key(MANH,MASP)
)
insert into CHITIETNHAPHANG
values ('NH01','SP02',300000,600000),
	   ('NH02','SP01',500000,500000),
	   ('NH03','SP04',250000,500000),
	   ('NH04','SP05',400000,800000),
	   ('NH05','SP03',300000,900000)
SELECT * FROM CHITIETNHAPHANG
DELETE FROM CHITIETNHAPHANG

CREATE TABLE QUYEN
(
	IDQUYEN CHAR(5) NOT NULL,
	TENQUYEN NVARCHAR(50),
	CONSTRAINT PK_DN PRIMARY KEY(IDQUYEN)
)
drop table QUYEN
insert into QUYEN
values('AD','ADMIN'),
('NV','NHANVIEN')
select * from QUYEN

GO
--------------------------------------KHOA NGOAI---------------------------------------------
ALTER TABLE SANPHAM ADD Constraint fk_SP Foreign Key(MALOAI) references LOAI(MALOAI)
ALTER TABLE NHAPHANG ADD Constraint fk_NH Foreign Key(MACC) references NHACUNGCAP(MACC)
ALTER TABLE HOADON ADD Constraint fk_HD Foreign Key(MAKH) references KHACH(MAKH)
ALTER TABLE HOADON ADD CONSTRAINT FK_HD2 FOREIGN KEY(MANV) REFERENCES NHANVIEN(MANV)
ALTER TABLE CHITIETHD ADD Constraint fk_CTHD Foreign Key(MAHD) references HOADON(MAHD)
ALTER TABLE CHITIETHD ADD Constraint fk_CTHD2 Foreign Key(MASP) references SANPHAM(MASP)
ALTER TABLE CHITIETNHAPHANG ADD Constraint fk_CTNH1 Foreign Key(MANH) references NHAPHANG(MANH)
ALTER TABLE CHITIETNHAPHANG ADD Constraint fk_CTNH2 Foreign Key(MASP) references SANPHAM(MASP)
--ALTER TABLE NhanVien ADD Constraint fk_nvq Foreign Key(IDQUYEN) references QUYEN(IDQUYEN)
--------------------------------------Nhập Liệu-------------------------------------------

SELECT * FROM NHANVIEN
SELECT * FROM KHACH
SELECT * FROM SANPHAM
SELECT * FROM LOAI
SELECT *FROM HOADON
SELECT *FROM CHITIETHD
SELECT *FROM NHACUNGCAP
SELECT *FROM NHAPHANG
SELECT *FROM CHITIETNHAPHANG

create view VIEW_SP_LOAI 
as
select MASP,TENLOAI,TENSP,GIABANTHAMKHAO,SIZE,CHATLIEU,MAUSAC from SANPHAM,LOAI
where SANPHAM.MALOAI = LOAI.MALOAI

select * from SANPHAM where MASP like '%P%'

select * from SANPHAM where MASP=@MASP;

backup database QLSHOPQUANAO to disk = 'C:\Users\HP\Desktop\DA_CongNghenet\Filesql\test1.bak'

--create proc [dbo].[SP_AuthoLogin]
--@Username nvarchar(20),
--@Password nvarchar(20)
--as
--begin
--    if exists (select * from NhanVien where TENTAIKHOAN = @Username and PASSW = @Password and QUYEN = 1)
--        select 1 as code
--    else if exists (select * from NhanVien where TENTAIKHOAN = @Username and MatKhau = @Password and ID = 0)
--        select 0 as code
--    else if exists(select * from NhanVien where TENTAIKHOAN = @Username and MatKhau != @Password) 
--        select 2 as code
--end

select TENQUYEN from NHANVIEN where USERNAME = N'Admin' and PASSW = '123'