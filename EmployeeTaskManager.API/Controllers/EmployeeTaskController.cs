using EmployeeTaskManager.API.Repositories;
using EmployeeTaskManager.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace EmployeeTaskManager.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeTaskController : ControllerBase
    {
        private readonly IEmployeeTaskRepository _employeeTaskRepository;
        public EmployeeTaskController(IEmployeeTaskRepository employeeTaskRepository)
        {
            _employeeTaskRepository = employeeTaskRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(EmployeeTask employeeTask)
        {
            var id = await _employeeTaskRepository.Create(employeeTask);
            return new JsonResult(id.ToString());
        }

        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var Task = await _employeeTaskRepository.Get(ObjectId.Parse(id));
            return new JsonResult(Task);
        }
        [HttpGet("getbyName/{Name}")]
        public async Task<IActionResult> GetbyName(string name)
        {
            var Task = await _employeeTaskRepository.GetByName(name);
            return new JsonResult(Task);
        }
        [HttpPut("get/{id}")]
        public async Task<IActionResult> Update(string id, EmployeeTask employeeTask)
        {
            var Task = await _employeeTaskRepository.Update(ObjectId.Parse(id), employeeTask);
            return new JsonResult(Task);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var Task = await _employeeTaskRepository.Delete(ObjectId.Parse(id));
            return new JsonResult(Task);
        }
        [HttpGet("Fetch")]
        public async Task<IActionResult> GetAll(string id)
        {
            var Task = await _employeeTaskRepository.GetAll();
            return new JsonResult(Task);
        }
    }
}
