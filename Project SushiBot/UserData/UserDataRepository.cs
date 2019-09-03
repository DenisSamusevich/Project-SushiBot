using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class UserDataRepository
    {
        private static readonly Logger logger = new Logger();
        public static List<UserData> GetUserData()
        {
            logger.Info("Data base request", Thread.CurrentThread);
            return UserDataBase.AllUserData;
        }
        public static UserData GetUserDataByLogin(string login)
        {
            logger.Info("Lodin request in base", Thread.CurrentThread);
            return UserDataBase.FindLogin(login);
        }
        public static UserData GetUserDataByEmail(string email)
        {
            logger.Info("Email request in base", Thread.CurrentThread);
            return UserDataBase.FindEmail(email);
        }
        public static void CreateUserData(UserData usersData)
        {
            logger.Info("Writing user data in base", Thread.CurrentThread);
            UserDataBase.Insert(usersData);
        }
    }
}
