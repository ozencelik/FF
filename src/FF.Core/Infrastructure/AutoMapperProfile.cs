using AutoMapper;
using FF.Data.Entities.Actions;
using FF.Data.Entities.Activities;
using FF.Data.Entities.Classes;
using FF.Data.Entities.SchoolBuses;
using FF.Data.Entities.Students;
using FF.Data.Entities.Teachers;
using FF.Data.Models.Actions;
using FF.Data.Models.Activities;
using FF.Data.Models.Students;
using FF.Data.Models.Teachers;
using FF.Data.Models.Classes;
using FF.Data.Models.SchoolBuses;

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

            #region Teacher
            CreateMap<TeacherModel, Teacher>();
            CreateMap<Teacher, TeacherModel>();

            CreateMap<CreateTeacherModel, Teacher>();
            CreateMap<Teacher, CreateTeacherModel>();

            CreateMap<UpdateTeacherModel, Teacher>();
            CreateMap<Teacher, UpdateTeacherModel>();
            #endregion

            #region SchoolBus
            CreateMap<SchoolBusModel, SchoolBus>();
            CreateMap<SchoolBus, SchoolBusModel>();

            CreateMap<CreateSchoolBusModel, SchoolBus>();
            CreateMap<SchoolBus, CreateSchoolBusModel>();

            CreateMap<UpdateSchoolBusModel, SchoolBus>();
            CreateMap<SchoolBus, UpdateSchoolBusModel>();
            #endregion

            #region Classroom
            CreateMap<ClassModel, Class>();
            CreateMap<Class, ClassModel>();

            CreateMap<CreateClassModel, Class>();
            CreateMap<Class, CreateClassModel>();

            CreateMap<UpdateClassModel, Class>();
            CreateMap<Class, UpdateClassModel>();
            #endregion

        }
    }
}
