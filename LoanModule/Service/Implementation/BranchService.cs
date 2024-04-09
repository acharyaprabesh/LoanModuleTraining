using AutoMapper;
using LoanModule.API.Models;
using LoanModule.API.RequestModel;
using LoanModule.API.ResponseModel;
using LoanModule.Repositories.Interface;
using LoanModule.Service.Interface;

namespace LoanModule.Service.Implementation
{
    public class BranchService : IBranchService
    {
        private IBranchRepository _repository;
        private IMapper _autoMapper;
        private IGenericRepository _genericRepository;
        public BranchService(IBranchRepository branchRepository,IMapper mapper, IGenericRepository genericRepository)
        {
            _repository = branchRepository;
            _autoMapper = mapper;
            _genericRepository = genericRepository; 
        }
        public async Task CreateBranchAsnyc(BranchRequestModel branch)
        {
            //BranchModel branchModel = new()
            //{
            //    BranchCode=branch.BranchCode,
            //    BranchName=branch.BranchName,
            //    Address=branch.Address,
            //    PhoneNo=branch.PhoneNo,
            //    status=branch.status,
            //    CreatedDate=branch.CreatedDate

            //};
            var BranchMappingModel = _autoMapper.Map<BranchParam>(branch);
            BranchMappingModel.Flag = 'c';
            var response = await _genericRepository.InsertAsync("spBranch", BranchMappingModel);
            return;
          // return _repository.CreateBranchAsnyc(BranchMappingModel);
        }

        async Task<List<BranchResponseModel>> IBranchService.GetBranchAsync()
        {
            BranchParam branchParam = new()
            {
                Flag = 's'
            };
            var BranchList = await _genericRepository.GetAllAsync<BranchResponseModel>("spBranch", branchParam);
            return BranchList;
           // return _repository.GetBranchAsync();
        }
    }
}
