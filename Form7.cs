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
    public partial class Form7 : Form
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
        private string clipasswd;
        public string Clipasswd
        {
            set
            {
                clipasswd = value;
            }
            get
            {
                return clipasswd;
            }
        }

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox_cliname.Text.ToString().Trim();
            string phone = textBox_phone.Text.ToString().Trim();
            string passwd = textBox_password.Text.ToString().Trim();
            string sex= textBox_sex.Text.ToString().Trim();
            string age = textBox_age.Text.ToString().Trim();
            if (!name.Equals("") && !sex.Equals("") && !passwd.Equals("") && !sex.Equals("") && !age.Equals("") )
            {
                string sql = string.Format("insert into clientinfo (cliname,cliphone,clipasswd,clisex,cliage) values (N'{0}',N'{1}',N'{2}',N'{3}',N'{4}')", name, phone,passwd, sex,age);
                SqlConnection conn = dataconnection.get_connection();
                try
                {
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    this.DialogResult = DialogResult.OK;
                    this.cliname = name;
                    this.clipasswd = passwd;
                 }
                catch (Exception)
                {
                    MessageBox.Show("\r\n" + "对不起！输入出错,该用户名已存在！！！ \n\r请重新添加！！！");
                    this.DialogResult = DialogResult.Cancel;
                }
                finally
                {
                    conn.Close();
                }
             }
            else
            {
                MessageBox.Show("请确保必填项非空！！！" + "\n\r密码与确认密码相同！！！");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
