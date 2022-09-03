using BusinessLayer.Model.Interfaces;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Model.Models;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace BusinessLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyService(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }
        public IEnumerable<CompanyInfo> GetAllCompanies()
        {
            var res = _companyRepository.GetAll();
            return _mapper.Map<IEnumerable<CompanyInfo>>(res);
        }

        public CompanyInfo GetCompanyByCode(string companyCode)
        {
            var result = _companyRepository.GetByCode(companyCode);
            return _mapper.Map<CompanyInfo>(result);
        }

        public bool SaveCompany(CompanyInfo company)
        {
            Company companyObject = _mapper.Map<Company>(company);
            var result = _companyRepository.SaveCompany(companyObject);
            return result;
        }

        public bool UpdateCompany(CompanyInfo company)
        {
            Company companyObject = _mapper.Map<Company>(company);
            bool result=false;
            try
            {
                result = _companyRepository.UpdateCompany(companyObject);
            }
            catch(System.Exception ex)
            {
                throw ex;
                
            }

            return result;
        }

    }
}
