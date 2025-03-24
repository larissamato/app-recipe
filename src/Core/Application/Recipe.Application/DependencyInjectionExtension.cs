using Microsoft.Extensions.DependencyInjection;
using Recipe.Application.UseCases.User.Register;
using Recipe.Application.Services.AutoMapper;
using Recipe.Application.Services.Cryptography;

namespace Recipe.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddPasswordEncripter(services);
        AddUseCases(services);
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddScoped(option => new AutoMapper.MapperConfiguration(options =>
        {
            options.AddProfile(new AutoMapping());
        }).CreateMapper());

    }
    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterUserUseCase, RegisterUserUseCase>();
    }

    private static void AddPasswordEncripter(IServiceCollection services)
    {
        services.AddScoped(option => new PasswordEncripter());
    }
}
