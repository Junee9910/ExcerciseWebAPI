using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Models
{
    public class StudentListModel
    {
        public int StudentID { get; set; }
        public string FullName { get; set; }
        public List<EnrollmentModel> Grades { get; set; }
    }
}
