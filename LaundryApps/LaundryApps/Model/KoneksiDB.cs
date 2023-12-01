using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;

namespace LaundryApps.Model
{
    class KoneksiDB
    {
        private static SQLiteConnection conn;
        private SQLiteCommand cmd;
        private bool result;

        public KoneksiDB()
        {
            GetOpenConnection();
        }

        public static SQLiteConnection GetOpenConnection()
        {
            try
            {
                string dbName = @"D:\Kuliah\Semester 3\Pemrograman Lanjut\P\LaundryApps\Database\laundry.db";
                string connectionString = string.Format("Data Source ={0}; FailIfMissing = True", dbName);

                conn = new SQLiteConnection(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return conn;
        }

        public DataSet Select(string tabel, string kondisi = null, string kolom = "*")
        {
            DataSet ds = new DataSet();

            try
            {
                conn.Open();
                cmd = new SQLiteCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                
                if(kondisi == null)
                {
                    cmd.CommandText = "SELECT " + kolom + " FROM " + tabel;
                }
                else
                {
                    cmd.CommandText = "SELECT " + kolom + " FROM " + tabel + " WHERE " + kondisi;
                }

                SQLiteDataAdapter sda = new SQLiteDataAdapter(cmd);
                sda.Fill(ds, tabel);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ds = null;
            }

            conn.Close();
            return ds;
        }
    }
}
