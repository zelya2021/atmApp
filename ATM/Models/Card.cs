using System.Collections.Generic;

namespace ATM.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public bool IsLocked { get; set; }
        public int NumberOfWrongAttempts { get; set; }
        public string PinCode { get; set; }
        public decimal Balance { get; set; }
        public List<Operation> Operations { get; set; }
    }
}
