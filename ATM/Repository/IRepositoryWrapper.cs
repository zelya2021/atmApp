using ATM.Repository.CardRep;
using ATM.Repository.OperationRep;

namespace ATM.Repository
{
    public interface IRepositoryWrapper
    {
        ICardRepository Card { get; }
        IOperationRepository Operation { get; }
        void Save();
    }
}
