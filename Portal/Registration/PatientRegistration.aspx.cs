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
using System.Configuration;





namespace Portal.Registration
{
    public partial class PatientRegistration : System.Web.UI.Page
    {
        public int Token;

        DataAccess da;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if ((TextBox1.Text == null) && (TextBox2.Text == null))Button1.Enabled = false;
                
            //else Button1.Enabled = true;
                
                       
            if (!Page.IsPostBack)
            {
                TextBox1.Text = "";
                TextBox2.Text = "";
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
             string cn = @"Data Source=.\SQLEXPRESS;Initial Catalog=QMS;Persist Security Info=True;User ID=sa;Password=sushma";

             //cn= ConfigurationManager.ConnectionStrings["Cn"].ToString();

             SqlConnection objsqlcn = new SqlConnection(cn);

                try

                {

                 if (TextBox1.Text != "")

                    {
                     objsqlcn.Open();
                     SqlCommand objcmd = new SqlCommand("usp_RegisterPatient", objsqlcn);
                    objcmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter Id = objcmd.Parameters.Add("@Id", SqlDbType.VarChar);
                    Id.Value = TextBox2.Text;
                    SqlParameter Name = objcmd.Parameters.Add("@Name", SqlDbType.VarChar);
                    Name.Value = TextBox1.Text;
                    SqlParameter Status = objcmd.Parameters.Add("@Status", SqlDbType.VarChar);
                    Status.Value = "NEW";
                     SqlParameter TimeStamp= objcmd.Parameters.Add("@TimeStamp", SqlDbType.DateTime);
                     TimeStamp.Value = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                     SqlParameter Token = objcmd.Parameters.Add("@Token", SqlDbType.Int);
                     Token.Direction = ParameterDirection.Output;
                     objcmd.ExecuteNonQuery();
                     //ClearAll();
                     

                     //Label1.Text = "Record inserted successfully. Token = " + Token.Value.ToString();
                     Response.Write("<script>alert('Registration Successfull your token number is  " + Token.Value + "');if(alert){ window.location='../Home.aspx';}</script>");
                    }

                }
                catch (Exception)

                 {
                     Label1.Text = "Registration failed ";
                     //Response.Write("<script>alert('Invalid Registration'</script>");

                 }
                finally

                 {
                     TextBox1.Text = "";
                     TextBox2.Text = "";
                     objsqlcn.Close();

                 }


                //da = new DataAccess();
                //String t = Convert.ToString(da.GetToken());

                //da.Increment();

                //Token = da.RegisterPatient(TextBox1.Text, TextBox2.Text, t);
                ////Token = Token.ToString();
                //if (Token != -1)
                //{



                //    Response.Write("<script>alert('Registration Successfull your token number is  " + Token + "');if(alert){ window.location='../Home.aspx';}</script>");



                //    TextBox1.Text = "";
                //    TextBox2.Text = "";



                //}
                //else
                //{
                //    Response.Write("<script>alert('Invalid Registration'</script>");
                    
                //}

            

        }
       
    }
    
}