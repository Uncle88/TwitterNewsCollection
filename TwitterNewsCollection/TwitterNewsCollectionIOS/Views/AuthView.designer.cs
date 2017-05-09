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
	[Register ("AuthView")]
	partial class AuthView
	{
		[Outlet]
		UIKit.UIButton authButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (authButton != null) {
				authButton.Dispose ();
				authButton = null;
			}
		}
	}
}
