
using ATM.Database;
using ATM.Models;

namespace ATM.Repository.OperationRep
{
    public class OperationRepository : RepositoryBase<Operation>, IOperationRepository
    {
        public OperationRepository(DatabaseContext repositoryContext)
           : base(repositoryContext)
        {
        }
    }
}
