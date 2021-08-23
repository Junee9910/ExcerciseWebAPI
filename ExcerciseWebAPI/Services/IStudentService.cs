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
        Student Get(int id);
        IEnumerable<Student> GetList(string userName, OwnerParameters ownerParameters);
        void Add(Student student);
        void Update(Student student);
        void Delete(Student student);
        bool Save();
        bool StudentExists(int id);
    }
}
