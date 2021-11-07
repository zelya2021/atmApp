
using ATM.Dto;
using ATM.Models;

namespace ATM.Services
{
    public interface ICardService
    {
        public Card GetCardByName(string dto);
        public Card GetCardByNameAndPin(AtmDto dto);
        void CheckNumberOfAttempts(AtmDto dto);
        public void UpdateCardByWithdrawnAmount(Card card, decimal withdrawnAmount);
        public void BlockCard(Card card);
        public void Update(Card card);
    }
}
