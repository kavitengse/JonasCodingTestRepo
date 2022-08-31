using AutoMapper;
using BusinessLayer.Model.Models;
using WebApi.Models;
using DataAccessLayer.Model.Models;
namespace WebApi
{
    public class AppServicesProfile : Profile
    {
        public AppServicesProfile()
        {
            CreateMapper();
        }

        private void CreateMapper()
        {
            CreateMap<BaseInfo, BaseDto>();
            CreateMap<CompanyInfo, CompanyDto>();
            CreateMap<CompanyInfo,Company >();
            CreateMap<ArSubledgerInfo, ArSubledgerDto>();
        }
    }
}