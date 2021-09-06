using AutoMapper;
using ExcerciseWebAPI.Extensions;
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
        //public StudentModel GetCourse(int id)
        //{
        //    var entity = _context.Students.Include(x=>x.Enrollments).ThenInclude(x=>x.Course)
        //        .FirstOrDefault(x => x.StudentID == id);

        //    return _mapper.Map<StudentModel>(entity);
        //}
        public StudentListModel Get(int id)
        {
            var entity = _context.Students
                .FirstOrDefault(x => x.StudentID == id);

            return _mapper.Map<StudentListModel>(entity);
        }

        public List<StudentListModel> GetList(StudentParams param)
        {
            var skip = (param.PageNumber.GetValueOrDefault() - 1) * param.PageSize.GetValueOrDefault();
            var take = param.PageSize.GetValueOrDefault();

            var result = _context.Students
                .AsQueryable()
                .WhereIf(!string.IsNullOrWhiteSpace(param.Name),
                    x => x.FirstMidName.Contains(param.Name) || x.LastName.Contains(param.Name))
                .Skip(skip)
                .Take(take)
                .OrderBy(x => x.StudentID)
                .ToList();

            return _mapper.Map<List<StudentListModel>>(result);
        }

        public StudentListModel Create(StudentCreateModel model)
        {
            var entity = _mapper.Map<Student>(model);
            _context.Students.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<StudentListModel>(entity);
        }

        public StudentListModel Update(StudentEditModel model)
        {
            var entity = _context.Students.FirstOrDefault(x => x.StudentID == model.Id);
            if (entity == null)
            {
                return null;
            }

            _mapper.Map(model, entity);
            _context.SaveChanges();

            return _mapper.Map<StudentListModel>(entity);
        }

        public Student Delete(int id)
        {
            var entity = _context.Students.FirstOrDefault(x => x.StudentID == id);
            if (entity == null)
            {
                return null;
            }

            _context.Students.Remove(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
