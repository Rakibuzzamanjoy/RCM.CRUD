using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCM.DAL.Models
{
    public class RetailerInformation
    {

        public int id { get; set; }
        public int RetailerID { get; set; }

        [Required]
        public string RetailerName { get; set; }
       
        [Required]
        public string RetailerPhone { get; set; }

        [Required]
        public DateTime EntryDate { get; set; }
        
    }
}
