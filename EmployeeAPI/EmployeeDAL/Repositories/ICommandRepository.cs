using EmployeeDAL.DTO;
using EmployeeDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Repositories
{
    interface ICommandRepository
    {
        void Create(AddEmployeeDTO employee);
        void Update(Employee employee);
        void SoftDelete(int id);
    }
}
