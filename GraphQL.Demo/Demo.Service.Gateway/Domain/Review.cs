using System;

namespace Demo.Service.Gateway.Domain
{
    public class Review
    {
        public string Id { get; set; }

        public string TitleId { get; set; }

        public string UserId { get; set; }

        public int Score { get; set; }

        public string Text { get; set; }
    }
}
