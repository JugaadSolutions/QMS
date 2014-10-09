using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using Portal.Entity;

namespace Portal.DLayer
{
     
    public class DataAccess
    {
        String Connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=QMS;Persist Security Info=True;User ID=sa;Password=sushma";

        public int RegisterPatient(String Name,String Id,String token)
        {

            String query = @"insert into PatientQ(Name,Id,Status,TimeStamp,Token) values('{0}','{1}','NEW','{2}','{3}')";
            query = String.Format(query, Name, Id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),Convert.ToInt32(token));
            SqlConnection cn;
            SqlCommand cmd, cmd1;
            SqlDataReader dr;
            cn = new SqlConnection(Connection);
            cn.Open();
            cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();
            cmd1 = new SqlCommand("select max(Token) from PatientQ where status='NEW'", cn);
            dr = cmd1.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            if (dt.Rows.Count > 0)
            {
                int Token = (int)dt.Rows[0][0];
                return Token;
                
            }

            return -1;
        }
        public Patient GetPatient()
        {
            String query = @"Select top(1) Name,Id,Token,Status From PatientQ Where Status='NEW' order by TimeStamp asc";
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            cn = new SqlConnection(Connection);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            dr=cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            if (dt.Rows.Count > 0)
            {
                Patient p = new Patient(dt.Rows[0]["Name"] as string, (string)dt.Rows[0]["Id"], (int)dt.Rows[0]["Token"], (string)dt.Rows[0]["Status"]);
                return p;
            }
            else
            {
                query = @"Select top(1) Name,Id,Token,Status From PatientQ Where Status='MISSED' order by TimeStamp asc";
              
                cn = new SqlConnection(Connection);
                cn.Open();
                cmd = new SqlCommand(query, cn);

                dr = cmd.ExecuteReader();
                dt = new DataTable();
                dt.Load(dr);
                dr.Close();
                cn.Close();
                if (dt.Rows.Count > 0)
                {
                    Patient p = new Patient(dt.Rows[0]["Name"] as string, (string)dt.Rows[0]["Id"], (int)dt.Rows[0]["Token"], (string)dt.Rows[0]["Status"]);
                    return p;
                }
                return null;
            }
        }
        public void NewPatient(int Token)
        {

            String query = @"Update PatientQ SET Status='ASSIGNED',TimeStamp='{0}'  where Token={1} ";
            query = String.Format(query,  DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),Token);
            SqlConnection cn;
            SqlCommand cmd;
            //SqlDataReader dr;
            cn = new SqlConnection(Connection);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            cmd.ExecuteNonQuery();
            
            cn.Close();
            
            

        }
        public void AssignPatient(int Token,String IP)
        {
            String query = @"Update PatientQ SET IP='{0}',Status='CALL' where Token={1}";
            query=String.Format(query,IP,Token);
            SqlConnection cn;
            SqlCommand cmd;
            //SqlDataReader dr;
            cn = new SqlConnection(Connection);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            cmd.ExecuteNonQuery();

            cn.Close();
        }
        public void ReQueuePatient(int Token, String IP)
        {
            String query = @"Update PatientQ SET IP=' ',Status='MISSED' where Token={1}";
            query = String.Format(query, IP, Token);
            SqlConnection cn;
            SqlCommand cmd;
            //SqlDataReader dr;
            cn = new SqlConnection(Connection);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            cmd.ExecuteNonQuery();

            cn.Close();
        }
        public void Served(int Token)
        {
            String query = @"Update PatientQ SET Status='DONE' where Token={0}";
            query = String.Format(query, Token);
            SqlConnection cn;
            SqlCommand cmd;
            //SqlDataReader dr;
            cn = new SqlConnection(Connection);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            cmd.ExecuteNonQuery();

            cn.Close();
        }
        public int  CountPatient()
        {
            String query = @"Select Count(Token) From PatientQ Where Status='NEW' OR Status='MISSED'";
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            cn = new SqlConnection(Connection);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            dr=cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            if (dt.Rows.Count > 0)
            {
               int Token = (int)dt.Rows[0][0];
               return Token;
            }
            else
            
            return 0;
        }
        public bool GetIP(String ip)
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            cn = new SqlConnection(Connection);
            String query = @"Select [IP] From [IP] where IP='{0}'";
            query = String.Format(query, ip);
            cn = new SqlConnection(Connection);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            if (dt.Rows.Count > 0)
            {
                
                return true;
            }
            
            return false;
                    
                    
        }
        public bool Login(String password)
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;

            cn = new SqlConnection(Connection);
            String query = @"Select Password From Users where Password='{0}'";
            query = String.Format(query, password);
            cn = new SqlConnection(Connection);
            cn.Open();
            cmd = new SqlCommand(query, cn);

            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            if (dt.Rows.Count > 0)
            {

                return true;
            }

            return false;


        }
        public void SetToken(int token)
        {
            SqlConnection cn;
            SqlCommand cmd;
            cn = new SqlConnection(Connection);
            String query = @"Update Config SET value={0} ";
            query = String.Format(query,token);
            cn = new SqlConnection(Connection);
            cn.Open();

            cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();

            cn.Close();
        }
        public int GetToken()
        {
            SqlConnection cn;
            SqlCommand cmd;
            SqlDataReader dr;
            cn = new SqlConnection(Connection);
            cn.Open();
            cmd = new SqlCommand("select value from Config", cn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dr.Close();
            cn.Close();
            if (dt.Rows.Count > 0)
            {
                int Token = (int)dt.Rows[0][0];
                return Token;
            }
            return -1;
        }
        public void Increment()
        {
            SqlConnection cn;
            SqlCommand cmd;
            cn = new SqlConnection(Connection);
            String query = @"Update Config SET value=value+1 ";
            query = String.Format(query, cn);
            cn = new SqlConnection(Connection);
            cn.Open();

            cmd = new SqlCommand(query, cn);
            cmd.ExecuteNonQuery();

            cn.Close();
        }
    }
    
}