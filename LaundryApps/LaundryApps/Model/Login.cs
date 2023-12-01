using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace LaundryApps.Model
{
    class Login
    {
        Model.KoneksiDB db;
        public string username { get; set; }
        public string password { get; set; }

        public bool cekLogin()
        {
            bool result;
            db = new Model.KoneksiDB();
            DataSet ds = new DataSet();

            string kondisi = "username = '" + username + "' AND password = '" + password + "'";
            ds = db.Select("login", kondisi);

            if(ds.Tables[0].Rows.Count > 0)
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
