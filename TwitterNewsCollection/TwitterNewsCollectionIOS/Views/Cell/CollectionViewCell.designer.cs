// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace TwitterNewsCollectionIOS.Cell
{
	[Register ("CollectionViewCell")]
	partial class CollectionViewCell
	{
		[Outlet]
		UIKit.UILabel entitiesCell { get; set; }

		[Outlet]
		UIKit.UILabel idCell { get; set; }

		[Outlet]
		UIKit.UILabel nameCell { get; set; }

		[Outlet]
		UIKit.UILabel statusCell { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (idCell != null) {
				idCell.Dispose ();
				idCell = null;
			}

			if (nameCell != null) {
				nameCell.Dispose ();
				nameCell = null;
			}

			if (entitiesCell != null) {
				entitiesCell.Dispose ();
				entitiesCell = null;
			}

			if (statusCell != null) {
				statusCell.Dispose ();
				statusCell = null;
			}
		}
	}
}
