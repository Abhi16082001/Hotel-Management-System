using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Management
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) Master.HideNav = true;
            else Master.HideNav = false;
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            excpn.Visible = false;
            Response.Redirect("Registration.aspx");
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            excpn.Visible = false;
            SqlConnection con= new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string user = username.Text;
                string pwd=password.Text;
                string constr = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
                con.ConnectionString = constr;
                con.Open();
                string query = "Select Password From Users Where Uname=@username";
                cmd.Connection= con;
                cmd.CommandText= query;
                cmd.Parameters.AddWithValue("@username",user);
                object res =cmd.ExecuteScalar();
                string dbpwd = (res == null || res == DBNull.Value) ? null : res.ToString();
                if (dbpwd == null) throw new Exception("UserName Doesn't Exist");
                if (dbpwd == pwd)
                {
                    Session["username"] = user;
                    Response.Redirect("DashBoard.aspx");
                    Master.HideNav = false;
                }
                else throw new Exception("Wrong Password !");
            }
            catch(Exception ex) { 
                excpn.Text=ex.Message;
                excpn.Visible = true;
            }
            finally
            {
                con.Close();
            }
            
        }
    }
}