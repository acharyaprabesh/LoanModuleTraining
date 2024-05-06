using LoanModule.API.RequestModel;
using LoanModule.API.ResponseModel;
using LoanModule.Repositories.Interface;
using LoanModule.Service.Interface;
using System.Data;

namespace LoanModule.Service.Implementation
{
    public class UtilityService:IUtilityService
    {
        private readonly IGenericRepository _genericRepository;
        public UtilityService(IGenericRepository genericRepository)
        {
                _genericRepository= genericRepository;
        }
        public async Task<List<object>> GenericAPIAsync(GenericAPIRequestModel genericAPIRequestModel)
        {
            string StoreProcedureName = await _genericRepository.GetAsync<string>
                     ("select ProcedureName from tblGenericAPISetup with(nolock) where ModuleName=@ModuleName", new { ModuleName = genericAPIRequestModel.ModuleName }
                     , CommandType.Text
                     );

            Dictionary<string, object> Parameter = new();
            foreach (var item in genericAPIRequestModel.Parameter)
                Parameter.Add(item.Key, item.Value);

            var report = await _genericRepository.GetAllAsync<object>(StoreProcedureName, Parameter);

            return report;
        }

        public async Task<List<DropDownResponseModel>> GetDropDownListAsync(string DropDownName, string? FilterValue)
        {
          return await  _genericRepository.GetAllAsync<DropDownResponseModel>("spDropDown", new { DropDownName = DropDownName, FilterValue = FilterValue });
        }
    }
}
