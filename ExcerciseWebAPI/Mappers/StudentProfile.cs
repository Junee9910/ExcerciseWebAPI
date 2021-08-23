using AutoMapper;
using ExcerciseWebAPI.Models;
using ExcerciseWebAPI.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExcerciseWebAPI.Mappers
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentListModel>();
            CreateMap<StudentCreateModel, Student>();
            CreateMap<OfficeAssignment, OfficeAssignmentModel>();
            CreateMap<Instructor, InstructorListModel>()
                .ForMember(
                dest=>dest.FullName,
                otp=>otp.MapFrom(src=>$"{src.LastName} {src.FirstMidName}")
                );
        }
    }
}
