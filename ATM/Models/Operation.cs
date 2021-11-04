﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATM.Models
{
    public class Operation
    {
        public int Id { get; set; }
        public string NameOfOperation { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
