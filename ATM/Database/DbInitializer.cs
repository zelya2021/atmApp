using ATM.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ATM.Database
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var operation = new Operation { Id = 1, NameOfOperation = "cash withdrawal", CardId = 1};

            modelBuilder.Entity<Operation>().HasData(operation);
            modelBuilder.Entity<Card>().HasData(
                 new Card { Id = 1, CardNumber = "1111-8888-7777-9999", IsLocked = false, PinCode = "1111", NumberOfWrongAttempts = 0, Balance=2000 }
            );
        }
    }
}
