using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
//this is the model where we will create the attributes for the sign up form
namespace IS413Project1.Models
{
    public class Signup
    {
        [Key]
        [Required]
        public int SignupId { get; set; }
        
        [Required]
        public string GroupName { get; set; }
        [Required]
        public int GroupSize { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        [RegularExpression(@"^\d{3}-\d{3}-\d{4}$", ErrorMessage = "Entered phone format is not valid. Correct format xxx-xxx-xxxx")]
        public string? Phone { get; set; }

        //set this to a string so that it will allow it to have null values and not throw an error: JK didn't do this
        [Column(TypeName = "smalldatetime")]
        public string? BeginTime { get; set; }
 


    }
}
