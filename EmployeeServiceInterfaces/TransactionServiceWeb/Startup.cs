using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TransactionServiceWeb.Startup))]
namespace TransactionServiceWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
