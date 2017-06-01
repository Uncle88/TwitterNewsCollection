using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using TwitterNewsCollection.Models;
using UIKit;

namespace TwitterNewsCollectionIOS.Views.Cell
{
    public partial class MyCollectionViewCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("MyCollectionViewCell");
        public static readonly UINib Nib;

        static MyCollectionViewCell()
        {
            Nib = UINib.FromName("MyCollectionViewCell", NSBundle.MainBundle);
        }

        protected MyCollectionViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<MyCollectionViewCell, RootObject>();
                set.Bind(_textCell).To(vm => vm.text);
                set.Bind(_retweetCell).To(vm => vm.retweet_count);
                set.Bind(_created_atCell).To(vm => vm.created_at);
                set.Apply();
            });
        }
    }
}
