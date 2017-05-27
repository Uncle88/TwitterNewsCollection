using System;
namespace TwitterNewsCollection.Models
{
    public class RetweetedStatus
    {
        public string created_at { get; set; }
        public Entities3 entities { get; set; }
        public string source { get; set; }
        public User2 user { get; set; }
    }
}
