using Livros.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using ServiceStack.Redis;

namespace Livros.Data.Repository
{
    public class RedisCacheService : IRedisCacheService
    {
        private IConfiguration _configuration;
        private readonly RedisEndpoint _redisConfiguration;
        public RedisCacheService(IConfiguration configuration)
        {
            _configuration = configuration;
            _redisConfiguration = new RedisEndpoint() { Host = _configuration["RedisConfig:Host"], Password = _configuration["RedisConfig:Password"], Port = Convert.ToInt32(_configuration["RedisConfig:Port"]) };
        }

        public void Set<T>(string key, T value, TimeSpan time) where T : class
        {
            using (IRedisClient client = new RedisClient(_redisConfiguration))
            {
                client.Set(key, value, time);
            }
        }

        public T Get<T>(string key) where T : class
        {
            using (IRedisClient client = new RedisClient(_redisConfiguration))
            {
                return client.Get<T>(key);
            }
        }

        public void Remove(string key)
        {
            using (IRedisClient client = new RedisClient(_redisConfiguration))
            {
                client.Remove(key);
            }
        }
    }
}
