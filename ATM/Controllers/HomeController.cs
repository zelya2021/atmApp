using AspNetCoreHero.ToastNotification.Abstractions;
using ATM.Dto;
using ATM.Services;
using Microsoft.AspNetCore.Mvc;

namespace ATM.Controllers
{
    public class HomeController : Controller
    {
        private readonly INotyfService _notyf;
        private ICardService _cardService;
        public HomeController(INotyfService notyf, ICardService cardService)
        {
            _notyf = notyf;
            _cardService = cardService;
        }

        [HttpPost]
        public IActionResult GetCardNumber(AtmDto dto)
        {
            if (dto.cardNumber == null)
            {
                _notyf.Error("Card number is empty");
            }
            else
            {
                var card = _cardService.GetCardByName(dto);
                if (card == null)
                {
                    _notyf.Error("Card not found");
                }
                else
                {
                    return Json(new { redirectToUrl = Url.Action("PinCodeEnter", "Home") });
                }
            }
             return View();
        }

        public IActionResult PinCodeEnter()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PinCodeEnter(AtmDto dto)
        {
            if (dto.pin == null)
            {
                _notyf.Error("Pin is empty");
            }
            else
            {
                var card = _cardService.GetCardByName(dto);
                if (card == null)
                {
                    _notyf.Error("Card not found");
                }
                else
                {
                    return Json(new { redirectToUrl = Url.Action("PinCodeEnter", "Home") });
                }
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
