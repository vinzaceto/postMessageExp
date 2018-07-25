using Android.Webkit;
using Java.Interop;

namespace PostMessageExp.Droid
{
    public class JSI : Java.Lang.Object
    {

        public JSI()
        {
            
        }

        [Export]
        [JavascriptInterface]
        public void NativeFunction()
        {
            System.Diagnostics.Debug.WriteLine("Native Function Called");
        }

    }
}
