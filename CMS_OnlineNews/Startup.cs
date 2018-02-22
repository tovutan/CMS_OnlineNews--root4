using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMS_OnlineNews.Startup))]
namespace CMS_OnlineNews
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
