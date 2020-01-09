using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MakerSpaceEntryInterface.Models;
using MakerSpaceEntryInterface.Services;
using MakerSpaceEntryInterface.Models.DatabaseModels;

namespace MakerSpaceEntryInterface.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginRequestModel lrm, DataServices dataServices)
        {
            lrm.RequestTime = DateTime.Now;



            var Users = dataServices.GetUserData();
            var user = Users.Where(u => u.Username.Equals(lrm.Username));
            if(user == null || !user.Any())
            {
                return View();
            }

            var userArray = user.ToArray();
            if (!PasswordServices.CompareHash(userArray[0].PasswordHash, PasswordServices.HashGen(userArray[0].Salt, lrm.Password)))
            {
                return View();
            }
            var newData = new List<LogDataModel>();
            newData.Add(new LogDataModel(userArray[0], DateTime.Now));
            dataServices.SaveLogData(newData, false);


                                                                                //TODO: Unlock door


            return RedirectToAction(actionName: "Unlocked", controllerName:"Home");

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Information()
        {
            return View();
        }

        public IActionResult Unlocked()
        {
            return View();
        }
    }
}
