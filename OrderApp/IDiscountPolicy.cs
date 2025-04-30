namespace OrderApp
{
    interface IDiscountPolicy
    {
        decimal ApplyPrice(decimal TotalPrice);
    }
}
