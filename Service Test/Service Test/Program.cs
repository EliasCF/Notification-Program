using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace TimeService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            Service myService = new Service();
            myService.OnDebug();
            System.Threading.Thread.Sleep(System.Threading.Timeout.Infinite);
        }
    }
}