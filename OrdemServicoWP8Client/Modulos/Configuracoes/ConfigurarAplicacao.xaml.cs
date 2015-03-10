using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;
using OrdemServicoWP8Client.Classes.Utils;

namespace OrdemServicoWP8Client.Modulos.Configuracoes
{
    public partial class ConfigurarAplicacao : PhoneApplicationPage
    {
        protected bool ItWorks = false;

        public ConfigurarAplicacao()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            WebServiceUtils.TestaDisponibilidadeWebService("http://" + txtUrlWebService.Text.Trim(), OpenReadCompleted);
        }
        
        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if ((this.ItWorks) && (!string.IsNullOrEmpty(txtUrlWebService.Text.Trim())))
            {
                WebServiceUtils.ConfigurarWebService("http://" + txtUrlWebService.Text.Trim());
            }

            var parametros = this.NavigationContext.QueryString;

            if ((parametros.ContainsKey("FirstTime")) && (Convert.ToBoolean(parametros["FirstTime"]) == true))
            {
                this.NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
            }
        }

        void OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (e.Result != null)
                {
                    this.ItWorks = true;
                    MessageBox.Show("Web Service disponível!");
                }
            }
        }
    }
}