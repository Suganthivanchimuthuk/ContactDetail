using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactDetail.DataAccesslayer
{
    public class ContactForm
    {
		[Key]
		public long EmployeeID { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name"), MaxLength(50)]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter your Address")]
        [DataType(DataType.Date)]

        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter your City")]

        public string City { get; set; }
		[Required(ErrorMessage = "Please Enter your State")]
		public string State { get; set; }
		[Required(ErrorMessage = "Please Enter your ZipCode")]
		public long Zip { get; set; }
		[Required(ErrorMessage = "Please Enter your Country")]
		public string Country { get; set; }
		[Required(ErrorMessage = "Please Enter your PhoneNumber")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Incorrect Phonenumber")]
        public long MobileNumber { get; set; }
        [Required(ErrorMessage = "Please Enter your Email")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter give your Comments")]
        public string Comments { get; set; }
	}
}
