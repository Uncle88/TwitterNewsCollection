using System;

using Foundation;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;
using TwitterNewsCollection.Models;

namespace TwitterNewsCollectionIOS.Views
{
    public partial class TwitterCollectionCell : MvxCollectionViewCell
    {
        public static readonly NSString Key = new NSString("TwitterCollectionCell");
        public static readonly UINib Nib;

        public UIImage ImageTwit
        {
            get { return _imageTwit.Image; }
            set { _imageTwit.Image = value; }
        }

        public string TextTwit
        {
            get { return _textTwit.Text; }
            set { _textTwit.Text = value; }
        }

        public string DescriptionTwit
        {
            get { return _descriptionTwit.Text; }
            set { _descriptionTwit.Text = value; }
        }

        public string StatusTwit
        {
            get { return _statusTwit.Text; }
            set { _statusTwit.Text = value; }
        }

        static TwitterCollectionCell()
        {
            Nib = UINib.FromName("TwitterCollectionCell", NSBundle.MainBundle);
        }

        protected TwitterCollectionCell(IntPtr handle) : base(handle)
        {
            this.DelayBind(() =>
            {
                var set = this.CreateBindingSet<TwitterCollectionCell, RootObject>();
                set.Bind(_imageTwit).To(vm => vm.status);
                set.Bind(_textTwit).To(vm => vm.entities);
                set.Bind(_descriptionTwit).To(vm => vm.name);
                set.Bind(_statusTwit).To(vm => vm.screen_name);
                set.Apply();
                set.Apply();
            });
        }
    }
}
