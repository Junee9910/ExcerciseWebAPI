using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Models
{
    public class StudentParams
    {
        public int? PageSize { get; set; } = 15;
        public int? PageNumber { get; set; } = 1;
        public string Name { get; set; }
    }
}
