using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QMS.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Name :")]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Password :")]

        public String Password { get; set; }
    }
}