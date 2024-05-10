namespace Locamoto.Domain.Core;

public abstract class EntityRoot
{
    public Guid Id { get; private set; } = Guid.NewGuid();

    public abstract void Validate();
}
