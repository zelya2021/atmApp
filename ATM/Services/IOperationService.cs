using ATM.Models;
using System.Collections.Generic;

namespace ATM.Services
{
    public interface IOperationService
    {
        public IEnumerable<Operation> GetAllOperations();
    }
}
