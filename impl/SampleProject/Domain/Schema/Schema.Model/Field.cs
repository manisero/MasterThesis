using System.Collections.Generic;

namespace Schema.Model
{
    public class Field
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public bool IsKeyInModel { get; set; }

        public int? OnKeyPostion { get; set; }

        public bool IsSearchableInModel { get; set; }

        public IEnumerable<FieldPresence> PresentIn { get; set; }
    }
}
