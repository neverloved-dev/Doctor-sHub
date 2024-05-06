namespace Authenticator.Interfaces
{

        public interface ICrudRepository<T> where T : class
        {
            public void Create(T variable);
            public T Update(T update);
            public List<T> GetAll();
            public T GetSingle(object identifier);
            public void Delete(object identifier);
        }
    
}
