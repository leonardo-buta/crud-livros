namespace Livros.Domain.Interfaces
{
    public interface IRedisCacheService
    {
        T Get<T>(string key) where T : class;
        void Set<T>(string key, T value, TimeSpan time) where T : class;
        void Remove(string key);
    }
}
