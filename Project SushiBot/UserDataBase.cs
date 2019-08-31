using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class UserDataBase
    {
        static FileInfo File { get; } = new FileInfo(Environment.CurrentDirectory + @"UserDataBase\UserDataBase.txt");
        internal static UserData[] AllUserData { get; }
        internal static int MaxNumberCollection { get; } = 50;
        internal static int СurrentNumberCollection { get; set; } = 0;
        static UserDataBase()
        {
            СurrentNumberCollection = NumberUsersDataReadFile();
            AllUserData = UsersDataReadFile(СurrentNumberCollection);
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
                else if (lineRead.Equals("start"))
                {
                    numberUsersData += 1;
                }
            }
            streamReader.Close();
            return numberUsersData;
        }
        internal static UserData[] UsersDataReadFile(int numberUsersData)
        {
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
            UserData[] returnAllUsersData = new UserData[numberUsersData];
            string lineRead = string.Empty;
            for (int i = 0; i < returnAllUsersData.Length; i++)
            {
                while (true)
                {
                    lineRead = streamReader.ReadLine();
                    if (lineRead.Equals("start",StringComparison.Ordinal))
                    {
                        returnAllUsersData[i] = new UserData(streamReader.ReadLine(), streamReader.ReadLine(), streamReader.ReadLine(), streamReader.ReadLine(), streamReader.ReadLine());
                        break;
                    }
                }
            }
            streamReader.Close();
            return returnAllUsersData;
        }
        internal static UserData FindLogin(string Login)
        {
            UserData UserData = new UserData();
            for (int i = 0; i < СurrentNumberCollection; i++)
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
            for (int i = 0; i < СurrentNumberCollection; i++)
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
            if (СurrentNumberCollection < MaxNumberCollection)
            {
                AllUserData[СurrentNumberCollection] = UserData;
                СurrentNumberCollection += 1;
                //Запись в файл
            }
            else
            {
                Console.WriteLine("Ошибка - колекция заполнена полностью.");
            }
        }
    }
}
