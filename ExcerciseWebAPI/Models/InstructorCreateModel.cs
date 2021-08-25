using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Models
{
    public class InstructorCreateModel
    {
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string Office { get; set; }
    }
    public class InstructorEditModel
    {
        public int InstructorID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime? HireDate { get; set; }
        public string Office { get; set; }
    }
}
