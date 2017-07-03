using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using TwitterNewsCollection.Models;
using UIKit;

namespace TwitterNewsCollectionIOS.Views.Cell
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
                var set = this.CreateBindingSet<CollectionViewCell, TwitterNewsResponse>();
				set.Bind(_textCell).To(vm => vm.text);
				set.Apply();
			});
		}
	}
}
