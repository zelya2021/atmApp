using ATM.Dto;
using ATM.Models;
using ATM.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ATM.Controllers
{
    public class HomeController : Controller
    {
        private ICardService _cardService;
        private IOperationService _operationService;
        public HomeController(ICardService cardService, IOperationService operationService)
        {
            _cardService = cardService;
            _operationService = operationService;
        }

        [HttpPost]
        public IActionResult GetCardNumber(AtmDto dto)
        {
            if (dto.cardNumber == null)
            {
                return Json(new { redirectToUrl = Url.Action("ErrorPage", "Home", new { errorMessage = "Card number is empty!" }) });
            }
            else
            {
                var card = _cardService.GetCardByName(dto.cardNumber);
                if (card == null)
                {
                    return Json(new { redirectToUrl = Url.Action("ErrorPage", "Home", new { errorMessage = "Card not found!" }) });
                }
                else
                {
                    return Json(new { redirectToUrl = Url.Action("PinCodeEnter", "Home") });
                }
            }
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
                return Json(new { redirectToUrl = Url.Action("ErrorPage", "Home", new { errorMessage = "PIN code cannot be empty!" }) });
            }
            else
            {
                var card = _cardService.GetCardByNameAndPin(dto);
                var cardInfo = _cardService.GetCardByName(dto.cardNumber);

                if (cardInfo.IsLocked)
                {
                    return Json(new { redirectToUrl = Url.Action("ErrorPage", "Home", new { errorMessage = "Your card is blocked!" }) });
                }
                if (cardInfo.NumberOfWrongAttempts > 3)
                {
                    _cardService.BlockCard(card);
                    return Json(new { redirectToUrl = Url.Action("ErrorPage", "Home", new { errorMessage = "Your card is blocked!" }) });
                }
                if (card == null)
                {
                    _cardService.CheckNumberOfAttempts(dto);
                    return Json(new { redirectToUrl = Url.Action("ErrorPage", "Home", new { errorMessage = "PIN code entered incorrectly!" }) });
                }
                else
                {
                    return Json(new { redirectToUrl = Url.Action("Operations", "Home", dto) });
                }
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Operations(AtmDto dto)
        {
            ViewBag.CardNumber = dto.cardNumber;
            return View(_operationService.GetAllOperationsByCard(dto.cardNumber));
        }

        [HttpPost]
        public IActionResult RedirectOperations(AtmDto dto)
        {
            ViewBag.CardNumber = dto.cardNumber;
            return Json(new { redirectToUrl = Url.Action("Operations", "Home", dto) });
        }

        public IActionResult Balance(string cardNumber)
        {
            ViewBag.CardNumber = cardNumber;
            var currentBalance = new CurrentBalance
            {
                CardId = _cardService.GetCardByName(cardNumber).Id,
                AccountBalance = _cardService.GetCardByName(cardNumber).Balance,
                Time = DateTime.Now,
                Description = "balance"
            };

            _operationService.AddNewOperationByCurrentBalance(currentBalance);

            return View(currentBalance);
        }

        [HttpPost]
        public IActionResult Withdrawal(AtmDto inputAmount)
        {
            ViewBag.CardNumber = inputAmount.cardNumber;

            var currentCard = _cardService.GetCardByName(inputAmount.cardNumber);

            if (currentCard.Balance < inputAmount.withdrawnAmount)
            {
                return Json(new { redirectToUrl = Url.Action("ErrorPage", "Home", new { errorMessage = "Insufficient funds on the card", flag=true }) });
            }
            _cardService.UpdateCard(currentCard, inputAmount.withdrawnAmount);

            var currentOperation = new Operation
            {
                CardId = _cardService.GetCardByName(inputAmount.cardNumber).Id,
                AccountBalance = currentCard.Balance,
                Time = DateTime.Now,
                NameOfOperation = "cash withdrawal",
                WithdrawnAmount = inputAmount.withdrawnAmount
            };

            _operationService.AddNewOperationByOperation(currentOperation);

            return Json(new { redirectToUrl = Url.Action("Operations", "Home", inputAmount) });
        }

        public IActionResult Withdrawal()
        {
            return View();
        }

        public IActionResult ErrorPage(string errorMessage, bool flag)
        {
            ViewBag.Message = errorMessage;
            ViewBag.Flag = flag;
            return View();
        }
    }
}
