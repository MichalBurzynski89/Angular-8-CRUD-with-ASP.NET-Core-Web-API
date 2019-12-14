using AspNetCoreWebAPI.Models.DataAccess;
using QBatis.DataMapper;
using System.Collections.Generic;

namespace AspNetCoreWebAPI.DataAccess.QBatis
{
    public class SqlMapperDataSource : IGenericDataSource
    {
        private readonly ISqlMapper _mapper;

        public SqlMapperDataSource(ISqlMapper mapper)
        {
            _mapper = mapper;
        }

        T IGenericDataSource.QueryForObject<T>(string statement, object args)
        {
            return _mapper.QueryForObject<T>(statement, args);
        }

        IEnumerable<T> IGenericDataSource.QueryForList<T>(string statement, object args)
        {
            return _mapper.QueryForList<T>(statement, args);
        }

        void IGenericDataSource.Insert(string statement, object item)
        {
            _mapper.Insert(statement, item);
        }

        void IGenericDataSource.Update(string statement, object item)
        {
            _mapper.Update(statement, item);
        }

        void IGenericDataSource.Delete(string statement, object item)
        {
            _mapper.Delete(statement, item);
        }
    }
}
