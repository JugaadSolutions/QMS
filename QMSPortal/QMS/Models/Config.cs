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
    }
}