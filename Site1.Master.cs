using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hotel_Management
{
    public partial class Site1 : System.Web.UI.MasterPage
    {


        public bool HideNav
        {
            set
            {
                if (value) { dash.Attributes["hidden"] = "hidden"; 
                             room.Attributes["hidden"] = "hidden";
                            booked.Attributes["hidden"] = "hidden";
                                }
                else {dash.Attributes.Remove("hidden");
                        room.Attributes.Remove("hidden");
                    booked.Attributes.Remove("hidden");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

}