using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace 数据库课程设计
{
    class dataconnection
    {
        public static string str= @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=d:\用户目录\我的文档\visual studio 2017\Projects\数据库课程设计\数据库课程设计\databaseclass.mdf;Integrated Security = True";

        public static SqlConnection conn = new SqlConnection(dataconnection.str);
        public static SqlConnection get_connection()
        {
            return dataconnection.conn;
        }
    }
}
