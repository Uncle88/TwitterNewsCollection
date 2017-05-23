using System;
namespace TwitterNewsCollection.Models
{
    public class Status
    {
        public long id { get; set; }
        public Entities2 entities { get; set; }
        public string source { get; set; }
        public RetweetedStatus retweeted_status { get; set; }
    }
}
