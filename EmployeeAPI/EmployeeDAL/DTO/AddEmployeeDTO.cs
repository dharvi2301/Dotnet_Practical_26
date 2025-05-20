﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.DTO
{
    public class AddEmployeeDTO
    {
        public string EmployeeName { get; set; }
        public decimal EmployeeSalary { get; set; }
        public string EmployeeEmail { get; set; }
        public int DepartmentId { get; set; }
        public DateTime EmployeeJoiningDate { get; set; }
    }
}
