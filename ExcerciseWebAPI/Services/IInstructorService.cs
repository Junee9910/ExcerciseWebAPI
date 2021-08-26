using ExcerciseWebAPI.Models;
using ExcerciseWebAPI.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Services
{
    public interface IInstructorService
    {
        InstructorListModel Get(int id);
        List<InstructorListModel> GetList();
        InstructorListModel Create(InstructorCreateModel model);
        InstructorListModel Update(InstructorEditModel model);
        Instructor Delete(int id);
    }
}
