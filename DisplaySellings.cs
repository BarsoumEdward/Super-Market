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
    public partial class DisplaySellings : Form
    {
        public DisplaySellings()
        {
            InitializeComponent();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplaySellings_Load(object sender, EventArgs e)
        {
            try
            {
                string sql = "select productname as أسم_المنتج,quantity as العدد_الذى_تم_بيعه,dateofday as تاريخ_البيع from sellings";
                select(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string sql = " select productname as أسم_المنتج,quantity as العدد_الذى_تم_بيعه,dateofday as تاريخ_البيع   from sellings where productname+convert(varchar,quantity) like '%" + textBox1.Text + "%'";
                select(sql);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Report_Form frm = new Report_Form();

            da = new SqlDataAdapter(" select *  from sellings",
                @"Data Source=.\SQLEXPRESS;Initial Catalog=super_market; Integrated Security=True");
            da.Fill(frm.super_marketDataSet.sellings);
            frm.reportViewer1.RefreshReport();
            frm.Show();
        }
        SqlDataAdapter da;
        private void button2_Click(object sender, EventArgs e)
        {
            Report2 frm2 = new Report2();
            da = new SqlDataAdapter(" select productname ,quantity ,dateofday  from sellings where productname+convert(varchar,quantity) like '%" + textBox1.Text + "%'",
                @"Data Source=.\SQLEXPRESS;Initial Catalog=super_market; Integrated Security=True");
            da.Fill(frm2.super_marketDataSet.sellings);
            frm2.reportViewer1.RefreshReport();
            frm2.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = MessageBox.Show
                    ("هل تريد حذف جميع بيانات البيع فعلا؟","Delete",MessageBoxButtons.YesNo,MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    SqlConnection con = new SqlConnection();
                    SqlCommand cmd = new SqlCommand();


                  
                    con.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=super_market; Integrated Security=True";
                    cmd.Connection = con;
                    cmd.CommandText = "delete from sellings";
                    con.Open();


                    cmd.ExecuteNonQuery();

                    con.Close();
                }



                //to show datagriview1 after Delete for Updating datagriview1
                string sql = "select productname as أسم_المنتج,quantity as العدد_الذى_تم_بيعه,dateofday as تاريخ_البيع from sellings";
                    select(sql);
                


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
