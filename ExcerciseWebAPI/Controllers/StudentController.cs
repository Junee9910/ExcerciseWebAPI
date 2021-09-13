using AutoMapper;
using ExcerciseWebAPI.Models;
using ExcerciseWebAPI.Persistence;
using ExcerciseWebAPI.Persistence.Entities;
using ExcerciseWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult Get(int id)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpGet("GetByCourse")]
        public IActionResult GetCourse(int id)
        {
            var student = _studentService.GetCourse(id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }

        [HttpGet("list")]
        public ActionResult<IEnumerable<StudentListModel>> GetList([FromQuery] StudentParams param)
        {
            var result = _studentService.GetList(param);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult<StudentListModel> Create(StudentCreateModel model)
        {
            var result = _studentService.Create(model);
            return CreatedAtRoute("GetStudent", new { Id = result.StudentID }, result);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, StudentEditModel student)
        {
            if (student.StudentID != id)
            {
                return BadRequest();
            }

            var entity = _studentService.Update(student);
            if (entity == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _studentService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
