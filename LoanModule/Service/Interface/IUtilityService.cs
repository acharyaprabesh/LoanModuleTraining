using LoanModule.API.RequestModel;
using LoanModule.API.ResponseModel;

namespace LoanModule.Service.Interface
{
    public interface IUtilityService
    {
        Task<List<object>> GenericAPIAsync(GenericAPIRequestModel genericAPIRequestModel);
        Task<List<DropDownResponseModel>> GetDropDownListAsync(string DropDownName, string? FilterValue);
    }
}
