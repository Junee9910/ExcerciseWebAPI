using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Models
{
    public class CourseModel
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public List<StudentByCourseId> Students { get; set; }
    }
}
