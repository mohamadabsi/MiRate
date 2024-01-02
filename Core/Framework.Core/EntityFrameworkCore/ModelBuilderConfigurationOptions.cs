using JetBrains.Annotations;

namespace Framework.Core.EntityFrameworkCore
{
    public class ModelBuilderConfigurationOptions
    {
        [CanBeNull]
        public string TablePrefix { get; set; }

        [CanBeNull]
        public string Schema { get; set; }

        public ModelBuilderConfigurationOptions(
            [CanBeNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
        {
            TablePrefix = tablePrefix;
            Schema = schema;
        }
    }
}
