using DataAccessLayers.Data;
using DataAccessLayers.Entityes;
using DataAccessLayers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinesslogicLayer
{
    public class EmployeeService:IEmployeeService

    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }



        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.GetEmployeesAsync();
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            return await _employeeRepository.AddEmployee(employee);
        }


        //public async Task<bool> DeleteEmployee(int id)
        //{
        //    await _employeeRepository.DeleteEmployee(id);
        //    return true;
            
        //}

        //public async Task<Employee> GetEmployeeById(int id)
        //{
        //    return await _employeeRepository.DeleteEmployee(id);
        //}
        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            return await _employeeRepository.UpdateEmployee(employee);
           
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            await _employeeRepository.DeleteEmployee(id);
              return true;
        }

        public Task<Employee> GetEmployeeById(int id)
        {
            return _employeeRepository.GetEmployeeById(id);
        }
    }
}
