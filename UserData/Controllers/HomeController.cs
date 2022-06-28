using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UserData.Models;

namespace UserData.Controllers
{
    public class HomeController : Controller
    {

        UserDataRepository _UserRepository = new UserDataRepository();

        public ActionResult Index()
        {
            return View(_UserRepository.GetUsers());
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        //Add user
        [HttpPost]
        public ActionResult CreateUser(UserDataModel user)
        {
            try
            {
                _UserRepository.InsertUserModel(user);
                return RedirectToAction("../Home/Index");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.InnerException.ToString());
            }
        }

        //Update student
        [HttpGet]
        public ActionResult UpdateUser(int id)
        {
            try
            {
                return View(_UserRepository.GetUserByID(id));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult UpdateUser(UserDataModel user)
        {
            try
            {
                _UserRepository.EditUserModel(user);
                TempData["Success"] = "User record updated successfully..";
                return RedirectToAction("../Home/Index");
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.InnerException.ToString());
            }
        }


        //Delete Selected User Records
        public ActionResult Delete(int id)
        {
            UserDataModel AllUsers = _UserRepository.GetUserByID(id);
            if (AllUsers == null)
                return RedirectToAction("Index");
            return View(AllUsers);
        }


        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _UserRepository.DeleteUserModel(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}