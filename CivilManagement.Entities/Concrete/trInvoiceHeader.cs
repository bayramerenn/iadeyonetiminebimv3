using CivilManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CivilManagement.Entities.Concrete
{
    public class trInvoiceHeader:IEntity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid InvoiceHeaderID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string OfficeCode { get; set; }
        public string ProcessCode { get; set; }
        public string CurrAccCode { get; set; }
        public bool IsReturn { get; set; }
        public string CreatedUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual List<trInvoiceLine> trInvoiceLine { get; set; }
    }
}
