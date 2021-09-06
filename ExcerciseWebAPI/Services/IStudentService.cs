using ExcerciseWebAPI.Models;
using ExcerciseWebAPI.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Services
{
    public interface IStudentService
    {
        //StudentModel GetCourse(int id);
        StudentListModel Get(int id);
        List<StudentListModel> GetList(StudentParams param);
        StudentListModel Create(StudentCreateModel model);
        StudentListModel Update(StudentEditModel model);
        Student Delete(int id);
    }
}
