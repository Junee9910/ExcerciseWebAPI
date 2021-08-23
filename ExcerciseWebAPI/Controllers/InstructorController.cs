using AutoMapper;
using ExcerciseWebAPI.Models;
using ExcerciseWebAPI.Persistence.Entities;
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
    public class InstructorController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;
        public InstructorController(IMapper mapper, IInstructorService instructorService)
        {
            _mapper = mapper;
            _instructorService = instructorService;
        }
        [HttpGet("instructors")]
        public ActionResult<IEnumerable<InstructorListModel>> GetList()
        {
            //var instructors = _instructorService.GetList();
            //return Ok(_mapper.Map<IEnumerable<InstructorListModel>>(instructors));
            var instructors = _instructorService.GetList();
            return Ok(_mapper.Map<List<Instructor>, List<InstructorListModel>>((List<Instructor>)instructors));
        }
    }
}
