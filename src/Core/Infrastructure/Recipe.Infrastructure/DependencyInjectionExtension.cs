using Microsoft.Extensions.DependencyInjection;
using Recipe.Domain.Repositories.User;
using Recipe.Infrastructure.DataAccess.Repositories;
using Recipe.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Recipe.Infrastructure;

public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        AddDbContext(services);
        AddRepositories(services);
    }

    private static void AddDbContext(IServiceCollection services)
    {
        var connectionString = "Server=localhost,1433;Database=RecipeDB;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;";
        services.AddDbContext<RecipeDbContext>(DbContextOptions =>
        {
            DbContextOptions.UseSqlServer(connectionString);
        });
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
    }
}
