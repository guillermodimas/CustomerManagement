using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWithIdentity.Shared.Models
{
    public class Customer_Profile
    {
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Company name cannot be blank")]
        public string BusinessName { get; set; }

        //public bool ActiveInd { get; set; }
        public string Address { get; set; }
        public  DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
