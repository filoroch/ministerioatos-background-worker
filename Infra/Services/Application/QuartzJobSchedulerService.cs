using System;
using System.Reactive.Concurrency;
using MinisterioAtos.Application.Contract;
using Quartz;

namespace MinisterioAtos.Infra.Services.Application;

public class QuartzJobSchedulerService (ISchedulerFactory factory) : IJobSchedulerService
{
    private readonly ISchedulerFactory _factory = factory;

    public async Task<string> GetJobsRunningAsync(CancellationToken ct)
    {
        var schedules = await _factory.GetScheduler();
        var runningJobs = await schedules.GetCurrentlyExecutingJobs();

        if (runningJobs.Count <= 0)
        {
            return "Nenhum job em execução no momento";
        }

        var listJobName = runningJobs.Select(job => job.JobDetail.Key.Name);
        var report = string.Join(", ", listJobName);

        return report;
    } 

    public async Task RunJobAsync 
    (
        DateTime startWith, 
        string jobName, 
        CancellationToken ct
    )
    {
        var scheduler = await _factory.GetScheduler(ct); 
        var job = new JobKey(jobName);

        if(!await scheduler.CheckExists(job, ct))
        {
            throw new AppException($"O job {job.Name} não existe");
        }

        var trigger = TriggerBuilder
            .Create()
            .StartAt(startWith)
            .ForJob(job)
            .Build();

        await scheduler.ScheduleJob(trigger, ct);
    }    
}
