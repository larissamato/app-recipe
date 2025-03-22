using Microsoft.AspNetCore.Mvc;
using Recipe.Communication.Requests;
using Recipe.Communication.Responses;
using Recipe.Application.UseCases.User.Register;

namespace Recipe.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
    public IActionResult Register(RequestRegisterUserJson request)
    {
        var useCase = new RegisterUserUseCase();
        var result = useCase.Execute(request);
        return Created(string.Empty, result);
    }
}
