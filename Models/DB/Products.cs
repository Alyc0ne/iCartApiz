using System;

namespace iCartApi.Models
{
    public class Products
    {
        public string productID { get; set; }
        public string productNo { get; set; }
        public string productCode { get; set; }
        public string productName { get; set; }
        public string productNameEng { get; set; }
        public bool isDelete { get; set; }
        public bool isInactive { get; set; }
        public string createdByID { get; set; }
        public DateTime createdDate { get; set; }
        public string modifiedByID { get; set; }
        public DateTime modifiedDate { get; set; }
    }
}
