﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public class UserRegisterRequestModel
    {
        [Required]
        [EmailAddress]
        [StringLength(128)]
        public string Email { get; set; }
        [Required]
        [StringLength(100, MinimumLength =8, ErrorMessage ="The password should be at least 8 characters and not exceeding 100")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[#$^+=!*()@%&]).{8,}$", ErrorMessage =
            "Password Should have minimum 8 with at least one upper, lower, number and special character")]
        public string Password { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        // 01/01/1790
        // 01/01/2020
        // Minimum age and Maximum Age
        public DateTime DateOfBirth { get; set; }
    }
}
