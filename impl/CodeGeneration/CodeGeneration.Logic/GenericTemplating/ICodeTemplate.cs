using System.Collections.Generic;

namespace CodeGeneration.Logic.GenericTemplating
{
    public interface ICodeTemplate
    {
        /// <summary>
        /// Current transformation session
        /// </summary>
        IDictionary<string, object> Session { get; set; }

        /// <summary>
        /// Initialize the template
        /// </summary>
        void Initialize();

        /// <summary>
        /// Create the template output
        /// </summary>
        string TransformText();
    }
}
