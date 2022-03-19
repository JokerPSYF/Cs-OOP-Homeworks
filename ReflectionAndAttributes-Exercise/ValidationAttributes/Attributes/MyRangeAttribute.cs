namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        public MyRangeAttribute(int minValue, int maxValue)
        {
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        private int minValue;

        private int maxValue;

        public override bool IsValid(object obj) => (int)obj >= minValue && (int)obj <= maxValue;
    }
}