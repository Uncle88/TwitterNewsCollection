using System;
using System.Collections.Generic;
using TwitterNewsCollection.Models;

namespace TwitterNewsCollection.Helpers
{
    public class TwitterEventArgs : EventArgs
    {
        public TwitterEventArgs(List<RetwittedItem> list)
        {
            TwitterObjects = list;
        }

        public List<RetwittedItem> TwitterObjects { get; private set; }
    }
}
