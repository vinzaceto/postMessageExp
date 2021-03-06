﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Webkit;
using Android.Widget;
using PostMessageExp.Models.WebView;

namespace PostMessageExp.Droid
{
    [Activity(Label = "WebviewActivity")]
    public class WebviewActivity : Activity, CustomWebviewInterface
    {
        int count = 1;

        private string jsonStringToSend = "{\"employees\": [{ \"firstName\":\"John\", \"lastName\":\"Doe\" }, { \"firstName\":\"Anna\" , \"lastName\":\"Smith\" },{ \"firstName\": \"Peter\" , \"lastName\": \"Jones \" }]}";

        WebView webView;
        Dialog dialog;
        Dialog loader;
        private CustomWebviewManager _manager;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WebviewActivityLayout);

            Button button = FindViewById<Button>(Resource.Id.myButton);
            webView = FindViewById<WebView>(Resource.Id.webView1);

            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            builder.SetView(Resource.Layout.Loader);
            loader = builder.Create();

            AlertDialog.Builder loaderBuilder = new AlertDialog.Builder(this);
            dialog = loaderBuilder.Create();

            button.Click += delegate
            {
                EvaluateJavascript(jsonStringToSend);
            };

            SetManager();
        }

        internal void OnCallBackJS(MessageJson messageJson)
        {
            if (messageJson != null)
            {
                if (messageJson.message.RequestAction.Equals("stopLoading"))
                {
                    ShowLoader(false, 0);
                }
                else if (messageJson.message.RequestAction.Equals("startLoading"))
                {
                    ShowLoader(true, 0);
                }
                else
                {
                    //TODO
                }
            }
        }

        internal void OnHtmlLoadCompletedCAllBack()
        {
            //Send InitContainer request
            _manager.SendInitContainer();
        }

        private async Task SetManager()
        {
            _manager = new CustomWebviewManager();
            _manager.SetIntInstance(this);
            var container = new ContainerWebView();
            _manager.GetConfigurations(container);
        }


        #region IMPLEMENT CustomWebViewInterface
        public void ShowLoader(bool IsVisible, int timeout)
        {
            RunOnUiThread(() =>
            {
                if (IsVisible) loader.Show();
                else loader.Dismiss();
            });
        }

        public void ShowDialog(bool IsVisible, string message)
        {
            RunOnUiThread(() =>
            {
                if (IsVisible) dialog.Show();
                else dialog.Dismiss();
                dialog.SetTitle(message);
            });
        }

        public void ShowThankYouPage()
        {
            throw new NotImplementedException();
        }

        public void EvaluateJavascript(string command)
        {
            webView.EvaluateJavascript(string.Format("javascript:sendToWebviewContainer('{0}');", command), null);
        }

        public void InitWebView(ConfigurationWebView command)
        {
            webView.ClearCache(true);
            webView.ClearHistory();
            webView.Settings.JavaScriptEnabled = true;
            webView.Settings.JavaScriptCanOpenWindowsAutomatically = true;
            webView.SetWebChromeClient(new WebChromeClient());
            webView.AddJavascriptInterface(new WebViewJSInterface(this), "WebViewJSInterface");

            webView.LoadUrl(command.URL);
        }

        public void SendToContainer(string json)
        {
            RunOnUiThread(() =>
            {
            webView.EvaluateJavascript(string.Format("javascript:sendToWebviewContainer('{0}');", json), null);
            });
        }

        internal void OnCallBackJS()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
