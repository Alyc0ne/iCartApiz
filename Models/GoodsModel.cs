using System.Collections.Generic;

namespace iCartApi.Models
{
    public class GoodsModel
    {
        public string goodsID { get; set; }
        public string goodsNo { get; set; }
        public string goodsCode { get; set; }
        public string goodsName { get; set; }
        public string goodsNameEng { get; set; }
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
