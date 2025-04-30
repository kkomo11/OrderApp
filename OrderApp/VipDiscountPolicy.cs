namespace OrderApp
{
    public class VipDiscountPolicy : IDiscountPolicy
    {
        public decimal ApplyPrice(decimal TotalPrice)
        {
            decimal CalcPrice = TotalPrice * (decimal) 0.9;
            return CalcPrice;
        }
    }
}
