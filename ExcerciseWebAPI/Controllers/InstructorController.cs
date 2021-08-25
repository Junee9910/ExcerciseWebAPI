using AutoMapper;
using ExcerciseWebAPI.Models;
using ExcerciseWebAPI.Persistence.Entities;
using ExcerciseWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InstructorController:ControllerBase
    {
        private readonly IInstructorService _instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }
        [HttpGet("{id}", Name = "GetInstructor")]
        public IActionResult Get(int id)
        {
            var student = _instructorService.Get(id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpGet("list")]
        public ActionResult<IEnumerable<InstructorListModel>> GetList()
        {
            var instructors = _instructorService.GetList();
            return Ok(instructors);
        }
        [HttpPost]
        public ActionResult<StudentListModel> Create(InstructorCreateModel model)
        {
            var result = _instructorService.Create(model);
            return CreatedAtRoute("GetInstructor", new { Id = result.InstructorID }, result);
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, InstructorEditModel instructor)
        {
            if (instructor.InstructorID != id)
            {
                return BadRequest();
            }

            var entity = _instructorService.Update(instructor);
            if (entity == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var result = _instructorService.Delete(id);
            if (result == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
