using CivilManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CivilManagement.Business.Abstract
{
    public interface IReturnInvoiceControlService
    {
        void AddRange(cvlReturnInvoiceControl[] entities);
    }
}
