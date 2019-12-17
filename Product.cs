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
    public partial class Product : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=super_market; Integrated Security=True");
        SqlCommand cmd;
        Items item;


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
                tbl.Clear();
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

        public Product()
        {
            InitializeComponent();
            string sql = "Select productname as أسم_المنتج,quantity as العدد_المتبقى,buy_price as سعر_الشراء ,sell_price as سعر_البيع,dateofbuying as تاريخ_الشراء,profits as الربح_للمنتح_الواحد  from products";
            select(sql);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                item = new Items();
                item.itemname = textBox1.Text;
                item.quantity = Int32.Parse(textBox2.Text);
                item.buyingprice = double.Parse(textBox3.Text);
                item.sellingprice = double.Parse(textBox4.Text);
                item.dateofbuying = dateTimePicker1.Text;

                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "update products set quantity=@quantity,buy_price=@buyingprice,sell_price=@sellingprice,dateofbuying=@dateofbuying,profits=@profits where productname=@itemname";
                cmd.Parameters.AddWithValue("@itemname", item.itemname);
                cmd.Parameters.AddWithValue("@quantity", item.quantity);
                cmd.Parameters.AddWithValue("@buyingprice", item.buyingprice);
                cmd.Parameters.AddWithValue("@sellingprice", item.sellingprice);
                cmd.Parameters.AddWithValue("@dateofbuying", item.dateofbuying);
                cmd.Parameters.AddWithValue("@profits", item.profits());



                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(" تم التعديل بنجاح ", "تعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                //تحديث الداتا جرد فيو بعد التعديل
                string sql = "Select productname as أسم_المنتج,quantity as العدد_المتبقى,buy_price as سعر_الشراء ,sell_price as سعر_البيع,dateofbuying as تاريخ_الشراء,profits as الربح_للمنتح_الواحد  from products";
                select(sql);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Product_Load(object sender, EventArgs e)
        {

        }

        

       
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                item = new Items();
                item.itemname = textBox1.Text;
                item.quantity = Int32.Parse(textBox2.Text);
                item.buyingprice = double.Parse(textBox3.Text);
                item.sellingprice = double.Parse(textBox4.Text);
                item.dateofbuying = dateTimePicker1.Text;


                cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into products (productname,quantity,buy_price,sell_price,dateofbuying,profits)values(@itemname,@quantity,@buyingprice,@sellingprice,@dateofbuying,@profits)  ";
                cmd.Parameters.AddWithValue("@itemname", item.itemname);
                cmd.Parameters.AddWithValue("@quantity", item.quantity);
                cmd.Parameters.AddWithValue("@buyingprice", item.buyingprice);
                cmd.Parameters.AddWithValue("@sellingprice", item.sellingprice);
                cmd.Parameters.AddWithValue("@dateofbuying", item.dateofbuying);
                cmd.Parameters.AddWithValue("@profits", item.profits());


                con.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show(" المنتج تم ادخاله بنجاح ", "أضافه", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();



                string sql = "Select productname as أسم_المنتج,quantity as العدد_المتبقى,buy_price as سعر_الشراء ,sell_price as سعر_البيع,dateofbuying as تاريخ_الشراء,profits as الربح_للمنتح_الواحد  from products";
                select(sql);

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
            }

            catch (SqlException)
            {
                MessageBox.Show("! هذا المنتج قد تم أدخاله سابقا ولا يمكن أدخاله مرتين ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();   // مهمه دى علشان يقفل الداتا بيز لو دخل هنا ىف الاكسبشن
            }
            catch (FormatException)
            {
                MessageBox.Show("! المدخلات خطأ أكتب أسم المنتج نص والباقى أرقام ","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
            }
            /* string messaage = "item"+item.itemname+",quantity is"+item.quantity.ToString()+",bp="+item.buyingprice.ToString() + ",sp="+
                 item.sellingprice.ToString() + " and date is  "+item.dateofbuying;
             MessageBox.Show(messaage);*/


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = MessageBox.Show
                    ("هل تريد حذف هذا المنتج فعلا؟", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //item = new Items();
                    //item.itemname = textBox1.Text;
                    cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from products where productname=@itemname ";
                    cmd.Parameters.AddWithValue("@itemname", dataGridView1.CurrentRow.Cells[0].Value.ToString()  /*item.itemname*/);


                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show(" تم حذف المنتج بنجاح ", "حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();

                    string sql = "Select productname as أسم_المنتج,quantity as العدد_المتبقى,buy_price as سعر_الشراء ,sell_price as سعر_البيع,dateofbuying as تاريخ_الشراء,profits as الربح_للمنتح_الواحد  from products";
                    select(sql);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
