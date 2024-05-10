using Locamoto.Domain.Core;
using Locamoto.Domain.Validations;

namespace Locamoto.Domain.Entities;
public class Motorcycle : EntityRoot
{
    public Motorcycle(int year, string model, string plate)
    {
        Year = year;
        Model = model;
        Plate = plate;

        Validate();
        SetAvailable();
    }

    public int Year { get; init; }
    public string Model { get; init; }
    public string Plate { get; private set; }
    public bool Available { get; private set; }

    public void SetPlate(string plate)
    {
        this.Plate = plate;
        Validate();
    }
    
    public override void Validate()
    {
        this.Year.GreaterThanZero("The field year is required.");
        this.Model.NotNull("The field model is required.");
        this.Plate.NotNull("The field Plate is required.");
    }

    public void SetAvailable()
    {
        this.Available = true;
    }

    public void SetUnavailable()
    {
        this.Available = false;
    }
}
