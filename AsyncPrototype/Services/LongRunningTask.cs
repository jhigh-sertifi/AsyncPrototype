using System;
using System.Diagnostics;
using System.Threading;

namespace AsyncPrototype.Services
{
    public class LongRunningTask
    {
        private static int counter = 0;
        public void Start(Guid jobGuid, CancellationToken cancellationToken = default(CancellationToken))
        {
            counter = 0;
        }

        public TaskResult GetStatus(Guid jobGuid)
        {
            var result = new TaskResult();
            if (counter == 3)
            {
                result.Status = "Complete";
            }
            else
            {
                result.Status = "Pending";
                counter++;
            }
            return result;
        }
    }
}