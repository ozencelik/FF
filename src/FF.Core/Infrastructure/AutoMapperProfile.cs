using AutoMapper;
using FF.Data.Entities.StudentActivities;
using FF.Data.Models.Activity;

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
        }
    }
}
