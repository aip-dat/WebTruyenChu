create database TruyenChu
use TruyenChu
create table theloai
(
 matheloai int IDENTITY(1,1) primary key,
 tentheloai nvarchar(300) not null,
 tenurl varchar(200)
)
create table truyen
(
 matruyen int IDENTITY(1,1) primary key,
 matheloai int,
 tentruyen nvarchar(1000) not null,
 hinh varchar(500) not null,
 tacgia nvarchar(200) not null,
 mota nvarchar(2000) not null,
 ngaydangtruyen datetime
 CONSTRAINT fk_matheloai FOREIGN KEY (matheloai) REFERENCES theloai (matheloai),
)
create table chuong
(
 machuong int IDENTITY(1,1) primary key,
 matruyen int,
 tenchuong nvarchar(1000) not null,
 noidungchuong nvarchar(4000) not null,
 ngaydangchuong datetime,
  CONSTRAINT fk_matruyen FOREIGN KEY (matruyen) REFERENCES truyen (matruyen)
)
create table CT_theloai_truyen
(
	matruyen int,
	matheloai int,
	CONSTRAINT fk_matruyen FOREIGN KEY (matruyen) REFERENCES truyen (matruyen),
	CONSTRAINT fk_matheloai FOREIGN KEY (matheloai) REFERENCES theloai (matheloai),
)
	CONSTRAINT fk_matruyen FOREIGN KEY (matruyen) REFERENCES truyen (matruyen),
	CONSTRAINT fk_matheloai FOREIGN KEY (matheloai) REFERENCES theloai (matheloai),
	CONSTRAINT Ma PRIMARY KEY (matruyen, matheloai)

--create table taikhoan
--(
--	mataikhoan int primary key,
--	tentaikhoan varchar(100) not null,
--	matkhau varchar(100) not null,
--)