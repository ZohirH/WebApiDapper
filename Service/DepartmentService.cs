using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Domain;

namespace Service
{
    public class DepartmentService
    {
        private string connectionString = "Server=localhost;port=5432;Database=Exam;User Id=postgres;password=MyData;";

      
        
        public NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(connectionString);
        }
        public List<DepartmentD> GetDepartment()
        {
            using (var connection = GetConnection())
            {
                var sql =" select D.Id, D.Name,E.Id as ManagerId, concat(E.FirsName,'  ', E.LastName) as ManagerFullName "+
                "  from Department as D "+
                 " join Employee as E on D.Id = E.Id  ";
                
              
                var result = connection.Query<DepartmentD>(sql);
                return result.ToList();
            }
        }
        public int Insert(Department department)
        {
            using (var con=GetConnection())
            {
                var sql = $" Insert into Department(Name) " +
                          $" values('{department.Name}') ";
                
             var insert = con.Execute(sql);
                return insert;
            }
        }
        public int Update(Department department ,int Id)
        {
            using (var con = GetConnection())
            {
                var sql = $" Update Department set Name='{department.Name}' Where Id={Id} ";
                var update = con.Execute(sql);
                return update;
            }
        }
    }
}
