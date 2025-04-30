namespace OrderApp
{
    public class EmployeeDiscountPolicy : IDiscountPolicy
    {
        public decimal ApplyDiscount(decimal TotalPrice)
        {
            return TotalPrice * 0.8m;
        }
    }
}
