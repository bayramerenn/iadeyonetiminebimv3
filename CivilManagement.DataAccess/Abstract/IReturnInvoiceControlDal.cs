using CivilManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CivilManagement.DataAccess.Abstract
{
    public interface IReturnInvoiceControlDal
    {
        void AddRange(cvlReturnInvoiceControl[] entities);
        List<cvlReturnInvoiceControl> GetReturnInvoiceGroup(string date,string officeCode);

    }
}
