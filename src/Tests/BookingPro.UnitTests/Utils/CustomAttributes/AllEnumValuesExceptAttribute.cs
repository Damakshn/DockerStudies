using System.Collections;
using NUnit.Framework.Interfaces;

namespace BookingPro.UnitTests.Utils.CustomAttributes
{
    /// <summary>
    /// Кастомный атрибут NUnit для пробрасывания в тест всех значений Enum-а, кроме некоторых
    /// Копипаста отсюда - https://github.com/nunit/nunit/issues/3431
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter)]
    public class AllEnumValuesExceptAttribute : NUnitAttribute, IParameterDataSource
    {
        private readonly object[] exceptValues;

        public AllEnumValuesExceptAttribute(object exceptValue)
        {
            exceptValues = new[] { exceptValue };
        }

        public AllEnumValuesExceptAttribute(params object[] exceptValues)
        {
            this.exceptValues = exceptValues;
        }

        public IEnumerable GetData(IParameterInfo parameter)
        {
            return new ValuesAttribute()
                .GetData(parameter)
                .Cast<object>()
                .Except(exceptValues);
        }
    }
}
