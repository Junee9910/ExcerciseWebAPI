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
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;

        public StudentController(IMapper mapper,IStudentService studentService)
        {
            _mapper = mapper;
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
            return Ok( _mapper.Map<StudentListModel>(student));
        }
        [HttpGet("students")]
        public ActionResult<IEnumerable<StudentListModel>> GetList()
        {
            var students = _studentService.GetList();
            return Ok(_mapper.Map<IEnumerable<StudentListModel>>(students));
        }
        [HttpPost]
        public ActionResult<StudentListModel> Create(StudentCreateModel student)
        {
            var studentEntity = _mapper.Map<Student>(student);
            _studentService.Add(studentEntity);
            _studentService.Save();

            var studentToReturn = _mapper.Map<StudentListModel>(studentEntity);
            return CreatedAtRoute("GetStudent",
                new { studentID = studentToReturn.StudentID }, studentToReturn);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, StudentCreateModel student)
        {
            if (!_studentService.StudentExists(id))
            {
                return NotFound();
            }
            var studentRepo = _studentService.Get(id);
            if (studentRepo==null)
            {
                return NotFound();
            }
            _mapper.Map(student, studentRepo);
            _studentService.Update(studentRepo);
            _studentService.Save();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!_studentService.StudentExists(id))
            {
                return NotFound();
            }
            var studentRepo = _studentService.Get(id);
            if (studentRepo == null)
            {
                return NotFound();
            }
            _studentService.Delete(studentRepo);
            _studentService.Save();

            return NoContent();
        }
    }
}
