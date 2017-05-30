using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using TwitterNewsCollection.Models;
using MvvmCross.Binding.BindingContext;
using System.Diagnostics.Contracts;

namespace TwitterNewsCollection.ViewModels
{
    public class ListViewModel : MvxViewModel<RootObject>
    {
        public override Task Initialize(RootObject obj)
        {
            return null;
        }
		public List<RootObject> _rootObj;
		public List<RootObject> RootObj
		{
		  get { return _rootObj; }
		  set
		  {
		      _rootObj = value;
		      RaisePropertyChanged(() => RootObj);
		  }
		}
	}
}
