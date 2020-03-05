using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class ForumPost
    {

        [Required, StringLength(20, ErrorMessage = "Username must be fewer than 20 characters.")]
        public string Username { get; set; }

        [Required, StringLength(1000, MinimumLength = 2, ErrorMessage = "Subject must be at least two characters.")]
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime PostDate { get; set; }



    }
}