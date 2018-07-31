using Android.Webkit;
using Java.Interop;
using PostMessageExp.Helpers;

namespace PostMessageExp.Droid
{
    
    public class WebViewJSInterface : Java.Lang.Object
    {
        private WebviewActivity _activity;

        public WebViewJSInterface(WebviewActivity activity)
        {
            _activity = activity;
        }

        [Export]
        [JavascriptInterface]
        public void OnCallBackJS()
        {
            _activity.OnCallBackJS();
        }   

        [Export]
        [JavascriptInterface]
        public void showLoader(bool show)
        {
            if (_activity != null) {
                _activity.ShowLoader(show,1);
            }
        }

        [Export]
        [JavascriptInterface]
        public void sendToApp(string json)
        {
            var messageJson = CustomWebviewHelper.JsonToModel(json);

            if (messageJson != null)
            {
                if (messageJson.message.Equals("stopLoading"))
                {
                    showLoader(false);
                }
                else if (messageJson.message.Equals("startLoading"))
                {
                    showLoader(true);
                }
                else
                {
                    _activity.OnCallBackJS(messageJson);
                }
            }
        }

        [Export]
        [JavascriptInterface]
        public void OnHtmlLoadCompleted()
        {
            _activity.OnHtmlLoadCompletedCAllBack();
        }   

    }
}
