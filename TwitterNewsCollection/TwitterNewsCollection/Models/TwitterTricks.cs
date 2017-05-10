using System;
namespace TwitterNewsCollection.Models
{
    public class TwitterTricks
    {
        public string Id { get; set; }
        public string Value { get; set; }
        public string ImageUri { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
