using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using TwitterNewsCollection.Models;
using UIKit;

namespace TwitterNewsCollectionIOS.Views.Cell
{
    public partial class TwitterCollectionViewCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("TwitterCollectionViewCell");
        public static readonly UINib Nib;

        static TwitterCollectionViewCell()
        {
            Nib = UINib.FromName("TwitterCollectionViewCell", NSBundle.MainBundle);
        }

        protected TwitterCollectionViewCell(IntPtr handle) : base(handle)
        {
			{
				this.DelayBind(() =>

				 {
					 var set = this.CreateBindingSet<TwitterCollectionViewCell, RootObject>();
				 set.Bind(_entitiesCell).To(vm => vm.entities);
                 set.Bind(_userCell).To(vm => vm.user);
                 set.Bind(_retweetedCell).To(vm => vm.retweeted_status);
				 set.Apply();
			 });
			}
        }
    }
}
