using FF.Data.Entities.Base;

namespace FF.Data.Entities
{
    public class Responsibles : BaseEntity
    {
        /// <summary>
        /// First name
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// Last name.
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// Birthday.
        /// </summary>
        public Datetime Birthday { get; set; }

    }
}
