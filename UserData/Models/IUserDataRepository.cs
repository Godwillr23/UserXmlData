using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserData.Models
{
    public interface IUserDataRepository
    {
        IEnumerable<UserDataModel> GetUsers();
        UserDataModel GetUserByID(int id);
        void InsertUserModel(UserDataModel Student);
        void DeleteUserModel(int id);
        void EditUserModel(UserDataModel Student);
    }
}