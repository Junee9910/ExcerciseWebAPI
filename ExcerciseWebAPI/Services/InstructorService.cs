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

        public InstructorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Instructor> GetList()
        {
            //IQueryable<InstructorListModel> result;
            //result = _context.Instructors.Include(x => x.OfficeAssignment)
            //    .Select(x => new InstructorListModel()
            //    {
            //        InstructorID = x.InstructorID,
            //        FullName = x.Fullname,
            //        LocationIn = x.OfficeAssignment.LocationIn
            //    }).AsQueryable();
            var result = _context.Instructors.AsQueryable();
            return result.ToList<Instructor>();
            //return result.AsNoTracking().AsEnumerable<Instructor>();
        }
    }
}
