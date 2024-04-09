using LoanModule.API.RequestModel;
using LoanModule.Repositories.Interface;
using LoanModule.Service.Interface;

namespace LoanModule.Service.Implementation
{
    public class BranchService : IBranchService
    {
        private IBranchRepository _repository;
        public BranchService(IBranchRepository branchRepository)
        {
            _repository=branchRepository;
        }
        public Task CreateBranchAsnyc(BranchRequestModel branch)
        {
           return _repository.CreateBranchAsnyc(branch);
        }
    }
}
