using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Portal.Registration;
using System.Data;
using System.Data.SqlClient;
using Portal.DLayer;





namespace Portal.Registration
{
    public partial class PatientRegistration : System.Web.UI.Page
    {
        DataAccess da;
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            da = new DataAccess();
        }
       
        protected void Button1_Click(object sender, EventArgs e)
        {
            
            
          int token = da.RegisterPatient(TextBox1.Text,TextBox2.Text);
          Token.Value = token.ToString();
            if(token != -1 )
            {
               
                MsgBox("Registration Successfull your token number is  " + token + "");
               // Response.Write("<script>alert('Registration Successfull your token number is  " + token + "');</script>");
                TextBox1.Text = "";
                TextBox2.Text = "";
                
            }
            else
            {
                MsgBox("invalid registration");
            }

        }
        void MsgBox(string strMsg)
        {
            Label lbl = new Label();
            lbl.Text = "<script language='javascript'>" + Environment.NewLine + "window.alert(" + "'" + strMsg + "'" + ")</script>";
            Page.Controls.Add(lbl);
        }

    }
    
}