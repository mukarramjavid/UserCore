using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserLive.Jobs
{
    public class BackgroundJobService : IBackgroundJobService
    {
        private readonly ISchedulerFactory _stdSchedulerFactory;
        private readonly IScheduler _scheduler;
        private readonly IServiceProvider _serviceProvider;
        public BackgroundJobService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _stdSchedulerFactory = new StdSchedulerFactory();
            _scheduler = _stdSchedulerFactory.GetScheduler().Result;
            _scheduler.JobFactory = new JobFactory(_serviceProvider);
            _scheduler.Start().Wait();
        }
        public void ScheduleAutoSignalR()
        {
            //Quartz Implementation

            IJobDetail jobDetail = JobBuilder.Create<ScheduledJob>()
                                   .WithIdentity("UserLive.job", "UserLive")
                                   .Build();


            // CronTrigger
            //ITrigger trigger = TriggerBuilder.Create()
            //                .WithIdentity($"UserLive.trigger", "UserLive")
            //                .WithCronSchedule("0 0/1 * * * ?")
            //                .ForJob(jobDetail.Key)
            //                .WithPriority(1)
            //                .Build();

            // Simple Trigger
            ITrigger trigger = TriggerBuilder.Create()
                             .WithIdentity($"UserLive.trigger", "UserLive")
                             .ForJob(jobDetail.Key)
                             .WithSimpleSchedule(s => s.WithInterval(TimeSpan.FromSeconds(20)).RepeatForever())
                             .WithPriority(1)
                             .Build();



            _scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}
