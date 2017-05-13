using System;
namespace TwitterNewsCollection.Models
{
    public class Status
    {
        public string created_at { get; set; }
        public long id { get; set; }
        public string id_str { get; set; }
        public string text { get; set; }
        public bool truncated { get; set; }
        public Entities2 entities { get; set; }
        public string source { get; set; }
        public RetweetedStatus retweeted_status { get; set; }
    }
}
