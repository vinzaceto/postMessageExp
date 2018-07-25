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

      var webViewDelegate = new PostMessageWebViewDelegate(this.webView);
      webView.Delegate = webViewDelegate;

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

  public class PostMessageWebViewDelegate : UIWebViewDelegate
  {
    private UIWebView _webView;

    public PostMessageWebViewDelegate(UIWebView webView) : base()
    {
      this._webView = webView;
    }

    public override void LoadingFinished(UIWebView webView)
    {
      if (webView.IsLoading)
      {
        return;
      }
    }

    public override bool ShouldStartLoad(UIWebView webView, NSUrlRequest request, UIWebViewNavigationType navigationType)
    {
      NSUrl url = request.Url;
      if (url.Scheme == "postmesssageiscalling")
      {
        System.Diagnostics.Debug.WriteLine("Chiamato");
      }
      else if (url.Scheme == "updategraphgc")
      {
      }

      return true;
    }
  }
}