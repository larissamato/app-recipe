namespace Recipe.Domain.Repositories;
public interface IUnitOfWork
{
    public Task Commit();
}
