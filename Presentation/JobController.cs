using System.Reactive.Concurrency;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinisterioAtos.Application.Contract;
using Quartz;

namespace MinisterioAtos.Presentation
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController(IJobSchedulerService scheduler) : ControllerBase
    {
        private readonly IJobSchedulerService _scheduler = scheduler;
        
        [HttpGet]
        public async Task<IActionResult> ListRunning(CancellationToken ct)
        {
            var report = await _scheduler.GetJobsRunningAsync(ct);
            return Ok(report);
        }

        [HttpPost]
        public async Task<IActionResult> RunJob([FromBody] DateTime startWith, string jobName, CancellationToken ct)
        {
            await _scheduler.RunJobAsync(startWith, jobName, ct);
            return Accepted("Job is running");
        }
    }
}
