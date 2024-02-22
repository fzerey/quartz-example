using Quartz;

namespace QuartzExample
{
    public static class ManuelJobTrigger
    {
        public static async Task TriggerJob(IScheduler scheduler, IJobDetail job)
        {
            var trigger = TriggerBuilder.Create()
                .WithIdentity("manuelTrigger", "group1")
                .StartNow()
                .Build();
            await scheduler.ScheduleJob(job, trigger);
            Console.WriteLine("Job scheduled.");
        }
    }
}
