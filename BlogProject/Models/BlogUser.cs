﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace BlogProject.Models
{
	public class BlogUser : IdentityUser
	{ 
		[StringLength(50, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters.", MinimumLength = 2)]
		[Display(Name = "First Name")]
		public required string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters.", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public required string LastName { get; set; }

        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters.", MinimumLength = 2)]
        [Display(Name = "Display Name")]
        public required string DisplayName { get; set; }

        public byte[]? ImageData { get; set; }
		public string? ContentType { get; set; }

        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters.", MinimumLength = 2)]
        public string? FacebookUrl { get; set; }

        [StringLength(200, ErrorMessage = "The {0} must be at least {2} and no more than {1} characters.", MinimumLength = 2)]
        public string? TwitterUrl { get; set; }

        [NotMapped]
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public virtual ICollection<Blog> Blogs { get; set; } = new HashSet<Blog>();
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();

    }
}

