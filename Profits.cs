using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Super_Market
{
    public partial class Profits : Form
    {
        public Profits()
        {
            InitializeComponent();
            comboBox1.SelectedIndex=0;
        }

        public void select(string sql)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand();

                SqlDataReader read;

                DataTable tbl = new DataTable();
                con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=super_market; Integrated Security=True";
                cmd.Connection = con;
                cmd.CommandText = sql;
                con.Open();


                read = cmd.ExecuteReader();
                tbl.Load(read);

                read.Close();
                con.Close();
                dataGridView1.DataSource = tbl;
                int sum = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    sum +=Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value);
                }
                textBox4.Text =sum.ToString()+" جنيه مصرى  ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void select2(string sql)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand();

                SqlDataReader read;

                DataTable tbl = new DataTable();
                con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=super_market; Integrated Security=True";
                cmd.Connection = con;
                cmd.CommandText = sql;
                con.Open();


                read = cmd.ExecuteReader();
                tbl.Load(read);

                read.Close();
                con.Close();
                dataGridView2.DataSource = tbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void select3(string sql)
        {
            try
            {
                SqlConnection con = new SqlConnection();
                SqlCommand cmd = new SqlCommand();

                SqlDataReader read;

                DataTable tbl = new DataTable();
                con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=super_market; Integrated Security=True";
                cmd.Connection = con;
                cmd.CommandText = sql;
                con.Open();


                read = cmd.ExecuteReader();
                tbl.Load(read);

                read.Close();
                con.Close();
                dataGridView3.DataSource = tbl;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void Profits_Load(object sender, EventArgs e)
        {
            if (tabPage1.Text == "معرفة أرباح المنتج")
            {
                string sql = " Select s.productname as أسم_المنتج ,sum(s.quantity) as العدد_الذى_تم_بيعه,max(p.profits) as الربح_من_بيع_المنتج_الواحد,sum(s.quantity)*max(p.profits) as الربح_من_بيع_العدد_الذى_تم_بيعه from  products p , sellings s where p.productname=s.productname group by s.productname";
                select(sql);


                

                
            }
            
            
          

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
            string sql = " Select s.productname as أسم_المنتج ,sum(s.quantity) as العدد_الذى_تم_بيعه,  max(p.quantity) as العدد_الباقى_من_المنتج from  products p , sellings s where p.productname=s.productname group by s.productname";
            select2(sql);
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox2.Text = dateTimePicker1.Text;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox3.Text= dateTimePicker2.Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
                if (comboBox1.Text == "اليوم")
                {
                    textBox2.Text = dateTimePicker1.Text;
                    textBox3.Text = dateTimePicker2.Text;
                }
                else if (comboBox1.Text == "من التاريخ")
                {
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
           
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    string sql = " Select dateofday as تاريخ_البيع,productname as أسم_المنتج,quantity as الكميه_التى_تم_بيعها from   sellings  where  dateofday Between'" + dateTimePicker1.Text + "'  And '" + dateTimePicker2.Text + "'";
                    select3(sql);
                }

                else
                {

                    string sql = " Select dateofday as تاريخ_البيع,productname as أسم_المنتج,quantity as الكميه_التى_تم_بيعها from   sellings  where  dateofday Between'" + dateTimePicker1.Text + "'  And '" + dateTimePicker2.Text + "' and productname like '%" + textBox1.Text + "%'";
                    select3(sql);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }
    }
}
