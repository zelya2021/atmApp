using AspNetCoreHero.ToastNotification.Abstractions;
using ATM.Dto;
using ATM.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ATM.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotyfService _notyf;
        public HomeController(INotyfService notyf)
        {
            _notyf = notyf;
        }

        [HttpPost]
        public void GetCardNumber(AtmDto dto)
        {
            if (dto.cardNumber == null)
            {
                _notyf.Error("Card number is empty");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
