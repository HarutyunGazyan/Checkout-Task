﻿using Checkout.Models;

namespace Checkout.DTOs.Requests
{
    public class CheckoutApiRequest
    {
        public int OfferId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ZipCode { get; set; }
        public string Telephone { get; set; }
        public Country Country { get; set; }
    }
}
