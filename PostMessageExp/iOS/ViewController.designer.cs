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
	[Register ("ViewController")]
	partial class ViewController
	{
		[Outlet]
		UIKit.UIButton Button { get; set; }

		[Outlet]
		UIKit.UIWebView webView { get; set; }

		[Outlet]
		WebKit.WKWebView wkView { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (webView != null) {
				webView.Dispose ();
				webView = null;
			}

			if (Button != null) {
				Button.Dispose ();
				Button = null;
			}

			if (wkView != null) {
				wkView.Dispose ();
				wkView = null;
			}
		}
	}
}
