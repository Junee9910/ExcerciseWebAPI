using AutoMapper;
using ExcerciseWebAPI.Models;
using ExcerciseWebAPI.Persistence;
using ExcerciseWebAPI.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Services
{
    public class InstructorService:IInstructorService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public InstructorService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public InstructorListModel Get(int id)
        {
            var instructorEntity = _context.Instructors.Include(x=>x.OfficeAssignment)
            .Include(x=>x.CourseAssignments).ThenInclude(x=>x.Course).ThenInclude(x=>x.Department)
            .FirstOrDefault(x => x.InstructorID == id);

            return _mapper.Map<InstructorListModel>(instructorEntity);
        }
        public List<InstructorListModel> GetList()
        {
            var result = _context.Instructors
                .Include(x => x.OfficeAssignment)
                .Include(x=>x.CourseAssignments).ThenInclude(x=>x.Course).ThenInclude(x=>x.Department)
                .AsQueryable()
                .OrderBy(x => x.InstructorID)
                .ToList();
            return _mapper.Map<List<InstructorListModel>>(result);
        }
        public InstructorListModel Create(InstructorCreateModel model)
        {
            var entity = _mapper.Map<Instructor>(model);
            _context.Instructors.Include(x => x.OfficeAssignment);
            _context.Instructors.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<InstructorListModel>(entity);
        }

        public InstructorListModel Update(InstructorEditModel model)
        {
            var entity = _context.Instructors.Include(x=>x.OfficeAssignment).FirstOrDefault(x => x.InstructorID== model.InstructorID);
            if (entity == null)
            {
                return null;
            }

            _mapper.Map(model, entity);
            _context.SaveChanges();

            return _mapper.Map<InstructorListModel>(entity);
        }

        public Instructor Delete(int id)
        {
            var entity = _context.Instructors.Include(x=>x.OfficeAssignment).FirstOrDefault(x => x.InstructorID == id);
            if (entity == null)
            {
                return null;
            }
            //entity.OfficeAssignment.Remove(office);
            _context.Instructors.Remove(entity);
            _context.SaveChanges();
            return entity;
        }
    }
}
