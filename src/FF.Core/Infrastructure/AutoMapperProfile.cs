using AutoMapper;
using FF.Data.Entities.Actions;
using FF.Data.Entities.Activities;
using FF.Data.Entities.Students;
using FF.Data.Models.Actions;
using FF.Data.Models.Activities;
using FF.Data.Models.Students;

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

            #region Action
            CreateMap<ActionModel, Action>();
            CreateMap<Action, ActionModel>();
            #endregion

            #region Student
            CreateMap<StudentModel, Student>();
            CreateMap<Student, StudentModel>();

            CreateMap<CreateStudentModel, Student>();
            CreateMap<Student, CreateStudentModel>();

            CreateMap<UpdateStudentModel, Student>();
            CreateMap<Student, UpdateStudentModel>();
            #endregion
        }
    }
}
