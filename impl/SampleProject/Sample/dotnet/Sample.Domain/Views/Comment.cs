using System;
using System.Collections.Generic;

namespace Sample.Domain.Views
{
	public class Comment : IView
	{
		public Guid CommentID { get; set; }
		public Guid? ParentCommentID { get; set; }
		public string Content { get; set; }
		public Guid PostID { get; set; }
		public string Author { get; set; }
	}
}
