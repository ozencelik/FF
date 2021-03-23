using AutoMapper;
using FF.Data.Entities.StudentActivities;
using FF.Data.Entities.Students;
using FF.Data.Models.Activity;
using FF.Data.Models.StudentModels;

namespace FF.Core.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            #region Activity
            CreateMap<CreateMealActivityModel, Meal>();
            //CreateMap<Meal, CreateMealActivityModel>();
            #endregion
            #region Student
            CreateMap<StudentModel, Student>();
            CreateMap<Student, StudentModel>();
            
            #endregion
        }
    }
}
