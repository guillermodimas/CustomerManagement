using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWithIdentity.Shared.Models
{
    public class Customer_Representatives
    {
        public int CustomerRepID { get; set; }

        [Required(ErrorMessage = "First Name cannot be blank")]
        public string First_Name { get; set; }

        [Required(ErrorMessage = "Last Name cannot be blank")]
        public string Last_Name { get; set; }

        [Required(ErrorMessage = "Address cannot be blank")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email cannot be blank")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Start date required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End date required")]
        public DateTime EndDate { get; set; }
        public  bool ActiveInd { get; set; }

        [Required(ErrorMessage = "Customer selection required")]
        public int? CustomerID { get; set; }

        
    }
}

