using System;
using System.Collections.Generic;

namespace Sample.Domain.Views
{
	public class Post : IView
	{
		public Guid PostID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public int CommentsNumber { get; set; }
		public string Author { get; set; }
	}
}
