using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingPro.Domain.Common.Rules;

namespace BookingPro.Domain.Common.ErrorHandling
{
    /// <summary>
    /// Исключение уровня бизнес-логики
    /// </summary>
    public class DomainException : Exception
    {
        public IRule BrokenRule { get; protected set; }

        private DomainException() : base() { }

        private DomainException(string message) : base(message) { }

        private DomainException(string message, Exception innerException) : base(message, innerException) { }

        public DomainException(IRule rule) : base(rule.Message)
        {
            BrokenRule = rule;
        }
    }
}
