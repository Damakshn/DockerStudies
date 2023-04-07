using BookingPro.Domain.Common.ErrorHandling;
using BookingPro.Domain.Common.Rules;

namespace BookingPro.Domain.Common.Abstractions
{
    /// <summary>
    /// Абстрактный класс доменного сервиса
    /// </summary>
    public abstract class DomainService
    {
        /// <summary>
        /// Проверяет, выполняется ли заданное правило или ограничение.
        /// </summary>
        /// <param name="rule">Проверяемое правило</param>
        /// <exception cref="DomainException">Если правило нарушено</exception>
        protected virtual void CheckRule(IRule rule)
        {
            if (rule.IsBroken())
            {
                throw new DomainException(rule);
            }
        }
    }
}
