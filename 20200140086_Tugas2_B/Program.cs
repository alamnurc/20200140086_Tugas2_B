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
        static void Main(string[] args)
        {
            //new Program().BuatTable();
            new Program().BuatTable();
        }
    }
}
