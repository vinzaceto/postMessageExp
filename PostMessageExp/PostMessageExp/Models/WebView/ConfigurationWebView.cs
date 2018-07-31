using System;
namespace PostMessageExp.Models.WebView
{
    public class ConfigurationWebView
    {
        private string _URL = string.Empty;

        public ConfigurationWebView(string url)
        {
            _URL = url;
        }

        public string URL{
            get{
                return _URL;
            }
            set{
                _URL = value; 
            }
        }
    }
}
