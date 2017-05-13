using System;
namespace TwitterNewsCollection.Models
{
    public class RetweetedStatus
    {
        public long id { get; set; }
        public string text { get; set; }
        public Entities3 entities { get; set; }
    }
}
