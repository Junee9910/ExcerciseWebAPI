using ExcerciseWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Services
{
    public interface IStudentService
    {
        Task<StudentListModel> Get(int id);
        Task<List<StudentListModel>> GetList();
    }
}
