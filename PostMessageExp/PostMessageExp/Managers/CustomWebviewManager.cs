using System;
using System.Threading.Tasks;
using PostMessageExp.Defines;
using PostMessageExp.Models.WebView;

namespace PostMessageExp
{
    public class CustomWebviewManager
    {
        private static object lockerInterface = new object();
        private static CustomWebviewInterface interfacesf;
        private ConfigurationWebView _configurationWebView;

        /// <summary>
        /// Metodo di utilità che invocando il servizio BE rotprnerà i parametri di configurazione webview 
        /// tra i quali anche l'url da passare alla pagina
        /// </summary>
        /// <returns>The configurations.</returns>
        /// <param name="chiaveServizio">Chiave servizio.</param>
        /// <param name="codiceFornitura">Codice fornitura.</param>
        public async Task GetConfigurations(string chiaveServizio, string codiceFornitura)
        {
            try
            {
                //TODO call service to get webview url

                _configurationWebView = new ConfigurationWebView(Constants.DEMO_URL);
                GetIntInstance().InitWebView(_configurationWebView);
            }
            catch (Exception ex)
            {
               //TODO ADD LOGMANAGER
            }           
        }

        #region PROPERTIES
        public CustomWebviewInterface GetIntInstance()
        {
            lock (lockerInterface)
            {
                return interfacesf;
            }
        }

        public void SetIntInstance(CustomWebviewInterface interfacesf)
        {
            lock (lockerInterface)
            {
                CustomWebviewManager.interfacesf = interfacesf;
            }
        }
        #endregion

        public void SendToContainer()
        {
            GetIntInstance().SendToContainer("asdf");
        }
    }
}
