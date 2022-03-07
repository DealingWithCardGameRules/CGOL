using System;

namespace CardGameWebApp.Client
{
	public class CallBackAction
	{
		public string Name { set; get; }
		public Action Execute { get; set; }
	}
}
