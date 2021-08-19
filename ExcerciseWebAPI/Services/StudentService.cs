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

namespace ExcerciseWebAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public StudentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StudentListModel> Get(int id)
        {
            var student = await _context.Students.FindAsync(id);

            return _mapper.Map<StudentListModel>(student);
        }

        public async Task<List<StudentListModel>> GetList()
        {
            var students = await _context.Students.ToListAsync();
            //var result = students.Select(x => new StudentModel
            //{
            //    StudentID=x.StudentID,
            //    LastName=x.LastName,
            //    FirstMidName=x.FirstMidName
            //});
            return _mapper.Map<List<StudentListModel>>(students);
        }
        //[HttpPost]
        //public async Task<ActionResult<StudentListModel>> Create(Student student)
        //{
        //    _context.Students.Add(student);
        //    await _context.SaveChangesAsync();

        //}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, Student student)
        //{
        //    _context.Entry(student).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StudentExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var student = await _context.Students.FindAsync(id);
        //    if (student == null)
        //    {
        //        return NotFound();
        //    }
        //    _context.Students.Remove(student);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}
        //private bool StudentExists(int id)
        //{
        //    return _context.Students.Any(s => s.StudentID == id);
        //}
    }
}
