using demo_master.Models;
using System;
using System.ServiceProcess;
using System.Threading;

namespace UserLive_console
{
    public class UserLiveService : ServiceBase
    {
        Thread _thread = null;
        public UserLiveService()
        {
            ServiceName = "UserLiveService";
        }
        protected override void OnStart(string[] args)
        {
            ThreadStart start = new ThreadStart(Working);
            _thread = new Thread(start);
            _thread.Start();
        }

        internal void onDebug()
        {
            OnStart(null);
        }

        protected override void OnStop()
        {
            try
            {
                if ((_thread != null) & _thread.IsAlive)
                {
                    _thread.Abort();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void Working(NewUserVM user)
        {
            int nsleep = 1;
            
            try
            {
                while (true)
                {
                    
                    ser.InputPrintRcrd(user);
                    Thread.Sleep(nsleep * 5 * 1000);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
