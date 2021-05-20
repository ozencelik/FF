namespace FF.Data.Models.Schools
{
    public class DashboardModel
    {
        #region Activity Part
        public int ActivitiesCount { get; set; }

        public string ActivitiesPageLink { get; set; }
        #endregion

        #region Class Part
        public int ClassesCount { get; set; }

        public string ClassesPageLink { get; set; }
        #endregion

        #region Teacher Part
        public int TeachersCount { get; set; }

        public string TeachersPageLink { get; set; }
        #endregion
        
        #region Student Part
        public int StudentsCount { get; set; }

        public string StudentsPageLink { get; set; }
        #endregion

        #region SchoolBus Part
        public int SchoolBusesCount { get; set; }

        public string SchoolBusesPageLink { get; set; }
        #endregion
    }
}
