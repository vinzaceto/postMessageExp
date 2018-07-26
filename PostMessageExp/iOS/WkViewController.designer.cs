// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace PostMessageExp.iOS
{
	[Register ("WkViewController")]
	partial class WkViewController
	{
		[Outlet]
		WebKit.WKWebView webView { get; set; }

		[Outlet]
		UIKit.UIView webViewContainer { get; set; }

		[Action ("buttonAction:")]
		partial void buttonAction (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (webViewContainer != null) {
				webViewContainer.Dispose ();
				webViewContainer = null;
			}

			if (webView != null) {
				webView.Dispose ();
				webView = null;
			}
		}
	}
}
