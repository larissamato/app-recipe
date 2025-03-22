using Recipe.Communication.Responses;
using Recipe.Communication.Requests;
using Recipe.Exceptions.ExceptionsBase;

namespace Recipe.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    public ResponseRegisteredUserJson Execute(RequestRegisterUserJson request)
    {
        Validate(request);

        return new ResponseRegisteredUserJson
        {
            Name = request.Name,
        };
    }

    private void Validate(RequestRegisterUserJson request)
    {
        var validator = new RegisterUserValidator();
        var result = validator.Validate(request);
        if (result.IsValid == false)
        {
            var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
