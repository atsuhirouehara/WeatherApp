using WheatherApp.Domain.Helpers;

namespace WheatherApp.Domain.ValueObjects
{
    public sealed class Temperature : ValueObject<Temperature>
    {
        // 温度の単位を指定
        public const string UnitName = "℃";

        // 小数点以下、取得する桁数を指定
        public const int DecimalPoint = 2;

        public Temperature(float value)
        {
            Value = value;
        }

        public float Value { get; }
        public string DisplayValue
        {
            get
            {
                return Value.RoundString(DecimalPoint);
            }
        }

        public string DisplayValueWithUnit
        {
            get
            {
                return Value.RoundString(DecimalPoint) + UnitName;
            }
        }

        public string DisplayValueWithUnitSpace
        {
            get
            {
                return Value.RoundString(DecimalPoint) + " " + UnitName;
            }
        }

        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }
    }   
}
