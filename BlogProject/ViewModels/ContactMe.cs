using System;
using System.ComponentModel.DataAnnotations;

namespace BlogProject.ViewModels
{
	public class ContactMe
	{
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public required string Name { get; set; }

        [EmailAddress]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
		public required string Email { get; set; }

        [Phone]
        public required string Phone { get; set; }

        [StringLength(80, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public required string Subject { get; set; }

        [StringLength(1000, ErrorMessage = "The {0} must be at least {2} and at most {1} characters long.", MinimumLength = 2)]
        public required string Message { get; set; }
    }
}

