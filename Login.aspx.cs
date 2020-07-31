using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FtcTimeSystem
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void LoginTo_Click(object sender, EventArgs e)
        {
            string userid = Username.Text;
            string userpassword = Password.Text;
            int result=Connection.GetPassword(userid, userpassword);
           
            if (result==1)
            {
                Label1.Text = "パスワードが間違います";
            }
            else if (result==2)
            {
                Label1.Text = "ユーザが存在しません";
            }
            else if (result==0)
            {
                Label1.Text = "ログイン中";
                Session["userid"] = userid;
                Response.Redirect("Menu.aspx");

            }
        }
    }
}