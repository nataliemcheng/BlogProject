using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlogProject.Enums;
using Microsoft.AspNetCore.Identity;

namespace BlogProject.Models
{
	public class Post
	{
		public int Id { get; set; }
		[Display(Name = "Blog Name")]
		public int BlogId { get; set; }
		public string? BlogUserId { get; set; }

		[Required]
		[StringLength(75, ErrorMessage = "Sorry, the {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
		public required string Title { get; set; }

		[Required]
        [StringLength(200, ErrorMessage = "Sorry, the {0} must be at least {2} and no more than {1} characters long.", MinimumLength = 2)]
        public required string Abstract { get; set; }

		[Required]
		public required string Content { get; set; }

		[DataType(DataType.Date)]
		[Display(Name = "Created Date")]
		public DateTime? Created { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Updated Date")]
        public DateTime? Updated { get; set; }

		public ReadyStatus ReadyStatus { get; set; }

		public string? Slug { get; set; }

		public byte[]? ImageData { get; set; }
		public string? ContentType { get; set; }

		[NotMapped]
		public IFormFile? Image { get; set; }

		// Navigation Properties
		public virtual Blog? Blog { get; set; }
		public virtual BlogUser? BlogUser { get; set; }

		public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
		public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
	}
}

