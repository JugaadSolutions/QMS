using Portal.DLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Portal.Admin
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel2.Visible = false;

        }

        

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataAccess da = new DataAccess();
            bool b = da.Login(TextBox1.Text);
            if (b == true)
            {
                Panel2.Visible = true;
                
            }
            else
            {
                Panel2.Visible = false;
                Response.Write("<script>alert('Invalid Password');</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int token = Convert.ToInt32(TextBox2.Text);
            DataAccess da = new DataAccess();
             da.SetToken(token);
             Response.Write("<script>alert('Token Set Successfully');if(alert){ window.location='../Home.aspx';}</script>");
        }
    }
}