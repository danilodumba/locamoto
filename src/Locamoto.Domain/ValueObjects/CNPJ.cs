
namespace Locamoto.Domain.ValueObjects
{
    public struct CNPJ: ValueObject
    {
        public CNPJ() {}
        public CNPJ(string cnpj)
        {
            Value = cnpj;
        }

        public string Value { get; init; } = "";

        public bool IsValid()
        {
            if (string.IsNullOrWhiteSpace(Value)) return false;

            return true;
        }

        public override string ToString()
        {
            return Value;
        }
    }
}