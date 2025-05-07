using System.Collections.Generic;

namespace OrderApp
{
    public class DefaultDiscountPolicyFactory : IDiscountPolicyFactory
    {
        private static readonly Dictionary<string, IDiscountPolicy> policies = new Dictionary<string, IDiscountPolicy>()
        {
            {"VIP", new VipDiscountPolicy()},
            {"EMPLOYEE", new EmployeeDiscountPolicy()},
            {"SEASONAL", new SeasonalDiscountPolicy()}
        };

        public IDiscountPolicy GetPolicy(string consumerType)
        {
            return policies.ContainsKey(consumerType) ? policies[consumerType] : new NoDiscountPolicy();
        }
    }
}
