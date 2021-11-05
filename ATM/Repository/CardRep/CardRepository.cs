using ATM.Database;
using ATM.Models;

namespace ATM.Repository.CardRep
{
    public class CardRepository : RepositoryBase<Card>, ICardRepository
    {
        public CardRepository(DatabaseContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
