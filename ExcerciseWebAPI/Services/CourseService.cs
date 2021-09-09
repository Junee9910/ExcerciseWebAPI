using AutoMapper;
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
        public CourseModel Get(int id) {
            var courseEntity = _context.Courses.Include(x=>x.Department).Include(x=>x.Enrollments).ThenInclude(x=>x.Student)
            .FirstOrDefault(x => x.CourseID == id);

            return _mapper.Map<CourseModel>(courseEntity);
        }
        public List<CourseListModel> GetList()
        {
            var result = _context.Courses.Include(x => x.Department)
                .AsQueryable()
                .OrderBy(x => x.CourseID)
                .ToList();

            return _mapper.Map<List<CourseListModel>>(result);
        }
    }
}
