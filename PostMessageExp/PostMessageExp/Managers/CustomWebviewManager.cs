using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PostMessageExp.Defines;
using PostMessageExp.Models.WebView;

namespace PostMessageExp
{
    public class CustomWebviewManager
    {
        private static object lockerInterface = new object();
        private static CustomWebviewInterface interfacesf;
        private ConfigurationWebView _configurationWebView;
        private ContainerWebView _container;

        //private const string jsonToInitProcess = "{\"MESSAGE\":{\"MESSAGE_TYPE\":\" PMBridge \",\"REQUEST_ACTION\":\"startProcess\",\"FLOW_DATA\":{\"ID_PROCESSO\":\"STRING\",\"NOME_PROCESSO\":\"STRING\",\"ESITO\":\"OK\",\"CODICE_ESITO\":\"STRING\",\"TIPOLOGIA_ESITO\":\"tecnico\"}}}";

        /// <summary>
        /// Metodo di utilità che invocando il servizio BE rotprnerà i parametri di configurazione webview 
        /// tra i quali anche l'url da passare alla pagina
        /// </summary>
        /// <returns>The configurations.</returns>
        /// <param name="chiaveServizio">Chiave servizio.</param>
        /// <param name="codiceFornitura">Codice fornitura.</param>
        public async Task GetConfigurations(ContainerWebView container)
        {
            try
            {
                //TODO call service to get webview url
                _container = container;
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

        #region Communication Channel

        public void SendInitContainer()
        {
            var jsonRequest = CreateInitContainerRequest();
            GetIntInstance().SendToContainer(jsonRequest);
        }

        public void SendToContainer()
        {
            //TODO 
        }

        #endregion

        #region UTILITY

        private string CreateInitContainerRequest()
        {
            var content = JsonConvert.SerializeObject(_container, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            string jsonRequest = string.Format("javascript:initContainer('{0}')", content);           
            return jsonRequest;
        }
        #endregion      
    }
}
