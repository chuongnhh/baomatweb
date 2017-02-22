using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(chuongnh.Startup))]
namespace chuongnh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
