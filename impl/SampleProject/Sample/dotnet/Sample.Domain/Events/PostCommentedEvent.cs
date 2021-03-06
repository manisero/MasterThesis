using System;
using System.Collections.Generic;
using Sample.Domain.Entities;

namespace Sample.Domain.Events
{
	public class PostCommentedEvent : IEvent
	{
		public Comment Comment { get; set; }
		public Guid? ParentCommentID { get; set; }
		public Guid PostID { get; set; }
		public string CommentAuthor { get; set; }
	}
}
