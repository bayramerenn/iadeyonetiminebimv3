using AutoMapper;
using CivilManagement.Business.Abstract;
using CivilManagement.Entities.Concrete;
using CivilManagement.UI.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Claims;
using System.Text.Json;

namespace CivilManagement.UI.Controllers
{
    [Authorize]
    public class ReturnController : Controller
    {
        private IReturnService _returnService;
        private readonly IMapper _mapper;
        private readonly IItemBarcodeService _itemBarcodeService;
        private readonly IReturnInvoiceControlService _returnInvoiceControlService;

        public ReturnController(IReturnService returnService, IMapper mapper, IItemBarcodeService itemBarcodeService, IReturnInvoiceControlService returnInvoiceControlService)
        {
            _returnService = returnService;
            _mapper = mapper;
            _itemBarcodeService = itemBarcodeService;
            _returnInvoiceControlService = returnInvoiceControlService;
        }

        public IActionResult Index()
        {
            ViewBag.UserName = User.Identity.Name;

            return View(new List<ReturnInvoiceInfoDto>());
        }

        [HttpPost]
        public IActionResult Index([Required] DateTime date)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Lütfen bir tarih giriniz");
                return View(new List<ReturnInvoiceInfoDto>());
            }

            var invoiceDate = date.ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);

            

            var store = User.FindFirst(ClaimTypes.Role).Value;

            ViewBag.InvoiceDate = invoiceDate.Replace("/", "-");

            ViewBag.Store = store;

            var result = _returnService.GetReturnInvoiceInfo(invoiceDate, store, true);

            if (result.Count == 0)
            {
                ModelState.AddModelError(string.Empty, "İadeniz bulunmamaktadır.");
                return View(new List<ReturnInvoiceInfoDto>());
            }

            ViewBag.Date = date;

            return View(_mapper.Map<List<ReturnInvoiceInfoDto>>(result));
        }

        public IActionResult ReturnList()
        {
            var date = DateTime.Now.ToString("yyyy/MM/dd");//DateTime.Now.ToString("yyyy/MM/dd");

           
            var store = User.FindFirst(ClaimTypes.Role).Value;

            var result = _returnService.GetReturnInvoiceInfo(date, store, false);

            return View(_mapper.Map<List<ReturnInvoiceInfoDto>>(result));
        }

        public IActionResult GetBarcode([FromBody] object item)
        {
            if (item != null)
            {
                var itemBarcode = JsonSerializer.Deserialize<ItemBarcodeDto>(item.ToString());

                var product = _itemBarcodeService.GetItemBarcode(itemBarcode.Barcode);

                if (product == null)
                {
                    return StatusCode(500);
                }
                var test = _mapper.Map<ProductSkuDto>(product);
                return Json(test);
            }

            return BadRequest();
        }

        public IActionResult AddProduct([FromBody] object entity)
        {
            var result = JsonSerializer.Deserialize<cvlReturnInvoiceControl[]>(entity.ToString());

            if (result.Length > 0)
            {
                _returnInvoiceControlService.AddRange(result);
                return Ok();
            }
            return BadRequest();
        }
    }
}