using System.Collections.Generic;

namespace iCartApi.Models
{
    public class ProductsModel
    {
        public string productID { get; set; }
        public string productNo { get; set; }
        public string productCode { get; set; }
        public string productName { get; set; }
        public string productNameEng { get; set; }
        public List<UnitModel> listUnit { get; set; }
    }

    public class UnitModel
    {
        public string uid { get;set; }
        public string barcode { get; set; }
        public string unitNo { get; set; }
        public string unitName { get; set; }
        public bool isBaseUnit { get; set; }
    }
}
