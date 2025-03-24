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
        var connectionString = "Server=localhost;Port=3306;Database=mydatabase;Uid=myuser;Pwd=mypassword";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 41));
        services.AddDbContext<RecipeDbContext>(dbContextOptions =>
        {
            dbContextOptions.UseMySql(connectionString, serverVersion);
        });

    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
        services.AddScoped<IUserWriteOnlyRepository, UserRepository>();
    }
}
