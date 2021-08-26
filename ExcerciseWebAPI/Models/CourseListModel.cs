using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Models
{
    public class CourseListModel
    {
        public int CourseID { get; set; }
        public string Name { get; set; }
        public int? Credits { get; set; }
        public string Department{ get; set; }
    }
}
