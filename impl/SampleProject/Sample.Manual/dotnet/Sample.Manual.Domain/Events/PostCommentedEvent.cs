using System;
using Sample.Manual.Domain.Entities;

namespace Sample.Manual.Domain.Events
{
    public class PostCommentedEvent : IEvent
    {
        public Guid PostID { get; set; }

        public Guid? ParentCommentID { get; set; }

        public Comment Comment { get; set; }
    }
}
