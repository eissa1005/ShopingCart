using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ShopingCart.Application.Abstraction;
using ShopingCart.Application.Core.Helper;
using System.Diagnostics.CodeAnalysis;

namespace ShopingCart.Application.Services
{
    public class SessionService : ISessionService, ISession
    {
        private IHttpContextAccessor _httpContextAccessor;

        public bool IsAvailable => _httpContextAccessor.HttpContext.Session.IsAvailable;

        public string Id => _httpContextAccessor.HttpContext.Session.Id;

        public IEnumerable<string> Keys => _httpContextAccessor.HttpContext.Session.Keys;

        public ISession Current => _httpContextAccessor.HttpContext.Session;

        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task LoadAsync(CancellationToken cancellationToken = default)
        {
            await _httpContextAccessor.HttpContext.Session.LoadAsync(cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            await _httpContextAccessor.HttpContext.Session.CommitAsync(cancellationToken);
        }

        public bool TryGetValue(string key, [NotNullWhen(true)] out byte[] value)
        {
            return _httpContextAccessor.HttpContext.Session.TryGetValue(key, out value);
        }

        public void Set(string key, byte[] value)
        {
            _httpContextAccessor.HttpContext.Session.Set(key, value);
        }

        public void Remove(string key)
        {
            _httpContextAccessor.HttpContext.Session.Remove(key);
        }

        public void Clear()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }
        public void SetObject<TValue>(string key, TValue value)
        {
            _httpContextAccessor.HttpContext.Session.SetObject(key, value);
        }
        public IList<T> GetObjects<T>(string key) where T : class
        {
            Dictionary<string, T> objects = new Dictionary<string, T>();

            string objectString = this.GetString(key);
            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }

            T value = JsonConvert.DeserializeObject<T>(objectString);
            if (!objects.ContainsKey(key))
            {
                objects.TryAdd(key, value);
            }
            var lst = objects.Values.ToList();
            return lst;
        }

        public IList<object> GetObjects(string key)
        {
            Dictionary<string, object> objects = new Dictionary<string, object>();

            string objectString = this.GetString(key);
            if (string.IsNullOrEmpty(objectString))
            {
                return null;
            }

            object value = JsonConvert.DeserializeObject<object>(objectString);
            if (!objects.ContainsKey(key))
            {
                objects.TryAdd(key, value);
            }
            var lst = objects.Values.ToList();
            return lst;
        }
    }
}
