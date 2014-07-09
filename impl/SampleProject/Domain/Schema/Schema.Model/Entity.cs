using System.Collections.Generic;

namespace Schema.Model
{
    public class Entity : INamed
    {
        public string Name { get; set; }

        public IEnumerable<EntityField> Fields { get; set; }

        public bool IsPresentInModel { get; set; }
    }
}
