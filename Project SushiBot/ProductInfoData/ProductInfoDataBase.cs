﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Project_SushiBot
{
    class ProductInfoDataBase : 
    {
        private static readonly Logger logger = new Logger();
        static FileInfo File { get; set; } = new FileInfo(Environment.CurrentDirectory + @"\ProductData\Product.txt");
        static ProductInfoData[][] AllProductInfoData { get; set; }
        static string[] MenuData { get; set; }
        internal ProductInfoDataBase()
        {
            AllProductInfoData = ProductReadFile(NumberMenuProductReadFile(NumberMenuReadFile()),out string[] returnMenuData);
            MenuData = returnMenuData;
        }
        internal static int NumberMenuReadFile()
        {
            string lineRead = string.Empty;
            int numberMenu = 0;
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
            while (true)
            {
                lineRead = streamReader.ReadLine();
                if (lineRead == null)
                {
                    break;
                }
                else if (lineRead.Equals("Menu",StringComparison.Ordinal))
                {
                    numberMenu += 1;
                }
            }
            streamReader.Close();
            return numberMenu;
        }
        internal static int[] NumberMenuProductReadFile(int numberMenu)
        {
            try
            {
                if (numberMenu == 0)
                {
                    throw new ArrayNotFoundExeption("Ошибка чтения данных");
                }
                else
                {
                    string lineRead = string.Empty;
                    int[] returnNumberMenuProduct = new int[numberMenu];
                    FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
                    int indexMenu = 0;
                    while (true)
                    {
                        lineRead = streamReader.ReadLine();
                        if (lineRead == null)
                        {
                            break;
                        }
                        else if (lineRead.Equals("Menu", StringComparison.Ordinal))
                        {
                            int numberProduct = 0;
                            while (true)
                            {
                                lineRead = streamReader.ReadLine();
                                if (lineRead.Equals("Product", StringComparison.Ordinal))
                                {
                                    numberProduct += 1;
                                }
                                else if (lineRead.Equals("EndMenuProduct", StringComparison.Ordinal))
                                {
                                    returnNumberMenuProduct[indexMenu++] = numberProduct;
                                    break;
                                }
                            }
                        }
                    }
                    streamReader.Close();
                    return returnNumberMenuProduct;
                }
            }
            catch
            {
                logger.Error("Menu product not found", Thread.CurrentThread);
                return null;
            }
        }
        internal static ProductInfoData[][] ProductReadFile(int[] numberMenuProduct, out string[] returnMenuData)
        {
            try
            {
                if (numberMenuProduct == null)
                {
                    throw new ArrayNotFoundExeption("Ошибка чтения данных");
                }
                else
                {
                    FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
                    ProductInfoData[][] AllProductInfoData = new ProductInfoData[numberMenuProduct.Length][];
                    for (int i = 0; i < AllProductInfoData.Length; i++)
                    {
                        AllProductInfoData[i] = new ProductInfoData[numberMenuProduct[i]];
                    }
                    returnMenuData = new string[numberMenuProduct.Length];
                    string lineRead = string.Empty;
                    for (int i = 0; i < AllProductInfoData.Length; i++)
                    {
                        while (true)
                        {
                            lineRead = streamReader.ReadLine();
                            if (lineRead.Equals("Menu", StringComparison.Ordinal))
                            {
                                returnMenuData[i] = streamReader.ReadLine();
                                for (int j = 0; j < AllProductInfoData[i].Length; j++)
                                {
                                    while (true)
                                    {
                                        lineRead = streamReader.ReadLine();
                                        if (lineRead.Equals("Product", StringComparison.Ordinal))
                                        {
                                            string[] productData = new string[3] { string.Empty, string.Empty, string.Empty };
                                            for (int n = 0; n < productData.Length; n++)
                                            {
                                                productData[n] = streamReader.ReadLine();
                                            }
                                            AllProductInfoData[i][j] = new ProductInfoData(productData[0], productData[1], productData[2]);
                                            break;
                                        }
                                    }
                                }
                                break;
                            }
                        }
                    }
                    streamReader.Close();
                    return AllProductInfoData;
                }
            }
            catch
            {
                logger.Error("Product not found", Thread.CurrentThread);
                returnMenuData = null;
                return null;
            }

        }
        internal ProductInfoData FindIndex(ref int indexMenu, ref int indexProduct)
        {
            if (AllProductInfoData==null)
            {
                logger.Error("No products in the database", Thread.CurrentThread);
                return null;
            }
            else
            {
                if (indexMenu > AllProductInfoData.Length - 1)
                {
                    indexMenu = AllProductInfoData.Length - 1;
                }
                else if (indexMenu < 0)
                {
                    indexMenu = 0;
                }
                if (indexProduct > AllProductInfoData[indexMenu].Length - 1)
                {
                    indexProduct = AllProductInfoData[indexMenu].Length - 1;
                }
                else if (indexProduct < 0)
                {
                    indexProduct = 0;
                }
                return AllProductInfoData[indexMenu][indexProduct];
            }
        }
        internal string[] GetAllMenuData()
        {
            if (MenuData==null)
            {
                logger.Error("No menu in the database", Thread.CurrentThread);
                return null;
            }
            else
            {
                return MenuData;
            }
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
                File = null;
                AllProductInfoData = null;
                MenuData = null;
            }
        }
        ~ProductInfoDataBase()
        {
            Dispose(false);
        }
    }
}
