using Recipe.Communication.Responses;
using Recipe.Communication.Requests;
using Recipe.Exceptions.ExceptionsBase;
using Recipe.Application.Services.AutoMapper;
using Recipe.Application.Services.Cryptography;
using Recipe.Domain.Repositories.User;


namespace Recipe.Application.UseCases.User.Register;

public class RegisterUserUseCase
{
    private readonly IUserWriteOnlyRepository _writeOnlyRepository;
    private readonly IUserReadOnlyRepository _readOnlyRepository;

    public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
    {
        var crip = new PasswordEncripter();
        var autoMapper = new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper();

        Validate(request);

        var user = autoMapper.Map<Domain.Entities.User>(request);
        user.Password = crip.Encrypt(request.Password);

        await _writeOnlyRepository.Add(user);

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
