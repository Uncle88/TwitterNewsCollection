using System;
namespace TwitterNewsCollection.Models
{
    public class RootObject
    {
        public long id { get; set; }
        public string name { get; set; }
        public Entities entities { get; set; }
        public Status status { get; set; }
    }
}
