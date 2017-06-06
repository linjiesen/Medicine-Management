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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            DataSet ds = new DataSet();
            string sql = "select a.medno,a.mednum,a.medname,a.medmanufacturer,a.meddate,a.medmethod,a.medprice,a.medquality,a.medoperator FROM  medicineinfo a right join repoinfo b on a.medno=b.medno";
            SqlConnection conn = new SqlConnection(dataconnection.str);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        void re_Form2_Load()
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            DataSet ds = new DataSet();
            string sql = "select a.medno,a.mednum,a.medname,a.medmanufacturer,a.meddate,a.medmethod,a.medprice,a.medquality,a.medoperator FROM  medicineinfo a right join repoinfo b on a.medno=b.medno";
            SqlConnection conn = new SqlConnection(dataconnection.str);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form4 fm4 = new Form4();
            if (fm4.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("插入成功!");
                re_Form2_Load();
            }
            else
            {
                MessageBox.Show("插入失败!");
            }
        }
        private void button_delete_Click(object sender, EventArgs e)
        {
            string med_no = textBox1.Text.Trim();
            string sql = string.Format("delete from medicineinfo where medno='{0}'",Convert.ToInt32(med_no));
            using (SqlConnection conn = new SqlConnection(dataconnection.str))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                int n = cmd.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("删除成功!");
                    re_Form2_Load();
                    return;
                }
                else
                {
                    MessageBox.Show("删除失败!");
                    return;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form5 fm5 = new Form5();
            if (fm5.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("修改成功！！！");
                re_Form2_Load();
            }
            else
            {
                MessageBox.Show("未修改!");
            }
           
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                if (column is DataGridViewButtonColumn)
                {
                    int row = e.RowIndex;
                    int col = e.ColumnIndex;
                    string[] str = new string[dataGridView1.Rows.Count];
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        if (i == row)
                        {
                            string s = "";
                            for (int j = 1; j < dataGridView1.Columns.Count; j++)
                            {
                                s += dataGridView1.Rows[i].Cells[j].Value.ToString().Trim()+",";
                            }
                            MessageBox.Show(s);
                            string[] tr=s.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            int medno = Convert.ToInt32(tr[0]);
                            int mednum= Convert.ToInt32(tr[1]);
                            string medname = tr[2];
                            string medmanufaturer = tr[3];
                            string meddate = tr[4];
                            string medrepoouttime = System.DateTime.Now.ToShortDateString();
                            string sql2 = string.Format("insert into repoout (medno,mednum,medname,medmanufaturer,meddate,medrepoouttime) values('{0}', N'{1}', N'{2}', N'{3}',N'{4}',N'{5}')",medno, mednum, medname, medmanufaturer, meddate, medrepoouttime);
                            using (SqlConnection conn2 = new SqlConnection(dataconnection.str))
                            {
                                try
                                {
                                    conn2.Open();
                                    SqlCommand cmd2 = new SqlCommand(sql2, conn2);
                                    cmd2.ExecuteNonQuery();
                                    this.DialogResult = DialogResult.OK;
                                    MessageBox.Show("。成功！！！！");
                                 }
                                catch (Exception ex)
                                {
                                    this.DialogResult = DialogResult.No;
                                    MessageBox.Show(ex.Message + "\r\n" + "对不起！输入出错！！！\n\r请重新添加!!!");
                                }
                            }
                            
                            string sql4 = string.Format("delete from repoinfo where medno="+tr[0].ToString());
                            using (SqlConnection conn4 = new SqlConnection(dataconnection.str))
                            {
                                try
                                {
                                    conn4.Open();
                                    SqlCommand cmd4 = new SqlCommand(sql4, conn4);
                                    cmd4.ExecuteNonQuery();
                                    this.DialogResult = DialogResult.OK;
                                    MessageBox.Show("更新仓库信息表成功！！！！");
                                    re_Form2_Load();
                                 }
                                catch (Exception ex)
                                {
                                    this.DialogResult = DialogResult.No;
                                    MessageBox.Show(ex.Message + "\r\n" + "对不起！输入出错！！！\n\r请重新添加!!!");
                                }
                            }
                        }
                    }
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            DataSet ds = new DataSet();
            string sql = "select * FROM repoin";
            SqlConnection conn = new SqlConnection(dataconnection.str);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            DataSet ds = new DataSet();
            string sql = "select * FROM repoout";
            SqlConnection conn = new SqlConnection(dataconnection.str);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            DataSet ds = new DataSet();
            string sql = "select * FROM repoinfo";
            SqlConnection conn = new SqlConnection(dataconnection.str);
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            re_Form2_Load();
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}