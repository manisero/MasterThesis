using Schema.Model;
using System.Linq;

namespace Schema.Templates.Utilities
{
    public static class CqlHelper
    {
        public static string FormatPrimaryKey(View view)
        {
            var keyColumns = view.Fields.Where(x => x.IsKey).OrderBy(x => x.OnKeyPostion).Select(x => "\"" + x.Name + "\"");

            return string.Format("PRIMARY KEY ({0})", string.Join(", ", keyColumns));
        }
    }
}
