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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_login_Click(object sender, EventArgs e)
        {


            if (radioButton2.Checked)
            {
                string cliname = textBox_user_name.Text.Trim();
                string clipasswd = textBox_password.Text.Trim();
                string sql = string.Format("select count(1) from clientinfo where cliname=N'{0}'and clipasswd='{1}'", cliname, clipasswd);
                using (SqlConnection conn = new SqlConnection(dataconnection.str))
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    int n = Convert.ToInt32(cmd.ExecuteScalar());
                    if (n > 0)
                    {
                        MessageBox.Show("登陆成功！");
                        Form3 fm3 = new Form3();
                        fm3.Show();
                        fm3.Cliname = cliname;
                     
                    }
                    else
                    {
                        string sql2 = string.Format("select count(2) from clientinfo where cliname=N'{0}'", cliname);
                        using (SqlConnection conn2 = new SqlConnection(dataconnection.str))
                        {
                            SqlCommand cmd2 = new SqlCommand(sql2, conn2);
                            conn2.Open();
                            int m = Convert.ToInt32(cmd2.ExecuteScalar());
                            if (m > 0) MessageBox.Show("登陆失败，密码错误！");
                            else
                                MessageBox.Show("登陆失败，查无此人！！！");
                        }
                    }
                }
            }

            if (radioButton1.Checked)
            {
                string cliname = textBox_user_name.Text.Trim();
                string clipasswd = textBox_password.Text.Trim();
                try
                {
                    int ng = Convert.ToInt32(cliname);

               
                string sql2 = string.Format("select count(1) from admin where adminid='{0}'and adminpasswd='{1}'", cliname, clipasswd);
                using (SqlConnection conn = new SqlConnection(dataconnection.str))
                {
                    SqlCommand cmd = new SqlCommand(sql2, conn);
                    conn.Open();
                        int n = Convert.ToInt32(cmd.ExecuteScalar());
                    if (n > 0)
                    {
                        MessageBox.Show("登陆成功！");
                        Form2 fm2 = new Form2();
                        fm2.Show();
                    }
                    else
                    {
                        string sql3 = string.Format("select count(2) from clientinfo where cliname=N'{0}'", cliname);
                        using (SqlConnection conn2 = new SqlConnection(dataconnection.str))
                        {
                            SqlCommand cmd2 = new SqlCommand(sql3, conn2);
                            conn2.Open();
                            int m = Convert.ToInt32(cmd2.ExecuteScalar());
                            if (m > 0) MessageBox.Show("登陆失败，密码错误！");
                            else
                                MessageBox.Show("登陆失败，查无此人！！！");
                        }
                    }
                }
                }
                catch (Exception)
                {
                    MessageBox.Show("输入用户名错误!请核对用户名之后再重新登陆!");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.radioButton2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 user_register = new Form7();
            //user_register.Login = this;

            if (user_register.ShowDialog() == DialogResult.OK)
            {
                string USER_NAME = user_register.Cliname;
                string USER_PASSWORD = user_register.Clipasswd;
                MessageBox.Show("恭喜你，注册成功！！！\r\n用户名为：" + USER_NAME + "   密码为：" + USER_PASSWORD + "\r\n请去登录！！！");

            }
            else
            {
                MessageBox.Show("未注册！！！");
            }
        }
        private void button_quit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}