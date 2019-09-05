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
        public static UserData GetUserDataByLogin(string login)
        {
            logger.Info("Lodin request in base", Thread.CurrentThread);
            UserDataBase userDataBase = new UserDataBase();
            UserData userData = userDataBase.FindLogin(login);
            userDataBase.Dispose();
            return userData;
        }
        public static UserData GetUserDataByEmail(string email)
        {
            logger.Info("Email request in base", Thread.CurrentThread);
            UserDataBase userDataBase = new UserDataBase();
            UserData userData = userDataBase.FindEmail(email);
            userDataBase.Dispose();
            return userData;
        }
        public static void CreateUserData(UserData usersData)
        {
            logger.Info("Writing user data in base", Thread.CurrentThread);
            UserDataBase userDataBase = new UserDataBase();
            userDataBase.Insert(usersData);
            userDataBase.Dispose();
        }
    }
}
