using System;
using PostMessageExp.Models.WebView;

namespace PostMessageExp
{
    public interface CustomWebviewInterface
    {

        /// <summary>
        /// Shows an activity indicator.
        /// </summary>
        /// <returns>The loader.</returns>
        /// <param name="IsVisible">If set to <c>true</c> is visible.</param>
        void ShowLoader(bool IsVisible, int timeout);

        /// <summary>
        /// Shows the page thank you page.
        /// </summary>
        /// <param name="model">ThankYouModel object to init ThankYouPage</param> 
        void ShowThankYouPage(/*ThankYouModel model*/);

        /// <summary>
        /// Evaluates the javascript. In ingresso il comando da processare con webViewInstance.EvaluateJavascript(command)
        /// </summary>
        /// <param name="command">Command.</param>
        void EvaluateJavascript(String command);


        /// <summary>
        /// Initialition webview with parameters
        /// </summary>
        /// <param name="command">Command.</param>
        void InitWebView(ConfigurationWebView command);

    }
}
