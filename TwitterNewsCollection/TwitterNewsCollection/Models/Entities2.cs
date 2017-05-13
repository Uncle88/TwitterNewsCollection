using System;
using System.Collections.Generic;

namespace TwitterNewsCollection.Models
{
    public class Entities2
    {
        public List<Hashtag> hashtags { get; set; }
        public List<UserMention> user_mentions { get; set; }
    }
}