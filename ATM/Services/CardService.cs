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

        public Card GetCardByName(AtmDto dto)
        {
           return _repoWrapper.Card.FindByCondition(x => x.CardNumber == dto.cardNumber).FirstOrDefault();
        }

        public Card GetCardByNameAndPin(AtmDto dto)
        {
            return _repoWrapper.Card.FindByCondition(x => x.CardNumber == dto.cardNumber && x.PinCode==dto.pin).FirstOrDefault();
        }

        public void CheckNumberOfAttempts(AtmDto dto)
        {
            var card = GetCardByName(dto);
            card.NumberOfWrongAttempts += 1;
            _repoWrapper.Card.Update(card);
        }
    }
}
