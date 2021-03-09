using CivilManagement.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CivilManagement.DataAccess.Abstract
{
    public interface IItemBarcodeDal
    {
        prItemBarcode GetItemBarcode(string barcode);
    }
}
