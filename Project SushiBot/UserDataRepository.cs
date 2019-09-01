using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class UserDataRepository
    {
        public static List<UserData> GetUserData()
        {
            return UserDataBase.AllUserData;
        }
        public static UserData GetUserDataByLogin(string login)
        {
            return UserDataBase.FindLogin(login);
        }
        public static UserData GetUserDataByEmail(string email)
        {
            return UserDataBase.FindEmail(email);
        }
        public static void CreateUserData(UserData usersData)
        {
            UserDataBase.Insert(usersData);
        }
    }
}
