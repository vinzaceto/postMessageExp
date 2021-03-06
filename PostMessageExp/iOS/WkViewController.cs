// This file has been autogenerated from a class added in the UI designer.

using System;
using System.Threading.Tasks;
using Foundation;
using PostMessageExp.Helpers;
using PostMessageExp.Models.WebView;
using UIKit;
using WebKit;

namespace PostMessageExp.iOS
{
  public partial class WkViewController : UIViewController, CustomWebviewInterface
  {
    private const string jsonStringToSend = "{\"employees\": [{ \"firstName\":\"John\", \"lastName\":\"Doe\" }, { \"firstName\":\"Anna\" , \"lastName\":\"Smith\" },{ \"firstName\": \"Peter\" , \"lastName\": \"Jones \" }]}";

    WeakReference<WKWebView> _pageReference;
    private WKWebView wkWebview
    {
      get
      {
        WKWebView _page = null;
        _pageReference.TryGetTarget(out _page);
        return _page;
      }
      set
      {
        _pageReference = new WeakReference<WKWebView>(value);
      }
    }
    
    public string url;
    private CustomWebviewManager _webViewManager;

    public WkViewController(IntPtr handle) : base(handle)
    {
    }

    public override async void ViewDidLoad()
    {
      base.ViewDidLoad();

      var scriptDelegate = new WkPostMessageScriptMessageHandler(this);

      WKUserContentController contentController = new WKUserContentController();
      contentController.AddScriptMessageHandler(scriptDelegate, "sendToApp");
      contentController.AddScriptMessageHandler(scriptDelegate, "onHtmlLoadCompleted");

      WKWebViewConfiguration config = new WKWebViewConfiguration();
      config.UserContentController = contentController;

      wkWebview = new WKWebView(webViewContainer.Frame, config);
      webViewContainer.AddSubview(wkWebview);

      var wkUIDelegate = new PostMessageWkWebViewDelegate();
      wkUIDelegate.ParentController = this;
      wkWebview.UIDelegate = wkUIDelegate;
      
      var navigationDelegate = new PostMessageNavigationDelegate();
      wkWebview.NavigationDelegate = navigationDelegate;

      activityIndicator.Hidden = true;
      
      await SetManager();
    }

    private async Task SetManager()
    {
		  _webViewManager = new CustomWebviewManager();
      _webViewManager.SetIntInstance(this);
      var container = new ContainerWebView();
      _webViewManager.GetConfigurations(container);
    }

    private void LoadHtml()
    {
      string fileName = "PosteMessage/index"; // remember case-sensitive
      string localHtmlUrl = NSBundle.MainBundle.PathForResource(fileName, "html");

      string remoteUrl = string.IsNullOrEmpty(this.url) ? "http://www.digitalentitypreview.com/mobileapp/enel/enelenergia/R3/DEMO/postMessageIndex.html" : this.url;
      var url = new NSUrl(localHtmlUrl, false);
      
      var url2 = new NSUrl(remoteUrl);
      wkWebview.LoadRequest(new NSUrlRequest(url2));
    }

    public void PageHasBeenLoaded()
    {
      // TODO: stop the loader and send the JSON of the init     
      System.Diagnostics.Debug.WriteLine("pagina caricata");
      _webViewManager.SendInitContainer();
    }

    partial void buttonAction(UIButton sender)
    {
      this.EvaluateJavascript("non usato per ora");
    }

    public void ShowLoader(bool IsVisible, int timeout)
    {
      activityIndicator.Hidden = !IsVisible;
      if (IsVisible)
      {
        this.activityIndicator.StartAnimating();
      }
      else
      {
        this.activityIndicator.StopAnimating();
      }
    }

    public void ShowThankYouPage( /*ThankYouModel model*/)
    {
      this.activityIndicator.StartAnimating();
    }

    public void EvaluateJavascript(String command)
    {
      wkWebview.EvaluateJavaScript(string.Format("sendToWebviewContainer('{0}');", jsonStringToSend), null);
    }

    public void SendToContainer(string json)
    {
      wkWebview.EvaluateJavaScript(string.Format("sendToWebviewContainer('{0}');", json), null);
    }

    public void InitWebView(ConfigurationWebView command)
    {
      this.url = command.URL;
      LoadHtml();
    }

    partial void CloseMe(UIButton sender)
    {
      wkWebview.RemoveFromSuperview();
      wkWebview.Dispose();
      wkWebview = null;
      
      _webViewManager = null;
      
      DismissViewController(true, null);
    }

    // Questo deve essere sempre chiamato se l'oggetto e' distrutto
    protected override void Dispose(bool disposing)
    {
      base.Dispose(disposing);
      Console.WriteLine("WkWebViewController has been disposed");
    }
  }

  public class PostMessageWkWebViewDelegate : WKUIDelegate
  {
    WeakReference<UIViewController> _pageReference;
    public UIViewController ParentController
    {
      get
      {
        UIViewController _page = null;
        _pageReference.TryGetTarget(out _page);
        return _page;
      }
      set
      {
        _pageReference = new WeakReference<UIViewController>(value);
      }
    }

    public override void RunJavaScriptAlertPanel(WKWebView webView, string message, WKFrameInfo frame, Action completionHandler)
    {
      var alert = UIAlertController.Create("Alert", message, UIAlertControllerStyle.Alert);
      alert.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

      // Let javascript handle the OK click by passing the completionHandler to the controller
      ParentController.PresentViewController(alert, true, completionHandler);
    }
  }

  public class WkPostMessageScriptMessageHandler : WKScriptMessageHandler
  {
    WeakReference<WkViewController> _pageReference;
    public WkViewController FatherVC
    {
      get
      {
        WkViewController _page = null;
        _pageReference.TryGetTarget(out _page);
        return _page;
      }
      set
      {
        _pageReference = new WeakReference<WkViewController>(value);
      }
    }

    public WkPostMessageScriptMessageHandler(WkViewController parent)
    {
      FatherVC = parent;
    }
    
    public override void DidReceiveScriptMessage(WKUserContentController userContentController, WKScriptMessage message)
    {
      if (message.Name == "sendToApp")
      {
        var arguments = message.Body;
        System.Diagnostics.Debug.WriteLine("Contenuto arrivato " + arguments);
        
        var model = CustomWebviewHelper.JsonToModelIOS(arguments.ToString());
        if (model.message.RequestAction == "stopLoading")
        {
          FatherVC.ShowLoader(IsVisible: false, timeout: 10);
        }
      }
      else if (message.Name == "onHtmlLoadCompleted")
      {
        FatherVC.PageHasBeenLoaded();
      }
    }
  }

  public class PostMessageNavigationDelegate : WKNavigationDelegate
  {
    public override void DidFinishNavigation(WKWebView webView, WKNavigation navigation)
    {
      System.Diagnostics.Debug.WriteLine("Web view page has been loaded");
    }
  }
}
