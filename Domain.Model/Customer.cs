﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Domain.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}