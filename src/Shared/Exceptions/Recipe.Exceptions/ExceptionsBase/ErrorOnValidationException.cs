namespace Recipe.Exceptions.ExceptionsBase;

public class ErrorOnValidationException : RecipeException
{
    public IList<string> ErrorMessages { get; set; }

    public ErrorOnValidationException(IList<string> errorMessages)
    {
        ErrorMessages = errorMessages;
    }
}
