using System.ComponentModel.DataAnnotations;

namespace Robot.Web.Models
{
    public class HomeModel
    {
        [Required(ErrorMessage = "Please enter a command for robot")]
        public string Input { get; set; }
        public ResultModel Result { get; set; }
    }

    public class ResultModel
    {
        public string Output;
    }
}