using System;
using Newtonsoft.Json;
using PostMessageExp.Models.WebView;

namespace PostMessageExp.Helpers
{
    /// <summary>
    /// Custom webview helper.
    /// </summary>
    public class CustomWebviewHelper
    {

        public static string CreateRequestMessage(string requestAction, string idProcesso, string tipologiaEsito)
        {
            var message = new MessageJson();
            message.message = new Message();
            message.message.MessageType = "SCBridge";
            message.message.FlowData = new FlowData()
            {
                ID_PROCESSO = idProcesso,
                STEP_CURR = 0,
                STEP_FINALE = 1,
                ESITO = "OK",
                CODICE_ESITO = "0",
                TIPOLOGIA_ESITO = tipologiaEsito
            };

            message.message.RequestAction = requestAction;
            //message.message.TrackingAnalytics = new Models.WebView.Tracking()
            //{
            //    LIVELLO2 = string.Empty,
            //    LIVELLO3 = string.Empty
            //};

            var json = JsonConvert.SerializeObject(message);
            return json;
        }


        public static MessageJson JsonToModel(string json){
            MessageJson result = null;
            json = JsonConvert.DeserializeObject<string>(json);
            try
            {
                //if (XLabs.Ioc.Resolver.Resolve<IGetDevice>().OS.Equals("iOS"))
                //{
                //    result = (JsonConvert.DeserializeObject<Root>(json)).content.messageJson;
                //}
                //else
                //{
                //    result = JsonConvert.DeserializeObject<MessageJson>(json);
                //}

                result = JsonConvert.DeserializeObject<MessageJson>(json);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("JsonToModel - Errore di Deserializzazione [" + json + "] " + e.Message);
                //TODO add logmanager
                //LogManager.ExceptionThrow(e);
            }
            return result;
        }
        
        public static MessageJson JsonToModelIOS(string json)
        {
            MessageJson result = null;
            try
            {
                result = JsonConvert.DeserializeObject<MessageJson>(json);
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("JsonToModel - Errore di Deserializzazione [" + json + "] " + e.Message);
            }
            return result;
        }
    }
}
