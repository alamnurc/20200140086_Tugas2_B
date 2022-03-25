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

                SqlCommand cm = new SqlCommand("Create Table Karyawan (Id_Karyawan VARCHAR(10) PRIMARY KEY NOT NULL, Nama_Karyawan VARCHAR(50) NOT NULL, Jenis_Kelamin CHAR(1) CHECK(Jenis_Kelamin in ('L', 'P')) NOT NULL, Alamat VARCHAR(100) NOT NULL, No_Telepon INT NOT NULL, Status VARCHAR(25) NOT NULL)", con);
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
