using System.Collections.Generic;
using Schema.Model;

namespace Schema.Generation.Console
{
    public class DomainProcessor
    {
        public IEnumerable<View> GetViews(Domain domain)
        {
            var views = new Dictionary<string, View>();

            foreach (var entity in domain.Entities)
            {
                if (entity.IsPresentInModel)
                {
                    if (!views.ContainsKey(entity.Name))
                    {
                        views[entity.Name] = new View
                            {
                                Name = entity.Name,
                                Fields = new List<ViewField>()
                            };
                    }
                }
            }

            return views.Values;
        }
    }
}
