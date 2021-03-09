using CivilManagement.Business.Abstract;
using CivilManagement.DataAccess.Abstract;
using CivilManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CivilManagement.Business.Concrete
{
    public class ItemBarcodeService : IItemBarcodeService
    {
        private readonly IItemBarcodeDal _itemBarcodeDal;
        public ItemBarcodeService(IItemBarcodeDal itemBarcodeDal)
        {
            _itemBarcodeDal = itemBarcodeDal;
        }
        public prItemBarcode GetItemBarcode(string barcode)
        {

            var product = _itemBarcodeDal.GetItemBarcode(barcode);

            return product;

        }
    }
}
