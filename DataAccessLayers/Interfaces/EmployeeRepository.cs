using DataAccessLayers.Data;
using DataAccessLayers.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayers.Interfaces
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _employeeRepository;

        public EmployeeRepository(ApplicationDbContext employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return await _employeeRepository.Employees.ToListAsync();
        }


        //public void AddEmployee(Employee employee)
        //{
        //    _employeeRepository.Employees.Add(employee);
        //    _employeeRepository.SaveChanges();

        //}


        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employeeRepository.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            _employeeRepository.Employees.Add(employee);
            await _employeeRepository.SaveChangesAsync(); 
            return employee;
        }

        public async Task SaveChangesAsync() 
        {
            await _employeeRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var cus = _employeeRepository.Employees.Find( id);
            if (cus != null)
            {
                _employeeRepository.Employees.Remove(cus);
                await _employeeRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            _employeeRepository.Employees.Update(employee);
            await _employeeRepository.SaveChangesAsync();
            return employee;

                 }

      
    }
  }
