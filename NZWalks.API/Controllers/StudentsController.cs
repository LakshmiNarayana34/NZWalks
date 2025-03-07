using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{    //url like
    //https://localhost:portNumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {

        //it excutes this url: https://localhost:portNumber/api/students
        [HttpGet] //http get attribute
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "lachi", "naga", "lakshmi", "pavan", "srinu" };
            return Ok(studentNames);
        }
    }
}
