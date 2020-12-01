using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserLive.Jobs
{
    public class JobFactory : IJobFactory
    {
        private readonly IServiceProvider Container;

        public JobFactory(IServiceProvider container)
        {
            Container = container;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return (IJob)Container.GetService(bundle.JobDetail.JobType);
        }

        public void ReturnJob(IJob job)
        {
            // Here is your Code
            (job as IDisposable)?.Dispose();
        }
    }
}
