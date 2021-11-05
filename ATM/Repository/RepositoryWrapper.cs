using ATM.Database;
using ATM.Repository.CardRep;

namespace ATM.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _dbContext;
        private ICardRepository _card;
        public ICardRepository Card
        {
            get
            {
                if (_card == null)
                {
                    _card = new CardRepository(_dbContext);
                }
                return _card;
            }
        }
        public RepositoryWrapper(DatabaseContext abContext)
        {
            _dbContext = abContext;
        }
        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
