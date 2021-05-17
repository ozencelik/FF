namespace FF.Data.Models.Dashboard
{
    public class FashboardModel
    {
        #region Activity Part
        public string ActivitiesCount { get; set; }

        public string ActivitiesPageLink { get; set; }
        #endregion

        #region Class Part
        public string ClassesCount { get; set; }

        public string ClassesPageLink { get; set; }
        #endregion

        #region Teacher Part
        public string TeachersCount { get; set; }

        public string TeachersPageLink { get; set; }
        #endregion
        
        #region Student Part
        public string StudentsCount { get; set; }

        public string StudentsPageLink { get; set; }
        #endregion

        #region SchoolBus Part
        public string SchoolBusesCount { get; set; }

        public string SchoolBusesPageLink { get; set; }
        #endregion
    }
}
