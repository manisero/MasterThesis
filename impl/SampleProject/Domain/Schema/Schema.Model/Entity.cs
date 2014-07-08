using System.Collections.Generic;

namespace Schema.Model
{
    public class Entity
    {
        public string Name { get; set; }

        public IEnumerable<Field> Fields { get; set; }

        public bool IsPresentInModel { get; set; }
    }
}
