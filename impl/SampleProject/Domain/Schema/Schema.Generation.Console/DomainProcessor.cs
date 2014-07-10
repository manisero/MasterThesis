using System.Collections.Generic;
using System.Linq;
using Schema.Model;

namespace Schema.Generation.Console
{
    public class DomainProcessor
    {
        public IList<View> GetViews(Domain domain)
        {
            var views = new Dictionary<string, View>();

            foreach (var entity in domain.Entities)
            {
                if (entity.IsPresentInModel)
                {
                    foreach (var field in entity.Fields)
                    {
                        ProcessEntityField(field, entity, views);
                    }
                }
            }

            return views.Values.ToList();
        }

        private void ProcessEntityField(EntityField field, Entity entity, IDictionary<string, View> views)
        {
            if (entity.IsPresentInModel)
            {
                views.GetView(entity.Name).Fields.Add(new ViewField
                    {
                        Name = field.Name,
                        Type = field.Type,
                        IsKey = field.IsKeyInModel,
                        OnKeyPostion = field.OnKeyPostion,
                        IsSearchable = field.IsSearchableInModel
                    });
            }

            foreach (var fieldPresence in field.PresentIn ?? Enumerable.Empty<EntityFieldPresence>())
            {
                views.GetView(fieldPresence.View).Fields.Add(new ViewField
                    {
                        Name = fieldPresence.As ?? field.Name,
                        Type = fieldPresence.HasType ?? field.Type,
                        IsKey = fieldPresence.IsKey,
                        OnKeyPostion = fieldPresence.OnKeyPosition,
                        IsSearchable = fieldPresence.IsSearchable
                    });
            }
        }
    }
}
