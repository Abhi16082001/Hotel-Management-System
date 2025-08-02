using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Hotel_Management
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null) Master.HideNav = true;
            else Master.HideNav = false;
            excpn.Visible = false;
        }

        protected void register_Click(object sender, EventArgs e)
        {
            SqlConnection con=new SqlConnection();
            try
            {
                string first = fname.Text;
                string last = lname.Text;
                string uname = usrnm.Text;
                char gndr = 'M';
                if (male.Checked) gndr = 'M';
                if (fmale.Checked) gndr = 'F';
                string password = pwd.Text;
                string email = eml.Text;
                string phone = phn.Text;
                string address = addrs.Text;
                int ag = Convert.ToInt32(age.Text);
                string lang = "";
                if (eng.Checked) lang += eng.Text + ", ";
                if (hindi.Checked) lang += hindi.Text + ", ";
                if (telugu.Checked) lang += telugu.Text;
                if (lang[lang.Length - 1] == ' ' && lang[lang.Length - 2] == ',')
                    lang = lang.Substring(0, lang.Length - 2);
                string country = cntry.SelectedItem.Text;

                string constr = ConfigurationManager.ConnectionStrings["SqlCon"].ConnectionString;
                con.ConnectionString = constr;
                con.Open();
                string query = "Insert into Users values(@fname,@lname,@uname,@gender,@password,@email,@phone,@address,@age,@lang,@country)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@fname", first);
                cmd.Parameters.AddWithValue("@lname", last);
                cmd.Parameters.AddWithValue("@uname", uname);
                cmd.Parameters.AddWithValue("@gender", gndr);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@age", ag);
                cmd.Parameters.AddWithValue("@lang", lang);
                cmd.Parameters.AddWithValue("@country", country);
                cmd.ExecuteNonQuery();
            Response.Redirect("RegSuccess.aspx");
            }
            catch (Exception ex) {
                excpn.Text = ex.Message;
                excpn.Visible = true;
            }
            finally{ 
            con.Close();
            }
        }
    }
}