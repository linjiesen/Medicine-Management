using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 数据库课程设计
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        private void Form5_Load(object sender, EventArgs e)
        {
            string sql = "select * FROM  medicineinfo";
            SqlConnection conn = new SqlConnection(dataconnection.str);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * FROM  medicineinfo";
            SqlConnection conn = new SqlConnection(dataconnection.str);
            try
            {
                SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
                SqlCommandBuilder scb = new SqlCommandBuilder(sda);
                sda.Update(ds);
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + "对不起！输入出错");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
