using System.Runtime.Remoting.Messaging;

namespace CodeGeneration.Logic.GenericTemplating
{
    /// <summary>
    /// Class to produce the template output
    /// </summary>
    public class CodeTemplate<TMetadata> : CodeTemplateBase
    {
        private TMetadata _MetadataField;

        /// <summary>
        /// Access the Metadata parameter of the template.
        /// </summary>
        protected TMetadata Metadata
        {
            get { return _MetadataField; }
        }

        /// <summary>
        /// Create the template output
        /// </summary>
        public override string TransformText()
        {
            return GenerationEnvironment.ToString();
        }

        /// <summary>
        /// Initialize the template
        /// </summary>
        public override void Initialize()
        {
            if ((Errors.HasErrors == false))
            {
                bool MetadataValueAcquired = false;

                if (Session.ContainsKey("Metadata"))
                {
                    if ((typeof(TMetadata).IsAssignableFrom(Session["Metadata"].GetType()) == false))
                    {
                        Error("The type \'TMetadata\' of the parameter \'Metadata\' did not match the type of the da" +
                              "ta passed to the template.");
                    }
                    else
                    {
                        _MetadataField = ((TMetadata)(Session["Metadata"]));
                        MetadataValueAcquired = true;
                    }
                }
                if ((MetadataValueAcquired == false))
                {
                    object data = CallContext.LogicalGetData("Metadata");

                    if ((data != null))
                    {
                        if ((typeof(TMetadata).IsAssignableFrom(data.GetType()) == false))
                        {
                            Error("The type \'TMetadata\' of the parameter \'Metadata\' did not match the type of the da" +
                                  "ta passed to the template.");
                        }
                        else
                        {
                            _MetadataField = ((TMetadata)(data));
                        }
                    }
                }
            }
        }
    }
}
