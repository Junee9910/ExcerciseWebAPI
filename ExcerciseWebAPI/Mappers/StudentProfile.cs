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
            CreateMap<Student, StudentListModel>()
                .ForMember(
                dest => dest.FullName,
                otp => otp.MapFrom(src => $"{src.LastName} {src.FirstMidName}"));
            CreateMap<Student, StudentModel>()
                .ForMember(
                dest=>dest.Courses,
                otp=>otp.MapFrom(src=>src.Enrollments.Select(x=>new EnrollmentCourseById()
                {
                    CourseName=x.Course.Title,
                    Grade=x.Grade
                }))).ReverseMap();
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
                )
                .ForMember(
                dest => dest.LocationIn,
                otp => otp.MapFrom(s => s.OfficeAssignment.LocationIn))
                .ForMember(
                dest => dest.Courses,
                otp => otp.MapFrom(src => src.CourseAssignments.Select(x => new CourseByInstructor()
                {
                    CourseID = x.CourseID,
                    Name = x.Course.Title,
                    Department = x.Course.Department.DepartmentName
                }))).ReverseMap();
            CreateMap<Course, CourseListModel>()
                .ForMember(
                dest => dest.Name,
                otp => otp.MapFrom(src =>src.Title)
                )
                .ForMember(
                dest=>dest.Department,
                otp=>otp.MapFrom(s=>s.Department.DepartmentName)).ReverseMap();
            CreateMap<Course, CourseModel>()
                .ForMember(
                dest => dest.Name,
                otp => otp.MapFrom(src => src.Title)
                )
                .ForMember(
                dest => dest.Department,
                otp => otp.MapFrom(s => s.Department.DepartmentName))
                .ForMember(
                dest=>dest.Students,
                otp=>otp.MapFrom(src=>src.Enrollments.Select(x=> new StudentByCourseId()
                {
                    FullName=x.Student.Fullname,
                    Grade=x.Grade
                }))).ReverseMap();
        }
    }
}
