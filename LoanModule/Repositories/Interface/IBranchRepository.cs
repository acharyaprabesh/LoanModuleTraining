using LoanModule.API.RequestModel;

namespace LoanModule.Repositories.Interface
{
    public interface IBranchRepository
    {
        Task CreateBranchAsnyc(BranchRequestModel branch);
    }
}
