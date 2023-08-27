using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Hosting;

namespace AsyncPrototype.Services
{
    public class BackgroundTaskRunner : IBackgroundTaskRunner
    {
        public void QueueBackgroundWorkItem(Action<CancellationToken> workItem)
        {
            HostingEnvironment.QueueBackgroundWorkItem(workItem);
        }
    }
}