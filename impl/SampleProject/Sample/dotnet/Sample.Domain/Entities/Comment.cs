using System;
using System.Collections.Generic;

namespace Sample.Domain.Entities
{
	public class Comment : IEntity
	{
		public Guid CommentID { get; set; }
		public string Content { get; set; }
	}
}
