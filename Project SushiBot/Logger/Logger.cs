using System;
using System.IO;
using System.Text;
using System.Reflection;
using System.Threading;

namespace Project_SushiBot
{
    delegate void DelegateWrite(string message);
    class Logger: ILogger
    {
        static int Count { get; set; } = 0;
        static FileInfo File { get; set; }
        
        static Logger()
        {
            File = new FileInfo(Environment.CurrentDirectory + string.Format(@"\Logs\log " + DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + "_{0:d2}.txt", Count));
            while (true)
            {
                if (File.Exists)
                {
                    if (File.Length > 30000)
                    {
                        Count += 1;
                        File = new FileInfo(Environment.CurrentDirectory + string.Format(@"\Logs\log " + DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + "_{0:d2}.txt", Count));
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    File.Create();
                    break;
                }
            }
        }
        public void Info(string infoMessage, Thread thread, [System.Runtime.CompilerServices.CallerMemberName] string infoMethod = "")
        {
            string namespaceinfo = Assembly.GetCallingAssembly().GetName().Name;
            DelegateWrite delegateWrite = WriteLogInFile;
            WriteFotrmatLog(infoMessage, "INFO", namespaceinfo, infoMethod, WriteDataThread(thread), delegateWrite);
            delegateWrite -= WriteLogInFile;
        }
        public void Debag(string infoMessage, Thread thread, [System.Runtime.CompilerServices.CallerMemberName] string infoMethod = "")
        {
            string namespaceinfo = Assembly.GetCallingAssembly().GetName().Name;
            DelegateWrite delegateWrite = WriteLogInFile;
            WriteFotrmatLog(infoMessage, "DEBG", namespaceinfo, infoMethod, WriteDataThread(thread), delegateWrite);
            delegateWrite -= WriteLogInFile;
        }
        public void Error(string infoMessage, Thread thread, [System.Runtime.CompilerServices.CallerMemberName] string infoMethod = "")
        {
            string namespaceinfo = Assembly.GetCallingAssembly().GetName().Name;
            DelegateWrite delegateWrite = WriteLogInFile;
            WriteFotrmatLog(infoMessage,"ERRR", namespaceinfo, infoMethod, WriteDataThread(thread), delegateWrite);
            delegateWrite -= WriteLogInFile;
        }
        public void WriteFotrmatLog(string message,string infoLevel,string namespaceinfo, string infoMethod, string threadData, DelegateWrite methodWrite)
        {
            methodWrite(DateTime.Now.ToString("yyyy-mm-dd HH:mm:ss  ")+ infoLevel+"   " + namespaceinfo + " | "+ infoMethod + " - "+ message+ threadData);
        }
        public void WriteLogInFile(string message)
        {
            FileStream fileStream = File.Open(FileMode.Append,FileAccess.Write,FileShare.Write);
            StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
            streamWriter.WriteLine(message);
            streamWriter.Close();
            if (File.Length > 30000)
            {
                Count += 1;
                File = new FileInfo(Environment.CurrentDirectory + string.Format(@"\Logs\log " + DateTime.Now.Year.ToString("D4") + DateTime.Now.Month.ToString("D2") + DateTime.Now.Day.ToString("D2") + "_{0:d2}.txt", Count));
                File.Create();
            }
        }
        public string WriteDataThread(Thread thread)
        {
            return string.Format("  Thread data - ContextID:{0}, Name:{1}, IsAlive:{2} Priority:{3}, State:{4}", Thread.CurrentContext.ContextID, thread.Name, thread.IsAlive, thread.Priority, thread.ThreadState);
        }
    }
}
