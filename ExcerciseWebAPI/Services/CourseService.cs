﻿using AutoMapper;
using ExcerciseWebAPI.Models;
using ExcerciseWebAPI.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Services
{
    public class CourseService:ICourseService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CourseService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<CourseListModel> GetList()
        {
            var result = _context.Courses.Include(x => x.Department)
                .Select(x => new CourseListModel()
                {
                    CourseID = x.CourseID,
                    Name = x.Title,
                    Credits=x.Credits,
                    Department=x.Department.DepartmentName
                })
                .AsQueryable()
                .OrderBy(x => x.CourseID)
                .ToList();

            //return _mapper.Map<List<InstructorListModel>>(result);
            return result;
        }
    }
}
