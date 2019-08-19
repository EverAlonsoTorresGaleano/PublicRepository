using MasGlobal.HandsOn.DAL.DataMapper;
using MasGlobal.HandsOn.Model.Entities;
using MasGlobal.HandsOn.Model.Integrations;
using MasGlobal.HandsOn.Repository.Interface;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MasGlobal.HandsOn.Repository.Implementation
{
    /// <see cref="IEmployeeRepository"/>
    public class EmployeeRepository : IEmployeeRepository
    {
        const string AppSettings_SawggerEmployeeServiceUrl = "SawggerEmployeeServiceUrl";
        /// <see cref="IEmployeeRepository.GetAll"/>
        public List<Employee> GetAll()
        {
            var temp =  GetAllExternal();
            var context = DataMapperFactory.GetDataContext();
            var returnList = context.Employees.ToList<Employee>();
            return returnList;
        }

        /// <see cref="IEmployeeRepository.GetAll"/>
        public async Task<List<EmployeeSwagger>> GetAllExternal()
        {
            List<EmployeeSwagger> interationList;
            var proxy = new HttpClient();
            
            HttpResponseMessage response =  await proxy.GetAsync(ConfigurationManager.AppSettings[AppSettings_SawggerEmployeeServiceUrl]);
            response.EnsureSuccessStatusCode();
            string content =  await response.Content.ReadAsStringAsync();
            interationList = JsonConvert.DeserializeObject<List<EmployeeSwagger>>(content);
            return interationList;
        }

        /// <see cref="IEmployeeRepository.GetById(int)"/>
        public Employee GetById(int employeeId)
        {
            var context = DataMapperFactory.GetDataContext();
            var returnList = context.Employees.Where(e => e.EmployeeId == employeeId).FirstOrDefault();
            return returnList;
        }
    }
}
