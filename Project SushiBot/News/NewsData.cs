using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project_SushiBot
{
    internal class NewsData : IDisposable
    {
        string Title { get; set; }
        string Text { get; set; }
        string Link { get; set; }
        internal NewsData(string title, string text, string link)
        {
            Title = title;
            Text = NewsTextConversion(text);
            Link = link;
        }
        internal static string NewsTextConversion(string NewsText)
        {
            if (NewsText.Length < 79)
            {
                return NewsText;
            }
            else
            {
                int lastindex = NewsText.LastIndexOf(' ', 79);
                string stringStart = NewsText.Substring(0, lastindex + 1);
                string stringEnd = NewsText.Substring(lastindex + 1, NewsText.Length - lastindex - 1);
                string returnNewsText = stringStart + "\n" + NewsTextConversion(stringEnd);
                return returnNewsText;
            }
        }
        internal void OpenPageBrowser()
        {
            Process.Start(Link);
        }
        internal void WriteNews()
        {
            Console.WriteLine("Новости");
            Console.WriteLine(Title);
            Console.WriteLine(Text);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Title = null;
                Text = null;
                Link = null;
            }
        }
        ~NewsData()
        {
            Dispose(false);
        }
    }
}
