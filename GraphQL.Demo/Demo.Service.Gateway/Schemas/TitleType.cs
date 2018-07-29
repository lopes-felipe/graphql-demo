using Demo.Service.Gateway.Core.Service;
using Demo.Service.Gateway.Domain;
using GraphQL.Types;

namespace Demo.Service.Gateway.Schemas
{
    public class TitleType 
        : ObjectGraphType<Title>
    {
        public TitleType(IPersonService personService, IReviewService reviewService)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.RealeaseDate);
            
            Field<ListGraphType<PersonType>>("directors",
                resolve: context => personService.ListByIdsAsync(context.Source.DirectorsIds));

            Field<ListGraphType<PersonType>>("actors",
                resolve: context => personService.ListByIdsAsync(context.Source.ActorsIds));

            Field<ListGraphType<ReviewType>>("reviews",
                resolve: context => reviewService.ListByTitleIdAsync(context.Source.Id));
        }
    }
}
