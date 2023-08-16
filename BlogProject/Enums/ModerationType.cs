using System;
using System.ComponentModel;

namespace BlogProject.Enums
{
	public enum ModerationType
	{
		[Description("Inappropriate political speech")]
		Political,

        [Description("Offensive language")]
        Language,

		[Description("Drug reference")]
		Drugs,

		[Description("Threatening speech")]
		Threatening,

		[Description("Sexual content")]
		Sexual,

		[Description("Malicious intent and hate speech")]
		HateSpeech
	}
}

