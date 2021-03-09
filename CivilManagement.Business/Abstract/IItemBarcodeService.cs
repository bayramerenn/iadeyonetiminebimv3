using CivilManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CivilManagement.Business.Abstract
{
    public interface IItemBarcodeService
    {
        prItemBarcode GetItemBarcode(string barcode);
    }
}
