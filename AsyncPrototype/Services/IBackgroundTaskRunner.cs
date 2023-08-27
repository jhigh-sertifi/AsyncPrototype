using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncPrototype.Services
{
    public interface IBackgroundTaskRunner
    {
        void QueueBackgroundWorkItem(Action<CancellationToken> workItem);
    }
}
