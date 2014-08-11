using System.Collections.Generic;
using Schema.Model;

namespace Schema.Generation.Console
{
    public class GenerationUnits
    {
        public IEnumerable<Entity> Entities { get; set; }

        public IEnumerable<View> Views { get; set; }

        public IEnumerable<Event> Events { get; set; }
    }
}
