﻿namespace OrderApp
{
    public class NoDiscountPolicy : IDiscountPolicy
    {
        public decimal ApplyDiscount(decimal TotalPrice)
        {
            return TotalPrice;
        }
    }
}
