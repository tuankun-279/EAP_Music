using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EAP_Music_Tên_Tuấn.Startup))]
namespace EAP_Music_Tên_Tuấn
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
