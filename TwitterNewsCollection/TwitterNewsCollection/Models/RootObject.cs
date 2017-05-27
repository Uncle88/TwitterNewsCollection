using System;
using System.Collections.Generic;

namespace TwitterNewsCollection.Models
{
    public class RootObject
    {
        public Entities entities { get; set; }
        public User user { get; set; }
        public RetweetedStatus retweeted_status { get; set; }
    }
}
