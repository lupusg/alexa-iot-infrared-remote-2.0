using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaIOTInfraredRemoteAPI.Domain.Services
{
    public interface IInfraredSignalService
    {
        Task<IReadOnlyList<InfraredSignal>> GetInfraredSignals(string sort);
    }
}
