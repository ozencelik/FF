using FF.Data.Entities.Base;

namespace FF.Data.Entities.Teachers
{
    public class Teacher : BaseEntity
    {
        /// <summary>
        /// Teacher name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Customer unique user name.
        /// </summary>
        public string Username { get; set; }
    }
}
