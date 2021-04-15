using FF.Data.Models.Base;

namespace FF.Data.Models.SchoolBuses
{
    public class CreateSchoolBusModel : PersonModel
    {
        public int SchoolId { get; set; }

        public string LicensePlate { get; set; }

        public string PhoneNumber { get; set; }

        public string CompanyName { get; set; }
    }
}
