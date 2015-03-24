using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QMS.Models
{
    public class Config
    {
        public int Id { get; set; }
        public String key { get; set; }
        [Required]
        [Display(Name="Token No. :")]
        public int Value { get; set; }

        //[Display(Name = "Counter1 IP :")]
        //public int Counter1 { get; set; }

        //[Display(Name = "Counter2 IP :")]
        //public int Counter2 { get; set; }

        //[Display(Name = "Counter3 IP :")]
        //public int Counter3 { get; set; }

        //[Display(Name = "Counter4 IP :")]
        //public int Counter4 { get; set; }

        //[Display(Name = "Counter5 IP :")]
        //public int Counter5 { get; set; }

        //[Display(Name = "Counter6 IP :")]
        //public int Counter6 { get; set; }

    }
}