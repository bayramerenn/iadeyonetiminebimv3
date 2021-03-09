using System;
using System.Collections.Generic;
using System.Text;

namespace CivilManagement.Entities.Concrete
{
    public class cvlReturnInvoiceControl
    {
        public int Id { get; set; }
        public string CreatedDate { get; set; }
        public string SKU { get; set; }
        public string ColorCode { get; set; }
        public string ItemDim1Code { get; set; }
        public string StoreCode { get; set; }
        public int ReturnQty { get; set; }
    }
}
