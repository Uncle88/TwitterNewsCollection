using System;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Views;
using TwitterNewsCollection.ViewModels;
using UIKit;

namespace TwitterNewsCollectionIOS.Views
{
    public partial class ListView : MvxCollectionViewController
    {
        public ListView() : base("ListView", null)
        {
        }

        public new ListViewModel ViewModel
        {
            get { return (ListViewModel)base.ViewModel; }
            set { base.ViewModel = (IMvxViewModel)value; }
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.CreateBindingSet<ListView, ListViewModel>();

            CollectionView.RegisterNibForCell(TwitterCollectionCell.Nib, TwitterCollectionCell.Key);
            var source = new MvxCollectionViewSource(CollectionView, (Foundation.NSString)TwitterCollectionCell.Key);
            CollectionView.Source = source;

            var set = this.CreateBindingSet<ListView, ListViewModel>();
            //set.Bind(source).To(vm => vm.);
            set.Apply();
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }
    }
}

