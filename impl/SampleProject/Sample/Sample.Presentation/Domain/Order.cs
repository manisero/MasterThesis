using System;
using System.Collections.Generic;

namespace Sample.Presentation.Domain
{
	public class Order
	{
		public Customer Owner { get; set; }
		public int ID { get; set; }
	}
}
