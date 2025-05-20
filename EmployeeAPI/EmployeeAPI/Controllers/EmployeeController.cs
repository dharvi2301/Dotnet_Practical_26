using EmployeeDAL.DTO;
using EmployeeDAL.Models;
using EmployeeDAL.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly CommandRepository _commands;
        private readonly QueryRepository _queries;

        public EmployeeController(CommandRepository commands, QueryRepository queries)
        {
            _commands = commands;
            _queries = queries;
        }

        [HttpPost]
        public IActionResult Create(AddEmployeeDTO dto)
        {
            _commands.Create(dto);
            return Ok("Employee Created");
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var emp = _queries.GetById(id);
            return emp == null ? NotFound() : Ok(emp);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_queries.GetAll());
        }

        [HttpPut]
        public IActionResult Update(Employee emp)
        {
            _commands.Update(emp);
            return Ok("Updated");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _commands.SoftDelete(id);
            return Ok("Soft Deleted");
        }
    }
}
