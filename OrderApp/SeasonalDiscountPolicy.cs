namespace OrderApp
{
    public class SeasonalDiscountPolicy : IDiscountPolicy
    {
        public decimal ApplyDiscount(decimal TotalPrice)
        {
            return TotalPrice * 0.85m;
        }
    }
}
