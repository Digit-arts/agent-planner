using System.Collections.Generic;
using System.Linq;
using AgentPlanner.Entities.Client;

namespace AgentPlanner.Entities.Mappers
{
    public static class PaymentMethodMapper
    {
        public static PaymentMethod ToDto(this DataAccess.PaymentMethod paymentMethod)
        {
            if (paymentMethod == null) return null;

            return new PaymentMethod
            {
                Id = paymentMethod.Id,
                MethodName = paymentMethod.MethodName
            };
        }

        public static PaymentMethod[] ToDtos(this IEnumerable<DataAccess.PaymentMethod> paymentMethods)
        {
            return paymentMethods.Select(x => x.ToDto()).ToArray();
        }

        public static DataAccess.PaymentMethod ToDbo(this PaymentMethod paymentMethod)
        {
            return new DataAccess.PaymentMethod
            {
                Id = paymentMethod.Id,
                MethodName = paymentMethod.MethodName
            };
        }
    }
}
