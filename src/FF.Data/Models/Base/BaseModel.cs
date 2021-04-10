using System;

namespace FF.Data.Models.Base
{
    public class BaseModel
    {
        public int Id { get; set; }

        public bool Deleted { get; set; }

        public DateTime Created { get; protected set; } = DateTime.Now;

        public DateTime Updated { get; set; }
    }
}
