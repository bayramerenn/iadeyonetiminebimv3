using CivilManagement.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CivilManagement.UI.Components
{
    public class CompletedReturnViewComponent:ViewComponent
    {
        private readonly IReturnService _returnService;

        public CompletedReturnViewComponent(IReturnService returnService)
        {
            _returnService = returnService;
        }

        public string Invoke()
        {

            var user = User as ClaimsPrincipal;
            if (user == null) return null;

            var store = user.FindFirst(ClaimTypes.Role).Value;

            var result = _returnService.GetReturnInvoiceInfo(DateTime.Now.ToString("yyyy/MM/dd"), store, false).Select(x => x.ReturnQty).Sum().ToString();

            return result;
        }
    }
}
