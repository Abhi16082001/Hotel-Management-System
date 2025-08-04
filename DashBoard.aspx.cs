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
    public partial class DashBoard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FetchUser(Session["username"].ToString());
                FetchUser();
            }
            excpn.Visible = false;
            
        }


    private void FetchUser(string un=null)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            DataTable dr = new DataTable();
            try
            {              
                string constr = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
                con.ConnectionString = constr;
                string query = "";
                if (un == null)
                {
                    query = "select * from Users";
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    UsrDtls.DataSource = dt;
                    UsrDtls.DataBind();
                }
                else {                    
                    query = "select * from Users where Uname=@username";
                    cmd.CommandText= query;
                    cmd.Connection= con;
                    cmd.Parameters.AddWithValue("@username",un);
                    da.SelectCommand = cmd;
                    da.Fill(dr);
                    welcome.Text += un + " !!";
                    username.Text = un;                   
                    email.Text = dr.Rows[0]["Email"].ToString();
                    name.Text = dr.Rows[0]["Fname"].ToString() + " " + dr.Rows[0]["Lname"].ToString();
                    string gen = dr.Rows[0]["Gender"].ToString();
                    if (gen == "M") gender.Text = "Male";
                    else if (gen == "F") gender.Text = "Female";
                    else gender.Text = gen;
                        phone.Text = dr.Rows[0]["Phone"].ToString();
                    address.Text = dr.Rows[0]["Address"].ToString();
                    age.Text = dr.Rows[0]["Age"].ToString();
                    lang.Text = dr.Rows[0]["Lang"].ToString();
                    country.Text = dr.Rows[0]["Country"].ToString();

                }
                   
            }
            catch (Exception ex)
            {
                excpn.Text = ex.Message;
                excpn.Visible = true;
            }
        }
        protected void UsrDtls_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                 GridViewRow row = UsrDtls.Rows[e.RowIndex];
                Label un = (Label)row.FindControl("Label3");
                string constr = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
                con.ConnectionString = constr;
                con.Open();
                string query = "delete from Users where Uname=@user";
                cmd.CommandText = query;
                cmd.Connection=con;
                cmd.Parameters.AddWithValue("@user", un.Text);
                cmd.ExecuteNonQuery();
                
            }
            catch (Exception ex)
            {
                excpn.Text = ex.Message;
                excpn.Visible = true;
            }
            finally {
                con.Close();
                FetchUser();
            }
        }

        protected void UsrDtls_RowEditing(object sender, GridViewEditEventArgs e)
        {
            UsrDtls.EditIndex = e.NewEditIndex;
            FetchUser();
        }

        protected void UsrDtls_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                GridViewRow row = UsrDtls.Rows[e.RowIndex];
                var fname = (TextBox)row.FindControl("TextBox1");
                var lname = (TextBox)row.FindControl("TextBox2");
                var uname = (Label)row.FindControl("TextBox3");
                var gndr = (TextBox)row.FindControl("TextBox4");
                var pwd = (TextBox)row.FindControl("TextBox5");
                var email = (TextBox)row.FindControl("TextBox6");
                var phone = (TextBox)row.FindControl("TextBox7");
                var addrs = (TextBox)row.FindControl("TextBox8");
                var age = (TextBox)row.FindControl("TextBox9");
                var lang = (TextBox)row.FindControl("TextBox10");
                var country = (TextBox)row.FindControl("TextBox11");
                string constr = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
                con.ConnectionString = constr;
                con.Open();
                string query = "update Users set Fname=@fnm, Lname=@lnm, Gender=@gndr,Password=@pwd,Phone=@phone, Email=@eml, Address=@addrs, Age=@age,Lang=@lang, Country=@cntry where Uname=@user";
                cmd.Connection= con;
                cmd.CommandText= query;
                cmd.Parameters.AddWithValue("@fnm", fname.Text);
                cmd.Parameters.AddWithValue("@lnm", lname.Text);
                cmd.Parameters.AddWithValue("@user", uname.Text);
                cmd.Parameters.AddWithValue("@gndr", gndr.Text);
                cmd.Parameters.AddWithValue("@pwd", pwd.Text);
                cmd.Parameters.AddWithValue("@eml", email.Text);
                cmd.Parameters.AddWithValue("@phone", phone.Text);
                cmd.Parameters.AddWithValue("@addrs", addrs.Text);
                cmd.Parameters.AddWithValue("@age", age.Text);
                cmd.Parameters.AddWithValue("@lang", lang.Text);
                cmd.Parameters.AddWithValue("@cntry", country.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                excpn.Text = ex.Message;
                excpn.Visible = true;
            }
            finally {
                con.Close();
                UsrDtls.EditIndex = -1;
                FetchUser();
            }

        }

        protected void UsrDtls_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            UsrDtls.EditIndex = -1;
            FetchUser();
        }

        protected void UsrDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UsrDtls.PageIndex = e.NewPageIndex;
            FetchUser();
        }
    }
}