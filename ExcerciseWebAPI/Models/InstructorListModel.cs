using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Models
{
    public class InstructorListModel
    {
        public int InstructorID { get; set; }
        public string FullName { get; set; }
        public string LocationIn { get; set; }
        public string Courses { get; set; }
    }
}
