using ATM.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ATM.Database
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var operation = new Operation { Id = 1, NameOfOperation = "cash withdrawal", CardId = 1, AccountBalance=2220, Time= DateTime.Now, WithdrawnAmount=1000};
            var operation2 = new Operation { Id = 2, NameOfOperation = "balance", CardId = 1, AccountBalance = 2220, Time = DateTime.Now };
            var operation3 = new Operation { Id = 3, NameOfOperation = "cash withdrawal", CardId = 1, AccountBalance = 1220, Time = DateTime.Now, WithdrawnAmount = 1000 };

            modelBuilder.Entity<Operation>().HasData(operation);
            modelBuilder.Entity<Operation>().HasData(operation2);
            modelBuilder.Entity<Operation>().HasData(operation3);
            modelBuilder.Entity<Card>().HasData(
                 new Card { Id = 1, CardNumber = "1111-8888-7777-9999", IsLocked = false, PinCode = "1111", NumberOfWrongAttempts = 0, Balance=5000 },
                 new Card { Id = 2, CardNumber = "1111-2222-3333-4444", IsLocked = false, PinCode = "1234", NumberOfWrongAttempts = 0, Balance = 2000 }
            );
        }
    }
}
