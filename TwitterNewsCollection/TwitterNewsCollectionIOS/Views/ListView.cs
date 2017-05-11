using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using TwitterNewsCollection.ViewModels;
using UIKit;

namespace TwitterNewsCollectionIOS.Views
{
    public partial class ListView : MvxViewController
    {
        public ListView() : base("ListView", null)
        {
        }

        public new ListViewModel ViewModel
        {
            get { return (ListViewModel)base.ViewModel; }
            set { base.ViewModel = (MvvmCross.Core.ViewModels.IMvxViewModel)value; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.CreateBindingSet<ListView, ListViewModel>();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}

