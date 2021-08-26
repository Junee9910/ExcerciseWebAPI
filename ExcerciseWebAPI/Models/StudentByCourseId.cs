using ExcerciseWebAPI.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Models
{
    public class StudentByCourseId
    {
        public Grades Grade { get; set; }
        public string FullName { get; set; }
        
    }
}
