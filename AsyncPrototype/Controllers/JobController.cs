using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using AsyncPrototype.Services;

namespace AsyncPrototype.Controllers
{
    public class JobController : ApiController
    {
        [HttpGet]
        [Route("api/Job/{id}")]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var task = new LongRunningTask();
            var status = task.GetStatus(id);
            return Json<TaskResult>(status);
        }

        [HttpPost]
        [Route("api/Job")]
        public async Task<IHttpActionResult> Post([FromBody] string value)
        {
            var jobGuid = Guid.NewGuid();
            var runner = new BackgroundTaskRunner();
            runner.QueueBackgroundWorkItem( 
                cancellationToken => new LongRunningTask().Start(jobGuid, cancellationToken));
            return Ok(jobGuid);
        }
    }
}