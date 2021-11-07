using ATM.Dto;
using ATM.Models;
using ATM.Repository;
using System.Linq;

namespace ATM.Services
{
    public class CardService:ICardService
    {
        private IRepositoryWrapper _repoWrapper;
        public CardService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public Card GetCardByName(string cardNumber)
        {
           return _repoWrapper.Card.FindByCondition(x => x.CardNumber == cardNumber).FirstOrDefault();
        }

        public Card GetCardByNameAndPin(AtmDto dto)
        {
            return _repoWrapper.Card.FindByCondition(x => x.CardNumber == dto.cardNumber && x.PinCode==dto.pin).FirstOrDefault();
        }

        public void CheckNumberOfAttempts(AtmDto dto)
        {
            var card = GetCardByName(dto.cardNumber);
            card.NumberOfWrongAttempts += 1;
            _repoWrapper.Card.Update(card);
        }
        public void BlockCard(Card card)
        {
            card.IsLocked = true;
            _repoWrapper.Card.Update(card);
        }

        public void UpdateCardByWithdrawnAmount(Card card, decimal withdrawnAmount)
        {
            card.Balance -= withdrawnAmount;
            _repoWrapper.Card.Update(card);
        }

        public void Update(Card card)
        {
            _repoWrapper.Card.Update(card);
        }
    }
}
