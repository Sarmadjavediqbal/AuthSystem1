using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace AuthSystem.Controllers
{
    [Authorize]
    public class CourierController : Controller
    {
        public IActionResult DateTime()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Select()
        {
            return View();
        }

        public IActionResult Generate(string productId)
        {
            ViewBag.productId = productId;
            return View("Index");
        }
    }

}
