namespace ValidationAttributes
{
    using System.Linq;
    using System.Reflection;

    public class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj
                .GetType()
                .GetProperties()
                .Where(x => x.GetCustomAttributes(typeof(MyValidationAttribute)).Any())
                .ToArray();

            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                object value = propertyInfo.GetValue(obj);
                MyValidationAttribute attribute = propertyInfo.GetCustomAttribute<MyValidationAttribute>();

                bool isValid = attribute.isValid(value);
                if (!isValid)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
