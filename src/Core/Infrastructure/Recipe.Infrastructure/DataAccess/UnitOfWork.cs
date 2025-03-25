using Recipe.Domain.Repositories;

namespace Recipe.Infrastructure.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly RecipeDbContext _dbContext;

    public UnitOfWork(RecipeDbContext dbContext) => _dbContext = dbContext;

    public async Task Commit() => await _dbContext.SaveChangesAsync();
}
