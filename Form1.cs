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


   
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


      
        Product p;
        Selling s;
        private void button1_Click(object sender, EventArgs e)
        {
            p = new Product();
            p.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            s = new Selling();
            s.Show();
        }

        DisplaySellings dselling;
        private void button3_Click(object sender, EventArgs e)
        {
            dselling = new DisplaySellings();
            dselling.Show();
        }

        Profits prof;
        private void button4_Click(object sender, EventArgs e)
        {
            prof = new Profits();
            prof.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }




    public class Items
    {
        public string itemname;
        public int quantity;
        public double buyingprice;
        public double sellingprice;
        public string dateofbuying;

        public double profits()
        {
            return (sellingprice - buyingprice);
        }

    }

   
}
