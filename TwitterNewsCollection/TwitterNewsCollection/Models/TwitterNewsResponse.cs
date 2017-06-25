using System;
using System.Collections.Generic;

namespace TwitterNewsCollection.Models
{
	public class TwitterNewsResponse
	{
		public string text { get; set; }
	}

    public class TwitterData
    {
        public List<TwitterNewsResponse> Data { get; set; }
    }
}
