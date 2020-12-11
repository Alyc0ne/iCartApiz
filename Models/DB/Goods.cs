using System;

namespace iCartApi.Models
{
    public class Goods
    {
        public string GoodsID { get; set; }
        public string GoodsNo { get; set; }
        public string GoodsCode { get; set; }
        public string GoodsName { get; set; }
        public string GoodsNameEng { get; set; }
        public bool IsDelete { get; set; }
        public bool IsInactive { get; set; }
        public string CreatedByID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ModifiedByID { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
