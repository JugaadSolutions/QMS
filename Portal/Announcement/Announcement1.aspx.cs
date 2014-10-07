using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal.DLayer;
using System.Data;
using System.Data.SqlClient;
using Portal.Entity;


namespace Portal.Announcement
{
    
    public partial class Announcement1 : System.Web.UI.Page
    {
        DataAccess da;
        protected void Page_Load(object sender, EventArgs e)
        {
            da = new DataAccess();
            Label1.Text = "Number of Patients:";
            Label2.Text = Convert.ToString(da.CountPatient());

           
            if (da.GetPatient() == null) Button1.Enabled = false;
           

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Response.Redirect("~/Announcement/Announcement2.aspx");
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            Label1.Text = "Number of Patients:";
            Label2.Text = Convert.ToString(da.CountPatient());
           
        }
    }
}