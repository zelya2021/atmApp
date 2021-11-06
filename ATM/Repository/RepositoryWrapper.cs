using ATM.Database;
using ATM.Repository.CardRep;
using ATM.Repository.OperationRep;

namespace ATM.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private DatabaseContext _dbContext;
        private ICardRepository _card;
        private IOperationRepository _operation;
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

        public IOperationRepository Operation
        {
            get
            {
                if (_operation == null)
                {
                    _operation = new OperationRepository(_dbContext);
                }
                return _operation;
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
