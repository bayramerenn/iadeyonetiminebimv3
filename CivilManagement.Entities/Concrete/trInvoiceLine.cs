using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CivilManagement.Entities.Concrete
{
    public class trInvoiceLine
    {
        [Key]
        public Guid InvoiceLineID { get; set; }

        public Guid InvoiceHeaderID { get; set; }
        public string ItemCode { get; set; }
        public string ColorCode { get; set; }
        public string ItemDim1Code { get; set; }
        public byte ItemTypeCode { get; set; }
        public double Qty1 { get; set; }

        public string SKU
        {
            get
            {
                return ItemCode + ColorCode + ItemDim1Code;
            }
        }

        [ForeignKey("InvoiceHeaderID")]
        public virtual trInvoiceHeader trInvoiceHeader { get; set; }
        //public virtual cdItemDesc cdItemDesc { get; set; }
    }
}