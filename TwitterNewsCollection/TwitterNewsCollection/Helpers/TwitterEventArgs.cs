using System;
using System.Collections.Generic;
using TwitterNewsCollection.Models;

namespace TwitterNewsCollection.Helpers
{
    public class TwitterEventArgs : EventArgs
    {
        public TwitterEventArgs(object sender, EventArgs e)
        {
            List<RootObject> _rootObj = new List<RootObject>();
        }
    }
}
