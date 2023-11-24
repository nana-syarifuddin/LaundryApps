using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace LaundryApps.Model
{
    class Dashboard
    {
        Model.KoneksiDB db;

        public bool tampilkanData()
        {
            bool result;
            db = new Model.KoneksiDB();
            DataSet ds = new DataSet();

            ds = db.Select("transaksi");

            
            if (ds.Tables[0].Rows.Count > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }

        public bool totalPendapatan()
        {
            bool result;
            db = new Model.KoneksiDB();
            DataSet ds = new DataSet();

            ds = db.Select("transaksi");

            if (ds.Tables[0].Rows.Count > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
        public bool laporan()
        {
            bool result;
            db = new Model.KoneksiDB();
            DataSet ds = new DataSet();

            ds = db.Select("transaksi");

            if (ds.Tables[0].Rows.Count > 0)
            {
                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
