using AutoMapper;
using CivilManagement.Entities.Concrete;
using CivilManagement.UI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CivilManagement.UI.Mapping
{
    public class ReturnInvoiceProfile:Profile
    {
        public ReturnInvoiceProfile()
        {
            CreateMap<ReturnInvoiceInfo, ReturnInvoiceInfoDto>().ReverseMap();
            CreateMap<prItemBarcode, ProductSkuDto>().ReverseMap();
        }
    }
}
