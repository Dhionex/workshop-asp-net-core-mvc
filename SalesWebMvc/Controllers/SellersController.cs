using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Services;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {

        private readonly SellerService _salerService;

        public SellersController(SellerService sellerService)
        {
              _salerService = sellerService;   
        }
        public IActionResult Index()
        {
            var list = _salerService.FindAll();

            return View(list);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _salerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
    }
}