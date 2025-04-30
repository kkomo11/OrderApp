namespace OrderApp
{
    public interface IDiscountPolicyFactory
    {
        IDiscountPolicy GetPolicy(string consumerType);
    }
}
