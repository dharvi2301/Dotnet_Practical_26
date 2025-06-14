﻿using EmployeeDAL.Data;
using EmployeeDAL.DTO;
using EmployeeDAL.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Repositories
{
    public class CommandRepository:ICommandRepository
    {
        private readonly DbService _dbService;

        public CommandRepository(DbService dbService)
        {
            _dbService = dbService;
        }

        public void Create(AddEmployeeDTO emp)
        {
            using (var conn = _dbService.GetConnection())
            {
                string query = @"INSERT INTO Employee 
                                (EmployeeName, EmployeeSalary, DepartmentId, EmployeeEmail, EmployeeJoiningDate, EmployeeStatus)
                                VALUES (@Name, @Salary, @DeptId, @Email, @JoinDate, 'Active')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@Salary", emp.EmployeeSalary);
                cmd.Parameters.AddWithValue("@DeptId", emp.DepartmentId);
                cmd.Parameters.AddWithValue("@Email", emp.EmployeeEmail);
                cmd.Parameters.AddWithValue("@JoinDate", emp.EmployeeJoiningDate);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void SoftDelete(int id)
        {
            using (var conn = _dbService.GetConnection())
            {
                string query = "UPDATE Employee SET EmployeeStatus = 'Inactive' WHERE EmployeeId = @Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Employee emp)
        {
            using (var conn = _dbService.GetConnection())
            {
                string query = @"UPDATE Employee SET 
                                EmployeeName = @Name,
                                EmployeeSalary = @Salary,
                                DepartmentId = @DeptId,
                                EmployeeEmail = @Email
                                WHERE EmployeeId = @Id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", emp.EmployeeId);
                cmd.Parameters.AddWithValue("@Name", emp.EmployeeName);
                cmd.Parameters.AddWithValue("@Salary", emp.EmployeeSalary);
                cmd.Parameters.AddWithValue("@DeptId", emp.DepartmentId);
                cmd.Parameters.AddWithValue("@Email", emp.EmployeeEmail);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
