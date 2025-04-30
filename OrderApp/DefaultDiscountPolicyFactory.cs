namespace OrderApp
{
    public class DefaultDiscountPolicyFactory : IDiscountPolicyFactory
    {

        public IDiscountPolicy GetPolicy(string consumerType)
        {
            IDiscountPolicy discountPolicy = new NoDiscountPolicy();
            switch (consumerType)
            {
                case "VIP":
                    discountPolicy = new VipDiscountPolicy();
                    break;
                case "EMPLOYEE":
                    discountPolicy = new EmployeeDiscountPolicy();
                    break;
                case "SEASONAL":
                    discountPolicy = new SeasonalDiscountPolicy();
                    break;
                default:
                    discountPolicy = new NoDiscountPolicy();
                    break;
            }

            return discountPolicy;
        }
    }
}
