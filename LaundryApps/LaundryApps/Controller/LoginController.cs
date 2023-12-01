using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaundryApps.Controller
{
    class LoginController
    {
        Model.Login model;
        View.Login view;

        public LoginController(View.Login view)
        {
            model = new Model.Login();
            this.view = view;
        }

        public void cekLogin()
        {
            model.username = view.txtUsername.Text;
            model.password = view.txtPassword.Text;
            bool result = model.cekLogin();

            if (result)
            {
                View.Dashboard dashboard = new View.Dashboard();
                view.Hide();
                dashboard.ShowDialog();
                view.Close();
            }
            else
            {
                MessageBox.Show("Username atau Password Salah", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
