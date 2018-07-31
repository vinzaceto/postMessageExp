using System;
namespace PostMessageExp.Models.WebView
{
  
    public class ContainerWebView
    {
        public string idProcesso { get; set; }
        public string idUtente { get; set; }      
        public string tipoOp { get; set; }
     
        #region TODO Aggiungere eventuali campi in base alle tipologie di webbview
      
        #endregion
       
        public ContainerWebView()
        {
            
            //TODO Aggiungere alla sessione corrente IdProcesso 
            //SessionManager.Instance.IdProcesso = Guid.NewGuid();
            this.idProcesso = Guid.NewGuid().ToString();
        }

       
    }

}
