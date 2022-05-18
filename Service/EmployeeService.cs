using Dapper;
using Domain;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class EmployeeService
    {
        private string connectionString = "Server=localhost;port=5432;Database=Exam;User Id=postgres;password=MyData;";



        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }


        public List<EmployeeE> GetEmployee()
        {
            using (var connection = GetConnection())
            {
                var sql = "select E.Id,concat(E.FirsName,'  ', E.LastName) as FullName, D.Id  as DepartmentId,D.Name as DepartmentName "+
                 " from Employee as E "+
                 " join Department as D on D.Id = E.Id ";
                  

                var result = connection.Query<EmployeeE>(sql);
                return result.ToList();
            }
        }


        public int Insert(Employee employee)
        {
            using (var con = GetConnection())
            {
                var sql = $" Insert into Employee( BirthDate,FirsName, LastName, Gender, HireDate) " +
                    $" values ('{employee.BirthDate}', " +
                    $" '{employee.FirsName}', " +
                    $" '{employee.LastName}', " +
                    $" '{employee.Gender}', " +
                    $" '{employee.HireDate}') ";
                    

                var insert = con.Execute(sql);
                return insert;
            }
        }


        public int Update(Employee employee, int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $"Update Employee" +
                    $" set" +
                    $" BirthDate='{employee.BirthDate}'," +
                    $" FirsName='{employee.FirsName}', " +
                    $" LastName='{employee.LastName}', " +
                    $" Gender='{employee.Gender}', " +
                    $" HireDate='{employee.HireDate}' " +
                    $" Where  Id={Id} ";

                var update = con.Execute(sql);
                return update;
            }
        }
    }
}
