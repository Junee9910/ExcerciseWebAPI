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
            var instructorEntities = _context.Instructors.Where(x => x.InstructorID == id)
            .Select(x => new InstructorListModel()
             {
                 InstructorID = x.InstructorID,
                 FullName = x.Fullname,
                 LocationIn = x.OfficeAssignment.LocationIn
             }).FirstOrDefault();

            //return _mapper.Map<InstructorListModel>(instructorEntities);
            return instructorEntities;
        }
        public List<InstructorListModel> GetList()
        {
            var result = _context.Instructors.Include(x => x.OfficeAssignment)
                .AsQueryable()
                .OrderBy(x => x.InstructorID)
                .ToList();
            return _mapper.Map<List<InstructorListModel>>(result);
        }
        public InstructorListModel Create(InstructorCreateModel model)
        {
            var entity = _mapper.Map<Instructor>(model);
            _context.Instructors.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<InstructorListModel>(entity);
        }

        public InstructorListModel Update(InstructorEditModel model)
        {
            var entity = _context.Instructors.FirstOrDefault(x => x.InstructorID== model.InstructorID);
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
            var officeAssignmentEntity = _context.OfficeAssignments.FirstOrDefault(x => x.InstructorID == id);
            if (officeAssignmentEntity == null)
            {
                return null;
            }

            _context.OfficeAssignments.Remove(officeAssignmentEntity);
            _context.SaveChanges();

            var instructorEntity = _context.Instructors.FirstOrDefault(x => x.InstructorID == id);
            _context.Instructors.Remove(instructorEntity);
            _context.SaveChanges();
            return instructorEntity;
        }
    }
}
