using API_Revision.Models;
using API_Revision.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Revision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class API_RevisionController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;

        public API_RevisionController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet("Get_Student")]
        public async Task<IActionResult> GetStudents_Info()
        {
            var data =await _studentRepository.GetStudentsInfo();
            return Ok(data);
        }

        [HttpGet("GetAllDetails")]
        public async Task<IActionResult> GetAllDetails([FromQuery] int Id)
        {
            var data = await _studentRepository.GetAllInfo(Id);
            if (data == null)
            {
                return Ok("There is no record for this Id: " + Id);
            }
            else
            {
                return Ok(data);
            }
        }

        [HttpGet("Get_Student_ById")]
        public async Task<IActionResult> GetStudents_ById([FromQuery]  int Id)
        {
            
            //if (Id.GetType() != typeof(int))
            //{
            //return Ok("Instead of string you should pass int");
            //}

            var data = await _studentRepository.GetStudentById(Id);
            if(data==null)
            {
                return Ok("There is no record for this Id: "+Id); 
            }
            else
            {
                return Ok(data);
            }
            
        }

        [HttpPost("Add_Student")]

        public async Task<string> AddStudent([FromBody] StudentsModel studentsModel)
        {
            var data =await _studentRepository.AddStudent(studentsModel);
            return data;
        }

        [HttpPut("Update_Student")]
        public async Task<IActionResult> UpdateStudent([FromQuery] int Id,[FromBody] StudentsModel studentsModel)
        {
            var data = await _studentRepository.updateStudent(Id,studentsModel);

                return Ok(data);
            
        }

        [HttpDelete("Delete_Student")]
        public async Task<IActionResult> DeleteStudent([FromQuery] int Id)
        {
            var data = await _studentRepository.DeleteRecord(Id);

            return Ok(data);

        }
    }
}
