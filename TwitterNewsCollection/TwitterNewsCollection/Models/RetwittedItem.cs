using System;
using System.Collections.Generic;

namespace TwitterNewsCollection.Models
{
	public class RetwittedItem 
	{
		public string Text { get; set; }
	}

    public class TwitterNewsResponse
    {
        public List<RetwittedItem> Data { get; set; }
    }
}
