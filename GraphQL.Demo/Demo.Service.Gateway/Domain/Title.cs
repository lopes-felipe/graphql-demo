using System;
using System.Collections.Generic;

namespace Demo.Service.Gateway.Domain
{
    public class Title
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime RealeaseDate { get; set; }

        public IEnumerable<string> DirectorsIds { get; set; }

        public IEnumerable<string> ActorsIds { get; set; }
    }
}
