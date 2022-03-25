using BussinessLayer.Interfaces;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinessLayer.Services
{
    public class EmployeeBL:IemployeeBL
    {
        IemployeeRL iemployeeRL;

        

        public EmployeeBL(IemployeeRL iemployeeRL)
        {
            this.iemployeeRL = iemployeeRL;

        }

        public void AddEmployee(Employee employee)
        {
            try
            {
                this.iemployeeRL.AddEmployee(employee);
            }
            catch (Exception)
            {
                throw;
            }
        }
        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                this.iemployeeRL.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteEmployee(int? EmpId)
        {
            try
            {
                this.iemployeeRL.DeleteEmployee(EmpId);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IEnumerable<Employee> GetAllEmployee()
        {
            try
            {
                return iemployeeRL.GetAllEmployee();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public Employee GetEmployeeData(int? EmpId)
        {
            try
            {
                return iemployeeRL.GetEmployeeData(EmpId);   
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
