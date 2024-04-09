using LoanModule.API.ResponseModel;
using LoanModule.Repositories.Interface;
using System.Data;

namespace Shared.Repositories.Implementation
{
    public class GenericRepositroy : IGenericRepository
    {

        private readonly IDapperRepository _dapperRepository;
        

        public GenericRepositroy(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<List<T>> GetAllAsync<T>(string spName, object obj, CommandType queryType)
            => await _dapperRepository.GetQueryResultAsync<T>(spName, obj, queryType);


        public async Task<T> GetAsync<T>(string spName, object obj, CommandType queryType)
            => await _dapperRepository.GetQueryFirstOrDefaultResultAsync<T>(spName, obj, queryType);

        public async Task<List<object>> GetFromMultipleQuery<T0, T1>(string sqlQuery, object sqlParam, CommandType queryType)
             => await _dapperRepository.GetFromMultipleQuery<T0, T1>(sqlQuery, sqlParam, queryType);

        public async Task<List<object>> GetFromMultipleQuery<T0, T1, T2>(string sqlQuery, object sqlParam, CommandType queryType)
            => await _dapperRepository.GetFromMultipleQuery<T0, T1, T2>(sqlQuery, sqlParam, queryType);

        public async Task<List<object>> GetFromMultipleQuery<T0, T1, T2, T3>(string sqlQuery, object sqlParam, CommandType queryType)
            => await _dapperRepository.GetFromMultipleQuery<T0, T1, T2, T3>(sqlQuery, sqlParam, queryType);

        public async Task<SystemResponse> UpdateAsync(string spName, object input, CommandType queryType)
        {
            return await _dapperRepository.ExecuteAsync(spName, input, queryType);
        }

        public async Task<SystemResponse> InsertAsync(string spName, object input, CommandType queryType)
        {
            return await _dapperRepository.ExecuteAsync(spName, input, queryType);
        }

        public async Task<SystemResponse> DeleteAsync(string spName, object input, CommandType queryType)
        {
            return await _dapperRepository.ExecuteAsync(spName, input, queryType);
        }
    }
}
