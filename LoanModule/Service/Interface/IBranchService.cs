using LoanModule.API.RequestModel;

namespace LoanModule.Service.Interface
{
    public interface IBranchService
    {
        Task CreateBranchAsnyc(BranchRequestModel branch);
    }
}
