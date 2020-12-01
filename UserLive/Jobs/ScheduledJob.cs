using BussinessOperation.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Quartz;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserLive.Hubs;

namespace UserLive.Jobs
{
    public class ScheduledJob : IJob
    {
        private readonly IUserService _userService;
        private readonly IMemoryCache _cache;

        public ScheduledJob(IUserService userService, IMemoryCache cache)
        {
            _userService = userService;
            _cache = cache;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                //await Console.Out.WriteLineAsync("HelloJob is executing.");
                //New User list
                LiveUpdateHub liveUpdatesHub = new LiveUpdateHub(_userService,_cache);
                await liveUpdatesHub.SendNewUsersList();
            }
            catch (Exception ex)
            {
                var e = ex.Message;
            }
        }
    }
}
