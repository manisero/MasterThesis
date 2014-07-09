using System;
using System.Collections.Generic;
using Sample.Domain.Entities;

namespace Sample.Domain.Events
{
	public class UserUpdatedEvent : IEvent
	{
		public User User { get; set; }
	}
}
