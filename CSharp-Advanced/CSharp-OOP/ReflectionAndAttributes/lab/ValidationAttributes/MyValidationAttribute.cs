namespace ValidationAttributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public abstract class MyValidationAttribute : Attribute
    {
        public abstract bool isValid(object obj);
    }

    public class MyRequiredAttribute : MyValidationAttribute
    {
        public override bool isValid(object obj)
            => obj != null;
    }

    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int min;
        private readonly int max;

        public MyRangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }

        public override bool isValid(object obj)
        {
            int currentValue = (int)obj;

            return currentValue >= min && currentValue <= max;
        }
    }
}
