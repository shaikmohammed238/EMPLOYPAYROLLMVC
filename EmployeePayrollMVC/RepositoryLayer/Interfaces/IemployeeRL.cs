using CommonLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interfaces
{
    public  interface IemployeeRL
    {
        public void AddEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        public void DeleteEmployee(int? EmpId);
        public IEnumerable<Employee> GetAllEmployee();
        public Employee GetEmployeeData(int? EmpId);
    }
}
