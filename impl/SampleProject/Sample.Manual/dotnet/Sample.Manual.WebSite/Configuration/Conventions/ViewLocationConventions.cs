using System;
using Nancy.Conventions;

namespace Sample.Manual.WebSite.Configuration.Conventions
{
    public class ViewLocationConventions : IConvention
    {
        public void Initialise(NancyConventions conventions)
        {
#if DEBUG
            conventions.ViewLocationConventions.Insert(0, (viewName, model, context) => string.Format("../../Views/{0}", viewName));
            conventions.ViewLocationConventions.Insert(0, (viewName, model, context) => string.Format("../../Views/{0}/{1}", context.ModuleName, viewName));
#endif
        }

        public Tuple<bool, string> Validate(NancyConventions conventions)
        {
            return new Tuple<bool, string>(true, null);
        }
    }
}
