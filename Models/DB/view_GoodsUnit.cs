using System;

namespace iCartApi.Models
{
    public class view_GoodsUnit
    {
        public string GoodsUnitID { get; set; }
        public string CompanyID { get; set; }
        public string GoodsID { get; set; }
        public string GoodsCode { get; set; }
        public string Barcode { get; set; }
        public string GoodsNo { get; set; }
        public string GoodsName { get; set; }
        public string GoodsNameEng { get; set; }
        public string UnitID { get; set; }
        public string UnitNo { get; set; }
        public string UnitName { get; set; }
        public string UnitNameEng { get; set; }
        public bool IsBaseUnit { get; set; }
        public decimal GoodsCost { get; set; }
        public decimal GoodsSalePrice { get; set; }
        public decimal GoodsPurchasePrice { get; set; }
        public string CreatedByID { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsDelete { get; set; }
        public bool IsInactive { get; set; }

    }
}
