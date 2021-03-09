using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CivilManagement.Entities.Concrete
{
    public class cdItemDesc
    {
        public byte ItemTypeCode { get; set; }
        public string ItemCode { get; set; }
        public string LangCode { get; set; }
        public string ItemDescription { get; set; }

      
    }
}
