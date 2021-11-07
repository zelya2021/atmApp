using System;

namespace ATM.Models
{
    public class CurrentBalance
    {
        public int CardId { get; set; }
        public decimal AccountBalance { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
    }
}
