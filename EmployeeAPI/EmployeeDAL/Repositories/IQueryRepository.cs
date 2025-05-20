using EmployeeDAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDAL.Repositories
{
    public interface IQueryRepository
    {
        List<Employee> GetAll();
        Employee GetById(int id);
    }
}
