using System;
using System.Collections.Generic;

namespace TwitterNewsCollection.Models
{
	public class RetwittedItem 
	{
		public string text { get; set; }
	}

    public class TwitterNewsResponse
    {
        public List<RetwittedItem> Data { get; set; }
    }
}
