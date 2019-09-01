using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    internal struct NewsData
    {
        internal string Title { get; }
        internal string Text { get; }
        internal string Link { get; }
        internal NewsData(string title, string text, string link)
        {
            Title = title;
            Text = NewsTextConversion(text);
            Link = link;
        }
        internal static string NewsTextConversion(string NewsText)
        {
            if (NewsText.Length < 80)
            {
                return NewsText;
            }
            else
            {
                int lastindex = NewsText.LastIndexOf(' ', 80);
                string stringStart = NewsText.Substring(0, lastindex + 1);
                string stringEnd = NewsText.Substring(lastindex + 1, NewsText.Length - lastindex - 1);
                string returnNewsText = stringStart + "\n" + NewsTextConversion(stringEnd);
                return returnNewsText;
            }
        }
    }
}
