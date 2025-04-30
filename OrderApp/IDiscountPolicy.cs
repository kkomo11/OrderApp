namespace OrderApp
{
    public interface IDiscountPolicy
    {
        decimal ApplyDiscount(decimal TotalPrice);
    }
}
