using ATM.Models;
using ATM.Repository;
using Microsoft.EntityFrameworkCore;
using System;
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

        public List<Operation> GetAllOperationsByCard(string cardName)
        {
            var allOperations = _repoWrapper.Operation.FindAll().Include(u => u.Card);
            var listOfOperations = new List<Operation>();

            foreach (var item in allOperations)
            {
                if (item.Card.CardNumber == cardName)
                    listOfOperations.Add(item);
            }
            return listOfOperations;
        }

        public void AddNewOperationByCurrentBalance(CurrentBalance currentBalance)
        {
            _repoWrapper.Operation.Create(new Operation
            {
                CardId = currentBalance.CardId,
                AccountBalance = currentBalance.AccountBalance,
                Time = currentBalance.Time,
                NameOfOperation= currentBalance.Description
            });
        }

        public void AddNewOperationByOperation(Operation operation)
        {
            _repoWrapper.Operation.Create(new Operation
            {
                CardId = operation.CardId,
                AccountBalance = operation.AccountBalance,
                Time = operation.Time,
                WithdrawnAmount = operation.WithdrawnAmount,
                NameOfOperation = operation.NameOfOperation
            });
        }
    }
}
