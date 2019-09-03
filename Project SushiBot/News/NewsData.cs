using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Project_SushiBot
{
    internal struct NewsData
    {
        string Title { get; }
        string Text { get; }
        string Link { get; }
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
    }
}
