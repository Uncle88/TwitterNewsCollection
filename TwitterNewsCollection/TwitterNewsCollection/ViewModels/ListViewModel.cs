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
        public ListViewModel()
        {
            //List<RootObject> _rootObj = new List<RootObject>()
            //    {
            //new RootObject() { id = 545, name = "Ivan" },
            //new RootObject() { id= 68685 ,name = "Petr" },
            //new RootObject() {id = 567473, name = "Matvey" }
            //};
        }

        public override Task Initialize(RootObject obj)
        {
            return null;
        }

        private List<RootObject> _rootObj = null;
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
