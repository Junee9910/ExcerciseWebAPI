using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Persistence.Entities
{
    public class OfficeAssignment
    {
        public int InstructorID { get; set; }
        public string LocationIn { get; set; }
        public Instructor Instructor { get; set; }
    }
}
