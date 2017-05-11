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
	[Register ("ListView")]
	partial class ListView
	{
		[Outlet]
		UIKit.UICollectionView _twitterList { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (_twitterList != null) {
				_twitterList.Dispose ();
				_twitterList = null;
			}
		}
	}
}
