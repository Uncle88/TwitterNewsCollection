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
	[Register ("CollectionViewCell")]
	partial class CollectionViewCell
	{
		[Outlet]
		UIKit.UILabel _idCell { get; set; }

		[Outlet]
		UIKit.UILabel _retweetedCell { get; set; }

		[Outlet]
		UIKit.UILabel _sourseCell { get; set; }

		[Outlet]
		UIKit.UILabel _textCell { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_idCell != null) {
				_idCell.Dispose ();
				_idCell = null;
			}

			if (_retweetedCell != null) {
				_retweetedCell.Dispose ();
				_retweetedCell = null;
			}

			if (_textCell != null) {
				_textCell.Dispose ();
				_textCell = null;
			}

			if (_sourseCell != null) {
				_sourseCell.Dispose ();
				_sourseCell = null;
			}
		}
	}
}
