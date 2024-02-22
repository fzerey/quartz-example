using Quartz;
using Quartz.Impl;

namespace QuartzExample
{
    public static class CronJobTrigger
    {
        public static async Task ScheduleJob(string cronSchedule)
        {
            IScheduler scheduler = await new StdSchedulerFactory().GetScheduler();

            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<ExampleJob>()
                .WithIdentity("job1", "group1")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .WithCronSchedule(cronSchedule)
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }
    }
}
