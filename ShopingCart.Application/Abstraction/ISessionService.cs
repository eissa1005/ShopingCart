using Microsoft.AspNetCore.Http;

namespace ShopingCart.Application.Abstraction
{
    public interface ISessionService :ISession 
    {
        void SetObject<TValue>(string key, TValue value);
        IList<T> GetObjects<T>(string key) where T : class;
        public IList<object> GetObjects(string key);
        ISession Current { get; }
    }
}
