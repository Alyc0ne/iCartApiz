using System;

namespace iCartApi.Models
{
    public class view_ProductsUnit
    {
        public string productUnitID { get; set; }
        public string companyID { get; set; }
        public string productID { get; set; }
        public string productCode { get; set; }
        public string barcode { get; set; }
        public string productNo { get; set; }
        public string productName { get; set; }
        public string productNameEng { get; set; }
        public string unitID { get; set; }
        public string unitNo { get; set; }
        public string unitName { get; set; }
        public string unitNameEng { get; set; }
        public bool isBaseUnit { get; set; }
        public decimal productCost { get; set; }
        public decimal productSalePrice { get; set; }
        public decimal productPurchasePrice { get; set; }
        public string createdByID { get; set; }
        public DateTime createdDate { get; set; }
        public bool isDelete { get; set; }
        public bool isInactive { get; set; }

    }
}
