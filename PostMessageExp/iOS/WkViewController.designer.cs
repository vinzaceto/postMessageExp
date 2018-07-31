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
		UIKit.UIActivityIndicatorView activityIndicator { get; set; }

		[Outlet]
		WebKit.WKWebView webView { get; set; }

		[Outlet]
		UIKit.UIView webViewContainer { get; set; }

		[Action ("buttonAction:")]
		partial void buttonAction (UIKit.UIButton sender);

		[Action ("CloseMe:")]
		partial void CloseMe (UIKit.UIButton sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (activityIndicator != null) {
				activityIndicator.Dispose ();
				activityIndicator = null;
			}

			if (webView != null) {
				webView.Dispose ();
				webView = null;
			}

			if (webViewContainer != null) {
				webViewContainer.Dispose ();
				webViewContainer = null;
			}
		}
	}
}
