using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using TwitterNewsCollection.Models;
using MvvmCross.Binding.BindingContext;

namespace TwitterNewsCollection.ViewModels
{
    public class ListViewModel : MvxViewModel<RootObject>
    {
        List<RootObject> _rootObj = new List<RootObject>();

        public override Task Initialize(RootObject obj)
        {
            return null;//ShowViewModel();
            //return null;
        }
    }
}
