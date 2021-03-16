using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public string Phone { get; set; }
        [Required]
        public string Date { get; }
        [Required]
        public string BeginTime { get; set; }
        [Required]
        public string EndTime { get; set; }


    }
}
