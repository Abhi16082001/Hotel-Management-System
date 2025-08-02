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
    public partial class HotelReg : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) username.Text = Session["username"].ToString();
            hidelabel();   
        }

        private void hidelabel()
        {
            excpn.Visible = false;
            success.Visible = false;
        }

        protected void Hregister_Click(object sender, EventArgs e)
        {
            hidelabel();
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            try
            {
                string user = username.Text;
                string room = RoomType.SelectedItem.Text;
                List<string> selectedAmenty= new List<string>();
                foreach(ListItem i in Amenities.Items)
                {
                    if(i.Selected) selectedAmenty.Add(i.Text);
                }
                string amnt = string.Join(", ",selectedAmenty);
                string constr = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
                con.ConnectionString = constr;
                con.Open();
                string query = "Insert into Rooms values(@username,@Roomtype,@Amenities)";
                cmd.CommandText = query;
                cmd.Connection= con;
                cmd.Parameters.AddWithValue("@username",user);
                cmd.Parameters.AddWithValue("@Roomtype",room);
                cmd.Parameters.AddWithValue("@Amenities",amnt);
                cmd.ExecuteNonQuery();
                success.Text = "Room Booked Successfully !!";
                success.Visible= true;
            }
            catch (Exception ex)
            {
                excpn.Text = ex.Message;
                excpn.Visible = true;
            }
            finally {
                con.Close();            
            }

        }
    }
}