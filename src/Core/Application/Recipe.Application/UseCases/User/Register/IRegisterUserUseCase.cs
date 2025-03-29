using Recipe.Communication.Requests;
using Recipe.Communication.Responses;

namespace Recipe.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    public Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}

