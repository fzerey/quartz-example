
using Quartz;
using Quartz.Impl;
using QuartzExample;

var schedulerFactory = new StdSchedulerFactory();

var scheduler = await schedulerFactory.GetScheduler();

await scheduler.Start();

var job = JobBuilder.Create<ExampleJob>()
    .WithIdentity("exampleJob", "group1")
    .Build();

Console.WriteLine("Choose trigger option: 1 for Manual, 2 for Cron Schedule");
var option = Console.ReadLine();

if (option == "1")
{
    await ManuelJobTrigger.TriggerJob(scheduler, job);
    Thread.Sleep(5000);
}
else if (option == "2")
{
    await CronJobTrigger.ScheduleJob("0/5 * * * * ?");
    Thread.Sleep(20000);
}
else
{
    Console.WriteLine("Invalid option.");
}

await scheduler.Shutdown();
Console.WriteLine("Scheduler shutdown.");
