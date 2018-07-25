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

        private string jsonStringToSend = "{\"employees\": [{ \"firstName\":\"John\", \"lastName\":\"Doe\" }, { \"firstName\":\"Anna\" , \"lastName\":\"Smith\" },{ \"firstName\": \"Peter\" , \"lastName\": \"Jones \" }]}";

        WebView webView;
        Dialog dialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);
            webView = FindViewById<WebView>(Resource.Id.webView1);

            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            //View view = getLayoutInflater().inflate(R.layout.progress);
            builder.SetView(Resource.Layout.Loader);
            dialog = builder.Create();

            webView.ClearCache(true);
            webView.ClearHistory();
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.JavaScriptCanOpenWindowsAutomatically = true;
            webView.SetWebChromeClient(new WebChromeClient());
            webView.AddJavascriptInterface(new JSI(this), "MyJSInterface");


            button.Click += delegate { 
                button.Text = $"{count++} clicks!"; 
                webView.EvaluateJavascript(string.Format("javascript:PostMessageForAlert('{0}');", jsonStringToSend),null);
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
                if (show) dialog.Show();
                else dialog.Dismiss();
            });
                
        }
    }
}

