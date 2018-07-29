using Demo.Service.Gateway.Core.Service;
using Demo.Service.Gateway.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Service.Gateway.Service
{
    public class PersonService
        : IPersonService
    {
        private IEnumerable<Person> _persons = new List<Person>
        {
            new Person
            {
                Id = Guid.Parse("b18e013d-eb03-43b9-b1ab-d47c981081ee").ToString(),
                BirthDate = DateTime.Now,
                Name = "David Lynch"
            },
            new Person
            {
                Id = Guid.Parse("264cd4d8-03eb-4dab-adae-5fa86340d224").ToString(),
                BirthDate = DateTime.Now,
                Name = "Darren Aronofsky"
            },
            new Person
            {
                Id = Guid.Parse("820c4d16-7b93-4d7b-896a-9369767ec628").ToString(),
                BirthDate = DateTime.Now,
                Name = "Naomi Watts"
            },
            new Person
            {
                Id = Guid.Parse("6c2cc878-d2eb-4e1e-bf48-1006c251a402").ToString(),
                BirthDate = DateTime.Now,
                Name = "Laura Harring"
            },
            new Person
            {
                Id = Guid.Parse("4c9102d1-1067-46a4-ad52-afdc3a1b183b").ToString(),
                BirthDate = DateTime.Now,
                Name = "Jennifer Lawrence"
            },
            new Person
            {
                Id = Guid.Parse("8868a03c-2bb2-4ca9-b96c-f53f0a9a65bb").ToString(),
                BirthDate = DateTime.Now,
                Name = "Javier Bardem"
            }
        };

        public Task<IEnumerable<Person>> ListByIdsAsync(IEnumerable<string> ids)
        {
            // Calling People microservice
            return Task.FromResult(_persons.Where(person => ids.Contains(person.Id)));
        }
    }
}
