using OrderManagement.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Service
{
    internal class Log : ILog
    {
        void ILog.Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
