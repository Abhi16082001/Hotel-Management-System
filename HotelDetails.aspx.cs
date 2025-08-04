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
    public partial class HotelDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { FetchRooms(); FetchUserRooms();

            }
            excpn.Visible = false;
        }

        private void FetchRooms()
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
                con.ConnectionString = constr;
                string query = "select * from Rooms";
                cmd.CommandText = query;
                cmd.Connection = con;
                da.SelectCommand = cmd;
                da.Fill(dt);
                RmDtls.DataSource = dt;
                RmDtls.DataBind();
            }
            catch (Exception ex)
            {
                excpn.Text = ex.Message;
                excpn.Visible = true;
            }

        }

        private void FetchUserRooms() {

            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            { string user = Session["username"].ToString();
                string constr = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
                con.ConnectionString = constr;
                string query = "select Roomtype, Amenities from Rooms where Uname=@username";
                cmd.Connection = con;
                cmd.CommandText = query;
                cmd.Parameters.AddWithValue("@username",user);
                da.SelectCommand = cmd;
                da.Fill(dt);
                usrnm.Text = user;
                if (dt != null && dt.Rows.Count > 0)
                {
                    Repeater1.DataSource = dt;
                    Repeater1.DataBind();
                    rooms.Visible = false;
                }
                else {
                    rooms.Text = "You haven't booked any Rooms !";
                    rooms.Visible = true;
                }
            }
            catch (Exception ex)
            {
                excpn.Text = ex.Message;
                excpn.Visible = true;
            }

        }

        protected void RmDtls_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                GridViewRow row = RmDtls.Rows[e.RowIndex];
                Label usr = (Label)row.FindControl("Label1");
                string constr = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
                con.ConnectionString = constr;
                con.Open();
                string query = "Delete from Rooms where Uname=@username";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@username",usr.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                excpn.Text = ex.Message;
                excpn.Visible = true;
            }
            finally {
                con.Close();
                FetchRooms();
            }

        }

        protected void RmDtls_RowEditing(object sender, GridViewEditEventArgs e)
        {
            RmDtls.EditIndex = e.NewEditIndex;
            FetchRooms();
        }

        protected void RmDtls_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                GridViewRow row = RmDtls.Rows[e.RowIndex];
                Label uname = (Label)row.FindControl("TextBox1");
                TextBox rmtp = (TextBox)row.FindControl("TextBox2");
                TextBox amnt = (TextBox)row.FindControl("TextBox3");
                string constr = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
                con.ConnectionString = constr;
                con.Open();
                string query = "Update Rooms set Roomtype=@room, Amenities=@amnts where Uname=@user";
                cmd.CommandText = query;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@room",rmtp.Text);
                cmd.Parameters.AddWithValue("@amnts",amnt.Text);
                cmd.Parameters.AddWithValue("@user",uname.Text);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                excpn.Text = ex.Message;
                excpn.Visible = true;
            }
            finally {
                con.Close();
                RmDtls.EditIndex = -1;
                FetchRooms();
            }
            }

        protected void RmDtls_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            RmDtls.EditIndex = -1;
            FetchRooms();
        }

        protected void RmDtls_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            RmDtls.PageIndex = e.NewPageIndex;
            FetchRooms();
        }
    }
}