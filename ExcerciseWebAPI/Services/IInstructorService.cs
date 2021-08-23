using ExcerciseWebAPI.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Services
{
    public interface IInstructorService
    {
        IEnumerable<Instructor> GetList();
    }
}
