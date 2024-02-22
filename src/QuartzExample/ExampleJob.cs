using Quartz;

namespace QuartzExample
{
    public class ExampleJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello Quartz");
        }

    }
}
