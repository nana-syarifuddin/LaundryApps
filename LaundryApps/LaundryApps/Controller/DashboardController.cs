using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace LaundryApps.Controller
{
    class DashboardController
    {
        Model.Dashboard model;
        View.Dashboard view;
        Model.KoneksiDB db;

        public DashboardController(View.Dashboard view)
        {
            model = new Model.Dashboard();
            db = new Model.KoneksiDB();
            this.view = view;
        }
        public void InisialisasiView()
        {
            view.lvwTransaksi.View = System.Windows.Forms.View.Details;
            view.lvwTransaksi.FullRowSelect = true;
            view.lvwTransaksi.GridLines = true;

            view.lvwTransaksi.Columns.Add("No.", 30, HorizontalAlignment.Center);
            view.lvwTransaksi.Columns.Add("ID Transaksi", 80, HorizontalAlignment.Center);
            view.lvwTransaksi.Columns.Add("Nama", 80, HorizontalAlignment.Left);
            view.lvwTransaksi.Columns.Add("Tanggal Order", 80, HorizontalAlignment.Left);
            view.lvwTransaksi.Columns.Add("Total Harga", 80, HorizontalAlignment.Left);
            view.lvwTransaksi.Columns.Add("Status", 70, HorizontalAlignment.Left);
            view.lvwTransaksi.Columns.Add("Metode Bayar", 70, HorizontalAlignment.Left);
            view.lvwTransaksi.Columns.Add("Catatan", 80, HorizontalAlignment.Left);
        }

        public void tampilkanData()
        {
            bool result = model.tampilkanData();

            if (result)
            {
                view.lvwTransaksi.Items.Clear();

                db = new Model.KoneksiDB();

                SQLiteConnection conn = Model.KoneksiDB.GetOpenConnection();

                conn.Open();

                string sql = "SELECT transaksi.id_transaksi, userdata.nama, transaksi.tanggal_order, transaksi.total_harga, transaksi.status, transaksi.metode_bayar, transaksi.catatan FROM transaksi, userdata WHERE transaksi.id_user = userdata.id_user";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                SQLiteDataReader dtr = cmd.ExecuteReader();

                while (dtr.Read())
                {
                    var noUrut = view.lvwTransaksi.Items.Count + 1;
                    var item = new ListViewItem(noUrut.ToString());
                    item.SubItems.Add(dtr["id_transaksi"].ToString());
                    item.SubItems.Add(dtr["nama"].ToString());
                    item.SubItems.Add(dtr["tanggal_order"].ToString());
                    item.SubItems.Add(dtr["total_harga"].ToString());
                    item.SubItems.Add(dtr["status"].ToString());
                    item.SubItems.Add(dtr["metode_bayar"].ToString());
                    item.SubItems.Add(dtr["catatan"].ToString());
                    view.lvwTransaksi.Items.Add(item);
                }
                dtr.Dispose();
                cmd.Dispose();
                conn.Dispose();
            }
            else
            {
                MessageBox.Show("Kesalahan Pada Tabel Transaksi", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void totalPendapatan()
        {
            bool result = model.totalPendapatan();

            if (result)
            {
                db = new Model.KoneksiDB();

                SQLiteConnection conn = Model.KoneksiDB.GetOpenConnection();

                conn.Open();

                string sql = "SELECT sum(total_harga) FROM transaksi";

                SQLiteCommand cmd = new SQLiteCommand(sql, conn);

                object hasil = cmd.ExecuteScalar();
                view.lblTotalPendapatan.Text = Convert.ToString(hasil);

                cmd.Dispose();
                conn.Dispose();
            }
            else
            {
                MessageBox.Show("Kesalahan Pada Tabel Transaksi", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
