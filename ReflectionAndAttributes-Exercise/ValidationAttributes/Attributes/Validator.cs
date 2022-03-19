using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propsInfo = obj.GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Any())
                .ToArray();

            foreach (var propertyInfo in propsInfo)
            {
                object value = propertyInfo.GetValue(obj);

                MyValidationAttribute attribute = propertyInfo.GetCustomAttribute<MyValidationAttribute>();

                bool isValid = attribute.IsValid(value);

                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}