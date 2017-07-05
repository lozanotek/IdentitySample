using IdentityProvider.Security;
using IdentityProvider.Services;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Services;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(IdentityProvider.Startup))]

namespace IdentityProvider
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var factory = new IdentityServerServiceFactory()
                                //.UseInMemoryUsers(Users.Get())
                                .UseInMemoryClients(Clients.Get())
                                .UseInMemoryScopes(Scopes.Get());

            factory.UserService = new Registration<IUserService, IdentityUserService>();

            var options = new IdentityServerOptions
            {
                RequireSsl = false,
                SigningCertificate = Cert.Load(),
                Factory = factory
            };

            app.Map("/identity", idsrvApp =>
            {
                idsrvApp.UseIdentityServer(options);
            });
        }
    }
}
