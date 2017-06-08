using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ContosoUniversity.Models;

namespace TestCoreWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Students")]
    public class StudentsController : Controller
    {
        private readonly SchoolContext _context;

        public StudentsController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public Task<List<Student>> Get()
        {
            return _context.Students.ToListAsync();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Student student) {

            _context.Students.Add(student);

            _context.SaveChanges();

            return Ok(student);
        }
    }
}