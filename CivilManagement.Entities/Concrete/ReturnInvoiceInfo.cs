using System;

namespace CivilManagement.Entities.Concrete
{
    public class ReturnInvoiceInfo
    {
        public string SKU { get; set; }
        public string Description { get; set; }
        public string CreatedUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ColorCode { get; set; }
        public string ItemDim1Code { get; set; }
        public double Qty1 { get; set; }
        public int ReturnQty { get; set; }
    }

}