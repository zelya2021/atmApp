using ATM.Models;
using System.Collections.Generic;

namespace ATM.Services
{
    public interface IOperationService
    {
        public IEnumerable<Operation> GetAllOperations();
        public List<Operation> GetAllOperationsByCard(string cardName);
        public void AddNewOperationByCurrentBalance(CurrentBalance currentBalance);
        public void AddNewOperationByOperation(Operation operation);
    }
}
