using Demo.Service.Gateway.Core.Service;
using Demo.Service.Gateway.Schemas;
using Demo.Service.Gateway.Service;
using GraphQL;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.GraphiQL;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.Service.Gateway
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<GatewaySchema>(provider => new GatewaySchema(
                new FuncDependencyResolver(type => provider.GetRequiredService(type)),
                provider.GetRequiredService<GatewayQuery>()));

            services.AddSingleton<GatewayQuery>();

            services.AddSingleton<ITitleService, TitleService>();
            services.AddSingleton<IPersonService, PersonService>();
            services.AddSingleton<IReviewService, ReviewService>();

            services.AddSingleton<TitleType>();
            services.AddSingleton<PersonType>();
            services.AddSingleton<ReviewType>();

            services.AddGraphQLHttp();
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseGraphQLHttp<GatewaySchema>(new GraphQLHttpOptions());
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
            app.UseGraphiQLServer(new GraphiQLOptions());
        }
    }
}
