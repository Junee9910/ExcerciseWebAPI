﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Persistence.Entities
{
    public class Course
    {
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int? Credits { get; set; }
        public int DepartmentID { get; set; }
        public Department Department { get; set; }
        public List<CourseAssignment> CourseAssignments { get; set; }
        public List<Enrollment> Enrollments { get; set; }
    }
}
