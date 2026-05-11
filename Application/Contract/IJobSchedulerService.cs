using System;

namespace MinisterioAtos.Application.Contract;

public interface IJobSchedulerService
{

    Task<string> GetJobsRunningAsync(CancellationToken ct);
    Task RunJobAsync(DateTime startWith, string jobName, CancellationToken ct);
}
