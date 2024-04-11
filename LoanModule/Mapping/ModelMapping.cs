using AutoMapper;
using LoanModule.API.Models;
using LoanModule.API.RequestModel;

namespace LoanModule.Mapping
{
    public class ModelMapping:Profile
    {
        public ModelMapping()
        {
                CreateMap<BranchModel,BranchRequestModel>().ReverseMap();
                CreateMap<BranchParam,BranchRequestModel>().ReverseMap();
                CreateMap<LoginModel, LoginRequestModel>().ReverseMap();
        }
    }
}
