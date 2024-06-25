namespace Backend.Repository;

public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    
}