﻿namespace Shared.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public CustomerDto CustomerDetail { get; set; }

       
    }
}