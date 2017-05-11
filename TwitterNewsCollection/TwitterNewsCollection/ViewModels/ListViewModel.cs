using System;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using TwitterNewsCollection.Models;

namespace TwitterNewsCollection.ViewModels
{
    public class ListViewModel : MvxViewModel<TwitterTricks>
    {
        public ListViewModel()
        {
        }

        public override Task Initialize(TwitterTricks parameter)
        {
            return null;
        }
    }
}
