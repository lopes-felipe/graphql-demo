using Demo.Service.Gateway.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Service.Gateway.Core.Service
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> ListByTitleIdAsync(string titleId);
    }
}
