using System;
using System.Collections.Generic;

namespace Sample.Domain.Views
{
	public class User : IView
	{
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
