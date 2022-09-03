using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using BusinessLayer.Model.Interfaces;
using BusinessLayer.Model.Models;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class CompanyController : ApiController
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;
        

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }
        // GET api/<controller>
        public async Task<IEnumerable<CompanyDto>> GetAll()
        {
            
               var items = _companyService.GetAllCompanies();
                return (await Task.FromResult(_mapper.Map<IEnumerable<CompanyDto>>(items)));
           
           
           
        }
        public void WriteLog(string logMessage)
        {
            LogEntry logEntry = new LogEntry();
            logEntry.EventId = 100;
            logEntry.Priority = 2;
            logEntry.Message = logMessage;
            Logger.Write(logEntry);
        }
        // GET api/<controller>/5
        public async Task<CompanyDto> Get(string companyCode)
        {
            var item = _companyService.GetCompanyByCode(companyCode);
            return (await Task.FromResult(_mapper.Map<CompanyDto>(item)));
        }

        // POST api/<controller>
        public async Task<bool> Post([FromBody]CompanyInfo companyInfo)
        {
            bool result = false;
            WriteLog("---Started SaveCompany Method----");
            try
            {
                result = _companyService.SaveCompany(companyInfo);
            }
            catch (Exception ex)
            {
                WriteLog("---Exception Occured----" + ex.Message);
            }
            return await Task.FromResult(result);
        }

        // PUT api/<controller>/5
        public async Task<bool> Put(int id, [FromBody] CompanyInfo companyInfo)
        {
            bool result =false;
            WriteLog("---Started UpdateCompany Method----");
            try
            {
                result = _companyService.UpdateCompany(companyInfo);
            }
            catch(Exception ex)
            {
                WriteLog("---Exception Occured----" + ex.Message);
            }
            return await Task.FromResult(result);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}