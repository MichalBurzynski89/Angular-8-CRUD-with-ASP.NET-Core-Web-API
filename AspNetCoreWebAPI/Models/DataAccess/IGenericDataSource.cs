using System.Collections.Generic;

namespace AspNetCoreWebAPI.Models.DataAccess
{
    public interface IGenericDataSource
    {
        T QueryForObject<T>(string statement, object args);
        IEnumerable<T> QueryForList<T>(string statement, object args);
        void Insert(string statement, object item);
        void Update(string statement, object item);
        void Delete(string statement, object item);
    }
}
