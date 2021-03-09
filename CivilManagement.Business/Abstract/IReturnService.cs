using CivilManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CivilManagement.Business.Abstract
{
    public interface IReturnService
    {
        List<ReturnInvoiceInfo> GetReturnInvoiceInfo(string date, string officeCode, bool isReturn);
        int GetTotalReturn(string storeCode);
        int GetReturnCustomerCount(string storeCode);

    }
}
