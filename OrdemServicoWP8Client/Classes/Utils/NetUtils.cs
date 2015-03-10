using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrdemServicoWP8Client.Classes.Utils
{
    public class NetUtils
    {        
        private static Timer timer = null;
        private static int TIME_INTERVAL_IN_MILLISECONDS = 1000;

        public static void IniciarMonitoramentoWebService(OpenReadCompletedEventHandler callback)
        {
            timer = new Timer(_ => VerificarDisponibilidadeWebService(callback), null, TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
        }

        protected static void VerificarDisponibilidadeWebService(OpenReadCompletedEventHandler callback)
        {
            IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
            if (appSettings.Contains("urlWebService"))
            {
                var webServiceURL = (string)appSettings["urlWebService"];
                WebServiceUtils.TestaDisponibilidadeWebService(webServiceURL, callback);                  
            }

            timer.Change(TIME_INTERVAL_IN_MILLISECONDS, Timeout.Infinite);
        }        
    }
}


