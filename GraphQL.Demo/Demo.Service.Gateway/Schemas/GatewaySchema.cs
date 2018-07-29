using Demo.Service.Gateway.Core.Service;
using GraphQL;
using GraphQL.Types;

namespace Demo.Service.Gateway.Schemas
{
    public class GatewaySchema 
        : Schema
    {
        public GatewaySchema(IDependencyResolver dependencyResolver, GatewayQuery query)
            : base(dependencyResolver)
        {
            Query = query;
        }
    }
}
