using CivilManagement.Business.Abstract;
using CivilManagement.DataAccess.Abstract;
using CivilManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CivilManagement.Business.Concrete
{
    public class ReturnInvoiceControlService : IReturnInvoiceControlService
    {
        private readonly IReturnInvoiceControlDal _returnInvoiceControlDal;
        public ReturnInvoiceControlService(IReturnInvoiceControlDal returnInvoiceControlDal)
        {
            _returnInvoiceControlDal = returnInvoiceControlDal;
        }
        public void AddRange(cvlReturnInvoiceControl[] entities)
        {
            _returnInvoiceControlDal.AddRange(entities);
        }
    }
}
