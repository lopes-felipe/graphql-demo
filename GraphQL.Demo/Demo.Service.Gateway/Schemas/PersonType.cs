using Demo.Service.Gateway.Core.Service;
using Demo.Service.Gateway.Domain;
using GraphQL.Types;

namespace Demo.Service.Gateway.Schemas
{
    public class PersonType 
        : ObjectGraphType<Person>
    {
        public PersonType(ITitleService titleService)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.BirthDate);

            Field<ListGraphType<TitleType>>("movies",
                resolve: context => titleService.ListFromPersonId(context.Source.Id));
        }
    }
}
