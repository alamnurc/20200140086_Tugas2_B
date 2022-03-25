using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _20200140086_Tugas2_B
{
    class Program
    {
        public void BuatTable()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=MACBOOK-PRO-MJL;database=Apotek_Alam_086;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand("Create Table Karyawan (Id_Karyawan VARCHAR(10) PRIMARY KEY NOT NULL, Nama_Karyawan VARCHAR(50) NOT NULL, Jenis_Kelamin CHAR(1) CHECK (Jenis_Kelamin in ('L','P')) NOT NULL, Alamat VARCHAR(100) NOT NULL, No_Telepon INT NOT NULL, Status VARCHAR (25) NOT NULL)"
                    + "Create Table Penyuplai(Id_Penyuplai varchar(10) PRIMARY KEY NOT NULL, Nama_Penyuplai varchar(50) NOT NULL, Alamat varchar(100) NOT NULL, No_Telepon int NOT NULL,)"
                    + "Create Table Pembeli(Id_Pembeli varchar(10) PRIMARY KEY NOT NULL, Nama_Pembeli varchar(50) NOT NULL, Jenis_Kelamin CHAR(1) CHECK(Jenis_Kelamin in ('L', 'P')) NOT NULL, Alamat varchar(100) NOT NULL, No_Telepon int  NOT NULL, Pekerjaan varchar(25)  NOT NULL,)"
                    + "Create Table Barang(Id_Barang varchar(10) PRIMARY KEY NOT NULL, Nama_Barang varchar(50) NOT NULL, Produksi varchar(25) NOT NULL, Kategori varchar(25) NOT NULL, Jenis varchar(25) NOT NULL, Ukuran varchar(10) NOT NULL, Harga_Beli money NOT NULL, Harga_Jual money NOT NULL, Stok int NOT NULL, Id_Penyuplai varchar(10) foreign key references Penyuplai(Id_Penyuplai) NOT NULL,)"
                    + "Create Table Struk_Penjualan(Id_Struk_Penjualan varchar(10) PRIMARY KEY NOT NULL, Tanggal date NOT NULL, Jam varchar(5) NOT NULL, Id_Karyawan varchar(10) foreign key references Karyawan(Id_Karyawan) NOT NULL, Id_Pembeli varchar(10) foreign key references Pembeli(Id_Pembeli) NOT NULL, Id_Barang varchar(10) foreign key references Barang(Id_Barang) NOT NULL, Nama_Barang varchar(50) NOT NULL, Jumlah_Barang int NOT NULL, Harga_Satuan money NOT NULL, Total_Harga_Satuan money NOT NULL, Total_Item int NOT NULL, Total_Transaksi money NOT NULL, Dibayar money NOT NULL, Kembali money NOT NULL,)"
                    + "Create Table Struk_Suplai(Id_Struk_Suplai varchar(10) PRIMARY KEY NOT NULL, Nama_Penyuplai varchar(50) NOT NULL, Tanggal date NOT NULL, Jam varchar(5) NOT NULL, Id_Penyuplai varchar(10) foreign key references Penyuplai(Id_Penyuplai) NOT NULL, Id_Karyawan varchar(10) foreign key references Karyawan(Id_Karyawan) NOT NULL, Id_Barang varchar(10) foreign key references Barang(Id_Barang) NOT NULL, Nama_Barang varchar(50) NOT NULL, Jumlah_Barang int NOT NULL, Harga_Satuan money NOT NULL, Total_Transaksi money NOT NULL)"
                    + "Create Table Penjualan(Id_Karyawan varchar(10) foreign key references Karyawan(Id_Karyawan) NOT NULL, Id_Barang varchar(10) foreign key references Barang(Id_Barang) NOT NULL, Stok int NOT NULL, Tanggal date NOT NULL)"
                    + "Create Table Pembelian(Id_Pembeli varchar(10) foreign key references Pembeli(Id_Pembeli) NOT NULL, Id_Barang varchar(10) foreign key references Barang(Id_Barang) NOT NULL, Stok int NOT NULL, Tanggal date NOT NULL)"
                    + "Create Table Penyuplaian(Id_Penyuplai varchar(10) foreign key references Penyuplai(Id_Penyuplai) NOT NULL, Id_Barang varchar(10) foreign key references Barang(Id_Barang) NOT NULL, Stok int NOT NULL, Tanggal date NOT NULL)", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Tabel berhasil dibuat!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Terjadi kesalahan. Silahkan baca pesan kesalahan berikut: " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
            Console.ReadKey();
        }
        public void IsiTabel()
        {
            SqlConnection con = null;
            try
            {
                con = new SqlConnection("data source=MACBOOK-PRO-MJL;database=Apotek_Alam_086;Integrated Security = TRUE");
                con.Open();

                SqlCommand cm = new SqlCommand("INSERT INTO Karyawan (Id_Karyawan, Nama_Karyawan, Jenis_Kelamin,Alamat, No_Telepon, Status) VALUES ('KR00000001','Alam','L','Sleman','0811111111','Aktif')" +
                    "INSERT INTO Karyawan (Id_Karyawan, Nama_Karyawan, Jenis_Kelamin,Alamat, No_Telepon, Status) VALUES ('KR00000002','Manyu','L','Sleman','0811111112','Cuti')" +
                    "INSERT INTO Karyawan (Id_Karyawan, Nama_Karyawan, Jenis_Kelamin,Alamat, No_Telepon, Status) VALUES ('KR00000003','Farkhan','L','Sleman','0811111113','Aktif')" +
                    "INSERT INTO Karyawan (Id_Karyawan, Nama_Karyawan, Jenis_Kelamin,Alamat, No_Telepon, Status) VALUES ('KR00000004','Fadhli','L','Bantul','0811111114','Aktif')" +
                    "INSERT INTO Karyawan (Id_Karyawan, Nama_Karyawan, Jenis_Kelamin,Alamat, No_Telepon, Status) VALUES ('KR00000005','Kresna','L','Bantul','0811111115','Aktif')" +
                    "INSERT INTO Penyuplai (Id_Penyuplai, Nama_Penyuplai, Alamat, No_Telepon) VALUES ('PY00000001','Konimex','Banten','0274000001')" +
                    "INSERT INTO Penyuplai (Id_Penyuplai, Nama_Penyuplai, Alamat, No_Telepon) VALUES ('PY00000002','Farmaku','Bogor','0274000002')" +
                    "INSERT INTO Penyuplai (Id_Penyuplai, Nama_Penyuplai, Alamat, No_Telepon) VALUES ('PY00000003','Kemistri','Surabaya','0274000003')" +
                    "INSERT INTO Penyuplai (Id_Penyuplai, Nama_Penyuplai, Alamat, No_Telepon) VALUES ('PY00000004','Fisikal','Semarang','0274000004')" +
                    "INSERT INTO Penyuplai (Id_Penyuplai, Nama_Penyuplai, Alamat, No_Telepon) VALUES ('PY00000005','Biologika','Bandung','0274000005')" +
                    "INSERT INTO Pembeli (Id_Pembeli, Nama_Pembeli, Jenis_Kelamin, Alamat, No_Telepon, Pekerjaan) VALUES ('PB00000001','Gilang','L','Kota Yogyakarta','085111111','Pelajar SMA')" +
                    "INSERT INTO Pembeli (Id_Pembeli, Nama_Pembeli, Jenis_Kelamin, Alamat, No_Telepon, Pekerjaan) VALUES ('PB00000002','Sinta','P','Sleman','085111112','Mahasiswa')" +
                    "INSERT INTO Pembeli (Id_Pembeli, Nama_Pembeli, Jenis_Kelamin, Alamat, No_Telepon, Pekerjaan) VALUES ('PB00000003','Permana','L','Bantul','085111113','Karyawan Swasta')" +
                    "INSERT INTO Pembeli (Id_Pembeli, Nama_Pembeli, Jenis_Kelamin, Alamat, No_Telepon, Pekerjaan) VALUES ('PB00000004','Pratiwi','P','Kulon Progo','085111114','Wiraswasta')" +
                    "INSERT INTO Pembeli (Id_Pembeli, Nama_Pembeli, Jenis_Kelamin, Alamat, No_Telepon, Pekerjaan) VALUES ('PB00000005','Syaifullah','L','Gunung Kidul','085111115','Pengusaha')" +
                    "INSERT INTO Barang (Id_Barang, Nama_Barang, Produksi, Kategori, Jenis, Ukuran, Harga_Beli, Harga_Jual, Stok, Id_Penyuplai) VALUES ('BR00000001','Betadine','Konimex','Cair','Bebas','100ml','14000','15000','50','PY00000001')" +
                    "INSERT INTO Barang (Id_Barang, Nama_Barang, Produksi, Kategori, Jenis, Ukuran, Harga_Beli, Harga_Jual, Stok, Id_Penyuplai) VALUES ('BR00000002','Insto','Farmaku','Cair','Bebas','100ml','18000','20000','25','PY00000002')" +
                    "INSERT INTO Barang (Id_Barang, Nama_Barang, Produksi, Kategori, Jenis, Ukuran, Harga_Beli, Harga_Jual, Stok, Id_Penyuplai) VALUES ('BR00000003','Kalpanax','Kemistri','Cair','Terbatas','100ml','9000','10000','50','PY00000003')" +
                    "INSERT INTO Barang (Id_Barang, Nama_Barang, Produksi, Kategori, Jenis, Ukuran, Harga_Beli, Harga_Jual, Stok, Id_Penyuplai) VALUES ('BR00000004','Degirol','Fisikal','Tablet','Bebas','10 tab','12000','14000','100','PY00000004')" +
                    "INSERT INTO Barang (Id_Barang, Nama_Barang, Produksi, Kategori, Jenis, Ukuran, Harga_Beli, Harga_Jual, Stok, Id_Penyuplai) VALUES ('BR00000005','Alkohol','Biologika','Cair','Keras','250ml','27000','30000','100','PY00000005')" +
                    "INSERT INTO Struk_Penjualan (Id_Struk_Penjualan, Tanggal, Jam, Id_Karyawan, Id_Pembeli, Id_Barang, Nama_Barang, Jumlah_Barang, Harga_Satuan, Total_Harga_Satuan, Total_Item, Total_Transaksi, Dibayar, Kembali) VALUES ('SPJ0000001','2022-03-20','20:20','KR00000001','PB00000001','BR00000001','Betadine','1','15000','15000','1','15000','20000','5000')" +
                    "INSERT INTO Struk_Penjualan (Id_Struk_Penjualan, Tanggal, Jam, Id_Karyawan, Id_Pembeli, Id_Barang, Nama_Barang, Jumlah_Barang, Harga_Satuan, Total_Harga_Satuan, Total_Item, Total_Transaksi, Dibayar, Kembali) VALUES ('SPJ0000002','2022-03-21','20:21','KR00000002','PB00000002','BR00000002','Insto','2','20000','40000','2','40000','50000','10000')" +
                    "INSERT INTO Struk_Penjualan (Id_Struk_Penjualan, Tanggal, Jam, Id_Karyawan, Id_Pembeli, Id_Barang, Nama_Barang, Jumlah_Barang, Harga_Satuan, Total_Harga_Satuan, Total_Item, Total_Transaksi, Dibayar, Kembali) VALUES ('SPJ0000003','2022-03-22','20:22','KR00000003','PB00000003','BR00000003','Kalpanax','3','10000','30000','3','30000','30000','0')" +
                    "INSERT INTO Struk_Penjualan (Id_Struk_Penjualan, Tanggal, Jam, Id_Karyawan, Id_Pembeli, Id_Barang, Nama_Barang, Jumlah_Barang, Harga_Satuan, Total_Harga_Satuan, Total_Item, Total_Transaksi, Dibayar, Kembali) VALUES ('SPJ0000004','2022-03-23','20:23','KR00000004','PB00000004','BR00000004','Degirol','4','14000','56000','4','56000','60000','4000')" +
                    "INSERT INTO Struk_Penjualan (Id_Struk_Penjualan, Tanggal, Jam, Id_Karyawan, Id_Pembeli, Id_Barang, Nama_Barang, Jumlah_Barang, Harga_Satuan, Total_Harga_Satuan, Total_Item, Total_Transaksi, Dibayar, Kembali) VALUES ('SPJ0000005','2022-03-24','20:24','KR00000005','PB00000005','BR00000005','Alkohol','5','30000','150000','5','150000','200000','50000')" +
                    "INSERT INTO Struk_Suplai (Id_Struk_Suplai, Nama_Penyuplai, Tanggal, Jam, Id_Penyuplai, Id_Karyawan, Id_Barang, Nama_Barang, Jumlah_Barang, Harga_Satuan, Total_Transaksi) VALUES ('SSP0000001','Konimex','2022-03-20','10:20','PY00000001','KR00000001','BR00000001','Betadine','50','14000','700000')" +
                    "INSERT INTO Struk_Suplai (Id_Struk_Suplai, Nama_Penyuplai, Tanggal, Jam, Id_Penyuplai, Id_Karyawan, Id_Barang, Nama_Barang, Jumlah_Barang, Harga_Satuan, Total_Transaksi) VALUES ('SSP0000002','Farmaku','2022-03-21','10:21','PY00000002','KR00000002','BR00000002','Insto','25','18000','450000')" +
                    "INSERT INTO Struk_Suplai (Id_Struk_Suplai, Nama_Penyuplai, Tanggal, Jam, Id_Penyuplai, Id_Karyawan, Id_Barang, Nama_Barang, Jumlah_Barang, Harga_Satuan, Total_Transaksi) VALUES ('SSP0000003','Kemistri','2022-03-22','10:22','PY00000003','KR00000003','BR00000003','Kalpanax','50','9000','450000')" +
                    "INSERT INTO Struk_Suplai (Id_Struk_Suplai, Nama_Penyuplai, Tanggal, Jam, Id_Penyuplai, Id_Karyawan, Id_Barang, Nama_Barang, Jumlah_Barang, Harga_Satuan, Total_Transaksi) VALUES ('SSP0000004','Fisikal','2022-03-23','10:23','PY00000004','KR00000004','BR00000004','Degirol','100','12000','1200000')" +
                    "INSERT INTO Struk_Suplai (Id_Struk_Suplai, Nama_Penyuplai, Tanggal, Jam, Id_Penyuplai, Id_Karyawan, Id_Barang, Nama_Barang, Jumlah_Barang, Harga_Satuan, Total_Transaksi) VALUES ('SSP0000005','Biologika','2022-03-24','10:24','PY00000005','KR00000005','BR00000005','Alkohol','100','27000','2700000')" +
                    "INSERT INTO Penjualan (Id_Karyawan, Id_Barang, Stok, Tanggal) VALUES ('KR00000001','BR00000001','50','2022-03-19')" +
                    "INSERT INTO Penjualan (Id_Karyawan, Id_Barang, Stok, Tanggal) VALUES ('KR00000002','BR00000002','25','2022-03-20')" +
                    "INSERT INTO Penjualan (Id_Karyawan, Id_Barang, Stok, Tanggal) VALUES ('KR00000003','BR00000003','50','2022-03-21')" +
                    "INSERT INTO Penjualan (Id_Karyawan, Id_Barang, Stok, Tanggal) VALUES ('KR00000004','BR00000004','100','2022-03-22')" +
                    "INSERT INTO Penjualan (Id_Karyawan, Id_Barang, Stok, Tanggal) VALUES ('KR00000005','BR00000005','100','2022-03-23')" +
                    "INSERT INTO Pembelian (Id_Pembeli, Id_Barang, Stok, Tanggal) VALUES ('PB00000001','BR00000001','50','2022-03-20')" +
                    "INSERT INTO Pembelian (Id_Pembeli, Id_Barang, Stok, Tanggal) VALUES ('PB00000002','BR00000002','25','2022-03-21')" +
                    "INSERT INTO Pembelian (Id_Pembeli, Id_Barang, Stok, Tanggal) VALUES ('PB00000003','BR00000003','50','2022-03-22')" +
                    "INSERT INTO Pembelian (Id_Pembeli, Id_Barang, Stok, Tanggal) VALUES ('PB00000004','BR00000004','100','2022-03-23')" +
                    "INSERT INTO Pembelian (Id_Pembeli, Id_Barang, Stok, Tanggal) VALUES ('PB00000005','BR00000005','100','2022-03-24')" +
                    "INSERT INTO Penyuplaian (Id_Penyuplai, Id_Barang, Stok, Tanggal) VALUES ('PY00000001','BR00000001','50','2022-03-18')" +
                    "INSERT INTO Penyuplaian (Id_Penyuplai, Id_Barang, Stok, Tanggal) VALUES ('PY00000002','BR00000002','25','2022-03-19')" +
                    "INSERT INTO Penyuplaian (Id_Penyuplai, Id_Barang, Stok, Tanggal) VALUES ('PY00000003','BR00000003','50','2022-03-20')" +
                    "INSERT INTO Penyuplaian (Id_Penyuplai, Id_Barang, Stok, Tanggal) VALUES ('PY00000004','BR00000004','100','2022-03-21')" +
                    "INSERT INTO Penyuplaian (Id_Penyuplai, Id_Barang, Stok, Tanggal) VALUES ('PY00000005','BR00000005','100','2022-03-22')", con);
                cm.ExecuteNonQuery();

                Console.WriteLine("Data berhasil ditambahkan!");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("Terjadi kesalahan. Silahkan baca pesan kesalahan berikut: " + e);
                Console.ReadKey();
            }
            finally
            {
                con.Close();
                Console.ReadKey();
            }
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            //Deklarasi Program IsiTabel
            new Program().IsiTabel();
        }
    }
}
