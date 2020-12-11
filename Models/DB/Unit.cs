using System;

namespace iCartApi.Models
{
    public class Unit
    {
        public string UnitID { get; set; }
        public string UnitNo { get; set; }
        public string UnitName { get; set; }
        public string UnitNameEng { get; set; }
        public bool IsDelete { get; set; }
        public bool IsInactive { get; set; }
        public string CreatedByID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedByID { get; set; }
        public DateTime ModifiedDate { get; set; }


    }
}
