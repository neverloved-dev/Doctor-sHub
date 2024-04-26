namespace Main.Interfaces;

public interface ICrudRepository<T> where T:class
{
    public void Create(T variable);
    public T Update(T update);
    public List<T> GetAll();
    public T GetSingle(object identifier);
    public T Delete(object identifier);
}