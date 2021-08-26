using ExcerciseWebAPI.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Models
{
    public class EnrollmentCourseById
    {
        public string CourseName { get; set; }
        public Grades Grade { get; set; }
    }
}
