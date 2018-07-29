using Demo.Service.Gateway.Core.Service;
using Demo.Service.Gateway.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Service.Gateway.Service
{
    public class TitleService
        : ITitleService
    {
        IEnumerable<Title> _titles = new[]
        {
            new Title
            {
                Id = Guid.Parse("13233e1e-61d9-4e90-b59e-a33c5283f019").ToString(),
                Name = "Muholland Drive",
                ActorsIds = new[] {Guid.Parse("820c4d16-7b93-4d7b-896a-9369767ec628").ToString(), Guid.Parse("6c2cc878-d2eb-4e1e-bf48-1006c251a402").ToString()},
                DirectorsIds = new[] {Guid.Parse("b18e013d-eb03-43b9-b1ab-d47c981081ee").ToString()},
                RealeaseDate = DateTime.Now
            },
            new Title
            {
                Id = Guid.Parse("4dacd4bf-d703-4b7d-888e-bb1722012f02").ToString(),
                Name = "Mother",
                ActorsIds = new[] {Guid.Parse("4c9102d1-1067-46a4-ad52-afdc3a1b183b").ToString(), Guid.Parse("8868a03c-2bb2-4ca9-b96c-f53f0a9a65bb").ToString()},
                DirectorsIds = new[] {Guid.Parse("264cd4d8-03eb-4dab-adae-5fa86340d224").ToString()},
                RealeaseDate = DateTime.Now
            }
        };

        public Task<Title> GetAsync(string id)
        {
            // Calling Titles microservice
            return Task.FromResult(_titles.FirstOrDefault(title => title.Id == id));
        }

        public Task<IEnumerable<Title>> ListAsync(int first)
        {
            // Calling Titles microservice
            return Task.FromResult(_titles.Take(first));
        }

        public Task<IEnumerable<Title>> ListFromPersonId(string personId)
        {
            // Calling Titles microservice
            return Task.FromResult(
                _titles.Where(title => title.ActorsIds.Contains(personId) || title.DirectorsIds.Contains(personId)));
        }
    }
}
