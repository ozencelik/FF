using System;

namespace FF.Data.Models.Base
{
    public class BaseModel
    {
        public int Id { get; set; }

        public bool Deleted { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
