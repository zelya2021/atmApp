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
        private IOperationService _operationService;
        public HomeController(INotyfService notyf, ICardService cardService, IOperationService operationService)
        {
            _notyf = notyf;
            _cardService = cardService;
            _operationService = operationService;
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
                var card = _cardService.GetCardByNameAndPin(dto);
                var cardInfo = _cardService.GetCardByName(dto);

                if (cardInfo.IsLocked)
                {

                }
                if (card == null)
                {
                    if (cardInfo.NumberOfWrongAttempts<=3)
                    {
                        _cardService.CheckNumberOfAttempts(dto);
                        //error
                    }
                    else
                    {
                        //error
                    }
                }
                else
                {
                    return Json(new { redirectToUrl = Url.Action("Operations", "Home") });
                }
            }
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Operations()
        {
            return View(_operationService.GetAllOperations());
        }
    }
}
