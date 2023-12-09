namespace InnoNet.Data;

public interface IUnitOfWork
{
    Task Commit();
}