using System.Collections.Generic;

namespace Schema.Model
{
    public class Event : INamed
    {
        public string Name { get; set; }

        public IList<EventField> Fields { get; set; }
    }
}
