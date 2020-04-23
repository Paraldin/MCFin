using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MCFin.Models
{
    class LoginForm
    {
        [Required, EmailAddress]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
