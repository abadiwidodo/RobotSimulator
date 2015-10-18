using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Robot.Web.Startup))]
namespace Robot.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
