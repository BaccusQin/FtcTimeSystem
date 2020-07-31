using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;


namespace FtcTimeSystem
{

    public partial class Index : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CloseAllPage();
                datepicker1.Visible = false;
                ChooseDate.Visible = false;
                page5.Visible = true;
                StartGridView();
                GetApply();
                GetApprove();

            }
            userid.Text =Session["userid"].ToString();


        }
        public void GetApply()
        {
            string userid = Session["userid"].ToString();
            ApplyData.AllowPaging = true;
            ApplyData.DataSource = Connection.GetApplyData(userid);
            ApplyData.DataBind();
        }
        public void GetApprove()
        {
            string userid = Session["userid"].ToString();
            DataTable dt = new DataTable();
            DropDownList dd = new DropDownList();

            dt = Connection.GetApproveData(userid).Tables[0];
            ApproveData.AllowPaging = true;
            ApproveData.DataSource = Connection.GetApproveData(userid);
           

            for (int i=0;i<ApproveData.Rows.Count;i++)
            {
                dd = (DropDownList)ApproveData.Rows[i].FindControl("Drop_ApproveTitle");
                dd.DataSource = Connection.GetApproveData(userid).Tables[0].DefaultView;
                dd.DataValueField = "Result";
                dd.DataTextField = "Status";
                dd.DataBind();
            }
            
           
            ApproveData.DataBind();
        }
        public void CloseAllPage()
        {
           for(int i=1; i<6; i++)
            {
                this.Page.FindControl("page" + i).Visible = false;
                
            }
        }
        public void ChooseDate_Click(object sender, EventArgs e)
        {
            TimeData.AllowPaging = true;
            string userid = Session["userid"].ToString();
            string date = datepicker1.Text.Substring(0, 7).Remove(4, 1);
            TimeData.DataSource = Connection.Connect(userid, date);
            TimeData.DataBind();
           

        }
        public void ApplyButton_Click(object sender, EventArgs e)
        {
            string userid = Session["userid"].ToString();
            string connectString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string sql = "proc_Apply";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ApplyUser", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@Title", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ApplyTime", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@AddWorkTime", SqlDbType.Decimal, 10);
            cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 100);
            cmd.Parameters["@ApplyUser"].Value = userid;
            cmd.Parameters["@ApplyTime"].Value = datepicker2.Text;
            cmd.Parameters["@Title"].Value = DropDownList_Title.Text;
            cmd.Parameters["@AddWorkTime"].Value = Convert.ToDecimal(ApplyTime.Text);
            cmd.Parameters["@Reason"].Value = ApplyReason.Text;
            cmd.ExecuteNonQuery();
           
            conn.Close();
            GetApply();

        }
        public void ApproveButton_Click(object sender, EventArgs e)
        {
            string userid = Session["userid"].ToString();
            string connectString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            string sql = "proc_Approve";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ApplyUser", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@Title", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@ApplyTime", SqlDbType.VarChar, 50);
            cmd.Parameters.Add("@AddWorkTime", SqlDbType.Decimal, 10);
            cmd.Parameters.Add("@Reason", SqlDbType.VarChar, 100);
            cmd.Parameters["@ApplyUser"].Value = userid;
            cmd.Parameters["@ApplyTime"].Value = datepicker2.Text;
            cmd.Parameters["@Title"].Value = DropDownList_Title.Text;
            cmd.Parameters["@AddWorkTime"].Value = Convert.ToDecimal(ApplyTime.Text);
            cmd.Parameters["@Reason"].Value = ApplyReason.Text;
            cmd.ExecuteNonQuery();

            conn.Close();
            GetApprove();

        }
        protected void AttendanceData_Click(object sender, EventArgs e)
        {
            CloseAllPage();
            page1.Visible = true;
            datepicker1.Visible =　true;
            ChooseDate.Visible = true;


        }
        protected void AttendanceDay_Click(object sender, EventArgs e)
        {
            CloseAllPage();
            page2.Visible = true;
            datepicker1.Visible = true;
            ChooseDate.Visible = true;


        }
        protected void Apply_Click(object sender, EventArgs e)
        {

            CloseAllPage();
            page3.Visible = true;
           datepicker1.Visible = false;
            ChooseDate.Visible = false;
            

        }
        protected void Approve_Click(object sender, EventArgs e)
        {

            CloseAllPage();
            page4.Visible = true;
            datepicker1.Visible = false;
            ChooseDate.Visible = false;
           
        }
        protected void TimeData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            TimeData.PageIndex = e.NewPageIndex;
            ChooseDate_Click(null, null);

        }
        protected void StartGridView()
        {
            string userid = "17519";
            string date = "201905";
            DataTable tmp_dt = Connection.Connect(userid, date).Tables[0];
            TimeData.AllowPaging = false;
            TimeData.DataSource = tmp_dt;
            TimeData.DataBind();
            for (int i = 0; i < this.TimeData.Rows.Count; i++)
                this.TimeData.Rows[i].Visible = false;
           
        }
        protected void Logout_Click(object sender, EventArgs e)
        {

            Response.Redirect("Login.aspx");

        }
    }
    public class Connection
    {
        public static DataSet Connect(string userid,string date)
        {
            string connectString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            string sql = "proc_Attendance";
            SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
            myda.SelectCommand.CommandType = CommandType.StoredProcedure;
            myda.SelectCommand.Parameters.Add("@Code", SqlDbType.VarChar, 50);
            myda.SelectCommand.Parameters.Add("@Date", SqlDbType.VarChar, 20);
            myda.SelectCommand.Parameters["@Code"].Value = userid;
            myda.SelectCommand.Parameters["@Date"].Value = date;
            DataSet ds = new DataSet();
            myda.Fill(ds, "myData");
            conn.Close();
            return ds;

        }
        public static int GetPassword(string userid,string userpassword)
        {
            string connectString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            string procedure = "User_Login";
            SqlConnection conn = new SqlConnection(connectString);
            SqlCommand cmd = new SqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter param;
            cmd.Parameters.Add("@ReturnValue", SqlDbType.Int, 4).Direction = ParameterDirection.ReturnValue;
            param = cmd.Parameters.Add("@userid", SqlDbType.VarChar, 50);
            param.Value = userid;
            param = cmd.Parameters.Add("@userpassword", SqlDbType.VarChar, 50);
            param.Value = userpassword;
            conn.Open();
            cmd.ExecuteNonQuery();
            int li_r = Convert.ToInt32(cmd.Parameters["@ReturnValue"].Value);
            conn.Close();
            return li_r;
        }
        public static DataSet GetApplyData(string userid)
        {
            string connectString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            string sql = "proc_TransData";
            SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
            myda.SelectCommand.CommandType = CommandType.StoredProcedure;
            myda.SelectCommand.Parameters.Add("@userid", SqlDbType.VarChar, 50);
            myda.SelectCommand.Parameters["@userid"].Value = userid;
            DataSet ds = new DataSet();
            myda.Fill(ds, "GetApplyData");
            conn.Close();
            return ds;

        }
        public static DataSet GetApproveData(string ApproveID)
        {
            string connectString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
            SqlConnection conn = new SqlConnection(connectString);
            conn.Open();
            string sql = "proc_TransDataApprove";
            SqlDataAdapter myda = new SqlDataAdapter(sql, conn);
            myda.SelectCommand.CommandType = CommandType.StoredProcedure;
            myda.SelectCommand.Parameters.Add("@ApproveID", SqlDbType.VarChar, 50);
            myda.SelectCommand.Parameters["@ApproveID"].Value = ApproveID;
            DataSet ds = new DataSet();
            myda.Fill(ds, "GetApproveData");
            conn.Close();
            return ds;

        }

    }

}