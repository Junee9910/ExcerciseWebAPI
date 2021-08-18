using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Persistence.Entities
{
    public class Department
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public int? Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public int? InstructorID { get; set; }
        public Instructor Instructor { get; set; }
        public List<Course> Courses { get; set; }
    }
}
