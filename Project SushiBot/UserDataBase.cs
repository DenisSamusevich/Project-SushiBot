﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class UserDataBase
    {
        static FileInfo File { get; } = new FileInfo(Environment.CurrentDirectory + @"\UserDataBase\UserDataBase.txt");
        internal static List<UserData> AllUserData { get; set; }
        //internal static int MaxNumberCollection { get; } = 50;
        //internal static int СurrentNumberCollection { get; set; } = 0;
        static UserDataBase()
        {
            //СurrentNumberCollection = NumberUsersDataReadFile();
            AllUserData = UsersDataReadFile(NumberUsersDataReadFile());
            //Console.WriteLine("Необходимо ввести максимальное количество элементов в колекции");
            //MaxNumberCollection = MotorcycleConsoleInput.InputConsoleNumber(MinNumberCollection, int.MaxValue);
            //Motorcycle[] MotorcyclesCreate = new Motorcycle[MaxNumberCollection];
            //for (int i = 0; i < MotorcyclesCreate.Length; i++)
            //{
            //    MotorcyclesCreate[i] = new Motorcycle(i + 1);
            //}
            //Motorcycles = MotorcyclesCreate;
            //for (int i = 0; i < MotorcyclesCreate.Length && Motorcycles[i].Id != 0; i++)
            //{
            //    СurrentNumberCollection = i + 1;
            //}
            //Console.WriteLine("Создана стандартная колекция в которой " + СurrentNumberCollection.ToString() + " экземпляров");
        }
        internal static int NumberUsersDataReadFile()
        {
            string lineRead = string.Empty;
            int numberUsersData = 0;
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
            while (true)
            {
                lineRead = streamReader.ReadLine();
                if (lineRead == null)
                {
                    break;
                }
                else if (lineRead.Equals("User"))
                {
                    numberUsersData += 1;
                }
            }
            streamReader.Close();
            return numberUsersData;
        }
        internal static List<UserData> UsersDataReadFile(int numberUsersData)
        {
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
            List<UserData> returnAllUsersData = new List<UserData>();
            string lineRead = string.Empty;
            for (int i = 0; i < numberUsersData; i++)
            {
                while (true)
                {
                    lineRead = streamReader.ReadLine();
                    if (lineRead.Equals("User",StringComparison.Ordinal))
                    {
                        returnAllUsersData.Add(new UserData(streamReader.ReadLine(), streamReader.ReadLine(), streamReader.ReadLine(), streamReader.ReadLine(), streamReader.ReadLine()));
                        break;
                    }
                }
            }
            streamReader.Close();
            return returnAllUsersData;
        }
        internal static void UsersDataWriteFile()
        {
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
            List<UserData> returnAllUsersData = new List<UserData>();
            for (int i = 0; i < AllUserData.Count - 1; i++)
            {
                streamWriter.WriteLine("User");
                streamWriter.WriteLine(AllUserData[i].Email);
                streamWriter.WriteLine(AllUserData[i].Name);
                streamWriter.WriteLine(AllUserData[i].Surname);
                streamWriter.WriteLine(AllUserData[i].Login);
                streamWriter.WriteLine(AllUserData[i].Password);
                streamWriter.WriteLine(string.Empty);
            }
            streamWriter.Close();
        }
        internal static UserData FindLogin(string Login)
        {
            UserData UserData = new UserData();
            for (int i = 0; i < AllUserData.Count; i++)
            {
                if (AllUserData[i].Login.Equals(Login,StringComparison.Ordinal))
                {
                    UserData = AllUserData[i];
                    break;
                }
            }
            return UserData;
        }
        internal static UserData FindEmail(string Email)
        {
            UserData UserData = new UserData();
            for (int i = 0; i < AllUserData.Count; i++)
            {
                if (AllUserData[i].Email.Equals(Email, StringComparison.Ordinal))
                {
                    UserData = AllUserData[i];
                    break;
                }
            }
            return UserData;
        }
        internal static void Insert(UserData UserData)
        {
            AllUserData.Add(UserData);
            UsersDataWriteFile();
        }
    }
}
