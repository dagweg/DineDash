using FluentResults;

public class DuplicateEmailError : IError
{
    public List<IError> Reasons => throw new NotImplementedException();

    public string Message => "Email already exists";

    public Dictionary<string, object> Metadata => throw new NotImplementedException();
}
