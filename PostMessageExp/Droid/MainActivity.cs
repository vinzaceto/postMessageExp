using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using Java.Lang;
using Android.Content;

namespace PostMessageExp.Droid
{
    [Activity(Label = "PostMessageExp", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {
      
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.myButton);

            button.Click += delegate { 
                var m_activity = new Intent(this, typeof(WebviewActivity));
                this.StartActivity(m_activity);            
            };
        }

    }
}

