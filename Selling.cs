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
    public partial class Selling : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=super_market; Integrated Security=True");
        SqlCommand cmd;
        SqlCommand cmd2;

        public Selling()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                

                cmd = new SqlCommand();
                cmd.Connection = con;

                //تحديث العدد       
                cmd2 = new SqlCommand();
                cmd2.Connection = con;
                cmd2.CommandText = "update products set quantity=quantity-@q where productname=@pname";
               cmd2.Parameters.AddWithValue("@q", textBox1.Text);
                cmd2.Parameters.AddWithValue("@pname", comboBox1.Text);
                con.Open();
                cmd2.ExecuteNonQuery();
               // ////MessageBox.Show(" تم الادخال بنجاح ", "أضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();


               

                cmd.CommandText = "insert into sellings (productname,quantity,dateofday)values(@productname,@quantity,@dateofday)";
                

                cmd.Parameters.AddWithValue("@dateofday", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@productname", comboBox1.Text);
                cmd.Parameters.AddWithValue("@quantity", textBox1.Text);

                
                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(" تم الادخال بنجاح ", "أضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                textBox1.Clear();
            }
            catch (SqlException)
            {

                MessageBox.Show("لايوجد هذا العدد من المنتج وقد يكون نفذ عدده من فضلك أذهب من القائمه الرئيسيه الى زر (أضافة منتجات جديده والتعديل عليها) لمعرفة العدد المتبقى ثم قم بشراءه ", "error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();   // مهمه دى علشان يقفل الداتا بيز لو دخل هنا ىف الاكسبشن
            }



        }

        SqlDataAdapter da1;
        
       
        DataSet ds = new DataSet();
        
       

        private void Selling_Load(object sender, EventArgs e)
        {
            try
            {
                da1 = new SqlDataAdapter("select * from products ", con);
                da1.Fill(ds);
                
                comboBox1.DataSource = ds.Tables[0];
                comboBox1.DisplayMember = "productname";
                comboBox1.ValueMember = "productname";            // Primary Key name
                


                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();   // مهمه دى علشان يقفل الداتا بيز لو دخل هنا ىف الاكسبشن
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
         

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


       
      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                

                



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
