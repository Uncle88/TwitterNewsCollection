// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TwitterNewsCollectionIOS.Views.Cell
{
	[Register ("MyCollectionViewCell")]
	partial class MyCollectionViewCell
	{
		[Outlet]
		UIKit.UILabel _created_atCell { get; set; }

		[Outlet]
		UIKit.UILabel _retweetCell { get; set; }

		[Outlet]
		UIKit.UILabel _textCell { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_textCell != null) {
				_textCell.Dispose ();
				_textCell = null;
			}

			if (_retweetCell != null) {
				_retweetCell.Dispose ();
				_retweetCell = null;
			}

			if (_created_atCell != null) {
				_created_atCell.Dispose ();
				_created_atCell = null;
			}
		}
	}
}
