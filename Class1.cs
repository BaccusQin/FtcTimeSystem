using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;


namespace FtcTimeSystem
{

    public partial class main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //1.获取配置文件里面配置的数据库连接字符串

            String connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();

            SqlConnection connection = new SqlConnection(connectionString);

            // Create the Command and Parameter objects.



            //2.sql语句

            string queryString =

            "SELECT * from T_Attendance";





            SqlCommand command = new SqlCommand(queryString, connection);

            // Open the connection in a try/catch block.

            // Create and execute the DataReader, writing the result

            // set to the console window.

            //3.打开连接

            connection.Open();

            //4.执行sql语句

            SqlDataReader reader = command.ExecuteReader();



            //5.查看返回结果

            while (reader.Read())

            {

                Console.WriteLine("\t{0}\t{1}\t{2}",

                reader[0], reader[1], reader[2]);

                String a = reader[0].ToString();

                Console.WriteLine(a);

            }

            //6.关闭连接

            reader.Close();


        }
    }
}