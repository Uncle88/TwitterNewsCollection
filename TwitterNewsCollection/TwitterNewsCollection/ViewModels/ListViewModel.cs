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
        { return null; }

        public ListViewModel()
        {
			_rootObj = new List<RootObject>
            {
                    new RootObject() { text = "Ahtung",  retweet_count = 2 , created_at = "today"},
                    new RootObject() { text = "Ahtung2", retweet_count = 46 , created_at="tonight"},
                    new RootObject() { text = "Ahtung3", retweet_count = 132 , created_at="yesterday"},
             };
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
