using ATM.Repository.CardRep;

namespace ATM.Repository
{
    public interface IRepositoryWrapper
    {
        ICardRepository Card { get; }
        void Save();
    }
}
