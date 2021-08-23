using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Models
{
    public class OfficeAssignmentModel
    {
        public int InstructorID { get; set; }
        public string LocationIn { get; set; }
        public InstructorListModel Instructor { get; set; }
    }
}
