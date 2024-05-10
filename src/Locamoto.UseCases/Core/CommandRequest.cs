using MediatR;

namespace Locamoto.UseCases.Core;

public abstract record CommandRequest<T>: IRequest<T> where T: CommandResponse
{
    private List<string> _errors = [];

    public virtual bool IsValid()
    {
        return _errors.Count == 0;
    }

    public virtual bool IsInvalid()
    {
        return !this.IsValid();
    }

    public List<string> GetErrors()
    {
        return _errors;
    }

    protected void AddError(string error)
    {
        _errors.Add(error);
    }

    protected void ValidateFieldlNull(string field, string textError)
    {
        if (string.IsNullOrWhiteSpace(field)) _errors.Add(textError?? "Field required");
    }

    protected void ValidateFieldlNull(Guid field, string textError)
    {
        if (field == Guid.Empty) _errors.Add(textError?? "Field required");
    }
}
