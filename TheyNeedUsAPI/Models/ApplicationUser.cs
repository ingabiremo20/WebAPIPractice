using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheyNeedUsAPI.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [Display(Name = "First Name")]
        [StringLength(60, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 3)]
        public string LastName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(30)]
        public string Genre { get; set; }

        [Required]
        [StringLength(300)]
        public string Bio { get; set; }
        [Required]


        public string RegDate { get; set; } = DateTime.UtcNow.ToString();

        [DataType(DataType.Date)]
        public DateTime DOB { get; set; }
    }
}