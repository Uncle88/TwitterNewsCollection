// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TwitterNewsCollectionIOS.Views
{
	[Register ("TwitterCollectionCell")]
	partial class TwitterCollectionCell
	{
		[Outlet]
		UIKit.UILabel _descriptionTwit { get; set; }

		[Outlet]
		UIKit.UIImageView _imageTwit { get; set; }

		[Outlet]
		UIKit.UILabel _statusTwit { get; set; }

		[Outlet]
		UIKit.UILabel _textTwit { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_imageTwit != null) {
				_imageTwit.Dispose ();
				_imageTwit = null;
			}

			if (_textTwit != null) {
				_textTwit.Dispose ();
				_textTwit = null;
			}

			if (_descriptionTwit != null) {
				_descriptionTwit.Dispose ();
				_descriptionTwit = null;
			}

			if (_statusTwit != null) {
				_statusTwit.Dispose ();
				_statusTwit = null;
			}
		}
	}
}
