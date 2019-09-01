using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace Project_SushiBot
{
    class OpenFile
    {
        static FileInfo File { get; } = new FileInfo(Environment.CurrentDirectory + @"\NewsData\NewsOpenBrowser.html");
        internal static void CreatePageBrowser(string linkNews)
        {
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
            streamWriter.WriteLine("<!DOCTYPE html>");
            streamWriter.WriteLine("<html lang=\"en\">");
            streamWriter.WriteLine("<head>");
            streamWriter.WriteLine("<meta charset=\"UTF-8\">");
            streamWriter.WriteLine("<title>Ссылка на новость</title>");
            streamWriter.WriteLine("</head>");
            streamWriter.WriteLine("<body>");
            streamWriter.WriteLine("<h3 align=\"center\"><a href=\"https://www.google.com\" title=\""+ linkNews + "\">Нажмите, чтобы перейти на новость</a></h3>");
            streamWriter.WriteLine("</body>");
            streamWriter.WriteLine("</html>");
            streamWriter.Close();
        }
        internal static void DeletePageBrowser()
        {
            File.Delete();
        }
        internal static void OpenPageBrowser(/*string linkNews*/)
        {
            Process.Start(File.FullName);
            //Process.Start("http://"+linkNews);
        }
    }
}
