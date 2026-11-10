namespace Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        List <T> Get();
    }
}
