namespace VacationManagement.Services
{
    public interface ICrud<T> where T : class
    {//
        void Insert(T entity);
        T RetriveById(int id);
        List<T> RetriveAll();
        void Delete(T entity);
        void Update(T entity);

    }
}
