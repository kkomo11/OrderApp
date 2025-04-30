namespace OrderApp
{
    public class VipDiscountPolicy : IDiscountPolicy
    {
        public decimal ApplyDiscount(decimal TotalPrice)
        {
            return TotalPrice * 0.9m;
        }
    }
}
