using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookATableWeb.Startup))]
namespace BookATableWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
