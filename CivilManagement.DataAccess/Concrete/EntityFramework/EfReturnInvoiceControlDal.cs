using CivilManagement.DataAccess.Abstract;
using CivilManagement.DataAccess.Concrete.EntityFramework.Context;
using CivilManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Schema;

namespace CivilManagement.DataAccess.Concrete.EntityFramework
{
    public class EfReturnInvoiceControlDal : IReturnInvoiceControlDal
    {
        public void AddRange(cvlReturnInvoiceControl[] entities)
        {
            using (var context = new CivilContext())
            {
                context.cvlReturnInvoiceControl.AddRange(entities);
                context.SaveChanges();
            }
        }

        public List<cvlReturnInvoiceControl> GetReturnInvoiceGroup(string date, string officeCode)
        {
            using (var context = new CivilContext())
            {
                var result = context.cvlReturnInvoiceControl.Where(x => x.CreatedDate == date && x.StoreCode == officeCode)
                    .GroupBy(x => new { x.SKU, x.StoreCode, x.CreatedDate })
                    .Select(x => new cvlReturnInvoiceControl
                    {
                        SKU = x.Key.SKU,
                        StoreCode = x.Key.StoreCode,
                        CreatedDate = x.Key.CreatedDate,
                        ReturnQty = x.Sum(r => r.ReturnQty)
                    }).ToList();

                return result;
            }
        }
    }
    
}
