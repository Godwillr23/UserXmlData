using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;

namespace UserData.Models
{
    public class UserDataRepository : IUserDataRepository
    {

        private List<UserDataModel> allUsers;
        private XDocument UserData;

        public UserDataRepository()
        {
            try
            {
                allUsers = new List<UserDataModel>();
                UserData = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/UserData.xml"));
                var Users = from t in UserData.Descendants("User")
                            select new UserDataModel(
                            (int)t.Element("id"),
                            t.Element("firstname").Value,
                            t.Element("lastname").Value,
                            t.Element("cellnumber").Value);

                allUsers.AddRange(Users.ToList<UserDataModel>());
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        //Code to get the list of all the users.
        public IEnumerable<UserDataModel> GetUsers()
        {
            return allUsers;
        }

        //Code to get user by ID
        public UserDataModel GetUserByID(int id)
        {
            return allUsers.Find(item => item.ID == id);
        }

        //Code to insert user information to XML file
        public void InsertUserModel(UserDataModel User)
        {
            User.ID = (int)(from S in UserData.Descendants("User") orderby (int)S.Element("id") descending select (int)S.Element("id")).FirstOrDefault() + 1;


            UserData.Root.Add(new XElement("User", new XElement("id", User.ID),
                new XElement("firstname", User.FirstName),
                new XElement("lastname", User.LastName),
                new XElement("cellnumber", User.Cellnumber)));

            UserData.Save(HttpContext.Current.Server.MapPath("~/App_Data/UserData.xml"));
           
        }
        
        //Code to Update user details
        public void EditUserModel(UserDataModel User)
        {
            try
            {
                XElement node = UserData.Root.Elements("User").Where(i => (int)i.Element("id") == User.ID).FirstOrDefault();

                node.SetElementValue("firstname", User.FirstName);
                node.SetElementValue("lastname", User.LastName);
                node.SetElementValue("cellnumber", User.Cellnumber);
                UserData.Save(HttpContext.Current.Server.MapPath("~/App_Data/UserData.xml"));
            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        //Code to delete user from XMl file
        public void DeleteUserModel(int id)
        {
            try
            {
                UserData.Root.Elements("User").Where(i => (int)i.Element("id") == id).Remove();

                UserData.Save(HttpContext.Current.Server.MapPath("~/App_Data/UserData.xml"));

            }
            catch (Exception)
            {

                throw new NotImplementedException();
            }
        }

        public void InsertUsersModel(UserDataModel Student)
        {
            throw new NotImplementedException();
        }
    }
}