using System.Collections.Generic;
using System.Linq;

namespace FrameworkCore.Data.Model
{
    public class ObjectCompletion
    {
        public string ObjectTitle { get; set; }
        public IList<PropertyCompletion> PropertiesCompletion { get; set; }

        public string Name { get; set; }
        public bool IsCompleted  { get; set; }
        public float  Percentage  { get; set; }
        public int AllRequiredFieldCount  { get; set; }
        public int CompletedFieldCount { get; set; }
        public int NotCompletedFieldCount { get; set; }
        public string  GetPercentage()
        {
            var result = ( (float)CompletedFieldCount / (float)AllRequiredFieldCount) * 100;
            return result.ToString("0");
        }


    }
    public class PropertyCompletion
    {
        public string PropertyName { get; set; }
        public bool IsCompleted { get; set; }
    }
}
