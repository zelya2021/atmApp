using ATM.Models;
using ATM.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ATM.Services
{
    public class OperationService:IOperationService
    {
        private IRepositoryWrapper _repoWrapper;
        public OperationService(IRepositoryWrapper repoWrapper)
        {
            _repoWrapper = repoWrapper;
        }

        public IEnumerable<Operation> GetAllOperations()
        {
            return _repoWrapper.Operation.FindAll().Include(u => u.Card);
        }
    }
}
