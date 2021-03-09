using System;
using System.ComponentModel.DataAnnotations;

namespace CivilManagement.UI.DTOs
{
    public class ReturnInvoiceInfoDto
    {
        public string SKU { get; set; }
        public string Description { get; set; }

        [Display(Name = "Renk")]
        public string ColorCode { get; set; }

        [Display(Name = "Beden")]
        public string ItemDim1Code { get; set; }

        public DateTime CreatedDate { get; set; }
        public string CreatedUserName { get; set; }

        [Display(Name = "Miktar")]
        public double Qty1 { get; set; }

        public double Qty2 { get; set; }





        public string DetailedDesc
        {
            get
            {
                return Description + " " + ColorCode + " " + ItemDim1Code;
            }
        }
    }
}