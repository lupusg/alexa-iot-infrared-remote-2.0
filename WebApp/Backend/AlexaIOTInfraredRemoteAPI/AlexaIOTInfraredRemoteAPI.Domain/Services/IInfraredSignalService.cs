using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlexaIOTInfraredRemoteAPI.Domain.Services
{
    public interface IInfraredSignalService
    {
        Task<InfraredSignal> CreateInfraredSignal(Guid userId, int length, int[] infraredData);
        Task<IReadOnlyList<InfraredSignal>> GetInfraredSignals(string sort);
    }
}
