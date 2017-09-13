using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GestionDieta.Startup))]
namespace GestionDieta
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
