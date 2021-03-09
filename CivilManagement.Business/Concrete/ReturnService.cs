using CivilManagement.Business.Abstract;
using CivilManagement.DataAccess.Abstract;
using CivilManagement.DataAccess.Concrete.EntityFramework.Context;
using CivilManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CivilManagement.Business.Concrete
{
    public class ReturnService : IReturnService
    {
        private readonly IReturnInvoiceControlDal _returnInvoiceControlDal;
        private readonly IReturnDal _returnDal;

        public ReturnService(IReturnInvoiceControlDal returnInvoiceControlDal, IReturnDal returnDal)
        {
            _returnInvoiceControlDal = returnInvoiceControlDal;
            _returnDal = returnDal;
        }

        public int GetReturnCustomerCount(string storeCode)
        {
            return _returnDal.GetReturnCustomerCount(storeCode);
        }

        public List<ReturnInvoiceInfo> GetReturnInvoiceInfo(string date, string officeCode, bool isReturn)
        {

            return _returnDal.Get(date, officeCode, isReturn);


            //using (var context = new CivilContext())
            //{
            //    var returnInvoiceInfos = (from header in context.trInvoiceHeader
            //                             join line in context.trInvoiceLine
            //                                on header.InvoiceHeaderID equals line.InvoiceHeaderID
            //                             join desc in context.cdItemDesc
            //                                 on line.ItemCode equals desc.ItemCode
            //                            //join isreturn in _returnInvoiceControlDal.GetReturnInvoiceGroup()
            //                            //    on line.SKU  equals isreturn.SKU 


            //                             where header.InvoiceDate == DateTime.Parse(date.ToShortDateString())
            //                                 && header.OfficeCode == officeCode
            //                                 && line.ItemTypeCode == 1
            //                                 && header.IsReturn == true
            //                                 && desc.LangCode == "TR"
            //                             select new ReturnInvoiceInfo
            //                             {
            //                                 SKU = line.SKU,
            //                                 Description = desc.ItemDescription,
            //                                 ColorCode = line.ColorCode,
            //                                 CreatedDate = header.CreatedDate,
            //                                 CreatedUserName = header.CreatedUserName,
            //                                 ItemDim1Code = line.ItemDim1Code,
            //                                 Qty1 = Math.Abs(line.Qty1)
            //                             }).ToList();

            //    //var test = (from invoice in returnInvoiceInfos
            //    //           join isreturn in _returnInvoiceControlDal.GetReturnInvoiceGroup(date,officeCode)
            //    //            on invoice.SKU  equals isreturn.SKU
            //    //            select new ReturnInvoiceInfo
            //    //           {
            //    //               SKU = invoice.SKU

            //    //           }).ToList();

            //    return returnInvoiceInfos.ToList();
            //}
        }
        /// <summary>
        /// Toplam iade miktarını getir 2.41 sunucundan alıyor
        /// </summary>
        /// <param name="storeCode">Mağaza kodu</param>
        /// <returns></returns>
        public int GetTotalReturn(string storeCode)
        {
            return _returnDal.GetTotalReturn(storeCode);
        }
    }
}