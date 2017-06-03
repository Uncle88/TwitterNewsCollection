using System;
using System.Collections.Generic;
using TwitterNewsCollection.Models;

namespace TwitterNewsCollection.Helpers
{
    public class TwitterEventArgs : EventArgs
    {
        public TwitterEventArgs(List<RootObject> list)
        {
            TwitterObjects = list;
        }

        public List<RootObject> TwitterObjects { get; private set; }
    }
}
