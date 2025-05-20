using EmployeeDAL.Data;
using EmployeeDAL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Repositories
{
    public class QueryRepository:IQueryRepository
    {
        private readonly DbService _dbService;
        public QueryRepository(DbService dbService)
        {
            _dbService = dbService;
        }

        public Employee GetById(int id)
        {
            Employee emp = null;
            using (var conn = _dbService.GetConnection())
            {
                string query = "SELECT * FROM Employee WHERE EmployeeId = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    emp = new Employee
                    {
                        EmployeeId = (int)reader["EmployeeId"],
                        EmployeeName = reader["EmployeeName"].ToString(),
                        EmployeeSalary = (decimal)reader["EmployeeSalary"],
                        DepartmentId = (int)reader["DepartmentId"],
                        EmployeeEmail = reader["EmployeeEmail"].ToString(),
                        EmployeeJoiningDate = (DateTime)reader["EmployeeJoiningDate"],
                        EmployeeStatus = reader["EmployeeStatus"].ToString()
                    };
                }
            }
            return emp;
        }

        public List<Employee> GetAll()
        {
            List<Employee> list = new List<Employee>();
            using (var conn = _dbService.GetConnection())
            {
                string query = "SELECT * FROM Employee";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Employee
                    {
                        EmployeeId = (int)reader["EmployeeId"],
                        EmployeeName = reader["EmployeeName"].ToString(),
                        EmployeeSalary = (decimal)reader["EmployeeSalary"],
                        DepartmentId = (int)reader["DepartmentId"],
                        EmployeeEmail = reader["EmployeeEmail"].ToString(),
                        EmployeeJoiningDate = (DateTime)reader["EmployeeJoiningDate"],
                        EmployeeStatus = reader["EmployeeStatus"].ToString()
                    });
                }
            }
            return list;
        }
}
}
