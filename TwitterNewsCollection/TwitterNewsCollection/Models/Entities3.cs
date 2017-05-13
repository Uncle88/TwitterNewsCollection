using System;
using System.Collections.Generic;

namespace TwitterNewsCollection.Models
{
    public class Entities3
    {
        public List<Hashtag2> hashtags { get; set; }
        public List<UserMention2> user_mentions { get; set; }
        public List<Url> urls { get; set; }

    }
}