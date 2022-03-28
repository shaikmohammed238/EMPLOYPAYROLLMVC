using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using CommonLayer.Models;
using RepositoryLayer.Interfaces;

namespace RepositoryLayer.Services
{
    public class EmployeeRL:IemployeeRL
    {
        string connectionString = "Data Source = (localdb)\\MSSQLLocalDB;Initial Catalog = EMP_MVC; Integrated Security = True;";
        //private readonly SqlConnection sqlConnection;
        //   private readonly IConfiguration configuration;

        // public IConfiguration Configuration { get; }
        //public EmployeeRL(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //}
        // public EmployeeRL(IConfiguration configuration)
        //{
        //  this.Configuration = configuration;
        //}

        /// <summary>
        /// Adds the employee data.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void AddEmployee(Employee employee)
        {
            //sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("EMP_MVC"));

            using (SqlConnection con = new SqlConnection(connectionString))

            //using (sqlConnection)
            {
                SqlCommand addemp = new SqlCommand("sp_EmpPayINSERT", con);
                addemp.CommandType = CommandType.StoredProcedure;

                addemp.Parameters.AddWithValue("@Name", employee.Name);
                addemp.Parameters.AddWithValue("@Profile", employee.ProfileImage);
                addemp.Parameters.AddWithValue("@Gender", employee.Gender);
                addemp.Parameters.AddWithValue("@Department", employee.Department);
                addemp.Parameters.AddWithValue("@Salary", employee.Salary);
                addemp.Parameters.AddWithValue("@Startdate", employee.Startdate);
                addemp.Parameters.AddWithValue("@Notes", employee.Notes);
                con.Open();
                addemp.ExecuteNonQuery();
                con.Close();

            }
        }
        /// <summary>
        /// Updates the employee.
        /// </summary>
        /// <param name="employee">The employee.</param>
        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand updateemp = new SqlCommand("sp_EmpPayUPDATE", connection);
                updateemp.CommandType = CommandType.StoredProcedure;

                updateemp.Parameters.AddWithValue("@EmpId", employee.EmpId);
                updateemp.Parameters.AddWithValue("@Name", employee.Name);
                updateemp.Parameters.AddWithValue("@Profile", employee.ProfileImage);
                updateemp.Parameters.AddWithValue("@Gender", employee.Gender);
                updateemp.Parameters.AddWithValue("@Department", employee.Department);
                updateemp.Parameters.AddWithValue("@Salary", employee.Salary);
                updateemp.Parameters.AddWithValue("@Startdate", employee.Startdate);
                updateemp.Parameters.AddWithValue("@Notes", employee.Notes);
                connection.Open();
                updateemp.ExecuteNonQuery();
                connection.Close();
            }
        }
        /// <summary>
        /// Deletes the employee.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public void DeleteEmployee(int? EmpId)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand deleteemp = new SqlCommand("sp_EmpPayDEL", connection);
                deleteemp.CommandType = CommandType.StoredProcedure;

                deleteemp.Parameters.AddWithValue("@EmpId", EmpId);

                connection.Open();
                deleteemp.ExecuteNonQuery();
                connection.Close();
            }
        }
        /// <summary>
        /// Gets all employee.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Employee> GetAllEmployee ( )
        {
            List<Employee> lstEmps = new List<Employee>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand getemp = new SqlCommand("sp_EmpPayGETALL", connection);
                getemp.CommandType = CommandType.StoredProcedure;
                connection.Open();
                SqlDataReader rdr = getemp.ExecuteReader();

                while (rdr.Read())
                {
                    Employee employee = new Employee();

                    employee.EmpId= Convert.ToInt32(rdr["EmpId"]);
                    employee.Name =rdr["Name"].ToString();
                    employee.ProfileImage = rdr["ProfileImage"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.Startdate = Convert.ToDateTime(rdr["Startdate"]);
                    employee.Notes = rdr["Notes"].ToString();
                     
                    lstEmps.Add(employee);
                }
                connection.Close();
            }
            return lstEmps;
        }
        /// <summary>
        /// Gets the employee data.
        /// </summary>
        /// <param name="EmpId">The emp identifier.</param>
        /// <returns></returns>
        public Employee GetEmployeeData(int? EmpId)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM EmployeePayrollForm Where EmpId = " + EmpId;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {

                    employee.EmpId = Convert.ToInt32(rdr["EmpId"]);
                    employee.Name = rdr["Name"].ToString();
                    employee.ProfileImage = rdr["ProfileImage"].ToString();
                    employee.Gender = rdr["Gender"].ToString();
                    employee.Department = rdr["Department"].ToString();
                    employee.Salary = Convert.ToInt32(rdr["Salary"]);
                    employee.Startdate = Convert.ToDateTime(rdr["Startdate"]);
                    employee.Notes = rdr["Notes"].ToString();

                }
                con.Close();
            }
            return employee;
        }
    }
}
