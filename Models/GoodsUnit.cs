using System;

namespace iCartApi.Models
{
    public class GoodsUnit
    {
        public string GoodsUnitID { get; set; }
        public string UnitID { get; set; }
        public string GoodsID { get; set; }
        public string Barcode { get; set; }
        public bool IsBaseUnit { get; set; }
        public bool IsDelete { get; set; }
        public bool IsInactive { get; set; }
        public string CreatedByID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedByID { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
