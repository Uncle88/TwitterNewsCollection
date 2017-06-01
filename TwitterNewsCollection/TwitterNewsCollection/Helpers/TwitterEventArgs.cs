using System;
using System.Collections.Generic;
using TwitterNewsCollection.Models;

namespace TwitterNewsCollection.Helpers
{
    public class TwitterEventArgs : EventArgs
    {
		public TwitterEventArgs()
        {
            List<RootObject> _rootObj = new List<RootObject>();
        }

        public List<RootObject> _rootObj;

    }
}
