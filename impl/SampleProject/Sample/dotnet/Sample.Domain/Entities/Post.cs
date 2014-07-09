using System;
using System.Collections.Generic;

namespace Sample.Domain.Entities
{
	public class Post : IEntity
	{
		public Guid PostID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public int CommentsNumber { get; set; }
	}
}
