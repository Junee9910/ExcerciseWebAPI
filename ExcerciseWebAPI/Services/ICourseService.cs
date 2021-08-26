using ExcerciseWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Services
{
    public interface ICourseService
    {
        List<CourseListModel> GetList();
    }
}
