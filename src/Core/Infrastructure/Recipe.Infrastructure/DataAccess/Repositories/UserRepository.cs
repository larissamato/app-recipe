using Microsoft.EntityFrameworkCore;
using Recipe.Domain.Entities;
using Recipe.Domain.Repositories.User;

namespace Recipe.Infrastructure.DataAccess.Repositories;

public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly RecipeDbContext _dbContext;

    public UserRepository(RecipeDbContext dbContext) => _dbContext = dbContext;

    public async Task Add(User user) => await _dbContext.Users.AddAsync(user);

    public async Task<bool> ExistActiveUserWithEmail(string email)
    {
        return await _dbContext.Users.AnyAsync(user => user.Email.Equals(email) && user.Active);
    }

}
