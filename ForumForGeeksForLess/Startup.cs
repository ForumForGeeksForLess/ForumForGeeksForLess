using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ForumForGeeksForLess.Startup))]
namespace ForumForGeeksForLess
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
