using System;
using Foundation;
using UIKit;

namespace PostMessageExp.iOS
{
    public partial class ViewController : UIViewController
    {
        int count = 1;

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            // Perform any additional setup after loading the view, typically from a nib.
            Button.AccessibilityIdentifier = "myButton";
            Button.TouchUpInside += delegate
            {
                var title = string.Format("{0} clicks!", count++);
                Button.SetTitle(title, UIControlState.Normal);

                webView.EvaluateJavascript(string.Format("javascript:PostMessageForAlert('{0}');", "ciao alert"));
            };

            LoadHtml();
        }

        private void LoadHtml()
        {
            string fileName = "PosteMessage/index"; // remember case-sensitive
            string localHtmlUrl = NSBundle.MainBundle.PathForResource(fileName, "html");
            webView.ScrollView.ScrollEnabled = false;

            var url = new NSUrl(localHtmlUrl, false);
            webView.LoadRequest(new NSUrlRequest(url));
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.        
        }
    }
}
