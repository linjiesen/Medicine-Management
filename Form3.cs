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
    public partial class Form3 : Form
    {
        private string cliname;
        public string Cliname
        {
            set
            {
                cliname = value;
            }
            get
            {
                return cliname;
            }
        }
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView_root_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Form3_Load(object sender, EventArgs e)
        {
            re_load();
        }
        void re_load()
        {
            DataSet ds = new DataSet();
            string sql = "select * FROM  medicineinfo";
            SqlConnection conn = new SqlConnection(dataconnection.str);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string medno = textBox1.Text.ToString().Trim();
            string mednum1 = textBox2.Text.ToString().Trim();
            if (!medno.Equals("") && !mednum1.Equals(""))
            {
                try
                {
                    int mednum = Convert.ToInt32(mednum1);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "请在空格处输入数据!!!");
                }
                string cliname = this.Cliname;
                    string sql = string.Format("select * from clientinfo where cliname=N'{0}'", cliname);
                    string phonenumber = null;
                    MessageBox.Show(cliname);
                    using (SqlConnection conn = new SqlConnection(dataconnection.str))
                    {
                        SqlCommand cmd = new SqlCommand(sql, conn);
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                phonenumber = dr["cliphone"].ToString().Trim();
                            }
                        }
                    }
                    string sql2 = "select * from medicineinfo where medno=" + medno;
                    string medname = null;
                    string mednumber = null;
                    using (SqlConnection conn = new SqlConnection(dataconnection.str))
                    {
                        SqlCommand cmd = new SqlCommand(sql2, conn);
                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                medname = dr["medname"].ToString().Trim();
                                mednumber = dr["mednum"].ToString().Trim();
                            }
                        }
                    }
                    MessageBox.Show(medname + mednumber);
                    string time = System.DateTime.Now.ToString();
                    MessageBox.Show(time);
                    string sql3 = string.Format("insert into clientbuyinfo (cliname,cliphone,clibuytime,clibuynumber,clibuymedicineno,climedname) values(N'{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}')", cliname, phonenumber, time, Convert.ToInt32(mednum1), medno, medname);
                    using (SqlConnection conn = new SqlConnection(dataconnection.str))
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(sql3, conn);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("插入到clientbuyinfo表成功！！！！");
                        }
                        catch (Exception ex)
                        {
                            this.DialogResult = DialogResult.No;
                            MessageBox.Show(ex.Message + "\r\n" + "插入到clientbuyinfo表失败！\n\r请重新添加!!!");
                        }
                    }

                string sql4 = string.Format("update medicineinfo set mednum=mednum - '{0}'", Convert.ToInt32(mednum1));
                using (SqlConnection conn = new SqlConnection(dataconnection.str))
                {
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(sql4, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("修改medicineinfo表成功！！！！");
                        re_load();
                    }
                    catch (Exception ex)
                    {
                        this.DialogResult = DialogResult.No;
                        MessageBox.Show(ex.Message + "\r\n" + "修改medicineinfo表失败！\n\r请重新添加!!!");
                    }
                }
            }
        }
    }
}
