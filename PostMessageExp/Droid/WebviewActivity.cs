
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace PostMessageExp.Droid
{
    [Activity(Label = "WebviewActivity")]
    public class WebviewActivity : Activity
    {
        int count = 1;

        private string jsonStringToSend = "{\"employees\": [{ \"firstName\":\"John\", \"lastName\":\"Doe\" }, { \"firstName\":\"Anna\" , \"lastName\":\"Smith\" },{ \"firstName\": \"Peter\" , \"lastName\": \"Jones \" }]}";

        WebView webView;
        Dialog dialog;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WebviewActivityLayout);

            Button button = FindViewById<Button>(Resource.Id.myButton);

            webView = FindViewById<WebView>(Resource.Id.webView1);

            AlertDialog.Builder builder = new AlertDialog.Builder(this);
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
                webView.EvaluateJavascript(string.Format("javascript:sendToWebviewContainer('{0}');", jsonStringToSend), null);
            };
            LoadHtml();
        }

        private void LoadHtml()
        {
            webView.LoadUrl("http://www.digitalentitypreview.com/mobileapp/enel/enelenergia/R3/DEMO/postMessageIndex.html");
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
