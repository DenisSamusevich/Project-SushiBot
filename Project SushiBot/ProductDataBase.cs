﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_SushiBot
{
    class ProductDataBase
    {
        static FileInfo File { get; } = new FileInfo(Environment.CurrentDirectory + @"ProductData\Product.txt");
        internal static ProductData[][] AllProductData { get; }
        internal static string[] MenuData { get; }
        static ProductDataBase()
        {
            AllProductData = ProductReadFile(NumberMenuProductReadFile(NumberMenuReadFile()),out string[] returnMenuData);
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
                        else if (lineRead.Equals("EndMenuProduct",StringComparison.Ordinal))
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
        internal static ProductData[][] ProductReadFile(int[] numberMenuProduct, out string[] returnMenuData)
        {
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
            ProductData[][] allProductData = new ProductData[numberMenuProduct.Length][];
            for (int i = 0; i < allProductData.Length; i++)
            {
                allProductData[i] = new ProductData[numberMenuProduct[i]];
            }
            returnMenuData = new string[numberMenuProduct.Length];
            string lineRead = string.Empty;
            for (int i = 0; i < allProductData.Length; i++)
            {
                while (true)
                {
                    lineRead = streamReader.ReadLine();
                    if (lineRead.Equals("Menu",StringComparison.Ordinal))
                    {
                        returnMenuData[i] = streamReader.ReadLine();
                        
                        for (int j = 0; j < allProductData[i].Length; j++)
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
                                    allProductData[i][j] = new ProductData(productData[0], productData[1], productData[2]);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            streamReader.Close();
            return allProductData;
        }

        internal static ProductData FindIndex(ref int indexMenu, ref int indexProduct)
        {
            if (indexMenu > AllProductData.Length - 1)
            {
                indexMenu = AllProductData.Length - 1;
            }
            else if (indexMenu < 0)
            {
                indexMenu = 0;
            }
            if (indexProduct > AllProductData[indexMenu].Length - 1)
            {
                indexProduct = AllProductData[indexMenu].Length - 1;
            }
            else if (indexProduct < 0)
            {
                indexProduct = 0;
            }
            return AllProductData[indexMenu][indexProduct];
        }
    }
}
