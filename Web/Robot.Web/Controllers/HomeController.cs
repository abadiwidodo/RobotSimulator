using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Mvc;
using Robot.Models;
using Robot.Models.Command;
using Robot.Models.Extensions;
using Robot.Web.Models;

namespace Robot.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRobot _robot;

        public HomeController(IRobot robot)
        {
            _robot = robot;
        }

        public ActionResult Index()
        {
            HomeModel model = new HomeModel();

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Index(HomeModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                //loop thru each line command inout strings
                foreach (string cmd in new List<string>(Regex.Split(model.Input, Environment.NewLine)))
                {
                    //validate input string first
                    if (cmd.IsValidRobotCommand())
                    {
                        ICommand command = CommandFactory.Get(cmd, _robot);
                        if(command != null) command.Execute();
                    }
                    //else ignore the command
                }

                model.Result = new ResultModel();
                model.Result.Output = _robot.GetReport(); //get robot report log

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            return View(model);
        }
    }
}