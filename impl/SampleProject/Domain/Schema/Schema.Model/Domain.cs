using System.Collections.Generic;

namespace Schema.Model
{
    public class Domain
    {
        public KeySpace KeySpace { get; set; }

        public IEnumerable<Entity> Entities { get; set; }
    }
}
