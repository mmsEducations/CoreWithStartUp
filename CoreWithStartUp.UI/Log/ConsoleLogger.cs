using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWithStartUp.UI.Log
{
    public class ConsoleLogger : IConsoleLogger
    {
        public void Error(string logInfo)
        {
            Console.WriteLine($"Error : {logInfo}");
        }

        public void Warning(string logInfo)
        {
            Console.WriteLine($"Warning : {logInfo}");
        }

        public void Success(string logInfo)
        {
            Console.WriteLine($"Success : {logInfo}");
        }


        public void Info(string logInfo)
        {
            Console.WriteLine($"Onfo : {logInfo}");
        }

    }
}
