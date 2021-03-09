using CivilManagement.DataAccess.Abstract;
using CivilManagement.DataAccess.Concrete.EntityFramework.Context;
using CivilManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CivilManagement.DataAccess.Concrete.EntityFramework
{
    public class EfItemBarcode : IItemBarcodeDal
    {
        public prItemBarcode GetItemBarcode(string barcode)
        {
            using (var context = new CivilContext())
            {
                return context.prItemBarcode.Where(x => x.Barcode == barcode && x.ItemTypeCode == 1).FirstOrDefault();
            }
        }
    }
}
