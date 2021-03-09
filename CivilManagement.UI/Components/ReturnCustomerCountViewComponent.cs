using CivilManagement.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CivilManagement.UI.Components
{
    public class ReturnCustomerCountViewComponent:ViewComponent
    {
        private readonly IReturnService _returnService;

        public ReturnCustomerCountViewComponent(IReturnService returnService)
        {
            _returnService = returnService;
        }
        public string Invoke()
        {
            var user = User as ClaimsPrincipal;

            if (user == null) return null;

            var storeCode = user.FindFirst(ClaimTypes.Role).Value;

            return _returnService.GetReturnCustomerCount(storeCode).ToString();
        }
    }
}
