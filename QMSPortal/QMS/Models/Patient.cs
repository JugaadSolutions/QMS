using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QMS.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Patient Name :")]
        public String PatientName { get; set; }

        [Required]
        [Display(Name = "Patient Id :")]
        public int PatientId { get; set; }

        [Display(Name = "Status :")]
        public String Status { get; set; }

        [Display(Name = "IP")]
        public String IP { get; set; }

        public DateTime TimeStamp { get; set; }

        [Display(Name = "Token No. :")]
        public int Token { get; set; }
    }
}