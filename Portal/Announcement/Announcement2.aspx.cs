using Portal.DLayer;
using Portal.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal.Announcement
{
    public partial class Announcement2 : System.Web.UI.Page
    {
        static DataAccess da;
        static Patient curPatient;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                da = new DataAccess();
                curPatient = da.GetPatient();
                da.NewPatient(curPatient.Token);
                TextBox1.Text = curPatient.Token.ToString();
                TextBox2.Text = curPatient.ID;
                TextBox3.Text = curPatient.Name;
                TextBox4.Text = curPatient.Status;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            curPatient.IP = Request.UserHostAddress;
            da.AssignPatient(curPatient.Token, curPatient.IP);

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            da.ReQueuePatient(curPatient.Token,curPatient.IP);
            Response.Redirect("~/Announcement/Announcement1.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            da.Served(curPatient.Token);
            Response.Redirect("~/Announcement/Announcement1.aspx");
        }

    }
}