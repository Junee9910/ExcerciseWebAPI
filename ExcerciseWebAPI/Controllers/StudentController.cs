using AutoMapper;
using ExcerciseWebAPI.Models;
using ExcerciseWebAPI.Persistence;
using ExcerciseWebAPI.Persistence.Entities;
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
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StudentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }
            var result = _mapper.Map<StudentModel>(student);
            return Ok(result);
        }
        [HttpGet("students")]
        public async Task<IActionResult> GetList()
        {
            var students = await _context.Students.ToListAsync();
            //var result = students.Select(x => new StudentModel
            //{
            //    StudentID=x.StudentID,
            //    LastName=x.LastName,
            //    FirstMidName=x.FirstMidName
            //});
            var result = _mapper.Map<List<StudentModel>>(students); 
            return Ok(result);
        }
        [HttpPost]
        public async Task<ActionResult<StudentModel>> Create(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", student);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Student student)
        {
            if(id!=student.StudentID)
            {
                return BadRequest();
            }
            _context.Entry(student).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student==null)
            {
                return NotFound();
            }
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool StudentExists(int id)
        {
            return _context.Students.Any(s => s.StudentID == id);
        }
    }
}
