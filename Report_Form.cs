using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market
{
    public partial class Report_Form : Form
    {
        public Report_Form()
        {
            InitializeComponent();
        }

        private void Report_Form_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'super_marketDataSet.sellings' table. You can move, or remove it, as needed.
          //  this.sellingsTableAdapter.Fill(this.super_marketDataSet.sellings);
          //this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
