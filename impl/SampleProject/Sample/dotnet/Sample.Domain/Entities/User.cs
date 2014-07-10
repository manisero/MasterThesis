using System;
using System.Collections.Generic;

namespace Sample.Domain.Entities
{
	public class User : IEntity
	{
		public string UserName { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
