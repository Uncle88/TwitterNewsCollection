using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using TwitterNewsCollection.Models;
using MvvmCross.Binding.BindingContext;
using System.Diagnostics.Contracts;

namespace TwitterNewsCollection.ViewModels
{
    public class ListViewModel : MvxViewModel<List<RootObject>>
    {
        public List<RootObject> RootObj { get; private set; }

        public override Task Initialize(List<RootObject> parameter)
        {
            RootObj = parameter;
            return null;
        }
    }
}
