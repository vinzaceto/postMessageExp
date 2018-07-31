using System;
using System.Threading.Tasks;

namespace PostMessageExp
{
    public class CustomWebviewManager
    {
        private static object lockerInterface = new object();
        private static CustomWebviewInterface interfacesf;


        /// <summary>
        /// Metodo di utilità che invocando il servizio BE rotprnerà i parametri di configurazione webview 
        /// tra i quali anche l'url da passare alla pagina
        /// </summary>
        /// <returns>The configurations.</returns>
        /// <param name="chiaveServizio">Chiave servizio.</param>
        /// <param name="codiceFornitura">Codice fornitura.</param>
        static public async Task GetConfigurations(string chiaveServizio, string codiceFornitura)
        {
            try
            {
               //TODO
              
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
    }


  
}
