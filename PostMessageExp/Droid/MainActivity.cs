using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using Java.Lang;

namespace PostMessageExp.Droid
{
    [Activity(Label = "PostMessageExp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        WebView webView;
        ProgressDialog mDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            webView = FindViewById<WebView>(Resource.Id.webView1);

            mDialog = new ProgressDialog(this);
            mDialog.SetMessage("Please wait...");
            mDialog.SetCancelable(false);

            webView.ClearCache(true);
            webView.ClearHistory();
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.JavaScriptCanOpenWindowsAutomatically = true;
            webView.SetWebChromeClient(new WebChromeClient());
            webView.AddJavascriptInterface(new JSI(this), "MyJSInterface");


            button.Click += delegate { 
                button.Text = $"{count++} clicks!"; 
                webView.EvaluateJavascript(string.Format("javascript:PostMessageForAlert('{0}');", "ciao alert"),null);
            };
            LoadHtml();
        }

        private void LoadHtml()
        {
            webView.LoadUrl("file:///android_asset/index.html");
        }

        public void showLoader(bool show)
        {
            RunOnUiThread(() => {
                if (mDialog != null)
                {
                    if (show)
                    {
                        mDialog.Show();
                    }
                    else
                    {
                        mDialog.Dismiss();
                    }
                }
            });
                
            }
    }
}

