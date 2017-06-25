using System;
using System.Collections.Generic;
using TwitterNewsCollection.Models;

namespace TwitterNewsCollection.Helpers
{
    public class TwitterEventArgs : EventArgs
    {
        public TwitterEventArgs(List<TwitterNewsResponse> list)
        {
            TwitterObjects = list;
        }

        public List<TwitterNewsResponse> TwitterObjects { get; private set; }
    }
}
