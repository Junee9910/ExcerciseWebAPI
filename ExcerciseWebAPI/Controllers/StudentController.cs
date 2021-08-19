﻿using AutoMapper;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpGet("students")]
        public async Task<IActionResult> GetList()
        {
            var students = await _studentService.GetList();
            return Ok(students);
        }
        //[HttpPost]
        //public async Task<ActionResult<StudentListModel>> Create(Student student)
        //{
        //    _context.Students.Add(student);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("Get", student);
        //}
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(int id, Student student)
        //{
        //    if (id != student.StudentID)
        //    {
        //        return BadRequest();
        //    }
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
