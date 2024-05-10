using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Locamoto.Domain.Validations;

namespace Locamoto.Domain.ValueObjects;

public struct CnhCard(string number, CnhType type, string image = ""): ValueObject
{
    public string Number { get; init; } = number;
    public CnhType Type { get; init; } = type;
    public string Image { get; init; } = image;

    public bool IsValid()
    {
       if (string.IsNullOrWhiteSpace(Number)) return false;

       return true;
    }

    public override string ToString()
    {
        return Number;
    }
}
