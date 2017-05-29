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
	[Register ("TwitterCollectionViewCell")]
	partial class TwitterCollectionViewCell
	{
		[Outlet]
		UIKit.UILabel _entitiesCell { get; set; }

		[Outlet]
		UIKit.UILabel _retweetedCell { get; set; }

		[Outlet]
		UIKit.UILabel _userCell { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_entitiesCell != null) {
				_entitiesCell.Dispose ();
				_entitiesCell = null;
			}

			if (_userCell != null) {
				_userCell.Dispose ();
				_userCell = null;
			}

			if (_retweetedCell != null) {
				_retweetedCell.Dispose ();
				_retweetedCell = null;
			}
		}
	}
}
