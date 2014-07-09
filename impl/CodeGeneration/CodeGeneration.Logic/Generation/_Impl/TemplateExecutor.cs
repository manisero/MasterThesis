using System;
using Microsoft.VisualStudio.TextTemplating;

namespace CodeGeneration.Logic.Generation._Impl
{
    public class TemplateExecutor : ITemplateExecutor
    {
        public string Execute<TMetadata>(object template, TMetadata metadata, params TemplateArgument[] arguments)
        {
            var templateType = template.GetType();

            var templatingSession = GetTemplateSession(template, templateType);
            FillTemplateSession(templatingSession, metadata, arguments);
            
            templateType.GetMethod("Initialize").Invoke(template, new object[0]);

            return (string)templateType.GetMethod("TransformText").Invoke(template, new object[0]);
        }

        private TextTemplatingSession GetTemplateSession(object template, Type templateType)
        {
            var sessionProperty = templateType.GetProperty("Session");
            var existingSession = (TextTemplatingSession)sessionProperty.GetValue(template);

            if (existingSession != null)
            {
                return existingSession;
            }
            else
            {
                var newSession = new TextTemplatingSession();
                sessionProperty.SetValue(template, newSession);

                return newSession;
            }
        }

        private void FillTemplateSession<TMetadata>(TextTemplatingSession session, TMetadata metadata, params TemplateArgument[] arguments)
        {
            session["Metadata"] = metadata;

            foreach (var argument in arguments)
            {
                session[argument.Name] = argument.Value;
            }
        }
    }
}
