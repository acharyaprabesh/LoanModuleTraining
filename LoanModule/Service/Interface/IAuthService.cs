using LoanModule.API.RequestModel;
using LoanModule.API.ResponseModel;

namespace LoanModule.Service.Interface
{
    public interface IAuthService
    {
        Task<SystemResponse> GetLoginToken(LoginRequestModel model);
    }
}
