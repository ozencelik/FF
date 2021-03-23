using AutoMapper;
using FF.Data.Entities.Activities;
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
            CreateMap<ActivityModel, Activity>();
            CreateMap<Activity, ActivityModel>();

            CreateMap<ActivityOptionModel, ActivityOption>();
            CreateMap<ActivityOption, ActivityOptionModel>();

            CreateMap<StudentActivityModel, StudentActivity>();
            CreateMap<StudentActivity, StudentActivityModel>();
            #endregion

            #region Student
            CreateMap<StudentModel, Student>();
            CreateMap<Student, StudentModel>();            
            #endregion
        }
    }
}
