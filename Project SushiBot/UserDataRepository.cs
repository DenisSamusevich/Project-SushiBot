using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SushiBot
{
    class UserDataRepository
    {
        public static UserData[] GetUserData()
        {
            return UserDataBase.UsersData;
        }
        public static UserData GetUserDataByLogin(string userLogin)
        {
            return UserDataBase.FindLogin(userLogin);
        }
        public static UserData GetUserDataByEmail(string userEmail)
        {
            return UserDataBase.FindEmail(userEmail);
        }
        public static void CreateUserData(UserData usersData)
        {
            UserDataBase.Insert(usersData);
        }
    }
}
