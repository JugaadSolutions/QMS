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
        public int Token;

        DataAccess da;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((TextBox1.Text == null) && (TextBox2.Text == null))Button1.Enabled = false;
                
            else Button1.Enabled = true;
                
                       
            if (!Page.IsPostBack)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if ((TextBox1.Text == null))
            //{
            //    Response.Write("<script>alert('Fields cannot be empty....');</script>");

            //}
            //else
            //{


                da = new DataAccess();
                String t = Convert.ToString(da.GetToken());

                da.Increment();

                Token = da.RegisterPatient(TextBox1.Text, TextBox2.Text, t);
                //Token = Token.ToString();
                if (Token != -1)
                {



                    Response.Write("<script>alert('Registration Successfull your token number is  " + Token + "');if(alert){ window.location='../Home.aspx';}</script>");



                    TextBox1.Text = "";
                    TextBox2.Text = "";



                }
                else
                {
                    Response.Write("<script>alert('Invalid Registration'</script>");
                    //MsgBox("Invalid Registration");
                }

            }
           
    //}
       
    }
    
}