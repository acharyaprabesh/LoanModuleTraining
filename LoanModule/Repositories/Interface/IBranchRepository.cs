using LoanModule.API.Models;
using LoanModule.API.RequestModel;
using LoanModule.API.ResponseModel;

namespace LoanModule.Repositories.Interface
{
    public interface IBranchRepository
    {
        Task CreateBranchAsnyc(BranchModel branch);
        Task<List<BranchResponseModel>> GetBranchAsync();
    }
}
