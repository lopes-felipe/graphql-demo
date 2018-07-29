using Demo.Service.Gateway.Core.Service;
using GraphQL.Types;
using System;

namespace Demo.Service.Gateway.Schemas
{
    public class GatewayQuery 
        : ObjectGraphType
    {
        public GatewayQuery(ITitleService titleService)
        {
            AddTitleFields(titleService);
        }

        private void AddTitleFields(ITitleService titleService)
        {
            Field<ListGraphType<TitleType>>("titles",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "first", DefaultValue = 10 }),
                resolve: context =>
                {
                    int first = context.GetArgument<int>("first");
                    return titleService.ListAsync(first);
                });

            Field<TitleType>("title",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    string id = context.GetArgument<string>("id");
                    return titleService.GetAsync(Guid.Parse(id).ToString());
                });
        }
    }
}
