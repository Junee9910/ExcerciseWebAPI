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
            CreateMap<StudentEditModel, Student>()
                .ForMember(x => x.StudentID, opt => opt.Ignore());

            CreateMap<InstructorCreateModel, Instructor>()
                .ForMember(x => x.HireDate, opt => opt.MapFrom(x => DateTime.Now))
                .ForMember(x => x.OfficeAssignment, opt => opt.MapFrom(x => string.IsNullOrWhiteSpace(x.Office)
                    ? null
                    : new OfficeAssignment
                    {
                        LocationIn = x.Office
                    }));

            CreateMap<InstructorEditModel, Instructor>()
                .AfterMap((model, entity) =>
                {
                    if (string.IsNullOrWhiteSpace(model.Office))
                    {
                        entity.OfficeAssignment = null;
                    }
                    else
                    {
                        entity.OfficeAssignment ??= new OfficeAssignment();
                        entity.OfficeAssignment.LocationIn = model.Office;
                    }
                });

            CreateMap<Instructor, InstructorListModel>()
                .ForMember(
                dest => dest.FullName,
                otp => otp.MapFrom(src => $"{src.LastName} {src.FirstMidName}")
                );
        }
    }
}
