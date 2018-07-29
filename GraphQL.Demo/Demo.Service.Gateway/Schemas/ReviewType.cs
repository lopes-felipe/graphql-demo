using System.Threading.Tasks;
using Demo.Service.Gateway.Core.Service;
using Demo.Service.Gateway.Domain;
using GraphQL.Types;

namespace Demo.Service.Gateway.Schemas
{
    public class ReviewType
        : ObjectGraphType<Review>
    {
        public ReviewType(ITitleService titleService)
        {
            Field(x => x.Id);
            Field(x => x.Score);
            Field(x => x.Text);
            Field(x => x.TitleId);
            Field(x => x.UserId);

            Field<TitleType>("title",
                resolve: context => titleService.GetAsync(context.Source.TitleId));
        }
    }
}
