using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Persistence.Entities
{
    public class Student
    {
        public int StudentID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime? EnrollmentDate { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public string Fullname => LastName.Trim() + " " + FirstMidName.Trim();
    }
}
