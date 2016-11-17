using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgentPlanner.ViewModels.PaymentMethod;

namespace AgentPlanner.ViewModels.Mappers
{
    public static class PaymentMethodMapper
    {
        public static PaymentMethodViewModel ToVm(this Entities.Client.PaymentMethod paymentMethod)
        {
            if (paymentMethod == null) return null;

            return new PaymentMethodViewModel
            {
                Id = paymentMethod.Id,
                MethodName = paymentMethod.MethodName
            };
        }


        public static PaymentMethodViewModel[] ToVms(this IEnumerable<Entities.Client.PaymentMethod> paymentMethods)
        {
            return paymentMethods.Select(x => x.ToVm()).ToArray();
        }
    }
}
