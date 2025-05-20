﻿using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Data
{
    public class DbService
    {
        private readonly string _connectionString;
        public DbService()
        {
            _connectionString = "Server=(LocalDb)\\MSSQLLocalDb;Database=Practical_22;Trusted_Connection=True;Encrypt=False;";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
