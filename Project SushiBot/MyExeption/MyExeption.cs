using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class ArrayNotFoundExeption : Exception
    {
        private static readonly Logger logger = new Logger();
        public ArrayNotFoundExeption()
        {
            logger.Error("Array not found exeption", Thread.CurrentThread);
        }
        public ArrayNotFoundExeption(string message): base(message)
        {
            Console.WriteLine(message);
            logger.Error("Array not found exeption", Thread.CurrentThread);
        }
    }
    class ConvertExeption : Exception
    {
        private static readonly Logger logger = new Logger();
        public ConvertExeption()
        {
            logger.Error("Not convert", Thread.CurrentThread);
        }
        public ConvertExeption(string message) : base(message)
        {
            Console.WriteLine(message);
            logger.Error("Not convert", Thread.CurrentThread);
        }
    }
}
