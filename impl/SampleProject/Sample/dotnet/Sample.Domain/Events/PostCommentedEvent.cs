using System;
using Sample.Domain.Entities;

namespace Sample.Domain.Events
{
    public class PostCommentedEvent : IEvent
    {
        public Guid PostID { get; set; }

        public Guid? ParentCommentID { get; set; }

        public Comment Comment { get; set; }
    }
}
