using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq;

namespace Awoo.Server.Data
{
    public class IntListToStringValueConverter : ValueConverter<List<int>, string>
    {
        public IntListToStringValueConverter() : base(le => ListToString(le), (s => StringToList(s)))
        {
        }

        public static string ListToString(List<int> value)
        {
            if (!value.Any())
            {
                return string.Empty;
            }

            return string.Join(',', value);
        }

        public static List<int> StringToList(string value)
        {
            if ( string.IsNullOrEmpty(value))
            {
                return new List<int>();
            }

            return value.Split(',').Select(i => Convert.ToInt32(i)).ToList(); ;

        }
    }
}
