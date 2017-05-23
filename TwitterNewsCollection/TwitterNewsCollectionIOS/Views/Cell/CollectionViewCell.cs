using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using TwitterNewsCollection.Models;

namespace TwitterNewsCollectionIOS.Cell
{
    public partial class CollectionViewCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("CollectionViewCell");
        public static readonly UINib Nib;

        static CollectionViewCell()
        {
            Nib = UINib.FromName("CollectionViewCell", NSBundle.MainBundle);
        }

        protected CollectionViewCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>

             {
                 var set = this.CreateBindingSet<CollectionViewCell, RootObject>();
                 set.Bind(idCell).To(vm => vm.id);
                 set.Bind(nameCell).To(vm => vm.name);
                 set.Bind(entitiesCell).To(vm => vm.entities);
                 set.Bind(statusCell).To(vm => vm.status);
                 set.Apply();
             });
        }
    }
}
