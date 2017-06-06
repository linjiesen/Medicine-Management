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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button_cancle_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button_sure_Click(object sender, EventArgs e)
        {
            string medname = textBox_medname.Text.Trim();
            try
            {
                int mednum = Convert.ToInt32(textBox_mednum.Text.ToString().Trim());
                string medmanufacturer = textBox_medmanufacturer.Text.Trim();
                string meddate = dateTimePicker1.Text.Trim();
                string medmethod = textBox_medmethod.Text.Trim();
                string medprice = textBox_medprice.Text.Trim();
                string medoperator = textBox_medoperator.Text.Trim();
                int medquality = Convert.ToInt32(comboBox_medquality.Text.Trim());

                if (!medname.Equals("") && !medmanufacturer.Equals("") && !meddate.Equals("") && !medmethod.Equals("") && !medprice.Equals("") && !medquality.Equals("") && !medoperator.Equals(""))
                {
                    string sql = string.Format("insert into medicineinfo (mednum,medname,medmanufacturer,meddate,medmethod,medprice,medquality,medoperator) values('{0}', N'{1}', N'{2}', N'{3}', N'{4}', N'{5}', '{6}', N'{7}')", mednum, medname, medmanufacturer, meddate, medmethod, medprice, medquality, medoperator);
                    using (SqlConnection conn = new SqlConnection(dataconnection.str))
                    {
                        try
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                        }
                    catch (Exception ex)
                    {
                        this.DialogResult = DialogResult.No;
                        MessageBox.Show(ex.Message + "\r\n" + "对不起！输入出错！！！\n\r请重新添加!!!");
                    }
                }

                    string medrepointime = DateTime.Now.ToShortDateString().ToString();             //获取系统当前时间
                    string sql2 = string.Format("insert into repoin (mednum,medname,medmanufaturer,meddate,medrepointime) values('{0}', N'{1}', N'{2}', N'{3}',N'{4}')", mednum, medname, medmanufacturer, meddate, medrepointime);
                    using (SqlConnection conn2 = new SqlConnection(dataconnection.str))
                    {
                        try
                        {
                            conn2.Open();
                            SqlCommand cmd2 = new SqlCommand(sql2, conn2);
                            cmd2.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            this.DialogResult = DialogResult.No;
                            MessageBox.Show(ex.Message + "\r\n" + "对不起！输入出错！！！\n\r请重新添加!!!");
                        }
                    }
                    string sql3 = string.Format("insert into repoinfo (mednum,medname,medmanufaturer,medlocate,meddate) values('{0}', N'{1}', N'{2}', N'{3}',N'{4}')", mednum, medname, medmanufacturer, "安徽工业大学",meddate);
                    using (SqlConnection conn3 = new SqlConnection(dataconnection.str))
                    {
                        try
                        {
                            conn3.Open();
                            SqlCommand cmd3 = new SqlCommand(sql3, conn3);
                            cmd3.ExecuteNonQuery();
                            this.DialogResult = DialogResult.OK;
                        }
                        catch (Exception ex)
                        {
                            this.DialogResult = DialogResult.No;
                            MessageBox.Show(ex.Message + "\r\n" + "对不起！输入出错！！！\n\r请重新添加!!!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请确保必填项非空！！！");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("输入错误!!!");
            }
        }
     }
}
