using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OrdemServicoWP8Client.Classes.Utils;

namespace OrdemServicoWP8Client.Modulos
{
    public partial class Index : PhoneApplicationPage
    {
        public Index()
        {
            InitializeComponent();
        }

        private void OnClick_OrdemServico(object sender, EventArgs e)
        {
            if (((App)Application.Current).WebServiceIsOK)
            {
                this.NavigationService.Navigate(new Uri("/Modulos/OrdemServico/PivotOrdemServico.xaml", UriKind.Relative));
            }
            else
            {
                FormUtils.InternetDesconectada();
            }
        }

        private void OnClick_Agendamentos(object sender, EventArgs e)
        {
            if (((App)Application.Current).WebServiceIsOK)
            {
                this.NavigationService.Navigate(new Uri("/Modulos/Agendamentos/Calendar.xaml", UriKind.Relative));
            }
            else
            {
                FormUtils.InternetDesconectada();
            }
        }

        private void onClick_Configuracoes(object sender, EventArgs e)
        {
            if (((App)Application.Current).WebServiceIsOK)
            {
                this.NavigationService.Navigate(new Uri("/Modulos/Configuracoes/ConfigurarAplicacao.xaml", UriKind.Relative));
            }
            else
            {
                FormUtils.InternetDesconectada();
            }
        }
    }
}