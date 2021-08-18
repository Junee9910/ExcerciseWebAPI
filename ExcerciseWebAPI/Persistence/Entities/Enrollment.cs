using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Persistence.Entities
{
    public enum Grades { None, A, B, C, D, E }
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        public Grades Grade { get; set; }
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}
