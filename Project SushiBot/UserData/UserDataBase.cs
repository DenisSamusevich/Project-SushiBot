using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class UserDataBase : IDisposable
    {
        private static readonly Logger logger = new Logger();
        static FileInfo File { get; set; } = new FileInfo(Environment.CurrentDirectory + @"\UserDataBase\UserDataBase.txt");
        internal static List<UserData> AllUserData { get; set; }
        internal UserDataBase()
        {
            AllUserData = UsersDataReadFile(NumberUsersDataReadFile());
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
            if (numberUsersData == 0)
            {
                logger.Error("User not found in database", Thread.CurrentThread);
                return null;
            }
            else
            {
                FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
                StreamReader streamReader = new StreamReader(fileStream, Encoding.Default);
                logger.Debag("Start database read", Thread.CurrentThread);
                List<UserData> returnAllUsersData = new List<UserData>();
                string lineRead = string.Empty;
                for (int i = 0; i < numberUsersData; i++)
                {
                    while (true)
                    {
                        lineRead = streamReader.ReadLine();
                        if (lineRead.Equals("User", StringComparison.Ordinal))
                        {
                            returnAllUsersData.Add(new UserData(streamReader.ReadLine(), streamReader.ReadLine(), streamReader.ReadLine(), streamReader.ReadLine(), streamReader.ReadLine()));
                            break;
                        }
                    }
                }
                streamReader.Close();
                return returnAllUsersData;
            }
        }
        internal static void UsersDataWriteFile()
        {
            logger.Debag("Start User database write", Thread.CurrentThread);
            FileStream fileStream = File.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default);
            for (int i = 0; i < AllUserData.Count; i++)
            {
                streamWriter.WriteLine("\nUser");
                streamWriter.WriteLine(AllUserData[i].Email);
                streamWriter.WriteLine(AllUserData[i].Name);
                streamWriter.WriteLine(AllUserData[i].Surname);
                streamWriter.WriteLine(AllUserData[i].Login);
                streamWriter.WriteLine(AllUserData[i].Password);
                streamWriter.WriteLine(string.Empty);
            }
            streamWriter.Close();
        }
        internal UserData FindLogin(string Login)
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
        internal UserData FindEmail(string Email)
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
        internal void Insert(UserData UserData)
        {
            logger.Debag("User added  in database", Thread.CurrentThread);
            AllUserData.Add(UserData);
            UsersDataWriteFile();
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
                AllUserData = null;
            }
        }
        ~UserDataBase()
        {
            Dispose(false);
        }
    }
}
