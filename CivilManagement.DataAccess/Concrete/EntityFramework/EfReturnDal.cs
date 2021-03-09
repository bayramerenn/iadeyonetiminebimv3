using CivilManagement.DataAccess.Abstract;
using CivilManagement.DataAccess.Concrete.EntityFramework.Context;
using CivilManagement.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CivilManagement.DataAccess.Concrete.EntityFramework
{
    public class EfReturnDal : IReturnDal
    {
        public List<ReturnInvoiceInfo> Get(string invoiceDate, string store, bool isReturn)
        {
            using (var context = new CivilContext())
            {
                var model = context.Set<ReturnInvoiceInfo>().FromSqlRaw($"EXEC cvl_ReturnInvoice @date='{invoiceDate}',@officeCode='{store}',@isreturn='{isReturn}'").ToList();

                return model;
            }
        }

        public int GetReturnCustomerCount(string storeCode)
        {
            var date = DateTime.Now.ToString("yyyy/MM/dd");
            using (var context = new CivilReportingContext())
            {
                return context.trInvoiceHeader

                        .Where(x => x.InvoiceDate == DateTime.Parse(date)
                                && x.OfficeCode == storeCode
                                && x.IsReturn == true)
                                    .Select(x => x.CurrAccCode)
                                    .Distinct()
                                    .Count();
            }
        }

        public int GetTotalReturn(string storeCode)
        {
            var date = DateTime.Now.ToString("yyyy/MM/dd");

            using (var context = new CivilReportingContext())
            {
                return (int) context.trInvoiceHeader
                            .Join(context.trInvoiceLine,
                                    header => header.InvoiceHeaderID,
                                    line => line.InvoiceHeaderID,
                                    (header, line) => new
                                    {
                                        Qty = Math.Abs(line.Qty1),
                                        header.OfficeCode,
                                        header.InvoiceDate,
                                        header.IsReturn,
                                        header.ProcessCode
                                    }).Where(x => x.InvoiceDate == DateTime.Parse(date)
                                          && x.OfficeCode == storeCode
                                            && x.IsReturn == true
                                            && x.ProcessCode == "R")
                                        .Select(x => x.Qty)
                                         .Sum();
                //.Where(x => x.InvoiceDate == DateTime.Parse(date)
                //        && x.OfficeCode == storeCode
                //        && x.IsReturn == true)
                //            .Select(x => x.IsReturn)
                //            .Count();
            }
        }
    }
}