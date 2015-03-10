using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;   

namespace OrdemServicoWP8Client.Classes.Utils
{
    public class WebServiceUtils
    {        
        public static bool ConfigurarWebService(string url)
        {
            try
            {
                IsolatedStorageSettings appSettings = IsolatedStorageSettings.ApplicationSettings;
                if (appSettings.Contains("urlWebService"))
                {
                    appSettings["urlWebService"] = url;
                }
                else
                {
                    appSettings.Add("urlWebService", url);
                }

                appSettings.Save();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void TestaDisponibilidadeWebService(string url, OpenReadCompletedEventHandler callback)
        {
            var client = new WebClient();
            client.OpenReadCompleted += callback;
            client.OpenReadAsync(new Uri(url));           
        }        
    }
}
