using CivilManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CivilManagement.DataAccess.Abstract
{
    public interface IReturnDal
    {
        List<ReturnInvoiceInfo> Get(string invoiceDate, string store, bool isReturn);
        int GetTotalReturn(string storeCode);
        int GetReturnCustomerCount(string storeCode);
    }
}
