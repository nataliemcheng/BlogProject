using System;
namespace BlogProject.ViewModels
{
	public class MailSettings
	{
		// we can configure and use and smtp server
		// for ex., google
		public string Mail { get; set; }
		public string DisplayName { get; set; }
		public string Password { get; set; }
		public string Host { get; set; }
		public int Port { get; set; }

	}
}

