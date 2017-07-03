using System;
using System.Collections.Generic;

namespace TwitterNewsCollection.Models
{
	public class TwitterNewsResponse // it is model for retwitted item
	{
		public string text { get; set; }
	}

    public class TwitterData //it is response
    {
        public List<TwitterNewsResponse> Data { get; set; }
    }
}
