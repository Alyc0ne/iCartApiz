using System;

namespace iCartApi.Models
{
    public class Unit
    {
        public string unitID { get; set; }
        public string unitNo { get; set; }
        public string unitName { get; set; }
        public string unitNameEng { get; set; }
        public bool isDelete { get; set; }
        public bool isInactive { get; set; }
        public string createdByID { get; set; }
        public DateTime createdDate { get; set; }
        public string modifiedByID { get; set; }
        public DateTime modifiedDate { get; set; }


    }
}
