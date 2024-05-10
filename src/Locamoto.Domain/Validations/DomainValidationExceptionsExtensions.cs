using Locamoto.Domain.Exceptions;
using Locamoto.Domain.ValueObjects;

namespace Locamoto.Domain.Validations;
    public static class DomainValidationExceptionsExtensions
    {
        public static string NotNull(this string value, string? textError = null)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new DomainException(textError ?? "Field Required.");

            return value;
        }

        public static Guid NotNull(this Guid value, string? textError = null)
        {
            if (value == Guid.Empty)
                throw new DomainException(textError ?? "Field Required.");

            return value;
        }

        public static int GreaterThanZero(this int value, string? textError = null)
        {
            if (value < 1)
                throw new DomainException(textError ?? "Field Required.");

            return value;
        }

        public static ValueObject NotValid(this ValueObject value, string? textError = null)
        {
            if (!value.IsValid())
                throw new DomainException(textError ?? "Value object is not valid.");

            return value;
        }

        public static object NotNull(this object value, string? textError = null)
        {
            if (value is null)
                throw new DomainException(textError ?? "Object can not be null.");

            return value;
        }
    }
