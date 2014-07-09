using System.Collections.Generic;

namespace Schema.Model
{
    public class View : INamed
    {
        public string Name { get; set; }

        public IList<ViewField> Fields { get; set; }
    }
}
