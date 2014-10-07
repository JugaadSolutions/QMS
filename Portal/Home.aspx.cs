using Portal.DLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;


namespace Portal
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String HostName = Dns.GetHostName();
            String MyIP = Dns.GetHostByName(HostName).AddressList[0].ToString();
            Label1.Text = MyIP;
            DataAccess da = new DataAccess();
            bool b = da.GetIP(Label1.Text);
            if (b == true)
            {
                Response.Redirect("~/Announcement/Announcement1.aspx");
            }
            else
            {
                Response.Redirect("~/Registration/PatientRegistration.aspx");
            }

        }
    }
}