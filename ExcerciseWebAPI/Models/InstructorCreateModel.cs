using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Models
{
    public class InstructorCreateModel
    {
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstMidName { get; set; }
        public string Office { get; set; }
    }
    public class InstructorEditModel
    {
        public int InstructorID { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string FirstMidName { get; set; }
        public DateTime? HireDate { get; set; }
        public string Office { get; set; }
    }
}
