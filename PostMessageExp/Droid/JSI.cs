using Android.Webkit;
using Java.Interop;

namespace PostMessageExp.Droid
{
    
    public class JSI : Java.Lang.Object
    {
        MainActivity _activity;

        public JSI(MainActivity activity)
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
                _activity.showLoader(show);
            }
        }

        [Export]
        [JavascriptInterface]
        public void messageJson(string show)
        {
            System.Diagnostics.Debug.WriteLine(show);
        }

    }
}
