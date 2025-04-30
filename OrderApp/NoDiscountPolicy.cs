namespace OrderApp
{
    public class NoDiscountPolicy : IDiscountPolicy
    {
        public decimal ApplyPrice(decimal TotalPrice)
        {
            return TotalPrice;
        }
    }
}
