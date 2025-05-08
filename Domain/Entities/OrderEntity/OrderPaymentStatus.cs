using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.OrderEntity
{
    public enum OrderPaymentStatus
    {
        pending=0,
        paymentRecieved=1,
        paymentFailed =2
    }
}
