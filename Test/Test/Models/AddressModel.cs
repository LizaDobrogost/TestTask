using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    [Serializable]
    public class AddressModel
    {
        [Required(ErrorMessage = "Choose country")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Office Name is required")]
        public string OfficeName { get; set; }
        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Code is required")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }
        [Required(ErrorMessage = "Choose state")]
        public string State { get; set; }
    }
}
