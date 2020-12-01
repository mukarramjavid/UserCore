using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserLive.Jobs
{
    public interface IBackgroundJobService
    {
        void ScheduleAutoSignalR();
    }
}
