using ExcerciseWebAPI.Models;
using ExcerciseWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController:ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet("list")]
        public ActionResult<IEnumerable<CourseListModel>> GetList()
        {
            var courses = _courseService.GetList();
            return Ok(courses);
        }
    }
}
