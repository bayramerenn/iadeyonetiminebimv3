using System;

namespace CivilManagement.UI.DTOs
{
    public class SaveProductsDto
    {
        public string SKU { get; set; }
        public string Description { get; set; }

        public string ColorCode { get; set; }

        public string ItemDim1Code { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedUserName { get; set; }

        public double Qty1 { get; set; }

        public double Qty2 { get; set; }
    }
}