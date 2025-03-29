using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Recipe.Domain.Repositories.User;
using Recipe.Domain.Repositories;
using Recipe.Infrastructure.DataAccess.Repositories;
using Recipe.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Recipe.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services, configuration);
        AddRepositories(services);
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connection = configuration.GetConnectionString("Connection");
        services.AddDbContext<RecipeDbContext>(DbContextOptions =>
        {
            DbContextOptions.UseSqlServer(connection);
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
    }
}
