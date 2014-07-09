using System.Collections.Generic;
using Schema.Model;

namespace Schema.Generation.Console
{
    public static class ViewsDictionaryExtensions
    {
        public static View GetView(this IDictionary<string, View> views, string viewName)
        {
            View view;

            if (views.TryGetValue(viewName, out view))
            {
                return view;
            }

            view = new View
                {
                    Name = viewName,
                    Fields = new List<ViewField>()
                };

            views.Add(viewName, view);

            return view;
        }
    }
}
