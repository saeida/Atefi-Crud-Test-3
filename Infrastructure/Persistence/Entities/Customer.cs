﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Infrastructure.Persistence.Entities
{
    public partial class Customer
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public long? PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
