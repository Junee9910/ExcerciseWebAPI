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

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Student Get(int id)
        {
            return _context.Students.FirstOrDefault(x => x.StudentID == id);
        }

        public IEnumerable<Student> GetList()
        {
            return _context.Students.ToList<Student>();
        }
        public void Add(Student student)
        {
            _context.Students.Add(student);
        }
        public void Update(Student student)
        { }

        public async void Delete(Student student)
        {
            _context.Students.Remove(student);
        }
        public bool StudentExists(int id)
        {
            return _context.Students.Any(s => s.StudentID == id);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
