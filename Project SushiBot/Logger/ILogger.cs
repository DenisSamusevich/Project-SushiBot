using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    interface ILogger
    {
        void Info(string infoMessage, Thread thread, string infoMethod);
        void Debag(string infoMessage, Thread thread, string infoMethod);
        void Error(string infoMessage, Thread thread, string infoMethod);
        void WriteFotrmatLog(string message, string infoLevel, string namespaceinfo, string infoMethod, string threadData, DelegateWrite methodWrite);
        void WriteLogInFile(string message);
    }
}
