using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LaundryApps.View
{
    public partial class Dashboard : Form
    {
        Controller.DashboardController dashboard;
        public Dashboard()
        {
            InitializeComponent();
            dashboard = new Controller.DashboardController(this);
            dashboard.InisialisasiView();
            dashboard.tampilkanData();
            dashboard.totalPendapatan();
            dashboard.laporan();
        }

    }
}
