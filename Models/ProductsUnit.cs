using System;

namespace iCartApi.Models
{
    public class ProductsUnit
    {
        public string productUnitID { get; set; }
        public string unitID { get; set; }
        public string productID { get; set; }
        public string barcode { get; set; }
        public bool isBaseUnit { get; set; }
        public bool isDelete { get; set; }
        public bool isInactive { get; set; }
        public string createdByID { get; set; }
        public DateTime createdDate { get; set; }
        public string modifiedByID { get; set; }
        public DateTime modifiedDate { get; set; }
    }
}
