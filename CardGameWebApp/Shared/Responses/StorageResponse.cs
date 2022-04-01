using System.Collections.Generic;

namespace CardGameWebApp.Shared.Responses
{
	public class StorageResponse : LinksExtension
	{
		public StorageResponse()
		{
		}

		public StorageResponse(string selfLink) : base(selfLink)
		{
		}

		public IDictionary<string, string> folders { get; set; }
		public IDictionary<string, string> files { get; set; }
	}
}
