using System;
using System.Collections.Generic;

namespace Sample.Presentation.Domain
{
	public class Customer : Person
	{
		public IEnumerable<Order> Orders { get; set; }
	}
}
