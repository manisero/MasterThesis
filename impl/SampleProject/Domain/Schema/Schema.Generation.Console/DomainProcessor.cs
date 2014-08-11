using System.Collections.Generic;
using System.Linq;
using Schema.Model;

namespace Schema.Generation.Console
{
    public class DomainProcessor
    {
        public GenerationUnits Process(Domain domain)
        {
            var viewsDictionary = new Dictionary<string, View>();
            var eventsDictionary = new Dictionary<string, Event>();

            foreach (var entity in domain.Entities)
            {
                foreach (var presence in entity.PresentInEvents ?? Enumerable.Empty<EntityPresenceInEvent>())
                {
                    eventsDictionary.GetEvent(presence.Event).Fields.Add(new EventField
                    {
                        Name = entity.Name,
                        Type = entity.Name
                    });
                }

                if (entity.IsPresentInModel)
                {
                    foreach (var field in entity.Fields)
                    {
                        ProcessEntityField(field, entity, viewsDictionary, eventsDictionary);
                    }
                }
            }

            return new GenerationUnits
                {
                    Entities = domain.Entities,
                    Views = viewsDictionary.Values.ToList(),
                    Events = eventsDictionary.Values.ToList()
                };
        }

        private void ProcessEntityField(EntityField field, Entity entity, IDictionary<string, View> views, IDictionary<string, Event> events)
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

            foreach (var presence in field.PresentInViews ?? Enumerable.Empty<EntityFieldPresenceInView>())
            {
                views.GetView(presence.View).Fields.Add(new ViewField
                    {
                        Name = presence.As ?? field.Name,
                        Type = field.Type,
                        IsKey = presence.IsKey,
                        OnKeyPostion = presence.OnKeyPosition,
                        IsNullable = presence.IsNullable,
                        IsSearchable = presence.IsSearchable
                    });
            }

            foreach (var presence in field.PresentInEvents ?? Enumerable.Empty<EntityFieldPresenceInEvent>())
            {
                events.GetEvent(presence.Event).Fields.Add(new EventField
                {
                    Name = presence.As ?? field.Name,
                    Type = field.Type,
                    IsNullable = presence.IsNullable,
                });
            }
        }
    }
}
