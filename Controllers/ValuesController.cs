using backend_api.Business.Abstracts;
using backend_api.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend_api.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private readonly IStudentManager _studentManager;

        public ValuesController(IStudentManager studentManager)
        {
            _studentManager = studentManager;
        }

        string dataone = "Veri";

        string[] datatwo = new string[] {
            "data1",
            "data2",
            "data3",
            "data4",
            "data5",
            "data6",
            "data7"
        };

        //List<string> datatwo = new List<string>()
        //{
        //    "data1",
        //    "data2",
        //    "data3"
        //};

        [HttpGet("dataone")]
        public IActionResult GetDataOne()
        {
            return Ok(dataone);
        }

        [HttpGet("datatwo")]
        public IActionResult GetDataTwo()
        {
            return Ok(datatwo);
        }
        [HttpGet("getstudents")]
        public IActionResult GetStudents()
        {
            return Ok(_studentManager.getAll());
        }
        [HttpPost("addstudent")]
        public IActionResult AddStudent(Student student) {
            _studentManager.add(student);
            return Ok();
        }


    }
}
