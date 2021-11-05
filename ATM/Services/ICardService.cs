
using ATM.Dto;
using ATM.Models;

namespace ATM.Services
{
    public interface ICardService
    {
        public Card GetCardByName(AtmDto dto);
    }
}
