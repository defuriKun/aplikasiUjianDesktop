using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.Reflection;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace aplikasiUlangan
{
    class SQL
    {
        public static MySqlConnection koneksi = new MySqlConnection("server=127.0.0.1; username=root; password = ; database = dbulangan;Convert Zero Datetime=True");
        public static DataSet ds = new DataSet();
        public static MySqlDataAdapter da;
        public static MySqlCommand perintah;
        public static string idUser, namaTabel, kdUlangan;
        public static int noSoal = 1;
        public static byte jumlahSelesai = 0;

        public static void CRUD(String sqlnya)
        {
            Console.WriteLine(sqlnya);
            ds.Tables.Clear();
            perintah = new MySqlCommand(sqlnya, koneksi);
            da = new MySqlDataAdapter(perintah);
            da.Fill(ds);
        }

        public static int getRowCount(String sqlnya)
        {
            Console.WriteLine(sqlnya);
            int rowCount = 0;
            using (MySqlCommand perintah = new MySqlCommand(sqlnya, koneksi))
            {
                koneksi.Open();
                using (MySqlDataReader reader = perintah.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        rowCount++;
                    }
                }
                koneksi.Close();
            }
            return rowCount;
        }

        public static void dgCepat(DataGridView dgv)
        {
            var dg = dgv.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            dg.SetValue(dgv, true, null);
        }

        public static void tampilgrid(String sql, DataGridView gridapa)
        {
            Console.WriteLine(sql);
            dgCepat(gridapa);
            aplikasiUlangan.SQL.CRUD(sql);
            gridapa.DataSource = aplikasiUlangan.SQL.ds.Tables[0];
            gridapa.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 10F, FontStyle.Regular);
            gridapa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            gridapa.ColumnHeadersHeight = 50;

            foreach (DataGridViewColumn kolom in gridapa.Columns)
            {
                kolom.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                if (kolom.GetType() == typeof(DataGridViewImageColumn))
                {
                    ((DataGridViewImageColumn)kolom).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }
            }
        }

        public static void hapusData(String namatabel, String namakolom, String KunciUtama)
        {
            String hasil = "DELETE FROM " + namatabel + " WHERE " + namakolom + " ='" + KunciUtama + "'";
            Console.WriteLine(hasil);
            CRUD(hasil);
        }
    }
}
