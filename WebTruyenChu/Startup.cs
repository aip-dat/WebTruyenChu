using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTruyenChu.Startup))]
namespace WebTruyenChu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
