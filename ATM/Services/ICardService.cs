
using ATM.Dto;
using ATM.Models;

namespace ATM.Services
{
    public interface ICardService
    {
        public Card GetCardByName(AtmDto dto);
        public Card GetCardByNameAndPin(AtmDto dto);
        void CheckNumberOfAttempts(AtmDto dto);
    }
}
