using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ICacheReepo
    {
        Task SetAsync(string key, object Value, TimeSpan duration);

        Task<string?> GetAsync(string key);
    }
}
