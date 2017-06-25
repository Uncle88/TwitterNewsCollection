using System;
using System.Collections.Generic;

namespace TwitterNewsCollection.Models
{
    public class Thumb
	{
	}

	public class Small
	{
	}

	public class Medium2
	{
	}

	public class Large
	{
	}

	public class Sizes
	{
		public Thumb thumb { get; set; }
		public Small small { get; set; }
		public Medium2 medium { get; set; }
		public Large large { get; set; }
	}

	public class Medium
	{
		public Sizes sizes { get; set; }
	}

	public class Entities
	{
		public List<Medium> media { get; set; }
	}

	public class Description
	{
		public List<object> urls { get; set; }
	}

	public class Entities2
	{
		public Description description { get; set; }
	}

	public class User
	{
		public Entities2 entities { get; set; }
	}

	public class Small2
	{
	}

	public class Medium4
	{
	}

	public class Thumb2
	{
	}

	public class Large2
	{
	}

	public class Sizes2
	{
		public Small2 small { get; set; }
		public Medium4 medium { get; set; }
		public Thumb2 thumb { get; set; }
		public Large2 large { get; set; }
	}

	public class Medium3
	{
		public List<int> indices { get; set; }
		public Sizes2 sizes { get; set; }
	}

	public class Entities3
	{
		public List<Medium3> media { get; set; }
	}

	public class Url2
	{
	}

	public class Url
	{
		public List<Url2> urls { get; set; }
	}

	public class Description2
	{
		public List<object> urls { get; set; }
	}

	public class Entities4
	{
		public Url url { get; set; }
		public Description2 description { get; set; }
	}

	public class User2
	{
		public Entities4 entities { get; set; }
	}

	public class Small3
	{
	}

	public class Medium6
	{
	}

	public class Thumb3
	{
	}

	public class Large3
	{
	}

	public class Sizes3
	{
		public Small3 small { get; set; }
		public Medium6 medium { get; set; }
		public Thumb3 thumb { get; set; }
		public Large3 large { get; set; }
	}

	public class Medium5
	{
		public Sizes3 sizes { get; set; }
	}

	public class ExtendedEntities
	{
		public List<Medium5> media { get; set; }
	}

	public class RetweetedStatus
	{
		public Entities3 entities { get; set; }
		public User2 user { get; set; }
		public ExtendedEntities extended_entities { get; set; }
	}

	public class Thumb4
	{
	}

	public class Small4
	{
	}

	public class Medium8
	{
	}

	public class Large4
	{
	}

	public class Sizes4
	{
		public Thumb4 thumb { get; set; }
		public Small4 small { get; set; }
		public Medium8 medium { get; set; }
		public Large4 large { get; set; }
	}

	public class Medium7
	{
		public Sizes4 sizes { get; set; }
	}

	public class ExtendedEntities2
	{
		public List<Medium7> media { get; set; }
	}

	public class TwitterNewsResponse
	{
		public string text { get; set; }
		public Entities entities { get; set; }
		public User user { get; set; }
		public RetweetedStatus retweeted_status { get; set; }
		public ExtendedEntities2 extended_entities { get; set; }
	}

    public class TwitterData
    {
        public List<TwitterNewsResponse> Data { get; set; }
    }
}
