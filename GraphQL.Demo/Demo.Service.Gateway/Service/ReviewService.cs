using Demo.Service.Gateway.Core.Service;
using Demo.Service.Gateway.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Service.Gateway.Service
{
    public class ReviewService
        : IReviewService
    {
        IEnumerable<Review> _reviews = new List<Review>
        {
            new Review
            {
                Id = Guid.NewGuid().ToString(),
                Score = 10,
                Text = "Loved it!",
                TitleId = Guid.Parse("13233e1e-61d9-4e90-b59e-a33c5283f019").ToString(),
                UserId = Guid.NewGuid().ToString()
            },
            new Review
            {
                Id = Guid.NewGuid().ToString(),
                Score = 9,
                Text = "Awesome!",
                TitleId = Guid.Parse("13233e1e-61d9-4e90-b59e-a33c5283f019").ToString(),
                UserId = Guid.NewGuid().ToString()
            },
            new Review
            {
                Id = Guid.NewGuid().ToString(),
                Score = 10,
                Text = "Best movie ever!",
                TitleId = Guid.Parse("4dacd4bf-d703-4b7d-888e-bb1722012f02").ToString(),
                UserId = Guid.NewGuid().ToString()
            },
            new Review
            {
                Id = Guid.NewGuid().ToString(),
                Score = 11,
                Text = "OMFG!",
                TitleId = Guid.Parse("4dacd4bf-d703-4b7d-888e-bb1722012f02").ToString(),
                UserId = Guid.NewGuid().ToString()
            }
        };

        public Task<IEnumerable<Review>> ListByTitleIdAsync(string titleId)
        {
            // Calling Reviews microservice
            return Task.FromResult(_reviews.Where(review => review.TitleId == titleId));
        }
    }
}
