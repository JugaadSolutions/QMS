using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal.Entity
{
    public class Patient
    {

        public String Name { get; set;}
        public String ID { get; set; }
        public int Token { get; set; }
        public String Status { get; set; }
        public String IP{get;set;}

        public Patient(String name, String Id, int token, String status)
        {
            Name = name;
            ID = Id;
            Token = token;
            Status = status;
        }

        
    }
}