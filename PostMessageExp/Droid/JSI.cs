using Android.Webkit;
using Java.Interop;

namespace PostMessageExp.Droid
{
    
    public class JSI : Java.Lang.Object
    {
        WebviewActivity _activity;

        public JSI(WebviewActivity activity)
        {
            _activity = activity;
        }

        [Export]
        [JavascriptInterface]
        public void NativeFunction()
        {
            System.Diagnostics.Debug.WriteLine("Native Function Called");
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
        public void sendToApp(string show)
        {
            if(show.Equals("sendToApp")){
                _activity.ShowDialog(true, show);
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
