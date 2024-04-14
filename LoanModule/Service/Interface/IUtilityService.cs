using LoanModule.API.RequestModel;

namespace LoanModule.Service.Interface
{
    public interface IUtilityService
    {
        Task<List<object>> GenericAPIAsync(GenericAPIRequestModel genericAPIRequestModel);
    }
}
