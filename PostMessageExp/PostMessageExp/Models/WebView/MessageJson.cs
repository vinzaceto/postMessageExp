using System;
using Newtonsoft.Json;

namespace PostMessageExp.Models.WebView
{
    public class MessageJson
    {
        [JsonPropertyAttribute("MESSAGE")]
        public Message message { get; set; }
    }

    public class Message
    {
        [JsonPropertyAttribute("MESSAGE_TYPE")]
        public string MessageType { get; set; }

        [JsonPropertyAttribute("REQUEST_ACTION")]
        public string RequestAction { get; set; }

        [JsonPropertyAttribute("FLOW_DATA")]
        public FlowData FlowData { get; set; }

        //[JsonPropertyAttribute("TRACKING_ANALYTICS")]
        //public Tracking TrackingAnalytics { get; set; }

    }

    public class FlowData
    {
        public string ID_PROCESSO { get; set; }
        public bool MULTIFORNITURA { get; set; }
        public string NOME_PROCESSO { get; set; }
        public string ESITO { get; set; }
        public string CODICE_ESITO { get; set; }
        public int? STEP_CURR { get; set; }
        public int? STEP_FINALE { get; set; }
        public string TIPOLOGIA_ESITO { get; set; }
        public string NOME { get; set; }
        public string CODICE_PROMO { get; set; }
        public string COGNOME { get; set; }
        public string NUMERO_UTENTE { get; set; }
    }

    public class Tracking
    {
        public string LIVELLO2 { get; set; }
        public string LIVELLO3 { get; set; }
        public string NOME_DISPOSITIVA { get; set; }
        public string AZIONE_TRACK { get; set; }
        public string FORNITURA { get; set; }

    }


}
