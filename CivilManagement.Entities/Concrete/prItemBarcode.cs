using CivilManagement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace CivilManagement.Entities.Concrete
{
    public class prItemBarcode:IEntity
    {
        public string Barcode { get; set; }
        public string ItemCode { get; set; }
        public string ColorCode { get; set; }
        public string ItemDim1Code { get; set; }
        public byte ItemTypeCode { get; set; }
        public string SKU {
            get 
            {
                return ItemCode+ColorCode+ItemDim1Code;
            } 
            }
    }
}
