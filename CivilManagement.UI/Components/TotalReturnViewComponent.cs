using CivilManagement.Business.Abstract;
using CivilManagement.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CivilManagement.UI.Components
{
    public class TotalReturnViewComponent:ViewComponent
    {
        private readonly IReturnService _returnService;

        public TotalReturnViewComponent(IReturnService returnService)
        {
            _returnService = returnService;
        }

        public string Invoke()
        {
            var user = User as ClaimsPrincipal;

            if (user == null) return null;
            
            var storeCode = user.FindFirst(ClaimTypes.Role).Value;

            return _returnService.GetTotalReturn(storeCode).ToString();
        }
    }
}
